using GTA;
using GTA.Math;
using GTA.Native;

public class CollectList
{
	public static Vector3 GetFiguresPosition(int id)
	{

		switch (id)
		{
			case 0:
				return new Vector3(-2557.4053f, 2315.502f, 33.742f);

			case 1:
				return new Vector3(2487.128f, 3759.327f, 42.317f);

			case 2:
				return new Vector3(457.198f, 5573.861f, 780.184f);

			case 3:
				return new Vector3(-1280.407f, 2549.743f, 17.534f);

			case 4:
				return new Vector3(-107.722f, -856.981f, 38.261f);

			case 5:
				return new Vector3(-1050.513f, -522.612f, 36.634f);

			case 6:
				return new Vector3(693.306f, 1200.583f, 344.524f);

			case 7:
				return new Vector3(2500.654f, -389.482f, 94.245f);

			case 8:
				return new Vector3(483.4f, -3110.621f, 6.627f);

			case 9:
				return new Vector3(-2169.277f, 5192.986f, 16.295f);

			case 10:
				return new Vector3(177.674f, 6394.054f, 31.376f);

			case 11:
				return new Vector3(2416.9421f, 4994.557f, 45.239f);

			case 12:
				return new Vector3(1702.9f, 3291f, 48.72f);

			case 13:
				return new Vector3(-600.813f, 2088.011f, 132.336f);

			case 14:
				return new Vector3(-3019.7935f, 41.9486f, 10.2924f);

			case 15:
				return new Vector3(-485.4648f, -54.441f, 38.9945f);

			case 16:
				return new Vector3(-1350.785f, -1547.089f, 4.675f);

			case 17:
				return new Vector3(379.535f, -1509.398f, 29.34f);

			case 18:
				return new Vector3(2548.713f, 385.386f, 108.423f);

			case 19:
				return new Vector3(-769.346f, 877.307f, 203.424f);

			case 20:
				return new Vector3(-1513.54f, 1517.184f, 111.305f);

			case 21:
				return new Vector3(-1023.899f, 190.912f, 61.282f);

			case 22:
				return new Vector3(1136.355f, -666.404f, 57.044f);

			case 23:
				return new Vector3(3799.76f, 4473.048f, 6.032f);

			case 24:
				return new Vector3(1243.588f, -2572.136f, 42.603f);

			case 25:
				return new Vector3(219.811f, 97.162f, 96.336f);

			case 26:
				return new Vector3(-1545.826f, -449.397f, 40.318f);

			case 27:
				return new Vector3(-928.683f, -2938.691f, 13.059f);

			case 28:
				return new Vector3(-1647.926f, -1094.716f, 12.736f);

			case 29:
				return new Vector3(-2185.939f, 4249.814f, 48.803f);

			case 30:
				return new Vector3(-262.339f, 4729.229f, 137.329f);

			case 31:
				return new Vector3(-311.701f, 6315.024f, 31.978f);

			case 32:
				return new Vector3(3306.444f, 5194.742f, 17.432f);

			case 33:
				return new Vector3(1389.886f, 3608.834f, 35.06f);

			case 34:
				return new Vector3(852.846f, 2166.327f, 52.717f);

			case 35:
				return new Vector3(-1501.96f, 814.071f, 181.433f);

			case 36:
				return new Vector3(2634.972f, 2931.061f, 44.608f);

			case 37:
				return new Vector3(660.57f, 549.947f, 129.157f);

			case 38:
				return new Vector3(-710.626f, -905.881f, 19.015f);

			case 39:
				return new Vector3(1207.701f, -1479.537f, 35.166f);

			case 40:
				return new Vector3(-90.151f, 939.849f, 232.515f);

			case 41:
				return new Vector3(-180.059f, -631.866f, 48.534f);

			case 42:
				return new Vector3(-299.634f, 2847.173f, 55.485f);

			case 43:
				return new Vector3(621.365f, -409.254f, -1.308f);

			case 44:
				return new Vector3(-988.92f, -102.669f, 40.157f);

			case 45:
				return new Vector3(63.999f, 3683.868f, 39.763f);

			case 46:
				return new Vector3(-688.668f, 5829.006f, 16.775f);

			case 47:
				return new Vector3(1540.435f, 6323.453f, 23.519f);

			case 48:
				return new Vector3(2725.806f, 4142.14f, 43.293f);

			case 49:
				return new Vector3(1297.977f, 4306.744f, 37.897f);

			case 50:
				return new Vector3(1189.579f, 2641.222f, 38.413f);

			case 51:
				return new Vector3(-440.796f, 1596.48f, 358.648f);

			case 52:
				return new Vector3(-2237.557f, 249.282f, 175.352f);

			case 53:
				return new Vector3(-1211.932f, -959.965f, 0.393f);

			case 54:
				return new Vector3(153.845f, -3077.341f, 6.744f);

			case 55:
				return new Vector3(-66.231f, -1451.825f, 31.164f);

			case 56:
				return new Vector3(987.982f, -136.863f, 73.454f);

			case 57:
				return new Vector3(-507.032f, 393.905f, 96.411f);

			case 58:
				return new Vector3(172.1275f, -564.1393f, 22.145f);

			case 59:
				return new Vector3(1497.202f, -2133.147f, 76.302f);

			case 60:
				return new Vector3(-2958.706f, 386.41f, 14.434f);

			case 61:
				return new Vector3(1413.963f, 1162.483f, 114.351f);

			case 62:
				return new Vector3(-1648.058f, 3018.313f, 31.25f);

			case 63:
				return new Vector3(-1120.2f, 4977.292f, 185.445f);

			case 64:
				return new Vector3(1310.683f, 6545.917f, 4.798f);

			case 65:
				return new Vector3(1714.573f, 4790.844f, 41.539f);

			case 66:
				return new Vector3(1886.6438f, 3913.7578f, 32.039f);

			case 67:
				return new Vector3(543.476f, 3074.79f, 40.324f);

			case 68:
				return new Vector3(1408.045f, 2157.34f, 97.575f);

			case 69:
				return new Vector3(-3243.858f, 996.179f, 12.486f);

			case 70:
				return new Vector3(-1905.566f, -709.6311f, 8.766f);

			case 71:
				return new Vector3(-1462.089f, 182.089f, 54.953f);

			case 72:
				return new Vector3(86.997f, 812.619f, 211.062f);

			case 73:
				return new Vector3(-886.554f, -2096.579f, 8.699f);

			case 74:
				return new Vector3(367.684f, -2113.475f, 16.274f);

			case 75:
				return new Vector3(679.009f, -1522.824f, 8.834f);

			case 76:
				return new Vector3(1667.377f, 0.119f, 165.118f);

			case 77:
				return new Vector3(-293.486f, -342.485f, 9.481f);

			case 78:
				return new Vector3(462.664f, -765.675f, 26.358f);

			case 79:
				return new Vector3(-57.784f, 1939.74f, 189.655f);

			case 80:
				return new Vector3(2618.4114f, 1692.3947f, 31.9462f);

			case 81:
				return new Vector3(-1894.5538f, 2043.5173f, 140.9093f);

			case 82:
				return new Vector3(2221.8577f, 5612.785f, 54.0631f);

			case 83:
				return new Vector3(-551.3712f, 5330.728f, 73.9861f);

			case 84:
				return new Vector3(-2171.4058f, 3441.188f, 32.175f);

			case 85:
				return new Vector3(1848.131f, 2700.702f, 63.008f);

			case 86:
				return new Vector3(-1719.6017f, -232.886f, 54.4441f);

			case 87:
				return new Vector3(-55.3785f, -2519.7546f, 7.2875f);

			case 88:
				return new Vector3(874.8454f, -2163.9976f, 32.3688f);

			case 89:
				return new Vector3(-43.6983f, -1747.9608f, 29.2778f);

			case 90:
				return new Vector3(173.324f, -1208.43f, 29.6564f);

			case 91:
				return new Vector3(2936.3228f, 4620.4834f, 48.767f);

			case 92:
				return new Vector3(3514.6545f, 3754.6873f, 34.4766f);

			case 93:
				return new Vector3(656.9f, -1046.9314f, 21.5745f);

			case 94:
				return new Vector3(-141.1536f, 234.8366f, 99.0008f);

			case 95:
				return new Vector3(-1806.68f, 427.6159f, 131.765f);

			case 96:
				return new Vector3(-908.9565f, -1148.9175f, 2.3868f);

			case 97:
				return new Vector3(387.9323f, 2570.408f, 43.299f);

			case 98:
				return new Vector3(2399.5054f, 3062.7463f, 53.4703f);

			case 99:
				return new Vector3(2394.7214f, 3062.6895f, 51.2379f);
		}

		return new Vector3(0, 0, 0);
	}

	public static Vector3 GetFiguresRotation(int id)
	{
		switch (id)
		{
			case 0:
				return new Vector3( -72.501f, 79.501f, -150.871f);

			case 1:
				return new Vector3( 0f, 0f, -108.4f);

			case 2:
				return new Vector3( 0f, 0f, -66.201f);

			case 3:
				return new Vector3( 0f, 0f, 179.599f);

			case 4:
				return new Vector3( 0f, 0f, -36.002f);

			case 5:
				return new Vector3( -24.634f, 101.263f, -178.531f);

			case 6:
				return new Vector3( 0f, 0f, -142.331f);

			case 7:
				return new Vector3( 0f, 0f, 86.069f);

			case 8:
				return new Vector3( 0f, 0f, 62.869f);

			case 9:
				return new Vector3( -77.337f, 0f, 62.869f);

			case 10:
				return new Vector3( 0f, 0f, 86.069f);

			case 11:
				return new Vector3( -0.938f, 0.437f, -26.769f);

			case 12:
				return new Vector3( 0f, 0f, -111.932f);

			case 13:
				return new Vector3( 0f, -3.923f, -162.532f);

			case 14:
				return new Vector3( 0f, 0f, 97.7147f);

			case 15:
				return new Vector3( 0f, 0f, -110.836f);

			case 16:
				return new Vector3( -45.713f, 0f, 93.164f);

			case 17:
				return new Vector3( -85.885f, 120.637f, -180f);

			case 18:
				return new Vector3( 0f, 0f, 111.4f);

			case 19:
				return new Vector3( 0f, 0f, 86.599f);

			case 20:
				return new Vector3( -43.946f, 0f, -111.401f);

			case 21:
				return new Vector3( 0f, 0f, 47.599f);

			case 22:
				return new Vector3( -88.249f, -180f, 112.799f);

			case 23:
				return new Vector3( 0f, 0f, 170.998f);

			case 24:
				return new Vector3( 0f, 0f, 111.798f);

			case 25:
				return new Vector3( 0f, 0f, 74.598f);

			case 26:
				return new Vector3( 0f, 0f, 137.597f);

			case 27:
				return new Vector3( 0f, 0f, 155.797f);

			case 28:
				return new Vector3( -21.498f, 0f, 155.797f);

			case 29:
				return new Vector3( 0f, 0f, -111.203f);

			case 30:
				return new Vector3( 0f, 0f, 158.597f);

			case 31:
				return new Vector3( -83.123f, 0f, -120.203f);

			case 32:
				return new Vector3( 0f, 0f, -39.603f);

			case 33:
				return new Vector3( 0f, 90.157f, 19.797f);

			case 34:
				return new Vector3( 0f, 0f, -9.403f);

			case 35:
				return new Vector3( 0f, 0f, -27.603f);

			case 36:
				return new Vector3( 0f, 0f, 173.396f);

			case 37:
				return new Vector3( -87.131f, -180f, -50.604f);

			case 38:
				return new Vector3( 0f, 0f, 113.396f);

			case 39:
				return new Vector3( 0f, 0f, -105.804f);

			case 40:
				return new Vector3( -45.53f, 0f, 86.795f);

			case 41:
				return new Vector3( -74.997f, 0f, 67.595f);

			case 42:
				return new Vector3( 0f, 0f, 91.595f);

			case 43:
				return new Vector3( 0f, 92.382f, -149.405f);

			case 44:
				return new Vector3( 0f, 0f, 19.595f);

			case 45:
				return new Vector3( 0f, 0f, 8.129f);

			case 46:
				return new Vector3( 5.231f, 0f, -122.071f);

			case 47:
				return new Vector3( -59.897f, 0f, 132.329f);

			case 48:
				return new Vector3( 0f, 0f, -89.672f);

			case 49:
				return new Vector3( 0f, 0f, 45.528f);

			case 50:
				return new Vector3( 0f, 0f, -56.473f);

			case 51:
				return new Vector3( 0f, 0f, 42.727f);

			case 52:
				return new Vector3( 0f, 0f, -74.873f);

			case 53:
				return new Vector3( 0f, 0f, -141.073f);

			case 54:
				return new Vector3( 0f, 0f, -52.873f);

			case 55:
				return new Vector3( 0f, 0f, 89.726f);

			case 56:
				return new Vector3( -82.457f, 89.968f, 177.526f);

			case 57:
				return new Vector3( 0f, 0f, 77.126f);

			case 58:
				return new Vector3( 0f, 0f, -56.074f);

			case 59:
				return new Vector3( 0f, 0f, 99.925f);

			case 60:
				return new Vector3( 0f, 0f, -136.875f);

			case 61:
				return new Vector3( 0f, 0f, 158.125f);

			case 62:
				return new Vector3( -74.779f, -5.132f, 75.389f);

			case 63:
				return new Vector3( -60.037f, -3.275f, 120.688f);

			case 64:
				return new Vector3( -87.314f, -180f, -10.112f);

			case 65:
				return new Vector3( 0f, 0f, -158.312f);

			case 66:
				return new Vector3( 0f, 0f, 5.888f);

			case 67:
				return new Vector3( 0f, 0f, -104.512f);

			case 68:
				return new Vector3( 0f, 0f, -155.112f);

			case 69:
				return new Vector3( -46.429f, 0f, -17.519f);

			case 70:
				return new Vector3( 0f, 0f, 57.0805f);

			case 71:
				return new Vector3( 0f, 0f, 64.281f);

			case 72:
				return new Vector3( 0f, 0f, -14.919f);

			case 73:
				return new Vector3( -87.096f, -180f, 75.281f);

			case 74:
				return new Vector3( 69.193f, 111.118f, -85.059f);

			case 75:
				return new Vector3( 6.063f, 3.703f, -85.059f);

			case 76:
				return new Vector3( 0f, 0f, -130.06f);

			case 77:
				return new Vector3( 0f, 0f, 97.74f);

			case 78:
				return new Vector3( 0f, 0f, -66.26f);

			case 79:
				return new Vector3( 0f, 0f, 35.94f);

			case 80:
				return new Vector3( 0f, 0f, 69.9999f);

			case 81:
				return new Vector3( 0f, 0f, 146.1993f);

			case 82:
				return new Vector3( -86.0052f, 0f, -51.0005f);

			case 83:
				return new Vector3( 0f, -13.103f, 9.607f);

			case 84:
				return new Vector3( 0f, -49.279f, -63.1121f);

			case 85:
				return new Vector3( -83.014f, 0f, -36.5122f);

			case 86:
				return new Vector3( -24.613f, 0f, -4.1123f);

			case 87:
				return new Vector3( 0f, 0f, -52.3123f);

			case 88:
				return new Vector3( 0f, 0f, 25.6875f);

			case 89:
				return new Vector3( 0f, 0f, -11.5121f);

			case 90:
				return new Vector3( -12.0161f, 0f, 100.6874f);

			case 91:
				return new Vector3( -82.841f, 0f, 100.6874f);

			case 92:
				return new Vector3( 0f, 0f, 173.2871f);

			case 93:
				return new Vector3( 0f, 0f, 129.9366f);

			case 94:
				return new Vector3( 0f, -32.4001f, 177.3364f);

			case 95:
				return new Vector3( -21.0109f, -28.2841f, 10.1365f);

			case 96:
				return new Vector3( -4.501f, -41.559f, -147.2637f);

			case 97:
				return new Vector3( 0f, 0f, 21.5362f);

			case 98:
				return new Vector3( 0f, 0f, -86.6639f);

			case 99:
				return new Vector3( -4.905f, 11.395f, 175.536f);
		}

		return new Vector3(0, 0, 0);
	}

