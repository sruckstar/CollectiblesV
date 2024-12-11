using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.Graphics;
using GTA.UI;
using LemonUI;
using LemonUI.Scaleform;
using LemonUI.Elements;
using LemonUI.Menus;

public class CollectibleManager : Script
{
    private readonly List<CollectibleItem> collectibles = new List<CollectibleItem>();
    private readonly HashSet<int> collectedIds = new HashSet<int>(); // Хранит ID найденных пропов
    private readonly Dictionary<CollectibleType, int> collectedCount = new Dictionary<CollectibleType, int>(); // Счетчик собранных предметов каждого типа
    private readonly float collectRadius = 2.0f;
    private readonly float spawnDistance = 100.0f;
    private readonly float zoneRadius = 200.0f;
    private readonly string saveFilePath = "scripts/CollectedProps.bin"; // Путь к файлу
    private readonly Vector3 SolomonOnFoot = new Vector3(-1008.088f, -486.9624f, 38.96949f);
    private readonly Vector3 SolomonInCar = new Vector3(-1081.645f, -501.2215f, 35.56962f);
    private ObjectPool pool = new ObjectPool();
    private BigMessage bigMessage;
    private Blip Solomon;
    private bool SolomonVehicleActive = false;
    private bool isCollectorRadarActive = false;
    private List<Blip> collectorBlips = new List<Blip>();
    private DateTime lastBlinkTime = DateTime.MinValue;
    private int blinkInterval = 1000;
    private int pauseInterval = 500; // Пауза между удалением и созданием меток
    private bool isRemovingBlips = true; // Указывает, удаляем ли метки в данный момент
    private DateTime lastActionTime = DateTime.MinValue; // Время последнего действия (удаление или создание меток)
    private readonly NativeMenu menu;

    private List<SpawnPoint[]> geraldZones = new List<SpawnPoint[]>
    {
        new[]
        {
            new SpawnPoint(new Vector3(192.5969f, -922.6927f, 30.69225f), new Vector3(0, 0, 0)),   // Точка для Blip и круга
            new SpawnPoint(new Vector3(212.2505f, -934.7871f, 28.91f), new Vector3(0, 0, 0)),  // Точка для спавна пропа
            new SpawnPoint(new Vector3(189.51f, -919.74f, 29.96f), new Vector3(4.86651f, 46.01437f, 59.76421f)),
            new SpawnPoint(new Vector3(211.9137f, -935.1722f, 23.39f), new Vector3(0, 0, 0)),
            new SpawnPoint(new Vector3(198.08f, -883.81f, 30.63f), new Vector3(1.001786f, 5.008956f, -35.99999f)),
            new SpawnPoint(new Vector3(169.3715f, -934.8247f, 29.22f), new Vector3(0, 0, -22f))
        },
        new[]
        {
            new SpawnPoint(new Vector3(192.5969f, -922.6927f, 30.69225f), new Vector3(0, 0, 0)),   // Точка для Blip и круга
            new SpawnPoint(new Vector3(212.2505f, -934.7871f, 28.91f), new Vector3(0, 0, 0)),  // Точка для спавна пропа
            new SpawnPoint(new Vector3(189.51f, -919.74f, 29.96f), new Vector3(4.86651f, 46.01437f, 59.76421f)),
            new SpawnPoint(new Vector3(211.9137f, -935.1722f, 23.39f), new Vector3(0, 0, 0)),
            new SpawnPoint(new Vector3(198.08f, -883.81f, 30.63f), new Vector3(1.001786f, 5.008956f, -35.99999f)),
            new SpawnPoint(new Vector3(169.3715f, -934.8247f, 29.22f), new Vector3(0, 0, -22f))
        },
    };

    private Vector3 blipPoint;
    private SpawnPoint[] spawnPoints;
    private Vector3 spawnPoint;
    private Vector3 spawnRotation;
    private int currentZoneIndex = -1;
    private Blip zoneBlip;
    private Prop geraldProp;

    public struct SpawnPoint
    {
        public Vector3 Position { get; }
        public Vector3 Rotation { get; }

        public SpawnPoint(Vector3 position, Vector3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }

    public CollectibleManager()
    {
        Tick += OnTick;
        KeyUp += onkeyup;
        Aborted += OnAborted;

        LoadCollectibles();
        InitializeCollectedCount(); // Инициализация счетчика для каждого типа
        LoadCollectedData();  // Загружаем данные о ранее найденных пропах и обновляем счетчик

        bigMessage = new BigMessage("", "", type: MessageType.Customizable);
        menu = new NativeMenu("CollectiblesV", "", "");
        pool.Add(bigMessage);
        pool.Add(menu);

        NativeItem figures = new NativeItem("Коллекционные фигурки", "");
        NativeItem snowmen = new NativeItem("Снеговики", "");
        NativeItem ghosts = new NativeItem("Призраки", "");
        NativeItem props = new NativeItem("Предметы реквизита", "");
        figures.AltTitle = $"{collectedCount[CollectibleType.ActionFigures]}/100";
        snowmen.AltTitle = $"{collectedCount[CollectibleType.Snowmen]}/25";
        ghosts.AltTitle = $"{collectedCount[CollectibleType.Ghosts]}/25";
        props.AltTitle = $"{collectedCount[CollectibleType.MovieProps]}/10";
        menu.Add(figures);
        menu.Add(snowmen);
        menu.Add(ghosts);
        menu.Add(props);
    }

