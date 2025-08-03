using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.Graphics;
using GTA.UI;
using LemonUI;
using LemonUI.Scaleform;
using LemonUI.Elements;
using LemonUI.Menus;

public class CollectiblesV : Script
{
    private readonly List<CollectibleItem> collectibles = new List<CollectibleItem>();
    private readonly HashSet<int> collectedIds = new HashSet<int>(); // Stores the IDs of the props found
    private readonly Dictionary<CollectibleType, int> collectedCount = new Dictionary<CollectibleType, int>(); // Counter of collected items of each type
    private readonly float collectRadius_without_keys = 2.0f;
    private readonly float collectRadius_with_keys = 1.0f;
    private readonly float spawnDistance = 100.0f;
    private readonly float zoneRadius = 200.0f;
    private readonly string saveFilePath = "scripts/CollectiblesV/CollectedProps.bin";
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
    private int pauseInterval = 500; 
    private bool isRemovingBlips = true; 
    private DateTime lastActionTime = DateTime.MinValue; 
    private readonly NativeMenu menu;
    private bool ShowHelpScanner = false;
    private NativeItem figures;
    private NativeItem snowmen;
    private NativeItem ghosts;
    private NativeItem props;
    private NativeItem LDorg;
    private NativeItem cards;
    private NativeItem signal;
    private NativeItem lanterns;
    private NativeItem Yuanbao;
    private NativeItem antennas;
    private Keys KeyActiveMenu;
    private ScriptSettings config;

    private int scaleformHandle;
    private bool messageVisible = false;
    private int messageStartTime;

    private static int ante_audio = -1;

    public CollectiblesV()
    {
        Tick += OnTick;
        KeyUp += onkeyup;
        Aborted += OnAborted;

        config = ScriptSettings.Load("Scripts\\CollectiblesV\\settings.ini");
        KeyActiveMenu = config.GetValue<Keys>("MAIN", "ActivateMenu", Keys.Y);

        bigMessage = new BigMessage("", "", type: MessageType.Customizable);
        menu = new NativeMenu("CollectiblesV", "", "");
        pool.Add(bigMessage);
        pool.Add(menu);

        figures = new NativeItem(Game.GetLocalizedString("DLCC_ACTIO"), "");
        snowmen = new NativeItem(Game.GetLocalizedString("PIM_SNOWMENTR"), "");
        ghosts = new NativeItem(Game.GetLocalizedString("PIM_GHOSTHUNT"), "");
        props = new NativeItem(Game.GetLocalizedString("DLCC_MOVIE"), "");
        LDorg = new NativeItem(Game.GetLocalizedString("PIM_ORGANITR"), "");
        cards = new NativeItem(Game.GetLocalizedString("PIM_PLAYINGCAR"), "");
        signal = new NativeItem(Game.GetLocalizedString("PIM_SIGNAL"), "");
        lanterns = new NativeItem(Game.GetLocalizedString("PIM_TRICKTR"), "");
        Yuanbao = new NativeItem(Game.GetLocalizedString("PIM_YUANBAOTR"), "");
        antennas = new NativeItem("Radio antennas", "");

        InitializeCollectedCount();
        LoadCollectibles();
        LoadCollectedData();
        UnlockRadioStations();
        LoadSoundsEffects();

        figures.AltTitle = $"{collectedCount[CollectibleType.ActionFigures]}/100";
        snowmen.AltTitle = $"{collectedCount[CollectibleType.Snowmen]}/25";
        ghosts.AltTitle = $"{collectedCount[CollectibleType.Ghosts]}/20";
        props.AltTitle = $"{collectedCount[CollectibleType.MovieProps]}/10";
        LDorg.AltTitle = $"{collectedCount[CollectibleType.LdWare]}/100";
        cards.AltTitle = $"{collectedCount[CollectibleType.PlayingCards]}/54";
        signal.AltTitle = $"{collectedCount[CollectibleType.Jammers]}/50";
        Yuanbao.AltTitle = $"{collectedCount[CollectibleType.Yuanbao]}/36";
        lanterns.AltTitle = $"{collectedCount[CollectibleType.Lanterns]}/200";
        antennas.AltTitle = $"{collectedCount[CollectibleType.RadioAntennas]}/10";
    }

    private void LoadSoundsEffects()
    {
        Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_MPSUM2/DLC_mpSum2_Collectibles", false, -1);
        Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_VINEWOOD/DLC_VW_HIDDEN_COLLECTIBLES", false, -1);
        Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_MPSUM2/DLC_mpSum2_Collectibles", false, -1);
        Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_24-2/DLC_24-2_Collectibles", false, -1);
        Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_FREEMODE_01", false, -1);
        Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "Ghost_Hunt_Sounds", false, -1);
        Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_SUM20/DLC_SUM20_HIDDEN_COLLECTIBLES", false, -1);
        Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_MPSUM2/DLC_mpSum2_Collectibles", false, -1);
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