	public static string GetFiguresModelHash(int id)
    {
		{
			switch (id)
			{
				case 0:
					return "vw_prop_vw_colle_pogo";

				case 1:
					return "vw_prop_vw_colle_alien";

				case 2:
					return "vw_prop_vw_colle_alien";

				case 3:
					return "vw_prop_vw_colle_alien";

				case 4:
					return "vw_prop_vw_colle_alien";

				case 5:
					return "vw_prop_vw_colle_alien";

				case 6:
					return "vw_prop_vw_colle_alien";

				case 7:
					return "vw_prop_vw_colle_alien";

				case 8:
					return "vw_prop_vw_colle_alien";

				case 9:
					return "vw_prop_vw_colle_imporage";

				case 10:
					return "vw_prop_vw_colle_imporage";

				case 11:
					return "vw_prop_vw_colle_imporage";

				case 12:
					return "vw_prop_vw_colle_imporage";

				case 13:
					return "vw_prop_vw_colle_imporage";

				case 14:
					return "vw_prop_vw_colle_imporage";

				case 15:
					return "vw_prop_vw_colle_imporage";

				case 16:
					return "vw_prop_vw_colle_imporage";

				case 17:
					return "vw_prop_vw_colle_imporage";

				case 18:
					return "vw_prop_vw_colle_imporage";

				case 19:
					return "vw_prop_vw_colle_imporage";

				case 20:
					return "vw_prop_vw_colle_imporage";

				case 21:
					return "vw_prop_vw_colle_imporage";

				case 22:
					return "vw_prop_vw_colle_imporage";

				case 23:
					return "vw_prop_vw_colle_imporage";

				case 24:
					return "vw_prop_vw_colle_imporage";

				case 25:
					return "vw_prop_vw_colle_imporage";

				case 26:
					return "vw_prop_vw_colle_imporage";

				case 27:
					return "vw_prop_vw_colle_prbubble";

				case 28:
					return "vw_prop_vw_colle_prbubble";

				case 29:
					return "vw_prop_vw_colle_prbubble";

				case 30:
					return "vw_prop_vw_colle_prbubble";

				case 31:
					return "vw_prop_vw_colle_prbubble";

				case 32:
					return "vw_prop_vw_colle_prbubble";

				case 33:
					return "vw_prop_vw_colle_prbubble";

				case 34:
					return "vw_prop_vw_colle_prbubble";

				case 35:
					return "vw_prop_vw_colle_prbubble";

				case 36:
					return "vw_prop_vw_colle_prbubble";

				case 37:
					return "vw_prop_vw_colle_prbubble";

				case 38:
					return "vw_prop_vw_colle_prbubble";

				case 39:
					return "vw_prop_vw_colle_prbubble";

				case 40:
					return "vw_prop_vw_colle_prbubble";

				case 41:
					return "vw_prop_vw_colle_prbubble";

				case 42:
					return "vw_prop_vw_colle_prbubble";

				case 43:
					return "vw_prop_vw_colle_prbubble";

				case 44:
					return "vw_prop_vw_colle_prbubble";

				case 45:
					return "vw_prop_vw_colle_pogo";

				case 46:
					return "vw_prop_vw_colle_pogo";

				case 47:
					return "vw_prop_vw_colle_pogo";

				case 48:
					return "vw_prop_vw_colle_pogo";

				case 49:
					return "vw_prop_vw_colle_pogo";

				case 50:
					return "vw_prop_vw_colle_pogo";

				case 51:
					return "vw_prop_vw_colle_pogo";

				case 52:
					return "vw_prop_vw_colle_pogo";

				case 53:
					return "vw_prop_vw_colle_pogo";

				case 54:
					return "vw_prop_vw_colle_pogo";

				case 55:
					return "vw_prop_vw_colle_pogo";

				case 56:
					return "vw_prop_vw_colle_pogo";

				case 57:
					return "vw_prop_vw_colle_pogo";

				case 58:
					return "vw_prop_vw_colle_pogo";

				case 59:
					return "vw_prop_vw_colle_pogo";

				case 60:
					return "vw_prop_vw_colle_pogo";

				case 61:
					return "vw_prop_vw_colle_pogo";

				case 62:
					return "vw_prop_vw_colle_rsrcomm";

				case 63:
					return "vw_prop_vw_colle_rsrcomm";

				case 64:
					return "vw_prop_vw_colle_rsrcomm";

				case 65:
					return "vw_prop_vw_colle_rsrcomm";

				case 66:
					return "vw_prop_vw_colle_rsrcomm";

				case 67:
					return "vw_prop_vw_colle_rsrcomm";

				case 68:
					return "vw_prop_vw_colle_rsrcomm";

				case 69:
					return "vw_prop_vw_colle_rsrcomm";

				case 70:
					return "vw_prop_vw_colle_rsrcomm";

				case 71:
					return "vw_prop_vw_colle_rsrcomm";

				case 72:
					return "vw_prop_vw_colle_rsrcomm";

				case 73:
					return "vw_prop_vw_colle_rsrcomm";

				case 74:
					return "vw_prop_vw_colle_rsrcomm";

				case 75:
					return "vw_prop_vw_colle_rsrcomm";

				case 76:
					return "vw_prop_vw_colle_rsrcomm";

				case 77:
					return "vw_prop_vw_colle_rsrcomm";

				case 78:
					return "vw_prop_vw_colle_rsrcomm";

				case 79:
					return "vw_prop_vw_colle_rsrcomm";

				case 80:
					return "vw_prop_vw_colle_rsrgeneric";

				case 81:
					return "vw_prop_vw_colle_rsrgeneric";

				case 82:
					return "vw_prop_vw_colle_rsrgeneric";

				case 83:
					return "vw_prop_vw_colle_rsrgeneric";

				case 84:
					return "vw_prop_vw_colle_rsrgeneric";

				case 85:
					return "vw_prop_vw_colle_rsrgeneric";

				case 86:
					return "vw_prop_vw_colle_rsrgeneric";

				case 87:
					return "vw_prop_vw_colle_rsrgeneric";

				case 88:
					return "vw_prop_vw_colle_rsrgeneric";

				case 89:
					return "vw_prop_vw_colle_rsrgeneric";

				case 90:
					return "vw_prop_vw_colle_rsrgeneric";

				case 91:
					return "vw_prop_vw_colle_rsrgeneric";

				case 92:
					return "vw_prop_vw_colle_rsrgeneric";

				case 93:
					return "vw_prop_vw_colle_rsrgeneric";

				case 94:
					return "vw_prop_vw_colle_rsrgeneric";

				case 95:
					return "vw_prop_vw_colle_rsrgeneric";

				case 96:
					return "vw_prop_vw_colle_rsrgeneric";

				case 97:
					return "vw_prop_vw_colle_rsrgeneric";

				case 98:
					return "vw_prop_vw_colle_beast";

				case 99:
					return "vw_prop_vw_colle_sasquatch";
			}
		}

		return "vw_prop_vw_colle_sasquatch";
	}

	public static string GetAudioFigures(int id)
    {
		switch (id)
		{
			case 0:
				return "pogo_space_monkey";

			case 1:
				return "alien";

			case 2:
				return "alien";

			case 3:
				return "alien";

			case 4:
				return "alien";

			case 5:
				return "alien";

			case 6:
				return "alien";

			case 7:
				return "alien";

			case 8:
				return "alien";

			case 9:
				return "impotent_rage";

			case 10:
				return "impotent_rage";

			case 11:
				return "impotent_rage";

			case 12:
				return "impotent_rage";

			case 13:
				return "impotent_rage";

			case 14:
				return "impotent_rage";

			case 15:
				return "impotent_rage";

			case 16:
				return "impotent_rage";

			case 17:
				return "impotent_rage";

			case 18:
				return "impotent_rage";

			case 19:
				return "impotent_rage";

			case 20:
				return "impotent_rage";

			case 21:
				return "impotent_rage";

			case 22:
				return "impotent_rage";

			case 23:
				return "impotent_rage";

			case 24:
				return "impotent_rage";

			case 25:
				return "impotent_rage";

			case 26:
				return "impotent_rage";

			case 27:
				return "princess_robot_bubblegum";

			case 28:
				return "princess_robot_bubblegum";

			case 29:
				return "princess_robot_bubblegum";

			case 30:
				return "princess_robot_bubblegum";

			case 31:
				return "princess_robot_bubblegum";

			case 32:
				return "princess_robot_bubblegum";

			case 33:
				return "princess_robot_bubblegum";

			case 34:
				return "princess_robot_bubblegum";

			case 35:
				return "princess_robot_bubblegum";

			case 36:
				return "princess_robot_bubblegum";

			case 37:
				return "princess_robot_bubblegum";

			case 38:
				return "princess_robot_bubblegum";

			case 39:
				return "princess_robot_bubblegum";

			case 40:
				return "princess_robot_bubblegum";

			case 41:
				return "princess_robot_bubblegum";

			case 42:
				return "princess_robot_bubblegum";

			case 43:
				return "princess_robot_bubblegum";

			case 44:
				return "princess_robot_bubblegum";

			case 45:
				return "pogo_space_monkey";

			case 46:
				return "pogo_space_monkey";

			case 47:
				return "pogo_space_monkey";

			case 48:
				return "pogo_space_monkey";

			case 49:
				return "pogo_space_monkey";

			case 50:
				return "pogo_space_monkey";

			case 51:
				return "pogo_space_monkey";

			case 52:
				return "pogo_space_monkey";

			case 53:
				return "pogo_space_monkey";

			case 54:
				return "pogo_space_monkey";

			case 55:
				return "pogo_space_monkey";

			case 56:
				return "pogo_space_monkey";

			case 57:
				return "pogo_space_monkey";

			case 58:
				return "pogo_space_monkey";

			case 59:
				return "pogo_space_monkey";

			case 60:
				return "pogo_space_monkey";

			case 61:
				return "pogo_space_monkey";

			case 62:
				return "space_ranger_commander";

			case 63:
				return "space_ranger_commander";

			case 64:
				return "space_ranger_commander";

			case 65:
				return "space_ranger_commander";

			case 66:
				return "space_ranger_commander";

			case 67:
				return "space_ranger_commander";

			case 68:
				return "space_ranger_commander";

			case 69:
				return "space_ranger_commander";

			case 70:
				return "space_ranger_commander";

			case 71:
				return "space_ranger_commander";

			case 72:
				return "space_ranger_commander";

			case 73:
				return "space_ranger_commander";

			case 74:
				return "space_ranger_commander";

			case 75:
				return "space_ranger_commander";

			case 76:
				return "space_ranger_commander";

			case 77:
				return "space_ranger_commander";

			case 78:
				return "space_ranger_commander";

			case 79:
				return "space_ranger_commander";

			case 80:
				return "republican_space_ranger";

			case 81:
				return "republican_space_ranger";

			case 82:
				return "republican_space_ranger";

			case 83:
				return "republican_space_ranger";

			case 84:
				return "republican_space_ranger";

			case 85:
				return "republican_space_ranger";

			case 86:
				return "republican_space_ranger";

			case 87:
				return "republican_space_ranger";

			case 88:
				return "republican_space_ranger";

			case 89:
				return "republican_space_ranger";

			case 90:
				return "republican_space_ranger";

			case 91:
				return "republican_space_ranger";

			case 92:
				return "republican_space_ranger";

			case 93:
				return "republican_space_ranger";

			case 94:
				return "republican_space_ranger";

			case 95:
				return "republican_space_ranger";

			case 96:
				return "republican_space_ranger";

			case 97:
				return "republican_space_ranger";

			case 98:
				return "beast";

			case 99:
				return "sasquatch";
		}
		return "sasquatch";
	}