    private void ToggleCollectorRadar()
    {
        if (isCollectorRadarActive)
        {
            isCollectorRadarActive = false;
            RemoveAllCollectorBlips();

            Function.Call(Hash.SET_MINIMAP_SONAR_SWEEP, false);
        }
        else
        {
            isCollectorRadarActive = true;

            Function.Call(Hash.SET_MINIMAP_SONAR_SWEEP, true);
        }
    }

    private void UpdateCollectorBlips()
    {
        if (!isCollectorRadarActive) return;

        // Проверяем, прошел ли интервал для текущего действия
        if ((DateTime.Now - lastActionTime).TotalMilliseconds >= (isRemovingBlips ? pauseInterval : blinkInterval))
        {
            if (isRemovingBlips)
            {
                // Удаляем существующие метки
                RemoveAllCollectorBlips();
                isRemovingBlips = false; // Переключаемся на создание новых меток
            }
            else
            {
                // Создаем новые метки
                foreach (var collectible in collectibles)
                {
                    if (!collectible.Collected && Vector3.Distance(Game.Player.Character.Position, collectible.Position) <= spawnDistance)
                    {
                        Blip blip = World.CreateBlip(collectible.Position);
                        blip.Sprite = BlipSprite.Standard; // Тип иконки
                        blip.Color = BlipColor.White;      // Цвет метки
                        blip.Scale = 0.8f;                // Размер иконки
                        collectorBlips.Add(blip);
                    }
                }
                isRemovingBlips = true; // Переключаемся на удаление меток
            }

            // Обновляем время последнего действия
            lastActionTime = DateTime.Now;
        }
    }

    private void RemoveAllCollectorBlips()
    {
        foreach (var blip in collectorBlips)
        {
            if (blip != null && blip.Exists())
            {
                blip.Delete();
            }
        }
        collectorBlips.Clear();
    }