        if ((DateTime.Now - lastActionTime).TotalMilliseconds >= (isRemovingBlips ? pauseInterval : blinkInterval))
        {
            if (isRemovingBlips)
            {
                RemoveAllCollectorBlips();
                isRemovingBlips = false;
            }
            else
            {
                foreach (var collectible in collectibles)
                {
                    if (!collectible.Collected && Vector3.Distance(Game.Player.Character.Position, collectible.Position) <= spawnDistance)
                    {
                        Blip blip = World.CreateBlip(collectible.Position);
                        blip.Sprite = BlipSprite.Standard; 
                        blip.Color = BlipColor.White;     
                        blip.Scale = 0.8f;               
                        collectorBlips.Add(blip);
                    }
                }
                isRemovingBlips = true; 
            }

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
            if (!ShowHelpScanner)
            {
                GTA.UI.Screen.ShowHelpText(Game.GetLocalizedString("COL_SCANPC"));
                ShowHelpScanner = true;
            }

            if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 0, 209))
            {
                ToggleCollectorRadar();
                while (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 0, 209)) Script.Wait(0);
            }
        }
        else if (isCollectorRadarActive)
        {
            ToggleCollectorRadar();
            while (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 0, 209)) Script.Wait(0);
        }
        else if (Game.Player.Character.CurrentVehicle == null || Game.Player.Character.CurrentVehicle.Model != VehicleHash.Terrorbyte)
        {
            ShowHelpScanner = false;
        }
    }

    private void InitializeCollectedCount()
    {
        foreach (CollectibleType type in Enum.GetValues(typeof(CollectibleType)))
        {
            collectedCount[type] = 0;
        }
    }

    private void LoadCollectibles()
    {

        //collectibles PARAMS: ID, Position, Model Name, Rotation, Type, Hour Spawn

        //Action figures
        if (config.GetValue<int>("SPAWN_SETTINGS", "ActionFigures", 1) == 1)
        {
            for (int i = 0; i < 100; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetFiguresPosition(i), CollectList.GetFiguresModelHash(i), CollectList.GetFiguresRotation(i), CollectibleType.ActionFigures, -1));
            }
            menu.Add(figures);
        }

        //Snowmen
        if (config.GetValue<int>("SPAWN_SETTINGS", "Snowmen", 1) == 1)
        {
            for (int i = 100; i < 126; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetSnowmanPosition(i), CollectList.GetSnowmanModelName(i), CollectList.GetSnowmanRotation(i), CollectibleType.Snowmen, -1));
            }
            menu.Add(snowmen);
        }

        //Ghosts 2024
        if (config.GetValue<int>("SPAWN_SETTINGS", "Ghosts", 1) == 1)
        {
            collectibles.Add(new CollectibleItem(126, new Vector3(-1725.097f, -192.2232f, 59.09193f), "m23_1_prop_m31_ghostrurmeth_01a", new Vector3(0, 0, -101.9999f), CollectibleType.Ghosts, 19));
            collectibles.Add(new CollectibleItem(127, new Vector3(140.4723f, -1193.647f, 28.689f), "m23_1_prop_m31_ghostskidrow_01a", new Vector3(0, 0, 278.6193f), CollectibleType.Ghosts, 20));
            collectibles.Add(new CollectibleItem(128, new Vector3(1294.687f, -1591.017f, 52.16328f), "m23_1_prop_m31_ghostsalton_01a", new Vector3(0, 0, 143.4934f), CollectibleType.Ghosts, 21));
            collectibles.Add(new CollectibleItem(129, new Vector3(-541.5305f, -2226.789f, 120.8702f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, 55.16325f), CollectibleType.Ghosts, 22));
            collectibles.Add(new CollectibleItem(130, new Vector3(-1798.732f, 441.6353f, 141.6041f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, 170.0002f), CollectibleType.Ghosts, 23));
            collectibles.Add(new CollectibleItem(131, new Vector3(1003.489f, -2148.367f, 37.33975f), "m23_1_prop_m31_ghostskidrow_01a", new Vector3(0, 0, 85.47829f), CollectibleType.Ghosts, 1));
            collectibles.Add(new CollectibleItem(132, new Vector3(-759.3058f, -20.97644f, 56.45779f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, 30.00001f), CollectibleType.Ghosts, 2));
            collectibles.Add(new CollectibleItem(133, new Vector3(-765.3237f, -694.7315f, 69.23154f), "m23_1_prop_m31_ghostrurmeth_01a", new Vector3(0, 0, 15f), CollectibleType.Ghosts, 4));
            collectibles.Add(new CollectibleItem(134, new Vector3(960.7609f, -216.1422f, 75.25533f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, 182.5328f), CollectibleType.Ghosts, 5));
            collectibles.Add(new CollectibleItem(135, new Vector3(1652.198f, -23.00671f, 132.7253f), "m24_1_prop_m41_ghost_dom_01a", new Vector3(0, 0, 298.3338f), CollectibleType.Ghosts, 0));
            collectibles.Add(new CollectibleItem(136, new Vector3(1907.59f, 4931.752f, 53.89161f), "m23_1_prop_m31_ghostrurmeth_01a", new Vector3(0, 0, 144.9998f), CollectibleType.Ghosts, 20));
            collectibles.Add(new CollectibleItem(137, new Vector3(1493.806f, 3641.064f, 34.51352f), "m23_1_prop_m31_ghostskidrow_01a", new Vector3(0, 0, 0), CollectibleType.Ghosts, 21));
            collectibles.Add(new CollectibleItem(138, new Vector3(2768.155f, 4237.339f, 47.88669f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, 182.4814f), CollectibleType.Ghosts, 22));
            collectibles.Add(new CollectibleItem(139, new Vector3(3418.761f, 5163.107f, 4.861958f), "m23_1_prop_m31_ghostrurmeth_01a", new Vector3(0, 0, 17.25412f), CollectibleType.Ghosts, 23));
            collectibles.Add(new CollectibleItem(140, new Vector3(165.5603f, 3118.98f, 45.2349f), "m23_1_prop_m31_ghostsalton_01a", new Vector3(0, 0, 45f), CollectibleType.Ghosts, 1));
            collectibles.Add(new CollectibleItem(141, new Vector3(-278.4065f, 2844.814f, 52.93954f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, 324.4669f), CollectibleType.Ghosts, 2));
            collectibles.Add(new CollectibleItem(142, new Vector3(56.36493f, 6647.847f, 35.58109f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, -2f), CollectibleType.Ghosts, 3));
            collectibles.Add(new CollectibleItem(143, new Vector3(-1643.409f, 2088.244f, 86.05696f), "m23_1_prop_m31_ghostrurmeth_01a", new Vector3(0, 0, 91.55879f), CollectibleType.Ghosts, 4));
            collectibles.Add(new CollectibleItem(144, new Vector3(-530.715f, 4534.124f, 100.1169f), "m23_1_prop_m31_ghostzombie_01a", new Vector3(0, 0, 0), CollectibleType.Ghosts, 5));
            collectibles.Add(new CollectibleItem(145, new Vector3(2014.283f, 3830.398f, 32.43386f), "m23_1_prop_m31_ghostjohnny_01a", new Vector3(0, 0, 339.7408f), CollectibleType.Ghosts, 0));
            menu.Add(ghosts);
        }

        //Movie Props
        if (config.GetValue<int>("SPAWN_SETTINGS", "MovieProps", 1) == 1)
        {
            for (int i = 146; i < 156; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetMoviePropsPosition(i), CollectList.GetMoviePropsModelName(i), CollectList.GetMoviePropsRotate(i), CollectibleType.MovieProps, -1));
            }
            menu.Add(props);
        }

        //LD Organics
        if (config.GetValue<int>("SPAWN_SETTINGS", "LDOrganics", 1) == 1)
        {
            for (int i = 156; i < 256; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetLDPosition(i), "reh_prop_reh_bag_weed_01a", CollectList.GetLDRotation(i), CollectibleType.LdWare, -1));
            }
            menu.Add(LDorg);
        }

        //Jammers
        if (config.GetValue<int>("SPAWN_SETTINGS", "Jammers", 1) == 1)
        {
            for (int i = 257; i < 307; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetJammerPosition(i), "ch_prop_ch_mobile_jammer_01x", CollectList.GetJammerRotation(i), CollectibleType.Jammers, -1));
            }
            menu.Add(signal);
        }

        //Playing cards
        if (config.GetValue<int>("SPAWN_SETTINGS", "PlayingCards", 1) == 1)
        {
            for (int i = 308; i < 362; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetPlayingCardsPosition(i), "vw_prop_vw_lux_card_01a", CollectList.GetPlayingCardsRotation(i), CollectibleType.PlayingCards, -1));
            }
            menu.Add(cards);
        }

        //Jack O’ Lanterns
        if (config.GetValue<int>("SPAWN_SETTINGS", "JackLanterns", 1) == 1)
        {
            for (int i = 363; i < 563; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetLanternsPosition(i), CollectList.GetLanernsModelName(i), CollectList.GetLanternsRotation(i), CollectibleType.Lanterns, -1));
            }
            menu.Add(lanterns);
        }

        //Yuanbao
        if (config.GetValue<int>("SPAWN_SETTINGS", "Yuanbao", 1) == 1)
        {
            for (int i = 564; i < 600; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetYuanbaoPosition(i), CollectList.GetYuanbaoModelName(i), CollectList.GetLanternsRotation(i), CollectibleType.Yuanbao, -1));
            }
            menu.Add(Yuanbao);
        }

        //Radio Antennas 
        if (config.GetValue<int>("SPAWN_SETTINGS", "RadioAntennas ", 1) == 1)
        {
            for (int i = 600; i < 610; i++)
            {
                collectibles.Add(new CollectibleItem(i, CollectList.GetAntePosition(i), CollectList.GetAnteModelName(0), CollectList.GetAnteRotation(i), CollectibleType.RadioAntennas, -1));
            }
            menu.Add(antennas);
        }
    }

    private void onkeyup(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == KeyActiveMenu)
        {
            figures.AltTitle = $"{collectedCount[CollectibleType.ActionFigures]}/100";
            snowmen.AltTitle = $"{collectedCount[CollectibleType.Snowmen]}/25";
            ghosts.AltTitle = $"{collectedCount[CollectibleType.Ghosts]}/20";
            props.AltTitle = $"{collectedCount[CollectibleType.MovieProps]}/10";
            LDorg.AltTitle = $"{collectedCount[CollectibleType.LdWare]}/100";
            cards.AltTitle = $"{collectedCount[CollectibleType.PlayingCards]}/54";
            signal.AltTitle = $"{collectedCount[CollectibleType.Jammers]}/50";
            Yuanbao.AltTitle = $"{collectedCount[CollectibleType.Yuanbao]}/36";
            lanterns.AltTitle = $"{collectedCount[CollectibleType.Lanterns]}/200";
            antennas.AltTitle = $"{collectedCount[CollectibleType.RadioAntennas]}/10";
            menu.Visible = true;
        }
    }

    private void ShowCollectMessage(string title, string subtitle)
    {
        scaleformHandle = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "MIDSIZED_MESSAGE");
        while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, scaleformHandle))
        {
            Script.Wait(0);
        }

        Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, scaleformHandle, "SHOW_COND_SHARD_MESSAGE");
        Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_LITERAL_STRING, title); 
        Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_LITERAL_STRING, subtitle);
        Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 2); // colID
        Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, true); // useDarkerShard
        Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);

        messageStartTime = Game.GameTime + 10000;
        messageVisible = true;
    }

    private void AnimateOut()
    {
        Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, scaleformHandle, "SHARD_ANIM_OUT");
        Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 7); // colID
        Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, 0.3f); 
        Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);

        messageVisible = false;
    }

    private void UpdateCollectMessages()
    {
        if (scaleformHandle != 0)
        {
            Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, scaleformHandle, 255, 255, 255, 255, 0);
        }

        if (messageVisible && Game.GameTime > messageStartTime)
        {
            AnimateOut();
        }
    }

    private void OnTick(object sender, EventArgs e)
    {
        pool.Process();
        UpdateCollectMessages();

        CheckCollectorRadar();

        UpdateCollectorBlips();

        CheckAwards();

        var playerPosition = Game.Player.Character.Position;

        foreach (var collectible in collectibles)
        {
            if ((collectible.Collected || collectedIds.Contains(collectible.Id)) && collectible.ModelName != "h4_prop_h4_ante_off_01a") continue;

            CheckMovieVehicleActive(collectible);

            float distanceToPlayer = Vector3.Distance(playerPosition, collectible.Position);

            if (distanceToPlayer <= spawnDistance && (collectible.hourSpawn == -1 || Function.Call<int>(Hash.GET_CLOCK_HOURS) == collectible.hourSpawn))
            {
                collectible.Spawn();

                if (collectible.Collected)
                {
                    collectible.prop = SwapModelKostyl(collectible.prop);
                }

                switch (collectible.Type)
                {
                    case CollectibleType.ActionFigures:
                    case CollectibleType.PlayingCards:
                        if (distanceToPlayer <= collectRadius_without_keys)
                        {
                            collectible.Collect();
                            collectible.Remove();
                            SaveCollectedId(collectible.Id);
                            IncrementCollectedCount(collectible.Type, collectible.Id);
                        }
                        break;

                    case CollectibleType.Lanterns:
                    case CollectibleType.LdWare:
                    case CollectibleType.MediaSticks:
                    case CollectibleType.Yuanbao:
                    case CollectibleType.RadioAntennas:

                        if (distanceToPlayer <= 1.5f && !collectible.Collected)
                        {

                            switch(collectible.Type)
                            {
                                case CollectibleType.LdWare:
                                    GTA.UI.Screen.ShowHelpTextThisFrame(Game.GetLocalizedString("CONTEXT_COLLEORG"));
                                    break;

                                case CollectibleType.Lanterns:
                                    GTA.UI.Screen.ShowHelpTextThisFrame(Game.GetLocalizedString("CONTEXT_COLLETRICK"));
                                    break;

                                case CollectibleType.MediaSticks:
                                    GTA.UI.Screen.ShowHelpTextThisFrame(Game.GetLocalizedString("CONTEXT_COLLECC"));
                                    break;

                                case CollectibleType.Yuanbao:
                                    GTA.UI.Screen.ShowHelpTextThisFrame(Game.GetLocalizedString("COL24CNYHELPCAN"));
                                    break;

                                case CollectibleType.RadioAntennas:
                                    GTA.UI.Screen.ShowHelpTextThisFrame(Game.GetLocalizedString("CONRAD_COLLEC"));
                                    break;
                            }

                            if (Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 0, 51))
                            {
                                int time_anim = 1000;
                                int scene = 0;
                                Vector3 toItemDirection = (collectible.prop.Position - Game.Player.Character.Position).Normalized;
                                Game.Player.Character.Task.LookAt(collectible.prop.Position, 2000);
                                Game.Player.Character.Heading = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, toItemDirection.X, toItemDirection.Y);

                                if (collectible.Type == CollectibleType.Lanterns)
                                {
                                    Function.Call(Hash.REQUEST_ANIM_DICT, "anim@scripted@player@freemode@tun_prep_ig1_grab_low@male@");
                                    while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, "anim@scripted@player@freemode@tun_prep_ig1_grab_low@male@")) Script.Wait(0);
                                    Game.Player.Character.Task.PlayAnimation("anim@scripted@player@freemode@tun_prep_ig1_grab_low@male@", "grab_low", 8.0f, -8.0f, -1, AnimationFlags.HideWeapon, 0.0f);
                                }
                                else if (collectible.Type == CollectibleType.RadioAntennas)
                                {
                                    Vector3 scenePos = CollectList.GetAntePosition(collectible.Id);
                                    Vector3 sceneRot = CollectList.GetAnteRotation(collectible.Id);
                                    scene = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, scenePos.X, scenePos.Y, scenePos.Z, sceneRot.X, sceneRot.Y, sceneRot.Z, 2);
                                    Function.Call(Hash.SET_SYNCHRONIZED_SCENE_LOOPED, scene, false);

                                    Model model = new Model("h4_prop_h4_ante_on_01a");
                                    model.Request();
                                    while (!model.IsLoaded) Script.Wait(50);

                                    Function.Call(Hash.REQUEST_ANIM_DICT, "anim@scripted@heist@ig2_hand_lever@heeled@");
                                    while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, "anim@scripted@heist@ig2_hand_lever@heeled@")) Script.Wait(0);


                                    float durationTime = Function.Call<float>(Hash.GET_ANIM_DURATION, "anim@scripted@heist@ig2_hand_lever@heeled@", "ENTER_ANTE_OFF");


                                    Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Game.Player.Character, false, false, false, false);

                                    Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, scene, "anim@scripted@heist@ig2_hand_lever@heeled@", "ENTER_HEELED", 1000.0, -4.0, 1, 0, 0x447a0000, 0);
                                    Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, collectible.prop, scene, "ENTER_ANTE_OFF", "anim@scripted@heist@ig2_hand_lever@heeled@", 1000.0, -1000.0, 0, 0x447a0000);
                                    Function.Call(Hash.SET_SYNCHRONIZED_SCENE_PHASE, scene, 0.0);
                                    Wait((int)durationTime * 1000);

                                    Function.Call(Hash.DETACH_SYNCHRONIZED_SCENE, scene);

                                    collectible.prop = SwapModelKostyl(collectible.prop);

                                    scene = Function.Call<int>(Hash.CREATE_SYNCHRONIZED_SCENE, scenePos.X, scenePos.Y, scenePos.Z, sceneRot.X, sceneRot.Y, sceneRot.Z, 2);
                                    Function.Call(Hash.SET_SYNCHRONIZED_SCENE_LOOPED, scene, false);
                                    Function.Call(Hash.TASK_SYNCHRONIZED_SCENE, Game.Player.Character, scene, "anim@scripted@heist@ig2_hand_lever@heeled@", "EXIT_HEELED", 1000.0, -4.0, 1, 0, 0x447a0000, 0);
                                    Function.Call(Hash.PLAY_SYNCHRONIZED_ENTITY_ANIM, collectible.prop, scene, "EXIT_ANTE_OFF", "anim@scripted@heist@ig2_hand_lever@heeled@", 1000.0, -1000.0, 0, 0x447a0000);
                                }
                                else
                                {
                                    Function.Call(Hash.REQUEST_ANIM_DICT, "anim@scripted@player@freemode@tun_prep_grab_midd_ig3@male@");
                                    while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, "anim@scripted@player@freemode@tun_prep_grab_midd_ig3@male@")) Script.Wait(0);
                                    Game.Player.Character.Task.PlayAnimation("anim@scripted@player@freemode@tun_prep_grab_midd_ig3@male@", "tun_prep_grab_midd_ig3", 8.0f, -8.0f, -1, AnimationFlags.UpperBodyOnly, 0.0f);
                                }

                                Wait(time_anim);

                                collectible.Collect();

                                if (collectible.Type != CollectibleType.RadioAntennas) collectible.Remove();

                                SaveCollectedId(collectible.Id);
                                IncrementCollectedCount(collectible.Type, collectible.Id);

                                Function.Call(Hash.REMOVE_ANIM_DICT, "anim@scripted@player@freemode@tun_prep_grab_midd_ig3@male@");
                                Function.Call(Hash.REMOVE_ANIM_DICT, "anim@scripted@player@freemode@tun_prep_ig1_grab_low@male@");

                                Function.Call(Hash.DETACH_SYNCHRONIZED_SCENE, scene);
                                Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Game.Player.Character, true, false, false, false);
                                Function.Call(Hash.CLEAR_PED_TASKS_IMMEDIATELY, Game.Player.Character);
                            }
                        }
                        break;

                    case CollectibleType.Snowmen:
                        if (collectible.prop != null && Function.Call<bool>(Hash.IS_ENTITY_DEAD, collectible.prop, false))
                        {
                            Function.Call(Hash.SET_ENTITY_HEALTH, collectible.prop, 0, 0, 0);

                            Function.Call(Hash.PLAY_SOUND_FROM_COORD,
                                -1,
                                "destroy",
                                collectible.prop.Position.X,
                                collectible.prop.Position.Y,
                                collectible.prop.Position.Z,
                                "Snowmen_Colllectible_Sounds",
                                false,
                                0,
                                false);

                            collectible.Collect();
                            collectible.MarkAsNoLongerNeeded();
                            SaveCollectedId(collectible.Id);
                            IncrementCollectedCount(collectible.Type, collectible.Id);
                        }
                        break;

                    case CollectibleType.Jammers:
                        if (collectible.prop != null && Function.Call<bool>(Hash.IS_ENTITY_DEAD, collectible.prop, false))
                        {
                            Wait(500);
                            Function.Call(Hash.PLAY_SOUND_FROM_COORD,
                                -1,
                                "destroy",
                                collectible.prop.Position.X,
                                collectible.prop.Position.Y,
                                collectible.prop.Position.Z,
                                "Snowmen_Colllectible_Sounds",
                                false,
                                0,
                                false);

                            collectible.Collect();
                            collectible.Remove();
                            SaveCollectedId(collectible.Id);
                            IncrementCollectedCount(collectible.Type, collectible.Id);
                        }
                        break;

                    case CollectibleType.Ghosts:
                        if (Function.Call<bool>(Hash.PHONEPHOTOEDITOR_IS_ACTIVE) &&
                        Function.Call<bool>(Hash.IS_CONTROL_PRESSED, 0, 176)) // ENTER
                        {
                            if(IsGhostInPhoto(collectible.prop))
                            {
                                Wait(1000);
                                collectible.Collect();
                                collectible.Remove();
                                SaveCollectedId(collectible.Id);
                                IncrementCollectedCount(collectible.Type, collectible.Id);
                            }
                        }
                        break;

                    case CollectibleType.MovieProps:
                        if (collectible.MovieVeh != null && collectible.MovieVeh.Exists())
                        {
                            CheckMovieVehicleActive(collectible);
                        }
                        else
                        {
                            if (distanceToPlayer <= collectRadius_without_keys)
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
                                IncrementCollectedCount(collectible.Type, collectible.Id);

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

    private bool IsGhostInPhoto(Prop ghostProp)
    {
        if (ghostProp == null || !ghostProp.Exists())
            return false;

        Vector3 cameraPosition = GameplayCamera.Position;
        Vector3 cameraForward = GameplayCamera.Direction;

        float rayLength = spawnDistance;

        int rayHandle = Function.Call<int>(
            Hash.START_EXPENSIVE_SYNCHRONOUS_SHAPE_TEST_LOS_PROBE,
            cameraPosition.X, cameraPosition.Y, cameraPosition.Z,          
            cameraPosition.X + cameraForward.X * rayLength,               
            cameraPosition.Y + cameraForward.Y * rayLength,
            cameraPosition.Z + cameraForward.Z * rayLength,
            -1,                                                         
            Game.Player.Character.Handle,                                   
            0
        );

        OutputArgument hit = new OutputArgument();
        OutputArgument endCoords = new OutputArgument();
        OutputArgument surfaceNormal = new OutputArgument();
        OutputArgument entityHit = new OutputArgument();

        int result = Function.Call<int>(
            Hash.GET_SHAPE_TEST_RESULT,
            rayHandle,
            hit,
            endCoords,
            surfaceNormal,
            entityHit
        );

        bool didHit = hit.GetResult<bool>();
        Entity hitEntity = Entity.FromHandle(entityHit.GetResult<int>());

        if (didHit && hitEntity != null && hitEntity.Handle == ghostProp.Handle)
        {
            return true; 
        }

        Vector3 rayEnd = endCoords.GetResult<Vector3>();
        float distanceToGhost = Vector3.Distance(ghostProp.Position, rayEnd);

        return distanceToGhost <= 1.5f; 
    }

    private void UnlockRadioStations()
    {
        if (collectedCount[CollectibleType.Jammers] == 50)
        {
            Function.Call(Hash.LOCK_RADIO_STATION, "RADIO_34_DLC_HEI4_KULT", false);
            Function.Call(Hash.LOCK_RADIO_STATION, "RADIO_35_DLC_HEI4_MLR", false);
            Function.Call(Hash.LOCK_RADIO_STATION, "RADIO_37_MOTOMAMI", false);
        }

        if (collectedCount[CollectibleType.RadioAntennas] == 10)
        {
            Function.Call(Hash.LOCK_RADIO_STATION, "RADIO_27_DLC_PRHEI4", false);
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
                            Game.Player.Money += 500000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.LdWare:
                        if (collectedCount[CollectibleType.LdWare] == 100)
                        {
                            Game.Player.Money += 500000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.PlayingCards:
                        if (collectedCount[CollectibleType.PlayingCards] == 54)
                        {
                            Game.Player.Money += 500000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.Yuanbao:
                        if (collectedCount[CollectibleType.Yuanbao] == 36)
                        {
                            Game.Player.Money += 500000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.Snowmen:
                        if (collectedCount[CollectibleType.Snowmen] == 25)
                        {
                            Game.Player.Money += 100000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.Jammers:
                    case CollectibleType.RadioAntennas:
                        if (collectedCount[CollectibleType.Jammers] == 50 || collectedCount[CollectibleType.RadioAntennas] == 10)
                        {
                            Game.Player.Money += 100000;
                            UnlockRadioStations();
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.Lanterns:
                        if (collectedCount[CollectibleType.Jammers] == 200)
                        {
                            Game.Player.Money += 1000000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.Ghosts:
                        if (collectedCount[CollectibleType.Ghosts] == 20)
                        {
                            Game.Player.Money += 100000;
                            collectible.IsAwarded = true;
                        }
                        break;

                    case CollectibleType.MovieProps:
                        if (collectedCount[CollectibleType.MovieProps] == 10)
                        {
                            Game.Player.Money += 100000;
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
                        IncrementCollectedCount(collectible.Type, collectible.Id);

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

    private void IncrementCollectedCount(CollectibleType type, int id)
    {

        collectedCount[type]++;
        string title = "";
        string subtitle = "";

        switch (type)
        {
            case CollectibleType.ActionFigures:
                title = Game.GetLocalizedString("FIGURE_HEADER");
                subtitle = ReplacePlaceholder(Game.GetLocalizedString("FIGURE_COLLECT"), collectedCount[type]);
                Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("FIGURE_TICKER"), collectedCount[type]), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, CollectList.GetAudioFigures(id), "dlc_vw_hidden_collectible_sounds", false);
                break;

            case CollectibleType.LdWare:
                title = Game.GetLocalizedString("ORGANI_HEADER");
                subtitle = ReplacePlaceholder(Game.GetLocalizedString("ORGANI_COLLECT"), collectedCount[type]);
                Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("ORGANI_TICKER"), collectedCount[type]), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Collect", "LD_Organics_sounds", false);
                break;

            case CollectibleType.PlayingCards:
                title = Game.GetLocalizedString("CARD_HEADER");
                subtitle = ReplacePlaceholder(Game.GetLocalizedString("CARD_COLLECT"), collectedCount[type]);
                Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("CARD_TICKER"), collectedCount[type]), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "playing_card", "dlc_vw_hidden_collectible_sounds", false);
                break;

            case CollectibleType.Yuanbao:
                title = Game.GetLocalizedString("YUANBAO_HEADER");
                subtitle = ReplacePlaceholders(Game.GetLocalizedString("YUANBAO_COLLECT"), new int[] { collectedCount[type], 36 });
                Notification.PostTicker(ReplacePlaceholders(Game.GetLocalizedString("YUANBAO_TICKER"), new int[] { collectedCount[type], 36 }), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Collect", "DLC_24-2_Lunar_New_Year_Collectible_Sounds", false);
                break;

            case CollectibleType.Snowmen:
                title = Game.GetLocalizedString("SNOWMEN_HEADER");
                subtitle = ReplacePlaceholder(Game.GetLocalizedString("SNOWMEN_COLLECT"), collectedCount[type]);
                Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("SNOWMEN_TICKER"), collectedCount[type]), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "destroy", "Snowmen_Colllectible_Sounds", false);
                break;

            case CollectibleType.Ghosts:
                title = Game.GetLocalizedString("SUM23GHSHARDHE");
                subtitle = ReplacePlaceholdersAndNumber(Game.GetLocalizedString("SUM23GHSHABOD1"), collectedCount[type], 10, 20);
                Notification.PostTicker(ReplacePlaceholdersAndNumber(Game.GetLocalizedString("GHOSTHUNT_HELPCOL"), collectedCount[type], 10, 20), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Collect_Shard", "Ghost_Hunt_Sounds", false);
                break;

            case CollectibleType.MovieProps:
                title = Game.GetLocalizedString("PROPS_HEADER");
                subtitle = ReplacePlaceholder(Game.GetLocalizedString("PROPS_COLLECT"), collectedCount[type]);
                GTA.UI.Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("PROPS_TICKER"), collectedCount[type]), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "movie_prop", "DLC_SUM20_HIDDEN_COLLECTIBLES", false);
                break;

            case CollectibleType.Jammers:
                Function.Call<bool>(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_CM2022/CM2022_FREEMODE_01", false, -1);
                title = Game.GetLocalizedString("SIGNAL_HEADER");
                subtitle = ReplacePlaceholder(Game.GetLocalizedString("SIGNAL_COLLECT2"), collectedCount[type]);
                GTA.UI.Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("SIGNAL_COLLECT"), collectedCount[type]), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "destroyed", "dlc_ch_hidden_collectibles_sj_sounds", false);
                break;

            case CollectibleType.Lanterns:
                title = Game.GetLocalizedString("TRICK_HEADER");
                subtitle = ReplacePlaceholdersAndNumber(Game.GetLocalizedString("TRICK_COLLECT"), collectedCount[type], 10, 200);
                Notification.PostTicker(ReplacePlaceholdersAndNumber(Game.GetLocalizedString("TRICK_TICKER"), collectedCount[type], 10, 200), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Collect_Treat", "Trick_Or_Treat_sounds", false);
                break;

            case CollectibleType.RadioAntennas:
                title = Game.GetLocalizedString("RADST_HEADER");
                subtitle = ReplacePlaceholder(Game.GetLocalizedString("RADST_COLLECT"), collectedCount[type]);
                GTA.UI.Notification.PostTicker(ReplacePlaceholder(Game.GetLocalizedString("RADST_TICKER"), collectedCount[type]), true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "radio_tower_shard_single", "dlc_hei4_hidden_collectibles_sounds", false);
                break;
        }

        ShowCollectMessage(title, subtitle);
    }

    private void OnAborted(object sender, EventArgs e)
    {

        foreach (var collectible in collectibles)
        {
            collectible.Remove();
        }

        RemoveAllCollectorBlips();

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

    static string ReplacePlaceholders(string input, int[] replacements)
    {
        int index = 0;
        return Regex.Replace(input, "~1~", match =>
        {
            if (index < replacements.Length)
            {
                return replacements[index++].ToString();
            }
            return match.Value;
        });
    }

    static string ReplacePlaceholdersAndNumber(string input, int placeholderValue, int targetNumber, int replacementNumber)
    {
        string result = input.Replace("~1~", placeholderValue.ToString());

        result = Regex.Replace(result, $"\\b{targetNumber}\\b", replacementNumber.ToString());

        return result;
    }

    static Prop SwapModelKostyl(Prop prop)
    {
        Model ante_on = new Model("h4_prop_h4_ante_on_01a");
        ante_on.Request(500);

        while (!ante_on.IsLoaded) Script.Wait(50);

        Prop prop_new = World.CreatePropNoOffset(ante_on, new Vector3(0, 0, 0), false);
        prop_new.Rotation = prop.Rotation;
        prop_new.IsVisible = false;
        prop_new.Position = prop.Position;
        prop_new.IsVisible = true;
        prop.Delete();
        ante_on.MarkAsNoLongerNeeded();

        Function.Call(Hash.STOP_SOUND, ante_audio);
        Function.Call(Hash.RELEASE_SOUND_ID, ante_audio);

        Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLC_HEI4_Collectibles", false, -1);
        ante_audio = Function.Call<int>(Hash.GET_SOUND_ID);
        Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, ante_audio, "radio_tower_fixed", prop_new, "dlc_hei4_hidden_collectibles_sounds", false, 0);

        return prop_new;
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
        public Prop prop { get; set; }
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

                while (!model.IsLoaded) Script.Wait(50);

                prop = World.CreatePropNoOffset(model, Position, false); 
                prop.Rotation = Rotation; 
                model.MarkAsNoLongerNeeded();

                if (Type == CollectibleType.Jammers || Type == CollectibleType.Lanterns)
                {

                    Function.Call(Hash.SET_OBJECT_TARGETTABLE, prop, true, 0);
                    Function.Call(Hash.SET_ENTITY_ONLY_DAMAGED_BY_PLAYER, prop, true);
                    Function.Call(Hash.ADD_PLAYER_TARGETABLE_ENTITY, Game.Player, prop);
                }

                if (Type == CollectibleType.Jammers)
                {
                    Function.Call(Hash.SET_PROJECTILES_SHOULD_EXPLODE_ON_CONTACT, prop, 1);
                    Function.Call(Hash.SET_ENTITY_PROOFS, prop, false, false, false, true, false, false, false, false);
                }

                if (Type == CollectibleType.Snowmen)
                {
                    Function.Call(Hash.SET_PROJECTILES_SHOULD_EXPLODE_ON_CONTACT, prop, 1);
                    Function.Call(Hash.SET_ENTITY_PROOFS, prop, true, false, false, true, true, false, false, false);
                    Function.Call(Hash.SET_ENTITY_HEALTH, prop, 200, 0, 0);
                }

                if (Type == CollectibleType.RadioAntennas)
                {
                    Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "DLC_HEI4/DLC_HEI4_Collectibles", false, -1);
                    ante_audio = Function.Call<int>(Hash.GET_SOUND_ID);
                    Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, ante_audio, "radio_tower_attract_loop", prop, "dlc_hei4_hidden_collectibles_sounds", false, 0);
    }

                if (Type == CollectibleType.MovieProps && MovieVeh == null)
                {
                    Function.Call(Hash.SET_ENTITY_COLLISION, prop, false, 0);

                    switch(ModelName)
                    {
                        case "sum_prop_ac_sarcophagus_01a":

                            Model veh = new Model("pony");
                            veh.Request();

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
                            veh = new Model("rebel");
                            veh.Request();

                            while (!veh.IsLoaded) Script.Wait(50);
                            MovieVeh = World.CreateVehicle(VehicleHash.Rebel, Position);
                            while (MovieVeh == null) Script.Wait(0);
                            MovieVeh.Rotation = Rotation;
                            prop.AttachTo(MovieVeh, new Vector3(0, -1.5f, 0), Vector3.Zero);
                            break;
                    }
                }
            }
        }


        public void MarkAsNoLongerNeeded()
        {
            if (prop != null && prop.Exists())
            {
                prop.MarkAsNoLongerNeeded();
                prop = null;
            }

            if (MovieVeh != null && MovieVeh.Exists())
            {
                MovieVeh.MarkAsNoLongerNeeded();
                MovieVeh = null;
            }
        }

        public void Remove()
        {
            if (prop != null && prop.Exists())
            {
                if (prop.Model.Hash == new Model("h4_prop_h4_ante_off_01a").Hash || prop.Model.Hash == new Model("h4_prop_h4_ante_on_01a").Hash)
                {
                    Function.Call(Hash.STOP_SOUND, ante_audio);
                    Function.Call(Hash.RELEASE_SOUND_ID, ante_audio);
                }

                prop.Delete();
                prop = null;
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
        MovieProps,
        MediaSticks,
        Lanterns,
        Yuanbao,
        RadioAntennas
    }
}