	public static Vector3 GetLDPosition(int id)
    {
		id -= 156;
		switch (id)
		{
			case 0:
				return new Vector3( -1002.254f, 130.075f, 55.519f);

			case 1:
				return new Vector3( -1504.595f, -36.351f, 54.707f);

			case 2:
				return new Vector3( -1677.4098f, -443.6646f, 39.8968f);

			case 3:
				return new Vector3( -842.328f, -345.95f, 38.501f);

			case 4:
				return new Vector3( -430.64f, 288.196f, 86.174f);

			case 5:
				return new Vector3( 1575.0677f, -1732.0293f, 87.9448f);

			case 6:
				return new Vector3( -2038.497f, 539.83f, 109.752f);

			case 7:
				return new Vector3( -2973.7725f, 20.3182f, 7.4278f);

			case 8:
				return new Vector3( -3235.982f, 1104.414f, 2.602f);

			case 9:
				return new Vector3( -2630.007f, 1874.927f, 160.251f);

			case 10:
				return new Vector3( -1875.84f, 2027.968f, 139.838f);

			case 11:
				return new Vector3( -1596.847f, 3054.303f, 33.12f);

			case 12:
				return new Vector3( 1740.868f, 3327.709f, 41.211f);

			case 13:
				return new Vector3( 1323.174f, 3008.294f, 44.09f);

			case 14:
				return new Vector3( 1766.628f, 3916.891f, 34.821f);

			case 15:
				return new Vector3( 2704.12f, 3521.006f, 61.773f);

			case 16:
				return new Vector3( 3608.93f, 3625.699f, 40.827f);

			case 17:
				return new Vector3( 2141.796f, 4790.2764f, 40.7243f);

			case 18:
				return new Vector3( 439.911f, 6455.761f, 36.068f);

			case 19:
				return new Vector3( 1444.224f, 6331.349f, 23.806f);

			case 20:
				return new Vector3( -581.923f, 5368.024f, 70.294f);

			case 21:
				return new Vector3( 497.611f, 5606.312f, 795.85f);

			case 22:
				return new Vector3( 1384.78f, 4288.897f, 36.391f);

			case 23:
				return new Vector3( 712.585f, 4111.207f, 31.65f);

			case 24:
				return new Vector3( 325.916f, 4429.151f, 64.688f);

			case 25:
				return new Vector3( -214.4409f, 3601.9602f, 61.6145f);

			case 26:
				return new Vector3( 66.001f, 3760.242f, 39.943f);

			case 27:
				return new Vector3( 98.651f, 3601.149f, 39.752f);

			case 28:
				return new Vector3( -1147.7292f, 4949.988f, 221.278f);

			case 29:
				return new Vector3( -2511.306f, 3613.96f, 13.469f);

			case 30:
				return new Vector3( -1936.931f, 3329.973f, 33.215f);

			case 31:
				return new Vector3( 2497.9932f, -429.74f, 93.2676f);

			case 32:
				return new Vector3( 3818.776f, 4488.587f, 4.532f);

			case 33:
				return new Vector3( 96.5449f, -255.7652f, 47.0503f);

			case 34:
				return new Vector3( -1393.931f, -1445.899f, 4.308f);

			case 35:
				return new Vector3( -929.642f, -746.513f, 19.752f);

			case 36:
				return new Vector3( 154.263f, 1098.689f, 231.338f);

			case 37:
				return new Vector3( 2982.726f, 6368.5f, 2.311f);

			case 38:
				return new Vector3( -512.5049f, -1626.8174f, 17.4995f);

			case 39:
				return new Vector3( -56.232f, 80.423f, 71.868f);

			case 40:
				return new Vector3( 431.973f, -2910.015f, 6.734f);

			case 41:
				return new Vector3( 664.98f, 1284.7817f, 360.1198f);

			case 42:
				return new Vector3( -452.9f, 1079.414f, 327.803f);

			case 43:
				return new Vector3( -196.239f, -2354.753f, 9.478f);

			case 44:
				return new Vector3( 248.439f, 128.028f, 103.099f);

			case 45:
				return new Vector3( 2661.16f, 1640.974f, 24.654f);

			case 46:
				return new Vector3( 1668.438f, -26.473f, 184.91f);

			case 47:
				return new Vector3( -37.931f, 1937.999f, 189.8f);

			case 48:
				return new Vector3( -1591.535f, 801.656f, 186.161f);

			case 49:
				return new Vector3( 2193.213f, 5593.691f, 53.684f);

			case 50:
				return new Vector3( 1641.563f, 2656.195f, 54.855f);

			case 51:
				return new Vector3( -1608.398f, 5262.396f, 3.966f);

			case 52:
				return new Vector3( -937.037f, -1044.216f, 0.436f);

			case 53:
				return new Vector3( -2200.313f, 4237.116f, 48.046f);

			case 54:
				return new Vector3( -1263.3214f, -367.5901f, 44.5355f);

			case 55:
				return new Vector3( 1018.407f, 2457.103f, 44.758f);

			case 56:
				return new Vector3( -3091.239f, 660.393f, 1.701f);

			case 57:
				return new Vector3( -193.708f, 793.051f, 197.758f);

			case 58:
				return new Vector3( 987.808f, -105.7523f, 74.1212f);

			case 59:
				return new Vector3( -927.8402f, -2934.0337f, 14.1399f);

			case 60:
				return new Vector3( -1640.2965f, -3165.1382f, 40.8515f);

			case 61:
				return new Vector3( -1011.2722f, -1491.9674f, 4.7604f);

			case 62:
				return new Vector3( 343.7568f, 946.6004f, 204.4755f);

			case 63:
				return new Vector3( 750.829f, 196.948f, 85.651f);

			case 64:
				return new Vector3( -331.626f, 6285.987f, 34.8f);

			case 65:
				return new Vector3( -311.981f, -1626.432f, 31.473f);

			case 66:
				return new Vector3( 819.625f, -796.649f, 35.338f);

			case 67:
				return new Vector3( 132.977f, -576.783f, 18.278f);

			case 68:
				return new Vector3( -1442.642f, 567.622f, 121.601f);

			case 69:
				return new Vector3( -363.567f, 572.64f, 127.044f);

			case 70:
				return new Vector3( -763.812f, 705.641f, 144.732f);

			case 71:
				return new Vector3( 1902.373f, 572.778f, 176.627f);

			case 72:
				return new Vector3( -672.715f, 59.853f, 61.902f);

			case 73:
				return new Vector3( 43.7134f, 2791.5322f, 57.6598f);

			case 74:
				return new Vector3( 1220.9852f, 1902.9747f, 78.0406f);

			case 75:
				return new Vector3( 2517.942f, 2615.929f, 38.086f);

			case 76:
				return new Vector3( 3455.177f, 5510.634f, 18.769f);

			case 77:
				return new Vector3( 1500.862f, -2513.839f, 56.26f);

			case 78:
				return new Vector3( 1467.102f, 1096.74f, 113.988f);

			case 79:
				return new Vector3( 545.206f, 2880.917f, 42.441f);

			case 80:
				return new Vector3( 2612.129f, 2782.483f, 34.102f);

			case 81:
				return new Vector3( -14.178f, 6491.451f, 37.251f);

			case 82:
				return new Vector3( -788.846f, -2086.048f, 9.164f);

			case 83:
				return new Vector3( 981.079f, -2583.384f, 10.37f);

			case 84:
				return new Vector3( 964.371f, -1811.011f, 31.146f);

			case 85:
				return new Vector3( 511.737f, -1335.028f, 29.488f);

			case 86:
				return new Vector3( -69.0361f, -1229.7703f, 29.3137f);

			case 87:
				return new Vector3( 202.812f, -1758.72f, 33.229f);

			case 88:
				return new Vector3( -328.378f, -1372.415f, 41.193f);

			case 89:
				return new Vector3( -1635.991f, -1031.127f, 13.024f);

			case 90:
				return new Vector3( 955.454f, 73.628f, 112.592f);

			case 91:
				return new Vector3( 265.722f, -1335.354f, 36.17f);

			case 92:
				return new Vector3( -1033.097f, -825.029f, 19.049f);

			case 93:
				return new Vector3( -592.9804f, -875.5658f, 25.5693f);

			case 94:
				return new Vector3( -246.484f, -786.507f, 30.531f);

			case 95:
				return new Vector3( 479.364f, -574.451f, 28.5f);

			case 96:
				return new Vector3( 1098.204f, -1528.952f, 34.475f);

			case 97:
				return new Vector3( 580.785f, -2284.23f, 6.491f);

			case 98:
				return new Vector3( -295.973f, -308.098f, 9.511f);

			case 99:
				return new Vector3( -117.05f, -1025.36f, 27.318f);
		}

		return new Vector3(0, 0, 0);
    }