    private void CheckCollectorRadar()
    {
        Vehicle playerVehicle = Game.Player.Character.CurrentVehicle;

        if (playerVehicle != null && playerVehicle.Model == VehicleHash.Terrorbyte)
        {
            // Если игрок в Terrorbyte и нажата кнопка активации (E или правый стик)
            if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 0, 51))
            {
                ToggleCollectorRadar();
            }
        }
        else if (isCollectorRadarActive)
        {
            // Отключаем радар, если игрок вышел из Terrorbyte
            ToggleCollectorRadar();
        }
    }

    private void InitializeCollectedCount()
    {
        // Инициализация счётчика для каждого типа
        foreach (CollectibleType type in Enum.GetValues(typeof(CollectibleType)))
        {
            collectedCount[type] = 0;
        }
    }

    private void LoadCollectibles()
    {
        Function.Call(Hash.ON_ENTER_MP);
        Function.Call(Hash.SET_INSTANCE_PRIORITY_MODE, 1);

        //collectibles PARAMS: ID, Position, Model Name, Rotation, Type, Hour Spawn

        // Action Figures
        collectibles.Add(new CollectibleItem(1, new Vector3(483.2734f, -3110.645f, 6.626692f), "vw_prop_vw_colle_alien", new Vector3(0, 0, -5.000109f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(2, new Vector3(153.8664f, -3077.427f, 6.746196f), "vw_prop_vw_colle_pogo", new Vector3(0, 0, -0.3255678f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(3, new Vector3(-56.60701f, -2519.034f, 7.50587f), "vw_prop_vw_colle_rsrcomm", new Vector3(0, 0, 0), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(4, new Vector3(-928.791f, -2938.799f, 13.05926f), "vw_prop_vw_colle_prbubble", new Vector3(0, 0, 141.9993f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(5, new Vector3(-886.023f, -2096.268f, 8.604954f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0, -90, 27.99991f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(6, new Vector3(-1351.024f, -1547.014f, 4.832373f), "vw_prop_vw_colle_imporage", new Vector3(0, 0, 128.9995f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(7, new Vector3(-1647.924f, -1094.698f, 12.77444f), "vw_prop_vw_colle_prbubble", new Vector3(0, 0, 115.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(8, new Vector3(-1211.608f, -959.7997f, 0.3933854f), "vw_prop_vw_colle_pogo", new Vector3(0, 0, -115.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(9, new Vector3(-908.9243f, -1148.853f, 2.81587f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0, 0, 157.9993f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(10, new Vector3(-710.6414f, -905.9454f, 19.01481f), "vw_prop_vw_colle_prbubble", new Vector3(0, 0, 107.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(11, new Vector3(-988.8632f, -102.6888f, 40.12762f), "vw_prop_vw_colle_prbubble", new Vector3(0, 0, 104.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(12, new Vector3(-1023.186462f, 190.656021f, 61.276814f), "vw_prop_vw_colle_imporage", new Vector3(0, 0, 0), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(13, new Vector3(-1461.534790f, 181.899689f, 54.921265f), "vw_prop_vw_colle_rsrcomm", new Vector3(0, 0, 0), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(14, new Vector3(-1806.486f, 427.4831f, 131.7327f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0, 0, 0), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(15, new Vector3(-2237.668701f, 249.575653f, 175.347015f), "vw_prop_vw_colle_pogo", new Vector3(0, 0, 0), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(16, new Vector3(-1719.692017f, -233.091766f, 54.396481f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0, 0, 0), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(17, new Vector3(-1545.627f, -449.089f, 40.31803f), "vw_prop_vw_colle_imporage", new Vector3(0, 0, 146.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(18, new Vector3(-1905.536f, -709.6414f, 8.758586f), "vw_prop_vw_colle_rsrcomm", new Vector3(0, 0, 39.99998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(19, new Vector3(-2958.838f, 386.3539f, 14.42863f), "vw_prop_vw_colle_pogo", new Vector3(0, 0, -164.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(20, new Vector3(-3019.844f, 41.94809f, 10.29463f), "vw_prop_vw_colle_imporage", new Vector3(0, 0, 124.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(21, new Vector3(-3243.792f, 996.2762f, 12.38142f), "vw_prop_vw_colle_rsrcomm", new Vector3(0, 0, 0), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(22, new Vector3(-2557.404f, 2315.358f, 33.65676f), "vw_prop_vw_colle_pogo", new Vector3(0, 0, -164.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(23, new Vector3(-1894.199f, 2043.225f, 140.9818f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0, 0, 108.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(24, new Vector3(-1513.48f, 1517.38f, 111.2599f), "vw_prop_vw_colle_imporage", new Vector3(0, 0, -110.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(25, new Vector3(-1501.962f, 814.1f, 181.4269f), "vw_prop_vw_colle_prbubble", new Vector3(0, 0, -19.99998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(26, new Vector3(-769.4471f, 877.2975f, 203.4522f), "vw_prop_vw_colle_imporage", new Vector3(0, 0, 89.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(27, new Vector3(-506.8459f, 393.9305f, 96.41114f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 16.99999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(28, new Vector3(-485.5287f, -55.18458f, 38.99421f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, -99.99994f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(29, new Vector3(-293.3383f, -342.3019f, 9.480515f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, 89.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(30, new Vector3(-180.7305f, -631.8358f, 48.72336f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, -110.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(31, new Vector3(-107.7905f, -856.9119f, 38.25625f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, -19.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(32, new Vector3(171.7099f, -563.9215f, 21.01385f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 87.24477f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(33, new Vector3(462.8026f, -766.5018f, 26.35841f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, -69.99999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(34, new Vector3(656.8463f, -1046.901f, 21.57538f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 154.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(35, new Vector3(678.9182f, -1523.204f, 8.838278f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, -119.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(36, new Vector3(379.4932f, -1511.115f, 29.3178f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 94.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(37, new Vector3(173.2723f, -1208.425f, 29.64939f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 89.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(38, new Vector3(-66.16029f, -1451.83f, 31.16709f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 84.99988f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(39, new Vector3(-43.68725f, -1747.946f, 29.28266f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, -39.99999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(40, new Vector3(368.5399f, -2112.629f, 16.18318f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, -129.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(41, new Vector3(874.84f, -2164.16f, 32.37094f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(42, new Vector3(1243.632f, -2571.87f, 42.61124f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 131.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(43, new Vector3(1497.255f, -2133.193f, 76.31209f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 134.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(44, new Vector3(1136.247f, -666.5859f, 57.08273f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, -54.99998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(45, new Vector3(1207.621f, -1479.126f, 35.17268f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, -79.99997f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(46, new Vector3(987.3749f, -136.6919f, 73.38173f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(47, new Vector3(622.5184f, -408.5135f, -1.4014875f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 201.425f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(48, new Vector3(660.3423f, 549.7959f, 129.0445f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, -169.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(49, new Vector3(693.3061f, 1200.531f, 344.5234f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, -179.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(50, new Vector3(1413.963f, 1162.406f, 114.3539f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 165.0002f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(51, new Vector3(1408.249f, 2157.385f, 97.58831f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, -119.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(52, new Vector3(1189.461f, 2641.25f, 38.41513f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, -2f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(53, new Vector3(852.7209f, 2166.091f, 52.94893f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(54, new Vector3(387.9406f, 2570.439f, 43.29837f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(55, new Vector3(543.3592f, 3074.853f, 40.40119f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, -89.99995f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(56, new Vector3(64.11636f, 3683.793f, 39.76267f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(57, new Vector3(-299.6486f, 2847.153f, 55.49355f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 164.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(58, new Vector3(-57.75655f, 1939.697f, 189.6552f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(59, new Vector3(-441.0704f, 1596.153f, 358.6569f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(60, new Vector3(-600.8517f, 2088.045f, 132.338f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, -174.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(61, new Vector3(-1280.369f, 2549.753f, 17.54423f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, -170.0003f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(62, new Vector3(-1648.616f, 3017.923f, 31.49657f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(63, new Vector3(-2171.622f, 3441.216f, 31.49332f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(64, new Vector3(-2185.954f, 4249.796f, 48.80135f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, -114.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(65, new Vector3(-2169.341f, 5192.887f, 16.21206f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(66, new Vector3(-1120.339f, 4976.073f, 185.489f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, 159.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(67, new Vector3(-688.7177f, 5829.018f, 16.75617f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, -79.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(68, new Vector3(-550.3628f, 5330.363f, 73.89193f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(69, new Vector3(-262.3064f, 4729.261f, 137.321f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 154.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(70, new Vector3(-311.5355f, 6314.711f, 31.95075f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, -74.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(71, new Vector3(177.6533f, 6394.152f, 31.38266f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 104.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(72, new Vector3(457.2986f, 5573.855f, 780.1841f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(73, new Vector3(1389.82f, 3608.912f, 34.95788f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(74, new Vector3(1297.945f, 4306.673f, 38.10214f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(75, new Vector3(1310.568f, 6544.97f, 4.743413f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, 154.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(76, new Vector3(1541.65f, 6323.765f, 23.45874f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, -129.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(77, new Vector3(1714.546f, 4790.819f, 41.54019f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, 169.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(78, new Vector3(2222.026f, 5612.345f, 54.02115f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, -69.99995f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(79, new Vector3(2416.754f, 4994.738f, 45.24838f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(80, new Vector3(1886.728f, 3913.735f, 32.03888f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(81, new Vector3(1702.945f, 3291.301f, 48.72552f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(82, new Vector3(1848.325f, 2701.526f, 62.94077f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(83, new Vector3(2487.573f, 3762.13f, 42.13271f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(84, new Vector3(2725.777f, 4142.154f, 43.29294f), "vw_prop_vw_colle_pogo", new Vector3(0f, 0f, -79.99994f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(85, new Vector3(2936.242f, 4620.459f, 48.67684f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 124.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(86, new Vector3(3306.464f, 5194.735f, 17.44758f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(87, new Vector3(3799.758f, 4473.06f, 6.029338f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 170.0002f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(88, new Vector3(3514.701f, 3754.387f, 34.45815f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(89, new Vector3(2634.986f, 2931.165f, 44.60777f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 174.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(90, new Vector3(2548.847f, 385.428f, 108.4227f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 89.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(91, new Vector3(2500.638f, -389.5438f, 94.24368f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, 84.99993f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(92, new Vector3(1667.529f, -0.02666736f, 165.1181f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, -139.9999f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(93, new Vector3(86.98901f, 812.6157f, 211.0638f), "vw_prop_vw_colle_rsrcomm", new Vector3(0f, 0f, 0f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(94, new Vector3(-90.29003f, 939.7905f, 232.4645f), "vw_prop_vw_colle_prbubble", new Vector3(0f, 0f, 89.99992f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(95, new Vector3(219.6697f, 97.19062f, 96.27957f), "vw_prop_vw_colle_imporage", new Vector3(0f, 0f, 74.99997f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(96, new Vector3(-140.5861f, 234.7685f, 98.6559f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, -174.9998f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(97, new Vector3(2618.428f, 1692.397f, 31.96086f), "vw_prop_vw_colle_rsrgeneric", new Vector3(0f, 0f, 79.99995f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(98, new Vector3(2399.596f, 3062.082f, 53.46168f), "vw_prop_vw_colle_beast", new Vector3(0f, 0f, 155.0001f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(99, new Vector3(2394.647f, 3062.783f, 51.20995f), "vw_prop_vw_colle_sasquatch", new Vector3(0f, 0f, -175.0002f), CollectibleType.ActionFigures, -1));
        collectibles.Add(new CollectibleItem(100, new Vector3(-1050.648f, -522.5958f, 36.54707f), "vw_prop_vw_colle_alien", new Vector3(0f, 0f, 164.9998f), CollectibleType.ActionFigures, -1));

        //Snowmen КРАСНЫЙ СИНИЙ ЗЕЛЕНЫЙ xm3_prop_xm3_snowman_01a xm3_prop_xm3_snowman_01b xm3_prop_xm3_snowman_01c
        collectibles.Add(new CollectibleItem(101, new Vector3(1340.966f, -1585.962f, 53.23f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 0), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(102, new Vector3(1270.01f, -646.6276f, 66.96817f), "xm3_prop_xm3_snowman_01b", new Vector3(0, 0, 121.5464f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(103, new Vector3(902.6162f, -285.7397f, 64.68812f), "xm3_prop_xm3_snowman_01c", new Vector3(0, 0, 16.60338f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(104, new Vector3(217.9505f, -104.4566f, 68.72256f), "xm3_prop_xm3_snowman_01b", new Vector3(0, 0, 69.65895f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(105, new Vector3(181.4533f, -906.3058f, 29.6935f), "xm3_prop_xm3_snowman_01c", new Vector3(0, 0, 19.21218f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(106, new Vector3(-254.1831f, -1562.791f, 30.89726f), "xm3_prop_xm3_snowman_01c", new Vector3(0, 0, 119.4156f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(107, new Vector3(-1106.281f, -1398.883f, 4.242457f), "xm3_prop_xm3_snowman_01b", new Vector3(0, 0, 40.3349f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(108, new Vector3(-958.4882f, -780.1604f, 16.83612f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 56.08267f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(109, new Vector3(-821.1164f, 165.2018f, 70.20119f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 72.16058f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(110, new Vector3(-780.3677f, 883.56f, 202.291f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 322.9184f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(111, new Vector3(-455.9423f, 1126.911f, 324.881f), "xm3_prop_xm3_snowman_01c", new Vector3(0, 0, 115.3341f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(112, new Vector3(-1938.353f, 592.8044f, 119.0633f), "xm3_prop_xm3_snowman_01b", new Vector3(0, 0, 243.7932f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(113, new Vector3(-2975.49f, 713.8936f, 27.31553f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 150.4708f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(114, new Vector3(-2829.72f, 1420.274f, 99.9081f), "xm3_prop_xm3_snowman_01c", new Vector3(0, 0, 101.7738f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(115, new Vector3(-1517.235f, 2141.644f, 55.04519f), "xm3_prop_xm3_snowman_01b", new Vector3(0, 0, 59.7851f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(116, new Vector3(237.1049f, 3104.991f, 41.40403f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 273.4308f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(117, new Vector3(-45.83523f, 1963.668f, 188.9175f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 206.5635f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(118, new Vector3(1517.938f, 1721.99f, 109.3151f), "xm3_prop_xm3_snowman_01c", new Vector3(0, 0, 268.1374f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(119, new Vector3(2358.468f, 2529.208f, 45.66771f), "xm3_prop_xm3_snowman_01b", new Vector3(0, 0, 139.9507f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(120, new Vector3(1990.175f, 3828.437f, 31.31994f), "xm3_prop_xm3_snowman_01c", new Vector3(0, 0, 123.5808f), CollectibleType.Snowmen, -1));
        collectibles.Add(new CollectibleItem(121, new Vector3(1710.18f, 4678.234f, 42.00475f), "xm3_prop_xm3_snowman_01a", new Vector3(0, 0, 272.4192f), CollectibleType.Snowmen, -1));
        //collectibles.Add(new CollectibleItem(122, new Vector3(0, 0, 0), "PLACE_HOLDER", new Vector3(0, 0, 0), CollectibleType.Snowmen, -1));
        //collectibles.Add(new CollectibleItem(123, new Vector3(0, 0, 0), "PLACE_HOLDER", new Vector3(0, 0, 0), CollectibleType.Snowmen, -1));
        //collectibles.Add(new CollectibleItem(124, new Vector3(0, 0, 0), "PLACE_HOLDER", new Vector3(0, 0, 0), CollectibleType.Snowmen, -1));
        //collectibles.Add(new CollectibleItem(125, new Vector3(0, 0, 0), "PLACE_HOLDER", new Vector3(0, 0, 0), CollectibleType.Snowmen, -1));
        //...

        //Ghosts
        //collectibles.Add(new CollectibleItem(27, new Vector3(-1725.097f, -192.2232f, 59.09193f), "m23_1_prop_m31_ghostrurmeth_01a", new Vector3(0, 0, -101.9999f), CollectibleType.Ghosts, -1));
        //...

        //Movie Props
        //collectibles.Add(new CollectibleItem(28, new Vector3(-825.494f, 182.681f, 70.74219f), "sum_prop_ac_tigerrug_01a", new Vector3(0, 0, 0), CollectibleType.MovieProps, -1));
        //collectibles.Add(new CollectibleItem(29, new Vector3(-1010.02f, -502.11f, 36.45f), "sum_prop_ac_filmreel_01a", new Vector3(0, -87.75f, 119.7253f), CollectibleType.MovieProps, -1));
        //...
    }

    private void onkeyup(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Y)
        {
            menu.Visible = true;
        }
    }

    private void OnTick(object sender, EventArgs e)
    {
        pool.Process();

        CheckCollectorRadar();

        UpdateCollectorBlips();

        CheckAwards();

        var playerPosition = Game.Player.Character.Position;

        if (currentZoneIndex != -1)
        {
            float distanceToZone = Vector3.Distance(playerPosition, blipPoint);

            // Если игрок находится в радиусе зоны, показываем Blip, если его еще нет
            if (distanceToZone <= zoneRadius)
            {
                if (zoneBlip == null)
                {
                    zoneBlip = World.CreateBlip(blipPoint);
                    zoneBlip.Sprite = (BlipSprite)842; // Иконка на мини-карте
                    zoneBlip.Color = BlipColor.Purple;
                }

                // При входе в круг Blip меняется на большой белый круг
                if (distanceToZone <= 50.0f)
                {
                    zoneBlip.Delete();
                    zoneBlip = Function.Call<Blip>(Hash.ADD_BLIP_FOR_RADIUS, blipPoint.X, blipPoint.Y, blipPoint.Z, 100.0f);
                    zoneBlip.Alpha = 50;
                }
                else
                {
                    zoneBlip.Delete();
                    zoneBlip = World.CreateBlip(blipPoint);
                    zoneBlip.Sprite = (BlipSprite)842; // Иконка на мини-карте
                    zoneBlip.Color = BlipColor.Purple;
                }

                // Спавн пропа в выбранной точке, если он еще не создан
                if (geraldProp == null)
                {
                    Model model = new Model("prop_mp_drug_package"); // Название модели пропа
                    model.Request();
                    while (!model.IsLoaded) Script.Wait(50);

                    geraldProp = World.CreateProp(model, spawnPoint, true, true);
                    geraldProp.Rotation = spawnRotation; // Устанавливаем углы поворота
                    model.MarkAsNoLongerNeeded();
                }

                // Проверяем, если игрок находится рядом с пропом, и он считается найденным
                if (geraldProp != null && Vector3.Distance(playerPosition, spawnPoint) <= collectRadius)
                {
                    GTA.UI.Screen.ShowSubtitle("Вы нашли предмет Gerald!");
                    geraldProp.Delete();
                    geraldProp = null;

                    // Удаляем Blip и выбираем новую зону
                    zoneBlip.Delete();
                    zoneBlip = null;
                    SelectRandomGeraldZone();
                }
            }
            else
            {
                // Удаляем Blip и проп при выходе из зоны
                if (zoneBlip != null && zoneBlip.Exists())
                {
                    zoneBlip.Delete();
                    zoneBlip = null;
                }

                if (geraldProp != null && geraldProp.Exists())
                {
                    geraldProp.Delete();
                    geraldProp = null;
                }
            }
        }
        else
        {
            // Инициализация с выбором первой зоны при загрузке скрипта
            SelectRandomGeraldZone();
        }

        foreach (var collectible in collectibles)
        {
            if (collectible.Collected || collectedIds.Contains(collectible.Id)) continue;

            CheckMovieVehicleActive(collectible);

            float distanceToPlayer = Vector3.Distance(playerPosition, collectible.Position);

            if (distanceToPlayer <= spawnDistance && (collectible.hourSpawn == -1 || Function.Call<int>(Hash.GET_CLOCK_HOURS) == collectible.hourSpawn))
            {
                collectible.Spawn();

                switch (collectible.Type)
                {
                    case CollectibleType.ActionFigures:
                    case CollectibleType.LdWare:
                    case CollectibleType.PlayingCards:
                        if (distanceToPlayer <= collectRadius)
                        {
                            collectible.Collect();
                            SaveCollectedId(collectible.Id);
                            IncrementCollectedCount(collectible.Type);
                        }
                        break;

                    case CollectibleType.Jammers:
                    case CollectibleType.Snowmen:
                        if (collectible.prop != null && collectible.prop.HasBeenDamagedBy(Game.Player.Character))
                        {
                            collectible.Collect();
                            SaveCollectedId(collectible.Id);
                            IncrementCollectedCount(collectible.Type);
                        }
                        break;

                    case CollectibleType.Ghosts:
                        if (collectible.ghostPed != null &&
                        Function.Call<bool>(Hash.CELL_CAM_IS_CHAR_VISIBLE_NO_FACE_CHECK, collectible.ghostPed.Handle) &&
                        Function.Call<bool>(Hash.PHONEPHOTOEDITOR_IS_ACTIVE) &&
                        Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 0, 176)) // 176 - это клавиша ENTER на геймпаде для съёмки
                        {
                            Wait(1000);
                            collectible.Collect();
                            SaveCollectedId(collectible.Id);
                            IncrementCollectedCount(collectible.Type);
                        }
                        break;

                    case CollectibleType.MovieProps:
                        if (collectible.MovieVeh != null && collectible.MovieVeh.Exists())
                        {
                            CheckMovieVehicleActive(collectible);
                        }
                        else
                        {
                            if (distanceToPlayer <= collectRadius)
                            {
                                GTA.UI.Screen.ShowHelpText(Game.GetLocalizedString("MOVPROPDELHELP"));
                                collectible.Remove();

                                if (Solomon == null)
                                {
                                    Solomon = World.CreateBlip(SolomonOnFoot);
                                    Solomon.Sprite = BlipSprite.MovieCollectibles;
                                    Solomon.Color = BlipColor.Yellow;
                                }

                                while (Vector3.Distance(Game.Player.Character.Position, SolomonOnFoot) > 4f)
                                {
                                    World.DrawMarker(MarkerType.VerticalCylinder, SolomonOnFoot, Vector3.Zero, Vector3.Zero, new Vector3(2.0f, 2.0f, 1.0f), System.Drawing.Color.Yellow);
                                    Script.Wait(0);
                                }
                                collectible.Collect();
                                SaveCollectedId(collectible.Id);
                                IncrementCollectedCount(collectible.Type);

                                if (Solomon != null && Solomon.Exists())
                                {
                                    Solomon.Delete();
                                    Solomon = null;
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                if (collectible.MovieVeh != null && collectible.MovieVeh.Exists())
                {
                    if (Vector3.Distance(Game.Player.Character.Position, collectible.MovieVeh.Position) > 300f)
                    {
                        collectible.Remove();
                    }
                }
                else
                {
                    collectible.Remove();
                }
            }
        }
    }

    private void CheckAwards()
    {
        foreach (var collectible in collectibles)
        {
            if (!collectible.IsAwarded)
            {
                switch (collectible.Type)
                {
                    case CollectibleType.ActionFigures:
                        if (collectedCount[CollectibleType.ActionFigures] == 100)
                        {
                            Game.Player.Money += 1000000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.Snowmen:
                        if (collectedCount[CollectibleType.Snowmen] == 1)
                        {
                            Game.Player.Money += 500000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.Ghosts:
                        if (collectedCount[CollectibleType.Ghosts] == 25)
                        {
                            Game.Player.Money += 500000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.MovieProps:
                        if (collectedCount[CollectibleType.MovieProps] == 10)
                        {
                            Game.Player.Money += 300000;
                        }
                        break;
                }
            }
        }
    }

    private void CheckMovieVehicleActive(CollectibleItem collectible)
    {
        if (collectible.MovieVeh != null && collectible.MovieVeh.Exists())
        {
            if (Game.Player.Character.CurrentVehicle == collectible.MovieVeh)
            {
                GTA.UI.Screen.ShowHelpText(Game.GetLocalizedString("MOVPROPDELHELP"));
                SolomonVehicleActive = true;

                if (Solomon == null)
                {
                    Solomon = World.CreateBlip(SolomonInCar);
                    Solomon.Sprite = BlipSprite.MovieCollectibles;
                    Solomon.Color = BlipColor.Yellow;
                }

                while (Game.Player.Character.CurrentVehicle == collectible.MovieVeh)
                {
                    Script.Wait(0);
                    World.DrawMarker(MarkerType.VerticalCylinder, SolomonInCar, Vector3.Zero, Vector3.Zero, new Vector3(2.0f, 2.0f, 1.0f), System.Drawing.Color.Yellow);
                    if (Vector3.Distance(Game.Player.Character.Position, SolomonInCar) <= 5f && !collectible.Collected)
                    {
                        Function.Call(Hash.DO_SCREEN_FADE_OUT, 1000);
                        Wait(1000);
                        collectible.Collect();
                        collectible.Remove();
                        Wait(1000);
                        Function.Call(Hash.DO_SCREEN_FADE_IN, 1000);
                        Wait(1000);
                        SaveCollectedId(collectible.Id);
                        IncrementCollectedCount(collectible.Type);

                        if (Solomon != null && Solomon.Exists())
                        {
                            Solomon.Delete();
                            Solomon = null;
                        }

                        break;
                    }
                }

                if (Solomon != null && Solomon.Exists())
                {
                    Solomon.Delete();
                    Solomon = null;
                }

                while (Game.Player.Character.CurrentVehicle != collectible.MovieVeh)
                {
                    Script.Wait(0);

                    if (collectible.MovieVeh.IsDead)
                    {
                        collectible.Collect();
                        collectible.Remove();
                        break;
                    }
                }
            }
        }
    }

    private void SelectRandomGeraldZone()
    {
        Random random = new Random();
        int newZoneIndex;

        // Выбираем новую случайную зону, отличную от текущей
        do
        {
            newZoneIndex = random.Next(geraldZones.Count);
        } while (newZoneIndex == currentZoneIndex);

        currentZoneIndex = newZoneIndex;

        // Первая точка используется для Blip и круга
        blipPoint = geraldZones[currentZoneIndex][0].Position;

        // Копируем оставшиеся точки (со 2-й по последнюю) в массив spawnPoints
        spawnPoints = new SpawnPoint[geraldZones[currentZoneIndex].Length - 1];
        Array.Copy(geraldZones[currentZoneIndex], 1, spawnPoints, 0, spawnPoints.Length);

        // Выбираем случайную точку из spawnPoints для спавна пропа
        SpawnPoint selectedSpawnPoint = spawnPoints[random.Next(spawnPoints.Length)];
        spawnPoint = selectedSpawnPoint.Position;
        spawnRotation = selectedSpawnPoint.Rotation;
    }


    private void IncrementCollectedCount(CollectibleType type)
    {

        collectedCount[type]++;

        switch (type)
        {
            case CollectibleType.ActionFigures:

                bigMessage.Title = Game.GetLocalizedString("FIGURE_HEADER");
                bigMessage.Message = ReplacePlaceholder(Game.GetLocalizedString("FIGURE_COLLECT"), collectedCount[type]);
                GTA.UI.Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("FIGURE_TICKER"), collectedCount[type]), true);
                Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_VINEWOOD/DLC_VW_HIDDEN_COLLECTIBLES", 0, 0);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "playing_card", "dlc_vw_hidden_collectible_sounds", false);
                break;

            case CollectibleType.Snowmen:
                bigMessage.Title = Game.GetLocalizedString("SNOWMEN_HEADER");
                bigMessage.Message = ReplacePlaceholder(Game.GetLocalizedString("SNOWMEN_COLLECT"), collectedCount[type]);
                GTA.UI.Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("SNOWMEN_TICKER"), collectedCount[type]), true);
                //Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "destroy", "Snowmen_Colllectible_Sounds", false);
                break;

            case CollectibleType.Ghosts:
                bigMessage.Title = Game.GetLocalizedString("SUM23GHSHARDHE");
                bigMessage.Message = ReplacePlaceholder(Game.GetLocalizedString("SUM23GHSHABOD1"), collectedCount[type]);
                GTA.UI.Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("GHOSTHUNT_HELPCOL"), collectedCount[type]), true);
                Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "Ghost_Hunt_Sounds", 0, 0);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Collect_Shard", "Ghost_Hunt_Sounds", false);
                break;

            case CollectibleType.MovieProps:
                bigMessage.Title = Game.GetLocalizedString("PROPS_HEADER");
                bigMessage.Message = ReplacePlaceholder(Game.GetLocalizedString("PROPS_COLLECT"), collectedCount[type]);
                GTA.UI.Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("PROPS_TICKER"), collectedCount[type]), true);
                //Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "destroy", "Snowmen_Colllectible_Sounds", false);
                break;
        }

        bigMessage.Visible = true;
        bigMessage.Draw();
        bigMessage.FadeOut(8000);
    }

    private void OnAborted(object sender, EventArgs e)
    {
        foreach (var collectible in collectibles)
        {
            collectible.Remove();
        }

        RemoveAllCollectorBlips();

        // Удаляем Blip, если он существует
        if (zoneBlip != null && zoneBlip.Exists())
        {
            zoneBlip.Delete();
        }

        if (Solomon != null && Solomon.Exists())
        {
            Solomon.Delete();
        }

        // Удаляем Prop, если он существует
        if (geraldProp != null && geraldProp.Exists())
        {
            geraldProp.Delete();
        }
    }

    private void LoadCollectedData()
    {
        if (File.Exists(saveFilePath))
        {
            using (var reader = new BinaryReader(File.Open(saveFilePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    int id = reader.ReadInt32();
                    collectedIds.Add(id);

                    var collectible = collectibles.Find(item => item.Id == id);
                    if (collectible != null)
                    {
                        collectible.Collect();
                        collectedCount[collectible.Type]++;
                    }
                }
            }
        }
    }

    private void SaveCollectedId(int id)
    {
        collectedIds.Add(id);

        using (var writer = new BinaryWriter(File.Open(saveFilePath, FileMode.Append)))
        {
            writer.Write(id);
        }
    }

    private static string ReplacePlaceholder(string input, int number)
    {
        return input.Replace("~1~", number.ToString());
    }

    private async void WaitAndFadeOutMessage(int delay)
    {
        // Ожидание указанное время (10 секунд)
        await Task.Delay(delay);

        // Запуск анимации исчезновения на 1 секунду (1000 мс)
        bigMessage.FadeOut(1000);

        // Ожидание завершения анимации исчезновения
        await Task.Delay(1000);

        // Скрытие сообщения
        bigMessage.Visible = false;
    }

    private class CollectibleItem
    {
        public int Id { get; }
        public Vector3 Position { get; }
        public string ModelName { get; }
        public Vector3 Rotation { get; }
        public CollectibleType Type { get; }
        public int hourSpawn { get; }
        public bool Collected { get; private set; }
        public bool IsAwarded { get; set; } = false;
        public Prop prop { get; private set; }
        public Ped ghostPed;
        public Vehicle MovieVeh;

        public CollectibleItem(int id, Vector3 position, string modelName, Vector3 rotation, CollectibleType type, int HourSpawn)
        {
            Id = id;
            Position = position;
            ModelName = modelName;
            Rotation = rotation;
            Type = type;
            Collected = false;
            hourSpawn = HourSpawn;
        }

        public void Spawn()
        {
            if (prop == null || !prop.Exists())
            {
                Model model = new Model(ModelName);
                model.Request();

                // Ожидание загрузки модели
                while (!model.IsLoaded) Script.Wait(50);

                
                prop = World.CreatePropNoOffset(model, Position, false); // Создаем проп без смещения
                prop.Rotation = Rotation; // Задаем угол поворота
                model.MarkAsNoLongerNeeded();

                if (Type == CollectibleType.Ghosts && ghostPed == null)
                {
                    // Создаем педа, делаем его невидимым и прикрепляем к пропу
                    ghostPed = World.CreatePed(PedHash.FreemodeMale01, Position);

                    while (ghostPed == null && !ghostPed.Exists()) Script.Wait(0);

                    ghostPed.IsVisible = false;
                    ghostPed.Task.ClearAllImmediately();
                    ghostPed.AttachTo(prop, new Vector3(0, 0, 0), Vector3.Zero); // Привязываем педа к пропу
                }

                if (Type == CollectibleType.MovieProps && MovieVeh == null)
                {
                    Function.Call(Hash.SET_ENTITY_COLLISION, prop, false, 0);

                    switch(ModelName)
                    {
                        case "sum_prop_ac_sarcophagus_01a":

                            Model veh = new Model("pony");
                            veh.Request();

                            // Ожидание загрузки модели
                            while (!veh.IsLoaded) Script.Wait(50);
                            MovieVeh = World.CreateVehicle(VehicleHash.Pony, Position);

                            while (MovieVeh == null) Script.Wait(0);
                            MovieVeh.Rotation = Rotation;
                            for (int i = 0; i < 20; i++) 
                            {
                                if (MovieVeh.IsExtraOn(i))
                                {
                                    MovieVeh.ToggleExtra(i, false);
                                }
                            }
                            prop.AttachTo(MovieVeh, new Vector3(0, 0.2f, 0.2f), new Vector3(-90f, 0, 180f));
                            Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, MovieVeh.Handle, 2, false, false);
                            Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, MovieVeh.Handle, 3, false, false);
                            break;

                        case "sum_prop_ac_tigerrug_01a":
                            veh = new Model("rumpo");
                            veh.Request();

                            // Ожидание загрузки модели
                            while (!veh.IsLoaded) Script.Wait(50);
                            MovieVeh = World.CreateVehicle(VehicleHash.Rumpo, Position);
                            while (MovieVeh == null) Script.Wait(0);
                            MovieVeh.Rotation = Rotation;
                            for (int i = 0; i < 20; i++)
                            {
                                if (MovieVeh.IsExtraOn(i))
                                {
                                    MovieVeh.ToggleExtra(i, false);
                                }
                            }
                            prop.AttachTo(MovieVeh, new Vector3(0, -1f, -0.5f), new Vector3(0, 0, 90f));
                            Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, MovieVeh.Handle, 2, false, false);
                            Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, MovieVeh.Handle, 3, false, false);
                            break;

                        case "sum_prop_ac_drinkglobe_01a":
                            veh = new Model("rabel");
                            veh.Request();

                            // Ожидание загрузки модели
                            while (!veh.IsLoaded) Script.Wait(50);
                            MovieVeh = World.CreateVehicle(VehicleHash.Rebel, Position);
                            while (MovieVeh == null) Script.Wait(0);
                            MovieVeh.Rotation = Rotation;
                            prop.AttachTo(MovieVeh, new Vector3(0, 0, 0), Vector3.Zero);
                            break;
                    }
                }
            }
        }


        public void Remove()
        {
            if (prop != null && prop.Exists())
            {

                prop.Delete();
                prop = null;
            }

            if (ghostPed != null && ghostPed.Exists())
            {
                ghostPed.Delete();
                ghostPed = null;
            }

            if (MovieVeh != null && MovieVeh.Exists())
            {
                if (MovieVeh.IsDead)
                {
                    MovieVeh.MarkAsNoLongerNeeded();
                }
                else
                {
                    MovieVeh.Delete();
                }

                MovieVeh = null;
            }
        }

        public void Collect()
        {
            Collected = true;
            Remove();
        }
    }

    private enum CollectibleType
    {
        ActionFigures,
        LdWare,
        PlayingCards,
        Jammers,
        Ghosts,
        Snowmen,
        Gerald,
        MovieProps
    }
}