	public static Vector3 GetLDRotation(int id)
	{
		id -= 156;
		switch (id)
		{
			case 0:
				return new Vector3( 0f, 0f, 118.689f);

			case 1:
				return new Vector3( 0f, 0f, 128.289f);

			case 2:
				return new Vector3( 0f, 0f, 51.489f);

			case 3:
				return new Vector3( 0f, 0f, 121.288f);

			case 4:
				return new Vector3( 0f, 0f, -91.912f);

			case 5:
				return new Vector3( 0f, 0f, -139.6008f);

			case 6:
				return new Vector3( 0f, 0f, -168.268f);

			case 7:
				return new Vector3( 0f, 0f, -25.916f);

			case 8:
				return new Vector3( 0f, 0f, 168.084f);

			case 9:
				return new Vector3( 0f, 0f, -45.916f);

			case 10:
				return new Vector3( 0f, 0f, -5.316f);

			case 11:
				return new Vector3( 0f, 0f, -2.716f);

			case 12:
				return new Vector3( 0f, 0f, 109.948f);

			case 13:
				return new Vector3( 0.34f, 13.679f, -4.852f);

			case 14:
				return new Vector3( 0f, 0f, 91.203f);

			case 15:
				return new Vector3( 0f, 0f, -20.597f);

			case 16:
				return new Vector3( 0f, 0f, -97.686f);

			case 17:
				return new Vector3( 0f, 0f, -156.086f);

			case 18:
				return new Vector3( 0f, 0f, 108.313f);

			case 19:
				return new Vector3( 0f, 0f, 85.513f);

			case 20:
				return new Vector3( 0f, 0f, 63.112f);

			case 21:
				return new Vector3( 0f, 0f, -0.262f);

			case 22:
				return new Vector3( 0f, 0f, -130.635f);

			case 23:
				return new Vector3( 31.889f, 1.775f, -84.606f);

			case 24:
				return new Vector3( 19.8f, 9.578f, 174.089f);

			case 25:
				return new Vector3( -0.1f, -6.076f, 102.888f);

			case 26:
				return new Vector3( 0f, 0f, 100.489f);

			case 27:
				return new Vector3( 66.227f, -0.052f, -74.131f);

			case 28:
				return new Vector3( 0f, 0f, -21.066f);

			case 29:
				return new Vector3( 0f, 0f, -12.313f);

			case 30:
				return new Vector3( 0f, 0f, 147.134f);

			case 31:
				return new Vector3( 0f, 0f, 0.5f);

			case 32:
				return new Vector3( 80.296f, 143.616f, -17.341f);

			case 33:
				return new Vector3( 0f, 0f, 66.056f);

			case 34:
				return new Vector3( 0f, 0f, 153.256f);

			case 35:
				return new Vector3( 0f, 0f, -92.4f);

			case 36:
				return new Vector3( 0f, 0f, -143.6f);

			case 37:
				return new Vector3( 6.003f, -21.346f, -101.837f);

			case 38:
				return new Vector3( 0f, 0f, -121f);

			case 39:
				return new Vector3( 0f, 0f, 69.4f);

			case 40:
				return new Vector3( 0f, 0f, 3.199f);

			case 41:
				return new Vector3( 0f, 0f, -95.4021f);

			case 42:
				return new Vector3( 61.558f, 15.504f, -115.875f);

			case 43:
				return new Vector3( 0f, 0f, 173.853f);

			case 44:
				return new Vector3( 0f, 0f, -11.712f);

			case 45:
				return new Vector3( 0f, 0f, -93.512f);

			case 46:
				return new Vector3( 0f, 0f, -165.712f);

			case 47:
				return new Vector3( 0f, 0f, 113.088f);

			case 48:
				return new Vector3( 0f, 0f, 117.888f);

			case 49:
				return new Vector3( 0f, 0f, -104.712f);

			case 50:
				return new Vector3( 0f, 0f, -125.712f);

			case 51:
				return new Vector3( -0.2f, 12.536f, -152.113f);

			case 52:
				return new Vector3( 0f, 0f, -77.113f);

			case 53:
				return new Vector3( 5.727f, 57.028f, -48.801f);

			case 54:
				return new Vector3( 0f, 0f, -154.5439f);

			case 55:
				return new Vector3( 0f, 0f, -96.8f);

			case 56:
				return new Vector3( 0f, 0f, -133.944f);

			case 57:
				return new Vector3( 0f, 0f, -32.544f);

			case 58:
				return new Vector3( 0f, 0f, -45.401f);

			case 59:
				return new Vector3( 0f, 0f, -121.8012f);

			case 60:
				return new Vector3( 0f, 0f, 117.0097f);

			case 61:
				return new Vector3( 0f, 0f, 43.4099f);

			case 62:
				return new Vector3( 0f, 0f, -42.991f);

			case 63:
				return new Vector3( 0f, 0f, 84.009f);

			case 64:
				return new Vector3( 0f, 0f, 47.809f);

			case 65:
				return new Vector3( 0f, 0f, -34.592f);

			case 66:
				return new Vector3( 0f, 0f, -5.473f);

			case 67:
				return new Vector3( 0f, 0f, -113.074f);

			case 68:
				return new Vector3( 0f, 0f, 174.126f);

			case 69:
				return new Vector3( 0f, 0f, -35.675f);

			case 70:
				return new Vector3( 0f, 0f, -38.675f);

			case 71:
				return new Vector3( 0f, 0f, 160.125f);

			case 72:
				return new Vector3( 0f, 0f, 115.925f);

			case 73:
				return new Vector3( 0f, 0f, -128.4001f);

			case 74:
				return new Vector3( 0.836f, -23.44f, -157.9993f);

			case 75:
				return new Vector3( 0f, 0f, -179.801f);

			case 76:
				return new Vector3( 2.893f, -125.112f, -167.148f);

			case 77:
				return new Vector3( 0f, 0f, 98.652f);

			case 78:
				return new Vector3( 0f, 0f, 89.252f);

			case 79:
				return new Vector3( 0f, 0f, -111.001f);

			case 80:
				return new Vector3( 0f, -60.369f, -103.746f);

			case 81:
				return new Vector3( 0f, 0f, -47.113f);

			case 82:
				return new Vector3( 0f, 0f, -85f);

			case 83:
				return new Vector3( 0f, 0f, -85f);

			case 84:
				return new Vector3( 0f, 0f, -85f);

			case 85:
				return new Vector3( 0f, 0f, 42.399f);

			case 86:
				return new Vector3( 0f, 0f, -40.6012f);

			case 87:
				return new Vector3( 0f, 0f, -37.001f);

			case 88:
				return new Vector3( 0f, 0f, -93.401f);

			case 89:
				return new Vector3( 0f, 0f, -41.802f);

			case 90:
				return new Vector3( 0f, 0f, -29.802f);

			case 91:
				return new Vector3( 0f, 0f, 44.8f);

			case 92:
				return new Vector3( 0f, 0f, 126.399f);

			case 93:
				return new Vector3( 0f, 0f, 176.7996f);

			case 94:
				return new Vector3( 0f, 0f, 157.6f);

			case 95:
				return new Vector3( 0f, 0f, -4.401f);

			case 96:
				return new Vector3( 0f, 0f, 88.999f);

			case 97:
				return new Vector3( 0f, 0f, 86.199f);

			case 98:
				return new Vector3( 0f, 0f, 179.43f);

			case 99:
				return new Vector3( 0f, 0f, 81.43f);
		}

		return new Vector3(0, 0, 0);
	}

	public static Vector3 GetPlayingCardsPosition(int id)
    {
		id -= 308;
		switch (id)
		{
			case 0:
				return new Vector3( 1992.183f, 3046.28f, 47.125f);

			case 1:
				return new Vector3( 120.38f, -1297.669f, 28.705f);

			case 2:
				return new Vector3( 79.293f, 3704.578f, 40.945f);

			case 3:
				return new Vector3( 2937.738f, 5325.846f, 100.176f);

			case 4:
				return new Vector3( 727.153f, 4189.818f, 40.476f);

			case 5:
				return new Vector3( -103.14f, 369.008f, 112.267f);

			case 6:
				return new Vector3( 99.959f, 6619.539f, 32.314f);

			case 7:
				return new Vector3( -282.6689f, 6226.274f, 31.3554f);

			case 8:
				return new Vector3( 1707.556f, 4921.021f, 41.865f);

			case 9:
				return new Vector3( -1581.8604f, 5204.295f, 3.9093f);

			case 10:
				return new Vector3( 10.8264f, -1101.1573f, 29.613f);

			case 11:
				return new Vector3( 1690.0428f, 3589.0144f, 35.5883f);

			case 12:
				return new Vector3( 1159.1442f, -316.5876f, 69.5134f);

			case 13:
				return new Vector3( 2341.8074f, 2571.737f, 47.6079f);

			case 14:
				return new Vector3( -3048.193f, 585.2986f, 7.7708f);

			case 15:
				return new Vector3( -3149.7073f, 1115.8302f, 20.7216f);

			case 16:
				return new Vector3( -1840.641f, -1235.3188f, 13.2937f);

			case 17:
				return new Vector3( 810.6056f, -2978.7407f, 5.8116f);

			case 18:
				return new Vector3( 202.2747f, -1645.2251f, 29.7679f);

			case 19:
				return new Vector3( 253.2056f, 215.9778f, 106.2848f);

			case 20:
				return new Vector3( -1166.183f, -233.9277f, 38.262f);

			case 21:
				return new Vector3( 729.9886f, 2514.7131f, 73.1663f);

			case 22:
				return new Vector3( 188.1851f, 3076.3318f, 43.0447f);

			case 23:
				return new Vector3( 3687.9143f, 4569.0728f, 24.9397f);

			case 24:
				return new Vector3( 1876.9755f, 6410.034f, 46.5982f);

			case 25:
				return new Vector3( 2121.1458f, 4784.6865f, 40.8114f);

			case 26:
				return new Vector3( 900.0845f, 3558.1562f, 33.6258f);

			case 27:
				return new Vector3( 2695.2722f, 4324.496f, 45.6516f);

			case 28:
				return new Vector3( -1829.4277f, 798.4049f, 138.0583f);

			case 29:
				return new Vector3( -1203.7251f, -1558.8663f, 4.1736f);

			case 30:
				return new Vector3( -73.2829f, -2005.4764f, 18.2561f);

			case 31:
				return new Vector3( -1154.2014f, -527.2959f, 31.7117f);

			case 32:
				return new Vector3( 990.0786f, -1800.3907f, 31.3781f);

			case 33:
				return new Vector3( 827.5513f, -2158.7441f, 29.417f);

			case 34:
				return new Vector3( -1512.0801f, -103.625f, 54.2027f);

			case 35:
				return new Vector3( -970.7493f, 104.3396f, 55.0431f);

			case 36:
				return new Vector3( -428.6815f, 1213.9049f, 325.9329f);

			case 37:
				return new Vector3( -167.8387f, -297.1122f, 39.0353f);

			case 38:
				return new Vector3( 2747.3215f, 3465.1196f, 55.6336f);

			case 39:
				return new Vector3( -1103.659f, 2714.6895f, 19.4539f);

			case 40:
				return new Vector3( 549.4841f, -189.3053f, 54.4369f);

			case 41:
				return new Vector3( -1287.6895f, -1118.8177f, 6.3057f);

			case 42:
				return new Vector3( 1131.428f, -982.0297f, 46.6521f);

			case 43:
				return new Vector3( -1028.0834f, -2746.9358f, 13.3589f);

			case 44:
				return new Vector3( -538.5779f, -1278.5424f, 26.3437f);

			case 45:
				return new Vector3( 1326.4489f, -1651.2626f, 52.0964f);

			case 46:
				return new Vector3( 183.3252f, -685.2661f, 42.607f);

			case 47:
				return new Vector3( 1487.8461f, 1129.2f, 114.3005f);

			case 48:
				return new Vector3( -2305.538f, 3387.973f, 31.0201f);

			case 49:
				return new Vector3( -522.632f, 4193.4595f, 193.7517f);

			case 50:
				return new Vector3( -748.9897f, 5599.5337f, 41.5794f);

			case 51:
				return new Vector3( -288.0628f, 2545.2104f, 74.4223f);

			case 52:
				return new Vector3( 2565.3264f, 296.8703f, 108.7367f);

			case 53:
				return new Vector3( -408.2484f, 585.783f, 124.378f);
		}
		
		return new Vector3(0, 0, 0);
    }

	public static Vector3 GetPlayingCardsRotation(int id)
    {
		id -= 308;
		switch (id)
		{
			case 0:
				return new Vector3(-0.006f, -180f, 100.4f);

			case 1:
				return new Vector3( 3.126f, -178.1f, -179.601f);

			case 2:
				return new Vector3( 0.009f, -180f, -69.801f);

			case 3:
				return new Vector3( -9.741f, 175.023f, 142.599f);

			case 4:
				return new Vector3( -0.027f, -180f, -37.401f);

			case 5:
				return new Vector3( -1.417f, -180f, -130.401f);

			case 6:
				return new Vector3( -0.998f, -180f, 70.799f);

			case 7:
				return new Vector3( 13.349f, -168.8419f, -84.001f);

			case 8:
				return new Vector3( -0.052f, -180f, 138.799f);

			case 9:
				return new Vector3( -7.7598f, -180f, 162.4f);

			case 10:
				return new Vector3( 0.0059f, -180f, -47.4005f);

			case 11:
				return new Vector3( -0.0859f, 180f, 95.4942f);

			case 12:
				return new Vector3( 0.0341f, -180f, -50.906f);

			case 13:
				return new Vector3( -0.037f, 180f, 162.894f);

			case 14:
				return new Vector3( -1.22f, 180f, -26.1063f);

			case 15:
				return new Vector3( 0.002f, -180f, 48.2936f);

			case 16:
				return new Vector3( 0.0041f, -180f, 161.0936f);

			case 17:
				return new Vector3( 0.0001f, -180f, -57.9067f);

			case 18:
				return new Vector3( -0.0162f, -180f, 75.8932f);

			case 19:
				return new Vector3( -0.0391f, -180f, -179.7069f);

			case 20:
				return new Vector3( -0.4621f, -179.5f, 0.2931f);

			case 21:
				return new Vector3( 0.143f, -180f, 159.0931f);

			case 22:
				return new Vector3( 0.023f, -180f, 34.2931f);

			case 23:
				return new Vector3( 0.0191f, -180f, -145.7069f);

			case 24:
				return new Vector3( 2.6831f, 180f, 49.8931f);

			case 25:
				return new Vector3( -0.043f, -180f, -31.7122f);

			case 26:
				return new Vector3( -0.0429f, -180f, 141.0878f);

			case 27:
				return new Vector3( -0.005f, 180f, -114.5125f);

			case 28:
				return new Vector3( 0.0058f, -180f, 65.4875f);

			case 29:
				return new Vector3( -0.018f, 180f, -171.7125f);

			case 30:
				return new Vector3( -0.1319f, -180f, -56.7126f);

			case 31:
				return new Vector3( 0f, 180f, 123.287f);

			case 32:
				return new Vector3( 0.1201f, -180f, -59.7126f);

			case 33:
				return new Vector3( -1.162f, 178.092f, 120.2871f);

			case 34:
				return new Vector3( 0.0341f, -180f, -59.7129f);

			case 35:
				return new Vector3( 0.6049f, 178.9569f, 120.2871f);

			case 36:
				return new Vector3( 0.0039f, -180f, -124.7131f);

			case 37:
				return new Vector3( 0.0111f, -180f, 4.0871f);

			case 38:
				return new Vector3( -0.005f, -180f, 108.487f);

			case 39:
				return new Vector3( -0.399f, -180f, -71.513f);

			case 40:
				return new Vector3( -0.0099f, -180f, 59.8867f);

			case 41:
				return new Vector3( -0.0111f, -180f, -20.9135f);

			case 42:
				return new Vector3( -0.0311f, -180f, 124.8865f);

			case 43:
				return new Vector3( 9.4101f, -173.8169f, -160.7137f);

			case 44:
				return new Vector3( 0.0172f, -180f, -86.3137f);

			case 45:
				return new Vector3( 0.9489f, 180f, 66.4862f);

			case 46:
				return new Vector3( -0.0279f, -180f, 128.0861f);

			case 47:
				return new Vector3( -0.5761f, -180f, -17.7141f);

			case 48:
				return new Vector3( -0.002f, -180f, 81.0857f);

			case 49:
				return new Vector3( 11.8481f, 180f, -129.5143f);

			case 50:
				return new Vector3( 0.0319f, -180f, 50.4857f);

			case 51:
				return new Vector3( 0.014f, 180f, -129.5143f);

			case 52:
				return new Vector3( -0.013f, 180f, 33.6856f);

			case 53:
				return new Vector3( -0.0399f, -180f, -81.3145f);
		}

		return new Vector3(0, 0, 0);
	}

	public static Vector3 GetJammerPosition(int id)
    {
		id -= 257;
		switch (id)
		{
			case 0:
				return new Vector3(1006.372f, -2881.68f, 30.422f);

			case 1:
				return new Vector3( -980.242f, -2637.703f, 88.528f);

			case 2:
				return new Vector3( -688.195f, -1399.329f, 23.331f);

			case 3:
				return new Vector3( 1120.696f, -1539.165f, 54.871f);

			case 4:
				return new Vector3( 2455.134f, -382.585f, 112.635f);

			case 5:
				return new Vector3( 793.878f, -717.299f, 48.083f);

			case 6:
				return new Vector3( -168.3f, -590.153f, 210.936f);

			case 7:
				return new Vector3( -1298.3429f, -435.8369f, 108.129f);

			case 8:
				return new Vector3( -2276.4841f, 335.0941f, 195.723f);

			case 9:
				return new Vector3( -667.25f, 228.545f, 154.051f);

			case 10:
				return new Vector3( 682.561f, 567.5302f, 153.895f);

			case 11:
				return new Vector3( 2722.561f, 1538.1031f, 85.202f);

			case 12:
				return new Vector3( 758.539f, 1273.6871f, 445.181f);

			case 13:
				return new Vector3( -3079.2578f, 768.5189f, 31.569f);

			case 14:
				return new Vector3( -2359.338f, 3246.831f, 104.188f);

			case 15:
				return new Vector3( 1693.7318f, 2656.602f, 60.84f);

			case 16:
				return new Vector3( 3555.018f, 3684.98f, 61.27f);

			case 17:
				return new Vector3( 1869.0221f, 3714.4348f, 117.068f);

			case 18:
				return new Vector3( 2902.552f, 4324.699f, 101.106f);

			case 19:
				return new Vector3( -508.6141f, 4426.661f, 87.511f);

			case 20:
				return new Vector3( -104.417f, 6227.2783f, 63.696f);

			case 21:
				return new Vector3( 1607.5012f, 6437.3154f, 32.162f);

			case 22:
				return new Vector3( 2792.933f, 5993.922f, 366.867f);

			case 23:
				return new Vector3( 1720.6129f, 4822.467f, 59.7f);

			case 24:
				return new Vector3( -1661.0101f, -1126.742f, 29.773f);

			case 25:
				return new Vector3( -1873.49f, 2058.357f, 154.407f);

			case 26:
				return new Vector3( 2122.4602f, 1750.886f, 138.114f);

			case 27:
				return new Vector3( -417.424f, 1153.1431f, 339.128f);

			case 28:
				return new Vector3( 3303.9011f, 5169.7925f, 28.735f);

			case 29:
				return new Vector3( -1005.8481f, 4852.1475f, 302.025f);

			case 30:
				return new Vector3( -306.627f, 2824.859f, 69.512f);

			case 31:
				return new Vector3( 1660.6631f, -28.07f, 179.137f);

			case 32:
				return new Vector3( 754.647f, 2584.067f, 133.904f);

			case 33:
				return new Vector3( -279.9081f, -1915.608f, 54.173f);

			case 34:
				return new Vector3( -260.4421f, -2411.8071f, 126.019f);

			case 35:
				return new Vector3( 552.132f, -2221.8528f, 73f);

			case 36:
				return new Vector3( 394.3919f, -1402.144f, 76.267f);

			case 37:
				return new Vector3( 1609.7911f, -2243.767f, 130.187f);

			case 38:
				return new Vector3( 234.2919f, 220.771f, 168.981f);

			case 39:
				return new Vector3( -1237.1211f, -850.4969f, 82.98f);

			case 40:
				return new Vector3( -1272.7319f, 317.9532f, 90.352f);

			case 41:
				return new Vector3( 0.088f, -1002.4039f, 96.32f);

			case 42:
				return new Vector3( 470.5569f, -105.049f, 135.908f);

			case 43:
				return new Vector3( -548.5471f, -197.9911f, 82.813f);

			case 44:
				return new Vector3( 2581.0469f, 461.9421f, 115.095f);

			case 45:
				return new Vector3( 720.14f, 4097.634f, 38.075f);

			case 46:
				return new Vector3( 1242.4711f, 1876.0681f, 92.242f);

			case 47:
				return new Vector3( 2752.1128f, 3472.779f, 67.911f);

			case 48:
				return new Vector3( -2191.856f, 4292.4077f, 55.013f);

			case 49:
				return new Vector3( 450.475f, 5581.514f, 794.0683f);
		}

		return new Vector3(0, 0, 0);
    }

	public static Vector3 GetJammerRotation(int id)
    {
		id -= 257;
		switch (id)
		{
			case 0:
				return new Vector3(0f, 0f, 0f);

			case 1:
				return new Vector3( 0f, 0f, 0.6f);

			case 2:
				return new Vector3( 0f, 0f, -85.6f);

			case 3:
				return new Vector3( 0f, 0f, 1.599f);

			case 4:
				return new Vector3( 0f, 0f, 0.799f);

			case 5:
				return new Vector3( 0f, 0f, -45.6f);

			case 6:
				return new Vector3( 0f, 0f, -17.6f);

			case 7:
				return new Vector3( 0f, 0f, 34.8f);

			case 8:
				return new Vector3( 0f, 0f, 119.399f);

			case 9:
				return new Vector3( 0f, 0f, 0.199f);

			case 10:
				return new Vector3( 0f, 0f, 69.999f);

			case 11:
				return new Vector3( 0f, 0f, 86.599f);

			case 12:
				return new Vector3( 0f, 0f, 106.999f);

			case 13:
				return new Vector3( 0f, 0f, -51.202f);

			case 14:
				return new Vector3( 0f, 0f, 60.998f);

			case 15:
				return new Vector3( 0f, 0f, 179.997f);

			case 16:
				return new Vector3( 0f, 0f, 1.597f);

			case 17:
				return new Vector3( 0f, 0f, -60.803f);

			case 18:
				return new Vector3( 0f, 0f, -63.004f);

			case 19:
				return new Vector3( 0f, 0f, -172.204f);

			case 20:
				return new Vector3( 0f, 0f, 33.196f);

			case 21:
				return new Vector3( 0f, 0f, 25.796f);

			case 22:
				return new Vector3( 0f, 0f, 99.396f);

			case 23:
				return new Vector3( 0f, 0f, 178.396f);

			case 24:
				return new Vector3( 0f, 0f, 178.396f);

			case 25:
				return new Vector3( 0f, 0f, -110.204f);

			case 26:
				return new Vector3( 0f, 0f, -3.005f);

			case 27:
				return new Vector3( 0f, 0f, 63.595f);

			case 28:
				return new Vector3( 0f, 0f, 51.999f);

			case 29:
				return new Vector3( 0f, 1.562f, -20.0009f);

			case 30:
				return new Vector3( 0f, 0f, -125.001f);

			case 31:
				return new Vector3( 0f, 0f, 14.399f);

			case 32:
				return new Vector3( 0f, 0f, -83.002f);

			case 33:
				return new Vector3( 0f, 0f, -130.202f);

			case 34:
				return new Vector3( 0f, 0f, -125.202f);

			case 35:
				return new Vector3( 0f, 0f, 86.598f);

			case 36:
				return new Vector3( 0f, 0f, -130.603f);

			case 37:
				return new Vector3( 0f, 0f, 2.797f);

			case 38:
				return new Vector3( 0f, 0f, -19.6f);

			case 39:
				return new Vector3( 0f, 0f, 123.4f);

			case 40:
				return new Vector3( 0f, 0f, 61.4f);

			case 41:
				return new Vector3( 0f, 0f, 68.999f);

			case 42:
				return new Vector3( 0f, 0f, 162.599f);

			case 43:
				return new Vector3( 0f, 0f, 119.399f);

			case 44:
				return new Vector3( 0f, 0f, 92.399f);

			case 45:
				return new Vector3( 0f, 68.2f, 179.398f);

			case 46:
				return new Vector3( 0f, 0f, 39.2f);

			case 47:
				return new Vector3( 0f, 0f, 155.5f);

			case 48:
				return new Vector3( 0f, 0f, -31.9998f);

			case 49:
				return new Vector3( 0f, 0f, -89.8f);
		}
		
		return new Vector3(0, 0, 0);
    }

	public static Vector3 GetLanternsPosition(int id)
    {
		id -= 363;
		switch (id)
        {
			case 0:
				return new Vector3( -190.373f, -765.0157f, 29.454f);

			case 1:
				return new Vector3( -232.1815f, -911.6266f, 31.3158f);

			case 2:
				return new Vector3( -551.4236f, -814.6341f, 29.6932f);

			case 3:
				return new Vector3( -730.1602f, -677.7001f, 29.3139f);

			case 4:
				return new Vector3( -1185.5961f, -563.8707f, 26.6809f);

			case 5:
				return new Vector3( -1340.4968f, -408.3962f, 35.3778f);

			case 6:
				return new Vector3( -1535.169f, -425.2085f, 34.597f);

			case 7:
				return new Vector3( -1581.3322f, -950.7216f, 12.0174f);

			case 8:
				return new Vector3( -1977.267f, -533.3744f, 10.7572f);

			case 9:
				return new Vector3( -1884.625f, -366.126f, 48.354f);

			case 10:
				return new Vector3( -1291.3967f, -1116.7255f, 5.637f);

			case 11:
				return new Vector3( -1500.9254f, -935.9632f, 9.1713f);

			case 12:
				return new Vector3( -1336.2579f, -1280.9673f, 3.836f);

			case 13:
				return new Vector3( -1185.0396f, -1560.546f, 3.3615f);

			case 14:
				return new Vector3( -968.8726f, -1094.0089f, 1.1503f);

			case 15:
				return new Vector3( -842.1452f, -1207.0352f, 5.4363f);

			case 16:
				return new Vector3( -297.1831f, -1331.8916f, 30.297f);

			case 17:
				return new Vector3( -223.5577f, -1499.9733f, 30.9955f);

			case 18:
				return new Vector3( -123.5291f, -1489.6184f, 32.7881f);

			case 19:
				return new Vector3( -194.6511f, -1606.9003f, 33.0044f);

			case 20:
				return new Vector3( -159.4701f, -1681.3734f, 35.9655f);

			case 21:
				return new Vector3( -79.1107f, -1642.9022f, 28.3086f);

			case 22:
				return new Vector3( -22.0813f, -1855.6912f, 24.0218f);

			case 23:
				return new Vector3( 24.8853f, -1895.4996f, 21.5917f);

			case 24:
				return new Vector3( 150.5378f, -1867.1224f, 23.2169f);

			case 25:
				return new Vector3( 178.8342f, -1929.7888f, 20.0126f);

			case 26:
				return new Vector3( 223.9479f, -2035.6016f, 17.0114f);

			case 27:
				return new Vector3( 325.045f, -1944.436f, 23.65f);

			case 28:
				return new Vector3( 386.8519f, -1881.897f, 24.6129f);

			case 29:
				return new Vector3( 322.9866f, -1760.0092f, 28.3121f);

			case 30:
				return new Vector3( 496.5819f, -1817.1823f, 27.4951f);

			case 31:
				return new Vector3( 428.3108f, -1724.3802f, 28.229f);

			case 32:
				return new Vector3( 411.7778f, -1487.622f, 29.1541f);

			case 33:
				return new Vector3( 378.3984f, -2069.2136f, 20.3342f);

			case 34:
				return new Vector3( 295.6716f, -2097.3076f, 16.4362f);

			case 35:
				return new Vector3( 1256.4258f, -1760.279f, 48.2596f);

			case 36:
				return new Vector3( 1311.3408f, -1699.24f, 56.8379f);

			case 37:
				return new Vector3( 1203.222f, -1672.258f, 41.356f);

			case 38:
				return new Vector3( 1296.15f, -1619.214f, 53.224f);

			case 39:
				return new Vector3( 1233.0139f, -1592.2017f, 52.3679f);

			case 40:
				return new Vector3( 1153.3143f, -1526.3145f, 33.8434f);

			case 41:
				return new Vector3( 1184.4565f, -1462.46f, 33.8987f);

			case 42:
				return new Vector3( 1320.3418f, -1557.6378f, 50.2518f);

			case 43:
				return new Vector3( 1435.1565f, -1493.8232f, 62.2245f);

			case 44:
				return new Vector3( 805.7251f, -1074.8779f, 27.6925f);

			case 45:
				return new Vector3( 845.4313f, -1019.5961f, 26.5348f);

			case 46:
				return new Vector3( 477.993f, -976.005f, 26.982f);

			case 47:
				return new Vector3( 388.4341f, -972.9575f, 28.4393f);

			case 48:
				return new Vector3( 360.7195f, -1071.742f, 28.541f);

			case 49:
				return new Vector3( 264.595f, -1028.3639f, 28.2114f);

			case 50:
				return new Vector3( 243.049f, -1072.8595f, 28.2851f);

			case 51:
				return new Vector3( 1209.9691f, -1390.7494f, 34.3769f);

			case 52:
				return new Vector3( 1143.6525f, -983.0127f, 45.0837f);

			case 53:
				return new Vector3( 74.4055f, -1027.7365f, 28.4745f);

			case 54:
				return new Vector3( 68.017f, -960.636f, 28.807f);

			case 55:
				return new Vector3( -17.7702f, -977.3105f, 28.3637f);

			case 56:
				return new Vector3( -1207.7314f, -1136.381f, 6.7069f);

			case 57:
				return new Vector3( -1126.7266f, -1089.4613f, 1.1504f);

			case 58:
				return new Vector3( -1075.5122f, -1026.6133f, 3.5503f);

			case 59:
				return new Vector3( -962.02f, -941.9618f, 1.1503f);

			case 60:
				return new Vector3( -1026.8787f, -920.5894f, 4.0462f);

			case 61:
				return new Vector3( -1150.8193f, -991.4618f, 1.1502f);

			case 62:
				return new Vector3( -1729.3214f, -193.1561f, 57.4907f);

			case 63:
				return new Vector3( -61.331f, -1451.4878f, 31.1237f);

			case 64:
				return new Vector3( -1549.4098f, -89.1561f, 53.9342f);

			case 65:
				return new Vector3( -1464.7268f, -30.3613f, 53.6885f);

			case 66:
				return new Vector3( -1473.8881f, 63.2148f, 52.2628f);

			case 67:
				return new Vector3( -1566.2877f, 41.6651f, 57.899f);

			case 68:
				return new Vector3( -1649.0979f, 149.3594f, 61.147f);

			case 69:
				return new Vector3( -1539.3986f, 127.9013f, 55.7802f);

			case 70:
				return new Vector3( -1179.4456f, 291.4474f, 68.4983f);

			case 71:
				return new Vector3( -1024.1099f, 359.9922f, 70.3614f);

			case 72:
				return new Vector3( -1129.4961f, 391.1533f, 69.687f);

			case 73:
				return new Vector3( -1215.7878f, 460.5076f, 90.8536f);

			case 74:
				return new Vector3( -1499.8252f, 521.8496f, 117.2722f);

			case 75:
				return new Vector3( -1291.5988f, 648.852f, 140.5015f);

			case 76:
				return new Vector3( -1123.263f, 575.838f, 103.399f);

			case 77:
				return new Vector3( -1025.289f, 504.43f, 80.493f);

			case 78:
				return new Vector3( -966.3106f, 435.4573f, 78.9716f);

			case 79:
				return new Vector3( -862.9261f, 389.6106f, 86.416f);

			case 80:
				return new Vector3( -821.3945f, 268.5576f, 85.1919f);

			case 81:
				return new Vector3( -599.8718f, 279.2693f, 81.0659f);

			case 82:
				return new Vector3( -573.4042f, 400.7639f, 99.6666f);

			case 83:
				return new Vector3( -584.9374f, 495.7831f, 106.1077f);

			case 84:
				return new Vector3( -716.3817f, 490.7623f, 108.2575f);

			case 85:
				return new Vector3( -883.1736f, 518.5231f, 91.4429f);

			case 86:
				return new Vector3( -937.1672f, 589.7529f, 100.5004f);

			case 87:
				return new Vector3( -703.9813f, 590.3892f, 141.0301f);

			case 88:
				return new Vector3( -887.7764f, 701.8289f, 149.7192f);

			case 89:
				return new Vector3( -1019.8739f, 717.6904f, 162.9962f);

			case 90:
				return new Vector3( -1166.0927f, 729.2139f, 154.5117f);

			case 91:
				return new Vector3( -579.6033f, 736.3465f, 182.7988f);

			case 92:
				return new Vector3( -549.6393f, 827.5657f, 196.5092f);

			case 93:
				return new Vector3( -493.592f, 739.668f, 162.035f);

			case 94:
				return new Vector3( -445.5339f, 685.0317f, 151.9563f);

			case 95:
				return new Vector3( -345.5573f, 625.1478f, 170.3568f);

			case 96:
				return new Vector3( -246.507f, 620.7859f, 186.8103f);

			case 97:
				return new Vector3( -136.3634f, 592.5217f, 203.5204f);

			case 98:
				return new Vector3( -177.6782f, 503.7645f, 135.8531f);

			case 99:
				return new Vector3( -353.838f, 467.898f, 111.6f);
		}
		switch (id)
		{
			case 100:
				return new Vector3( -370.1311f, 344.5311f, 108.9476f);

			case 101:
				return new Vector3( -251.8532f, 396.8915f, 110.2553f);

			case 102:
				return new Vector3( -86.914f, 424.611f, 112.2026f);

			case 103:
				return new Vector3( -824.227f, 811.451f, 200.441f);

			case 104:
				return new Vector3( -1313.2588f, 451.1252f, 99.9888f);

			case 105:
				return new Vector3( -1685.8473f, -292.574f, 50.8941f);

			case 106:
				return new Vector3( 83.5373f, -93.1314f, 59.4387f);

			case 107:
				return new Vector3( 125.1977f, 64.5473f, 78.7415f);

			case 108:
				return new Vector3( -50.014f, -57.517f, 62.72f);

			case 109:
				return new Vector3( -175.5796f, 87.1064f, 69.3113f);

			case 110:
				return new Vector3( -437.0936f, -67.1628f, 42.0095f);

			case 111:
				return new Vector3( -374.8927f, 45.3917f, 53.4299f);

			case 112:
				return new Vector3( -568.7596f, 169.4346f, 65.5686f);

			case 113:
				return new Vector3( 1774.5756f, 3740.3174f, 33.6558f);

			case 114:
				return new Vector3( 1914.7343f, 3825.1387f, 31.445f);

			case 115:
				return new Vector3( 2001.318f, 3777.756f, 31.1808f);

			case 116:
				return new Vector3( 1923.4122f, 3916.0962f, 31.5573f);

			case 117:
				return new Vector3( 1759.4656f, 3870.6042f, 33.7011f);

			case 118:
				return new Vector3( 1662.0552f, 3820.5872f, 34.4747f);

			case 119:
				return new Vector3( 1420.6212f, 3667.069f, 38.7334f);

			case 120:
				return new Vector3( 439.7653f, 3572.8428f, 32.2386f);

			case 121:
				return new Vector3( 245.8423f, 3168.3188f, 41.848f);

			case 122:
				return new Vector3( 196.278f, 3031.2563f, 42.8867f);

			case 123:
				return new Vector3( -286.9354f, 2837.5405f, 54.101f);

			case 124:
				return new Vector3( -325.1589f, 2818.6377f, 58.4498f);

			case 125:
				return new Vector3( -462.0065f, 2858.0605f, 33.6856f);

			case 126:
				return new Vector3( -35.9165f, 2870.4795f, 58.6161f);

			case 127:
				return new Vector3( 470.9384f, 2608.392f, 43.4822f);

			case 128:
				return new Vector3( 562.8749f, 2600.1355f, 42.086f);

			case 129:
				return new Vector3( 734.8266f, 2524.5442f, 72.2213f);

			case 130:
				return new Vector3( 721.2478f, 2331.9592f, 50.7553f);

			case 131:
				return new Vector3( 789.176f, 2180.511f, 51.652f);

			case 132:
				return new Vector3( 842.0989f, 2114.0498f, 51.2915f);

			case 133:
				return new Vector3( 1530.5115f, 1730.1178f, 109.0085f);

			case 134:
				return new Vector3( 2589.495f, 3168.7852f, 49.9631f);

			case 135:
				return new Vector3( 2618.848f, 3280.744f, 54.249f);

			case 136:
				return new Vector3( 2984.8315f, 3483.6782f, 70.4326f);

			case 137:
				return new Vector3( 1358.385f, 1147.032f, 113.311f);

			case 138:
				return new Vector3( 1534.132f, 2219.926f, 76.202f);

			case 139:
				return new Vector3( -147.5901f, 287.9106f, 95.804f);

			case 140:
				return new Vector3( 1990.7943f, 3055.594f, 46.215f);

			case 141:
				return new Vector3( 2167.6953f, 3380.1665f, 45.4396f);

			case 142:
				return new Vector3( 2179.8206f, 3498.9768f, 44.4457f);

			case 143:
				return new Vector3( 2420.2131f, 4020.7922f, 35.8409f);

			case 144:
				return new Vector3( 347.93f, 442.0758f, 146.7062f);

			case 145:
				return new Vector3( 328.0847f, 536.6777f, 152.7901f);

			case 146:
				return new Vector3( 214.4626f, 620.8659f, 186.4865f);

			case 147:
				return new Vector3( 169.3364f, 487.6725f, 141.9653f);

			case 148:
				return new Vector3( 58.4103f, 452.8104f, 145.7748f);

			case 149:
				return new Vector3( 9.1567f, 544.157f, 174.657f);

			case 150:
				return new Vector3( -149.5679f, 994.9072f, 235.8329f);

			case 151:
				return new Vector3( -2007.9575f, 446.1511f, 102.021f);

			case 152:
				return new Vector3( -1973.8724f, 630.3096f, 121.5363f);

			case 153:
				return new Vector3( -1813.797f, 343.9179f, 87.55f);

			case 154:
				return new Vector3( -1965.1586f, 247.954f, 85.4182f);

			case 155:
				return new Vector3( -341.4331f, 6164.9224f, 30.4905f);

			case 156:
				return new Vector3( -402.97f, 6315.9043f, 27.9477f);

			case 157:
				return new Vector3( -305.763f, 6330.902f, 31.4893f);

			case 158:
				return new Vector3( -245.7304f, 6411.35f, 30.1952f);

			case 159:
				return new Vector3( -111.4322f, 6461.069f, 30.4874f);

			case 160:
				return new Vector3( -49.15f, 6581.322f, 31.179f);

			case 161:
				return new Vector3( 53.9975f, 6642.753f, 30.5189f);

			case 162:
				return new Vector3( -105.4065f, 6314.929f, 30.5813f);

			case 163:
				return new Vector3( 2233.797f, 5610.202f, 53.6149f);

			case 164:
				return new Vector3( 1856.19f, 3682.137f, 33.2675f);

			case 165:
				return new Vector3( 3312.5024f, 5176.1436f, 18.6196f);

			case 166:
				return new Vector3( 1663.3909f, 4776.14f, 41.0075f);

			case 167:
				return new Vector3( 1724.3854f, 4641.8906f, 42.8755f);

			case 168:
				return new Vector3( 1967.815f, 4621.2466f, 39.7539f);

			case 169:
				return new Vector3( 1311.782f, 4361.6685f, 39.8597f);

			case 170:
				return new Vector3( 723.7969f, 4185.509f, 39.7092f);

			case 171:
				return new Vector3( 92.6489f, 3742.2568f, 38.5802f);

			case 172:
				return new Vector3( 34.6049f, 3668.4692f, 38.6801f);

			case 173:
				return new Vector3( -267.54f, 2627.4531f, 60.9923f);

			case 174:
				return new Vector3( -263.1123f, 2196.1797f, 129.4037f);

			case 175:
				return new Vector3( 749.1031f, 224.0523f, 86.428f);

			case 176:
				return new Vector3( 133.2061f, -567.3676f, 42.8161f);

			case 177:
				return new Vector3( -1873.0062f, 2030.0165f, 138.4322f);

			case 178:
				return new Vector3( -1112.3536f, 2687.4917f, 17.6057f);

			case 179:
				return new Vector3( -3182.6006f, 1293.0519f, 13.5678f);

			case 180:
				return new Vector3( -3202.2632f, 1152.0481f, 8.6543f);

			case 181:
				return new Vector3( -3239.6838f, 930.4217f, 16.155f);

			case 182:
				return new Vector3( -2998.8748f, 693.8451f, 24.4588f);

			case 183:
				return new Vector3( -3035.1628f, 492.2418f, 5.7679f);

			case 184:
				return new Vector3( -3086.823f, 222.3769f, 13.0732f);

			case 185:
				return new Vector3( -770.0883f, 5512.973f, 33.9196f);

			case 186:
				return new Vector3( 1705.9131f, 6423.9487f, 31.6352f);

			case 187:
				return new Vector3( 2453.944f, 4965.184f, 45.5766f);

			case 188:
				return new Vector3( 2638.4111f, 4247.0205f, 43.7979f);

			case 189:
				return new Vector3( 967.0685f, -545.4393f, 58.3827f);

			case 190:
				return new Vector3( 955.1855f, -594.7885f, 58.3677f);

			case 191:
				return new Vector3( 998.2266f, -727.2252f, 56.5344f);

			case 192:
				return new Vector3( 1204.7295f, -620.3536f, 65.1218f);

			case 193:
				return new Vector3( 1371.1569f, -558.0407f, 73.3388f);

			case 194:
				return new Vector3( 1323.9185f, -581.7794f, 72.2514f);

			case 195:
				return new Vector3( 1262.832f, -427.9097f, 68.8054f);

			case 196:
				return new Vector3( 1012.4821f, -423.275f, 63.9577f);

			case 197:
				return new Vector3( -2552.7603f, 1913.5398f, 168.053f);

			case 198:
				return new Vector3( 3689.8367f, 4563.4194f, 24.1881f);

			case 199:
				return new Vector3( -1524.1754f, 853.2913f, 180.5948f);
		}

		return new Vector3(0, 0, 0);
	}

	public static Vector3 GetLanternsRotation(int id)
    {
		id -= 363;
		switch (id)
        {
			case 0:
				return new Vector3( 0f, 0f, -20.6982f);

			case 1:
				return new Vector3( 0f, 0f, 78.199f);

			case 2:
				return new Vector3( 0f, 0f, 41.999f);

			case 3:
				return new Vector3( 0f, 0f, 234.5034f);

			case 4:
				return new Vector3( 0f, 0f, 220.1651f);

			case 5:
				return new Vector3( -0.17f, 5.103f, -151.594f);

			case 6:
				return new Vector3( 0f, 0f, 40.3985f);

			case 7:
				return new Vector3( 0f, 0f, 232.3804f);

			case 8:
				return new Vector3( 0f, 0f, -35.395f);

			case 9:
				return new Vector3( 0f, 0f, -46.395f);

			case 10:
				return new Vector3( 0f, 0f, -100.2251f);

			case 11:
				return new Vector3( 0f, 0f, -47.5335f);

			case 12:
				return new Vector3( 0f, 0f, 286.7332f);

			case 13:
				return new Vector3( 0f, 0f, -62.1634f);

			case 14:
				return new Vector3( 0f, 0f, 63.119f);

			case 15:
				return new Vector3( 0f, 0f, 222.0146f);

			case 16:
				return new Vector3( 0f, 0f, 142.014f);

			case 17:
				return new Vector3( 9.37f, 6.148f, 96.096f);

			case 18:
				return new Vector3( 0f, 0f, -67.705f);

			case 19:
				return new Vector3( 7.291f, -1.954f, 86.619f);

			case 20:
				return new Vector3( 0f, 0f, -44.581f);

			case 21:
				return new Vector3( 0f, 0f, 73.219f);

			case 22:
				return new Vector3( 0f, 0f, 137.819f);

			case 23:
				return new Vector3( 0f, 0f, 137.819f);

			case 24:
				return new Vector3( 0f, 0f, -34.182f);

			case 25:
				return new Vector3( 0f, 0f, 51.817f);

			case 26:
				return new Vector3( 0f, 0f, -125.383f);

			case 27:
				return new Vector3( 0f, 0f, 48.5421f);

			case 28:
				return new Vector3( 0f, 0f, 13.216f);

			case 29:
				return new Vector3( 0f, 0f, 63.816f);

			case 30:
				return new Vector3( 0f, 0f, -127.384f);

			case 31:
				return new Vector3( 0f, 0f, -127.785f);

			case 32:
				return new Vector3( 0f, 0f, -134.985f);

			case 33:
				return new Vector3( 0f, 0f, 44.815f);

			case 34:
				return new Vector3( 0f, 0f, -57.785f);

			case 35:
				return new Vector3( 0f, 0f, -158.585f);

			case 36:
				return new Vector3( 0f, 0f, 28.015f);

			case 37:
				return new Vector3( 0f, 0f, 34.015f);

			case 38:
				return new Vector3( 0f, 0f, 26.815f);

			case 39:
				return new Vector3( 0f, 0f, 37.815f);

			case 40:
				return new Vector3( 0f, 0f, 150.414f);

			case 41:
				return new Vector3( 0f, 0f, -175.386f);

			case 42:
				return new Vector3( 0f, 0f, 280.7728f);

			case 43:
				return new Vector3( 0f, 0f, -3.186f);

			case 44:
				return new Vector3( 0f, 0f, -16.386f);

			case 45:
				return new Vector3( 0f, 0f, 241.4945f);

			case 46:
				return new Vector3( 0f, 0f, 166.414f);

			case 47:
				return new Vector3( 0f, 0f, 90.213f);

			case 48:
				return new Vector3( 0f, 0f, 175.413f);

			case 49:
				return new Vector3( 0f, 0f, 36.013f);

			case 50:
				return new Vector3( 0f, 0f, -155.187f);

			case 51:
				return new Vector3( 0f, 0f, 13.6193f);

			case 52:
				return new Vector3( 0.371f, -3.62f, 103.823f);

			case 53:
				return new Vector3( 0f, 0f, 62.423f);

			case 54:
				return new Vector3( 0f, 0f, -20.377f);

			case 55:
				return new Vector3( 0f, 0f, 161.023f);

			case 56:
				return new Vector3( 0f, 0f, 286.0904f);

			case 57:
				return new Vector3( 0f, 0f, -65.8f);

			case 58:
				return new Vector3( 0f, 0f, 135.799f);

			case 59:
				return new Vector3( 0f, 0f, -28.001f);

			case 60:
				return new Vector3( 0f, 0f, 26.599f);

			case 61:
				return new Vector3( 0f, 0f, 26.599f);

			case 62:
				return new Vector3( 0f, 0f, -84.002f);

			case 63:
				return new Vector3( 0f, 0f, 17.8011f);

			case 64:
				return new Vector3( 0f, 0f, 178.369f);

			case 65:
				return new Vector3( 0f, 0f, 127.369f);

			case 66:
				return new Vector3( 0f, 0f, 55.969f);

			case 67:
				return new Vector3( 2.172f, -3.122f, 165.828f);

			case 68:
				return new Vector3( 0f, 0f, 56.027f);

			case 69:
				return new Vector3( 0f, 0f, -27.973f);

			case 70:
				return new Vector3( 0f, 0f, 18.227f);

			case 71:
				return new Vector3( 0f, 0f, 71.227f);

			case 72:
				return new Vector3( 0f, 0f, 162.8423f);

			case 73:
				return new Vector3( 0f, 0f, -175.974f);

			case 74:
				return new Vector3( 0f, 0f, 12.625f);

			case 75:
				return new Vector3( 0f, 0f, 24.625f);

			case 76:
				return new Vector3( 0f, 0f, 30.625f);

			case 77:
				return new Vector3( 10.174f, 6.614f, 30.035f);

			case 78:
				return new Vector3( 0f, 0f, 104.635f);

			case 79:
				return new Vector3( 0f, 0f, 84.5137f);

			case 80:
				return new Vector3( 0f, 0f, -146.546f);

			case 81:
				return new Vector3( 0f, 0f, 14.654f);

			case 82:
				return new Vector3( 0f, 0f, -72.346f);

			case 83:
				return new Vector3( 0f, 0f, 179.057f);

			case 84:
				return new Vector3( 0f, 0f, 92.057f);

			case 85:
				return new Vector3( 0f, 0f, 101.457f);

			case 86:
				return new Vector3( 0f, 0f, -23.143f);

			case 87:
				return new Vector3( 0f, 0f, -163.743f);

			case 88:
				return new Vector3( 0f, 0f, 178.057f);

			case 89:
				return new Vector3( 0f, 0f, -2.544f);

			case 90:
				return new Vector3( 0f, 0f, -131.144f);

			case 91:
				return new Vector3( 0f, 0f, -134.544f);

			case 92:
				return new Vector3( 0f, 0f, 171.056f);

			case 93:
				return new Vector3( 0f, 0f, 95.456f);

			case 94:
				return new Vector3( 0f, 0f, 30.056f);

			case 95:
				return new Vector3( 0f, 0f, -134.544f);

			case 96:
				return new Vector3( 0f, 0f, 6.056f);

			case 97:
				return new Vector3( 0f, 0f, 176.255f);

			case 98:
				return new Vector3( 0f, 0f, -163.345f);

			case 99:
				return new Vector3( 0f, 0f, 152.455f);

		}
		switch (id)
		{
			case 100:
				return new Vector3( 0f, 0f, -178.638f);

			case 101:
				return new Vector3( 0f, 0f, -66.638f);

			case 102:
				return new Vector3( 0f, 0f, -39.638f);

			case 103:
				return new Vector3( 0f, 0f, -154.638f);

			case 104:
				return new Vector3( 0f, 0f, -175.638f);

			case 105:
				return new Vector3( 0f, 0f, 3.762f);

			case 106:
				return new Vector3( 0f, 0f, 78.561f);

			case 107:
				return new Vector3( 0f, 0f, 60.961f);

			case 108:
				return new Vector3( 0f, 0f, 163.5772f);

			case 109:
				return new Vector3( 0f, 0f, 169.5499f);

			case 110:
				return new Vector3( 0f, 0f, 79.3929f);

			case 111:
				return new Vector3( 0f, 0f, -0.239f);

			case 112:
				return new Vector3( 0f, 0f, 93.961f);

			case 113:
				return new Vector3( 0f, 0f, -65.4476f);

			case 114:
				return new Vector3( 0f, 0f, -54.349f);

			case 115:
				return new Vector3( 0f, 0f, 34.1118f);

			case 116:
				return new Vector3( 0f, 0f, 144.4475f);

			case 117:
				return new Vector3( 0f, 0f, 113.251f);

			case 118:
				return new Vector3( 0f, 0f, 131.451f);

			case 119:
				return new Vector3( 0f, 0f, -156.35f);

			case 120:
				return new Vector3( 0f, 0f, 167.85f);

			case 121:
				return new Vector3( 0f, 0f, -85.75f);

			case 122:
				return new Vector3( 0f, 0f, 89.249f);

			case 123:
				return new Vector3( -4.888f, 2.664f, -27.837f);

			case 124:
				return new Vector3( 0f, 0f, 218.5632f);

			case 125:
				return new Vector3( 0f, 0f, 6.5869f);

			case 126:
				return new Vector3( 0f, 0f, -23.237f);

			case 127:
				return new Vector3( 0f, 0f, 151.562f);

			case 128:
				return new Vector3( 0f, 0f, -54.438f);

			case 129:
				return new Vector3( 0f, 0f, 57.762f);

			case 130:
				return new Vector3( 0f, 0f, -178.439f);

			case 131:
				return new Vector3( 0f, 0f, 154.561f);

			case 132:
				return new Vector3( 0f, 0f, -106.04f);

			case 133:
				return new Vector3( 0f, 0f, -90.9838f);

			case 134:
				return new Vector3( 0f, 0f, 139.233f);

			case 135:
				return new Vector3( 0f, 0f, 139.233f);

			case 136:
				return new Vector3( 0f, 0f, 143.1906f);

			case 137:
				return new Vector3( 0f, 0f, -97.3761f);

			case 138:
				return new Vector3( -10.635f, -7.309f, -83.448f);

			case 139:
				return new Vector3( 0f, 0f, 24.322f);

			case 140:
				return new Vector3( 0f, 0f, 140.551f);

			case 141:
				return new Vector3( 0f, 0f, 47.551f);

			case 142:
				return new Vector3( 10.377f, 1.331f, -137.17f);

			case 143:
				return new Vector3( 0f, 0f, 63.43f);

			case 144:
				return new Vector3( 0f, 0f, 117.8f);

			case 145:
				return new Vector3( 0f, 0f, 117.8f);

			case 146:
				return new Vector3( 0f, 0f, -100.601f);

			case 147:
				return new Vector3( 0f, 0f, 142.9758f);

			case 148:
				return new Vector3( 0f, 0f, 208.6368f);

			case 149:
				return new Vector3( 0f, 0f, -158.878f);

			case 150:
				return new Vector3( 0f, 0f, -76.078f);

			case 151:
				return new Vector3( 0f, 0f, 112.321f);

			case 152:
				return new Vector3( 0f, 0f, 66.321f);

			case 153:
				return new Vector3( 0f, 0f, -106.279f);

			case 154:
				return new Vector3( 0f, 0f, 136.72f);

			case 155:
				return new Vector3( 5.838f, 2.77f, -76.221f);

			case 156:
				return new Vector3( 0f, 0f, 49.778f);

			case 157:
				return new Vector3( 0f, 0f, -159.422f);

			case 158:
				return new Vector3( 0f, 0f, -50.622f);

			case 159:
				return new Vector3( 0f, 0f, -50.622f);

			case 160:
				return new Vector3( 0f, 0f, -137.022f);

			case 161:
				return new Vector3( 0f, 0f, -29.022f);

			case 162:
				return new Vector3( 0f, 0f, -52.6974f);

			case 163:
				return new Vector3( 0f, 0f, 27.3126f);

			case 164:
				return new Vector3( 0f, 0f, 30.262f);

			case 165:
				return new Vector3( 0f, 0f, 57.9839f);

			case 166:
				return new Vector3( 0f, 0f, 93.434f);

			case 167:
				return new Vector3( 0f, 0f, -65.166f);

			case 168:
				return new Vector3( 0f, 0f, -51.966f);

			case 169:
				return new Vector3( 0f, 0f, 76.033f);

			case 170:
				return new Vector3( 0f, 0f, 76.033f);

			case 171:
				return new Vector3( 0f, 0f, 54.433f);

			case 172:
				return new Vector3( 0f, 0f, 54.433f);

			case 173:
				return new Vector3( 0f, 0f, 3.8178f);

			case 174:
				return new Vector3( 0f, 0f, 58.432f);

			case 175:
				return new Vector3( 0f, 0f, -28.768f);

			case 176:
				return new Vector3( 0f, 0f, -88.4003f);

			case 177:
				return new Vector3( 0f, 0f, 91.7006f);

			case 178:
				return new Vector3( 0f, 0f, 41.8993f);

			case 179:
				return new Vector3( 0f, 0f, 81.5992f);

			case 180:
				return new Vector3( 0f, 0f, 81.4794f);

			case 181:
				return new Vector3( 0f, 0f, 105.5991f);

			case 182:
				return new Vector3( 0f, 0f, -64.8011f);

			case 183:
				return new Vector3( 0f, 0f, 94.9987f);

			case 184:
				return new Vector3( 0f, 0f, 124.1985f);

			case 185:
				return new Vector3( 0f, 0f, -30.8019f);

			case 186:
				return new Vector3( 0f, 0f, -30.8019f);

			case 187:
				return new Vector3( 0f, 0f, -39.8019f);

			case 188:
				return new Vector3( 0f, 0f, 207.2845f);

			case 189:
				return new Vector3( 0f, 0f, 29.1975f);

			case 190:
				return new Vector3( 0f, 0f, 201.2103f);

			case 191:
				return new Vector3( 0f, 0f, 133.3969f);

			case 192:
				return new Vector3( 0f, 0f, -96.6033f);

			case 193:
				return new Vector3( 0f, 0f, -21.0036f);

			case 194:
				return new Vector3( 0f, 0f, 162.0395f);

			case 195:
				return new Vector3( 0f, 0f, 114.5959f);

			case 196:
				return new Vector3( 0f, 0f, 130.7957f);

			case 197:
				return new Vector3( 0f, 0f, 55.1955f);

			case 198:
				return new Vector3( 0f, 0f, 93.1954f);

			case 199:
				return new Vector3( 0f, 0f, -156.4045f);
		}

		return new Vector3(0, 0, 0);
    }

	public static string GetLanernsModelName(int id)
    {
		id -= 363;
		switch (id)
		{
			case 0:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 1:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 2:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 3:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 4:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 5:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 6:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 7:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 8:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 9:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 10:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 11:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 12:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 13:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 14:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 15:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 16:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 17:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 18:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 19:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 20:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 21:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 22:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 23:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 24:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 25:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 26:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 27:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 28:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 29:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 30:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 31:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 32:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 33:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 34:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 35:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 36:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 37:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 38:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 39:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 40:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 41:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 42:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 43:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 44:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 45:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 46:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 47:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 48:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 49:
				return "reh_Prop_REH_Lantern_PK_01b";
				
		}
		switch (id)
		{
			case 50:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 51:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 52:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 53:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 54:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 55:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 56:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 57:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 58:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 59:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 60:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 61:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 62:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 63:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 64:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 65:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 66:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 67:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 68:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 69:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 70:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 71:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 72:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 73:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 74:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 75:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 76:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 77:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 78:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 79:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 80:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 81:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 82:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 83:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 84:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 85:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 86:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 87:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 88:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 89:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 90:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 91:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 92:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 93:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 94:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 95:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 96:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 97:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 98:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 99:
				return "reh_Prop_REH_Lantern_PK_01a";
				
		}
		switch (id)
		{
			case 100:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 101:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 102:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 103:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 104:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 105:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 106:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 107:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 108:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 109:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 110:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 111:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 112:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 113:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 114:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 115:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 116:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 117:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 118:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 119:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 120:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 121:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 122:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 123:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 124:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 125:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 126:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 127:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 128:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 129:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 130:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 131:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 132:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 133:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 134:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 135:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 136:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 137:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 138:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 139:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 140:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 141:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 142:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 143:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 144:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 145:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 146:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 147:
				return "reh_Prop_REH_Lantern_PK_01a";
				

			case 148:
				return "reh_Prop_REH_Lantern_PK_01b";
				

			case 149:
				return "reh_Prop_REH_Lantern_PK_01c";
				

			case 150:
				return "reh_Prop_REH_Lantern_PK_01a";
				
		}
		switch (id)
		{
			case 151:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 152:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 153:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 154:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 155:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 156:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 157:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 158:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 159:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 160:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 161:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 162:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 163:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 164:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 165:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 166:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 167:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 168:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 169:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 170:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 171:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 172:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 173:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 174:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 175:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 176:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 177:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 178:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 179:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 180:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 181:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 182:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 183:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 184:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 185:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 186:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 187:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 188:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 189:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 190:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 191:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 192:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 193:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 194:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 195:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 196:
				return "reh_Prop_REH_Lantern_PK_01b";


			case 197:
				return "reh_Prop_REH_Lantern_PK_01c";


			case 198:
				return "reh_Prop_REH_Lantern_PK_01a";


			case 199:
				return "reh_Prop_REH_Lantern_PK_01b";
		}

		return "reh_Prop_REH_Lantern_PK_01a";
	}

	public static Vector3 GetYuanbaoPosition(int id)
    {
		id -= 564;
		switch(id)
        {
			case 0:
				return new Vector3( -1120.689f, -3422.574f, 15.351f);

			case 1:
				return new Vector3( -1180.531f, -2053.92f, 14.058f);

			case 2:
				return new Vector3( 218.507f, -1527.742f, 35.576f);

			case 3:
				return new Vector3( 297.35f, 208.676f, 116.156f);

			case 4:
				return new Vector3( -167.208f, -1442.337f, 37.364f);

			case 5:
				return new Vector3( 1902.529f, 3718.78f, 36.373f);

			case 6:
				return new Vector3( 1112.469f, -642.014f, 56.332f);

			case 7:
				return new Vector3( -1141.207f, -1.957f, 48.526f);

			case 8:
				return new Vector3( -2222.705f, 265.771f, 184.601f);

			case 9:
				return new Vector3( -3106.753f, 301.746f, 8.154f);

			case 10:
				return new Vector3( -1004.495f, 4851.613f, 274.313f);

			case 11:
				return new Vector3( -379.758f, 6032.034f, 31.292f);

			case 12:
				return new Vector3( -181.7757f, 6305.9824f, 31.4852f);

			case 13:
				return new Vector3( 1802.5061f, 4601.2456f, 37.3489f);

			case 14:
				return new Vector3( 0.821f, -708.807f, 45.553f);

			case 15:
				return new Vector3( -915.678f, -346.504f, 38.66f);

			case 16:
				return new Vector3( -911.097f, 745.881f, 181.63f);

			case 17:
				return new Vector3( -1600.762f, 846.4665f, 185.5793f);

			case 18:
				return new Vector3( -1589.4058f, 2793.292f, 17.0092f);

			case 19:
				return new Vector3( -213.81f, -2356.633f, 26.106f);

			case 20:
				return new Vector3( -282.426f, -2782.826f, 4.332f);

			case 21:
				return new Vector3( -155.124f, -952.196f, 254.207f);

			case 22:
				return new Vector3( -267.99f, 282.176f, 104.623f);

			case 23:
				return new Vector3( 770.403f, -1791.812f, 54.702f);

			case 24:
				return new Vector3( 738.426f, -976.089f, 36.531f);

			case 25:
				return new Vector3( 914.629f, -7.809f, 111.094f);

			case 26:
				return new Vector3( 1281.2179f, -1766.5231f, 51.7544f);

			case 27:
				return new Vector3( 1242.1023f, -3053.7625f, 14.2502f);

			case 28:
				return new Vector3( 1572.0837f, -2167.2332f, 77.5689f);

			case 29:
				return new Vector3( -1661.709f, -149.666f, 58.223f);

			case 30:
				return new Vector3( -1199.482f, -1159.825f, 12.728f);

			case 31:
				return new Vector3( -2310.027f, 4377.879f, 9.57f);

			case 32:
				return new Vector3( 711.269f, 4097.148f, 35.852f);

			case 33:
				return new Vector3( 2443.325f, 5823.494f, 58.631f);

			case 34:
				return new Vector3( 1014.965f, 99.436f, 88.204f);

			case 35:
				return new Vector3( 546.6995f, 2662.438f, 42.009f);
		}

		return new Vector3(0, 0, 0);
    }

	public static Vector3 GetYuanbaoRotation(int id)
	{
		id -= 564;
		switch (id)
		{
			case 0:
				return new Vector3(0f, 0f, 39.8f);

			case 1:
				return new Vector3(0f, 0f, -13.801f);

			case 2:
				return new Vector3(0f, 0f, 81.799f);

			case 3:
				return new Vector3(0f, 0f, 67.399f);

			case 4:
				return new Vector3(0f, 0f, 103.799f);

			case 5:
				return new Vector3(0f, 0f, 156.999f);

			case 6:
				return new Vector3(0f, 0f, -26.201f);

			case 7:
				return new Vector3(0f, 0f, 50.599f);

			case 8:
				return new Vector3(0f, 0f, -66.601f);

			case 9:
				return new Vector3(0f, 0f, -70.201f);

			case 10:
				return new Vector3(0f, 0f, -109.201f);

			case 11:
				return new Vector3(0f, 0f, -69.001f);

			case 12:
				return new Vector3(0f, 0f, 168.1367f);

			case 13:
				return new Vector3(-0.575f, 0f, -72.001f);

			case 14:
				return new Vector3(5.763f, 0f, -58.801f);

			case 15:
				return new Vector3(0f, 0f, 30.998f);

			case 16:
				return new Vector3(0f, 0f, 58.398f);

			case 17:
				return new Vector3(0f, 0f, 58.5431f);

			case 18:
				return new Vector3(0f, 0f, 135.1841f);

			case 19:
				return new Vector3(0f, 0f, -94.416f);

			case 20:
				return new Vector3(0f, 0f, -150.816f);

			case 21:
				return new Vector3(0f, 0f, -150.816f);

			case 22:
				return new Vector3(0f, 0f, -10.016f);

			case 23:
				return new Vector3(0f, 0f, 173.184f);

			case 24:
				return new Vector3(0f, 0f, 54.183f);

			case 25:
				return new Vector3(0f, 0f, -28.217f);

			case 26:
				return new Vector3(0f, 0f, 31.3827f);

			case 27:
				return new Vector3(0f, 0f, -121.217f);

			case 28:
				return new Vector3(0f, 0f, -93.2f);

			case 29:
				return new Vector3(0f, 0f, 105.6f);

			case 30:
				return new Vector3(0f, 0f, -87.4f);

			case 31:
				return new Vector3(0f, 0f, -119f);

			case 32:
				return new Vector3(0f, 0f, -10.016f);

			case 33:
				return new Vector3(0.204f, -3.7f, -119f);

			case 34:
				return new Vector3(0f, 0f, -119f);

			case 35:
				return new Vector3(0f, 0f, -140.6004f);
		}

		return new Vector3(0, 0, 0);
	}

	public static string GetYuanbaoModelName(int id)
    {
		id -= 564;
		switch (id)
        {
			case 11:
			case 10:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 33:
			case 34:
				return "m24_2_prop_m42_treasure_02a";

			case 21:
			case 22:
			case 24:
			case 25:
			case 26:
			case 27:
			case 29:
			case 30:
			case 32:
				return "m24_2_prop_m42_treasure_03a";

			default:
				return "m24_2_prop_m42_treasure_01a";
		}
    }
}