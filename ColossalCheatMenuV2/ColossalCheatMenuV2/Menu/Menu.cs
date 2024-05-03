using BepInEx;
using Colossal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using UnityEngine;
using Colossal.Mods;
using UnityEngine.XR;
using GorillaNetworking;
using Photon.Pun;
using PlayFab;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using ExitGames.Client.Photon;
using Colossal.Menu.ClientHub;
using HarmonyLib;
using System.Reflection;
using Photon.Realtime;
using Valve.VR;
using System.Runtime.Remoting.Messaging;
using Colossal.Patches;
using PlayFab.ClientModels;
using static UnityEngine.Random;

namespace Colossal.Menu {
    public class MenuOption {
        public string DisplayName;
        public string _type;
        public bool AssociatedBool;
        public string AssociatedString;
        public float AssociatedFloat;
        public int AssociatedInt;
        public string[] StringArray;
        public int stringsliderind;
    }
    public class Menu {
        public static bool GUIToggled = true;

        public static GameObject HUDObj;
        public static GameObject HUDObj2;
        static GameObject MainCamera;
        static Text Testtext;
        private static TextAnchor textAnchor = TextAnchor.UpperRight;
        static Material AlertText = new Material(Shader.Find("GUI/Text Shader"));
        static Text NotifiText;

        public static string MenuState = "Main";

        public static string MenuColour = "magenta";

        public static string MenuColourString = "magenta";

        public static float menurgb = 0;
        public static int SelectedOptionIndex = 0;
        public static MenuOption[] CurrentViewingMenu = null;
        public static MenuOption[] MainMenu;
        public static MenuOption[] Movement;
        public static MenuOption[] Movement2;
        public static MenuOption[] Visual;
        public static MenuOption[] Player;
        public static MenuOption[] Computer;
        public static MenuOption[] Modders;
        public static MenuOption[] Account;
        public static MenuOption[] Settings;

        public static MenuOption[] Speed;

        public static MenuOption[] TagAura;
        public static MenuOption[] Presets;
        public static MenuOption[] Sky;

        public static MenuOption[] ColourSettings;
        public static MenuOption[] ModSettings;
        public static MenuOption[] MovementSettings;
        public static MenuOption[] VisualSettings;
        public static MenuOption[] PlayerSettings;


        public static bool inputcooldown = false;
        public static bool menutogglecooldown = false;

        public static bool agreement = false;

        public static void LoadOnceOculus()
        {
            CustomConsole.LogToConsole("[COLOSSAL] Spawning Oculus Prompt");

            MainCamera = GameObject.Find("Main Camera");
            HUDObj = new GameObject();
            HUDObj2 = new GameObject();
            HUDObj2.name = "CLIENT_HUB_AGREEMENT";
            HUDObj.name = "CLIENT_HUB_AGREEMENT";
            HUDObj.AddComponent<Canvas>();
            HUDObj.AddComponent<CanvasScaler>();
            HUDObj.AddComponent<GraphicRaycaster>();
            HUDObj.GetComponent<Canvas>().enabled = true;
            HUDObj.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            HUDObj.GetComponent<Canvas>().worldCamera = MainCamera.GetComponent<Camera>();
            HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
            HUDObj.GetComponent<RectTransform>().position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
            HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 4.6f);
            HUDObj.transform.parent = HUDObj2.transform;
            HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
            var Temp = HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
            Temp.y = -270f;
            HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
            HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(Temp);
            GameObject TestText = new GameObject();
            TestText.transform.parent = HUDObj.transform;
            Testtext = TestText.AddComponent<Text>();
            Testtext.text = "<color=red>YOU ARE PLAYING ON THE OCULUS VERSION!\n</color><color=white>Please launch Gorilla Tag using a steam\nversion of the game to continue using the menu.\n\nThank you for chosing CCMV2</color>";
            Testtext.fontSize = 10;
            Testtext.font = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().font;
            Testtext.rectTransform.sizeDelta = new Vector2(260, 300);   
            Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
            Testtext.rectTransform.localPosition = new Vector3(-2.4f, -0.4f, 1f);
            Testtext.material = AlertText;
            NotifiText = Testtext;
            Testtext.alignment = TextAnchor.UpperLeft;

            //HUDObj2.transform.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
            //HUDObj2.transform.rotation = MainCamera.transform.rotation;
            HUDObj2.transform.transform.SetParent(MainCamera.transform);
        }
        public static void LoadOnce() {
            Debug.Log("Load Once Ran");

            try {
                if (!agreement) {
                    Debug.Log("Aggreement Is False");

                    MainCamera = GameObject.Find("Main Camera");
                    HUDObj = new GameObject();
                    HUDObj2 = new GameObject();
                    HUDObj2.name = "CLIENT_HUB_AGREEMENT";
                    HUDObj.name = "CLIENT_HUB_AGREEMENT";
                    HUDObj.AddComponent<Canvas>();
                    HUDObj.AddComponent<CanvasScaler>();
                    HUDObj.AddComponent<GraphicRaycaster>();
                    HUDObj.GetComponent<Canvas>().enabled = true;
                    HUDObj.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
                    HUDObj.GetComponent<Canvas>().worldCamera = MainCamera.GetComponent<Camera>();
                    HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
                    HUDObj.GetComponent<RectTransform>().position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 4.6f);
                    HUDObj.transform.parent = HUDObj2.transform;
                    HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
                    var Temp = HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
                    Temp.y = -270f;
                    HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
                    HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(Temp);
                    GameObject TestText = new GameObject();
                    TestText.transform.parent = HUDObj.transform;
                    Testtext = TestText.AddComponent<Text>();
                    Testtext.text = "<color=magenta><CONTROLS (DRIFT MODE)></color>\nLeft Joystick (Hold): Control\nRight Grip: Select\nRight Trigger: Move\nBoth Joysticks: Toggle\n\n<color=magenta><CONTROLS></color>\nRight Joystick (Right): Select\nRight Joystick (Down): Move\nBoth Joysticks: Toggle\n\n<color=magenta><CONTROLS (PC)></color>\nEnterKey: Select\nArrowKey (Up): Move Up\nArrowKey (Down): Move Down\n\n<color=cyan>Press Both Joysticks Or Enter...</color>";
                    Testtext.fontSize = 10;
                    Testtext.font = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().font;
                    Testtext.rectTransform.sizeDelta = new Vector2(260, 300);
                    Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
                    Testtext.rectTransform.localPosition = new Vector3(-2.4f, -0.4f, 1f);
                    Testtext.material = AlertText;
                    NotifiText = Testtext;
                    Testtext.alignment = TextAnchor.UpperLeft;

                    //HUDObj2.transform.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    //HUDObj2.transform.rotation = MainCamera.transform.rotation;
                    HUDObj2.transform.transform.SetParent(MainCamera.transform);
                } else {
                    Debug.Log("Aggreement Is True");

                    // Adding once the menu has been made or like whatever because it causes errors
                    if (Plugin.holder.GetComponent<SpeedMod>() == null)
                        Plugin.holder.AddComponent<SpeedMod>();
                    if (Plugin.holder.GetComponent<SkyColour>() == null)
                        Plugin.holder.AddComponent<SkyColour>();

                    // Adding here so you dont see them before you accepted the aggreement
                    if (GorillaTagger.Instance.gameObject.GetComponent<Overlay>() == null)
                        GorillaTagger.Instance.gameObject.AddComponent<Overlay>();

                    if (GorillaTagger.Instance.gameObject.GetComponent<Notifacations>() == null)
                        GorillaTagger.Instance.gameObject.AddComponent<Notifacations>();

                    if (GorillaTagger.Instance.gameObject.GetComponent<ToolTips>() == null)
                        GorillaTagger.Instance.gameObject.AddComponent<ToolTips>();

                    MainCamera = GameObject.Find("Main Camera");
                    HUDObj = new GameObject();
                    HUDObj2 = new GameObject();
                    HUDObj2.name = "CLIENT_HUB";
                    HUDObj.name = "CLIENT_HUB";
                    HUDObj.AddComponent<Canvas>();
                    HUDObj.AddComponent<CanvasScaler>();
                    HUDObj.AddComponent<GraphicRaycaster>();
                    HUDObj.GetComponent<Canvas>().enabled = true;
                    HUDObj.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
                    HUDObj.GetComponent<Canvas>().worldCamera = MainCamera.GetComponent<Camera>();
                    HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
                    HUDObj.GetComponent<RectTransform>().position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 4.6f);
                    HUDObj.transform.parent = HUDObj2.transform;
                    HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
                    var Temp = HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
                    Temp.y = -270f;
                    HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
                    HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(Temp);
                    GameObject TestText = new GameObject();
                    TestText.transform.parent = HUDObj.transform;
                    Testtext = TestText.AddComponent<Text>();
                    Testtext.text = "";
                    Testtext.fontSize = 10;
                    Testtext.font = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().font;
                    Testtext.rectTransform.sizeDelta = new Vector2(260, 160);
                    Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
                    Testtext.rectTransform.localPosition = new Vector3(-2.4f, 1f, 2f);
                    Testtext.material = AlertText;
                    NotifiText = Testtext;
                    Testtext.alignment = TextAnchor.UpperLeft;

                    //HUDObj2.transform.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    //HUDObj2.transform.rotation = MainCamera.transform.rotation;
                    HUDObj2.transform.transform.SetParent(MainCamera.transform);

                    MainMenu = new MenuOption[12];
                    MainMenu[0] = new MenuOption { DisplayName = "Movement", _type = "submenu", AssociatedString = "Movement" };
                    MainMenu[1] = new MenuOption { DisplayName = "Visual", _type = "submenu", AssociatedString = "Visual" };
                    MainMenu[2] = new MenuOption { DisplayName = "Player", _type = "submenu", AssociatedString = "Player" };
                    MainMenu[3] = new MenuOption { DisplayName = "Computer", _type = "submenu", AssociatedString = "Computer" };
                    MainMenu[4] = new MenuOption { DisplayName = "Modders", _type = "submenu", AssociatedString = "Modders" };
                    MainMenu[5] = new MenuOption { DisplayName = "Account", _type = "submenu", AssociatedString = "Account" };
                    MainMenu[6] = new MenuOption { DisplayName = "Settings", _type = "submenu", AssociatedString = "Settings" };
                    //MainMenu[8] = new MenuOption { DisplayName = "AntiCrash", _type = "toggle", AssociatedBool = true };
                    MainMenu[7] = new MenuOption { DisplayName = "Notifacations", _type = "toggle", AssociatedBool = true };
                    MainMenu[8] = new MenuOption { DisplayName = "Overlay", _type = "toggle", AssociatedBool = true };
                    MainMenu[9] = new MenuOption { DisplayName = "CS Visuals", _type = "toggle", AssociatedBool = true };
                    MainMenu[10] = new MenuOption { DisplayName = "Tool Tips", _type = "toggle", AssociatedBool = true };
                    MainMenu[11] = new MenuOption { DisplayName = "Show Startup", _type = "toggle", AssociatedBool = true };

                    Movement = new MenuOption[12];
                    Movement[0] = new MenuOption { DisplayName = "ExcelFly", _type = "toggle", AssociatedBool = false };
                    Movement[1] = new MenuOption { DisplayName = "TFly", _type = "toggle", AssociatedBool = false };
                    Movement[2] = new MenuOption { DisplayName = "WallWalk", _type = "toggle", AssociatedBool = false };
                    Movement[3] = new MenuOption { DisplayName = "Speed", _type = "submenu", AssociatedString = "Speed" };
                    Movement[4] = new MenuOption { DisplayName = "Platforms", _type = "toggle", AssociatedBool = false };
                    Movement[5] = new MenuOption { DisplayName = "UpsideDown Monkey", _type = "toggle", AssociatedBool = false };
                    Movement[6] = new MenuOption { DisplayName = "WateryAir", _type = "toggle", AssociatedBool = false };
                    Movement[7] = new MenuOption { DisplayName = "LongArms", _type = "toggle", AssociatedBool = false };
                    Movement[8] = new MenuOption { DisplayName = "[BROKEN] SpinBot", _type = "toggle", AssociatedBool = false };
                    Movement[9] = new MenuOption { DisplayName = "WASD Fly", _type = "toggle", AssociatedBool = false };
                    Movement[10] = new MenuOption { DisplayName = "Next ->", _type = "submenu", AssociatedString = "Movement2" };
                    Movement[11] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };
                    Movement2 = new MenuOption[5];
                    Movement2[0] = new MenuOption { DisplayName = "Timer", _type = "toggle", AssociatedBool = false };
                    Movement2[1] = new MenuOption { DisplayName = "FloatyMonkey", _type = "toggle", AssociatedBool = false };
                    Movement2[2] = new MenuOption { DisplayName = "Climbable Gorillas", _type = "toggle", AssociatedBool = false };
                    Movement2[3] = new MenuOption { DisplayName = "Near Pulse", _type = "toggle", AssociatedBool = false };
                    Movement2[4] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };
                    Speed = new MenuOption[5];
                    Speed[0] = new MenuOption { DisplayName = "Speed", _type = "toggle", AssociatedBool = false };
                    Speed[1] = new MenuOption { DisplayName = "Speed (LG)", _type = "toggle", AssociatedBool = false };
                    Speed[2] = new MenuOption { DisplayName = "Speed (RG)", _type = "toggle", AssociatedBool = false };
                    Speed[3] = new MenuOption { DisplayName = "Near Speed", _type = "toggle", AssociatedBool = false };
                    Speed[4] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Visual = new MenuOption[12];
                    Visual[0] = new MenuOption { DisplayName = "Chams", _type = "toggle", AssociatedBool = false };
                    Visual[1] = new MenuOption { DisplayName = "BoxESP", _type = "toggle", AssociatedBool = false };
                    Visual[2] = new MenuOption { DisplayName = "HollowBoxESP", _type = "toggle", AssociatedBool = false };
                    Visual[3] = new MenuOption { DisplayName = "Sky Colour", _type = "STRINGslider", StringArray = new string[] { "Default", "Purple", "Red", "Cyan", "Green" } };
                    Visual[4] = new MenuOption { DisplayName = "WhyIsEveryoneLookingAtMe", _type = "toggle", AssociatedBool = false };
                    Visual[5] = new MenuOption { DisplayName = "No Expressions", _type = "toggle", AssociatedBool = false };
                    Visual[6] = new MenuOption { DisplayName = "Tracers", _type = "toggle", AssociatedBool = false };
                    Visual[7] = new MenuOption { DisplayName = "BoneESP", _type = "toggle", AssociatedBool = false };
                    Visual[8] = new MenuOption { DisplayName = "First Person Cam", _type = "toggle", AssociatedBool = false };
                    Visual[9] = new MenuOption { DisplayName = "Day Time", _type = "button", AssociatedString = "daytime" };
                    Visual[10] = new MenuOption { DisplayName = "Night Time", _type = "button", AssociatedString = "nighttime" };
                    Visual[11] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Player = new MenuOption[12];
                    Player[0] = new MenuOption { DisplayName = "NoFinger", _type = "toggle", AssociatedBool = false };
                    Player[1] = new MenuOption { DisplayName = "TagGun", _type = "toggle", AssociatedBool = false };
                    Player[2] = new MenuOption { DisplayName = "[BROKEN] LegMod", _type = "toggle", AssociatedBool = false };
                    Player[3] = new MenuOption { DisplayName = "CreeperMonkey", _type = "toggle", AssociatedBool = false };
                    Player[4] = new MenuOption { DisplayName = "GhostMonkey", _type = "toggle", AssociatedBool = false };
                    Player[5] = new MenuOption { DisplayName = "InvisMonkey", _type = "toggle", AssociatedBool = false };
                    Player[6] = new MenuOption { DisplayName = "TagAura", _type = "toggle", AssociatedBool = false };
                    Player[7] = new MenuOption { DisplayName = "TagAll", _type = "toggle", AssociatedBool = false };
                    Player[8] = new MenuOption { DisplayName = "[BROKEN] FreezeMonke", _type = "toggle", AssociatedBool = false };
                    Player[9] = new MenuOption { DisplayName = "Desync", _type = "toggle", AssociatedBool = false };
                    Player[10] = new MenuOption { DisplayName = "HitBoxes", _type = "toggle", AssociatedBool = false };
                    Player[11] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Modders = new MenuOption[5];
                    Modders[0] = new MenuOption { DisplayName = "Break NameTags", _type = "toggle", AssociatedBool = false };
                    Modders[1] = new MenuOption { DisplayName = "Break ModCheckers", _type = "toggle", AssociatedBool = false };
                    Modders[2] = new MenuOption { DisplayName = "Pc Check Bypass", _type = "toggle", AssociatedBool = false };
                    Modders[3] = new MenuOption { DisplayName = "Fake Quest Menu", _type = "toggle", AssociatedBool = false };
                    Modders[4] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Computer = new MenuOption[8];
                    Computer[0] = new MenuOption { DisplayName = "Disconnect", _type = "button", AssociatedString = "disconnect" };
                    Computer[1] = new MenuOption { DisplayName = "RandomIdentity", _type = "button", AssociatedString = "randomidentity" };
                    Computer[2] = new MenuOption { DisplayName = "Join GTC", _type = "button", AssociatedString = "join GTC" };
                    Computer[3] = new MenuOption { DisplayName = "Join TTT", _type = "button", AssociatedString = "join TTT" };
                    Computer[4] = new MenuOption { DisplayName = "Join YTTV", _type = "button", AssociatedString = "join YTTV" };
                    Computer[5] = new MenuOption { DisplayName = "Modded Casual", _type = "button", AssociatedString = "moddedcasual" };
                    Computer[6] = new MenuOption { DisplayName = "Modded Infection", _type = "button", AssociatedString = "moddedinfection" };
                    Computer[7] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Account = new MenuOption[5];
                    Account[0] = new MenuOption { DisplayName = "Disconnect", _type = "button", AssociatedString = "disconnectplayfab" };
                    Account[1] = new MenuOption { DisplayName = "Server: USW", _type = "button", AssociatedString = "serverusw" };
                    Account[2] = new MenuOption { DisplayName = "Server: US", _type = "button", AssociatedString = "serverus" };
                    Account[3] = new MenuOption { DisplayName = "Server: EU", _type = "button", AssociatedString = "servereu" };
                    Account[4] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Settings = new MenuOption[7];
                    Settings[0] = new MenuOption { DisplayName = "Colour Settings", _type = "submenu", AssociatedString = "ColourSettings" };
                    Settings[1] = new MenuOption { DisplayName = "Mod Settings", _type = "submenu", AssociatedString = "ModSettings" };
                    Settings[2] = new MenuOption { DisplayName = "MenuPosition", _type = "STRINGslider", StringArray = new string[] { "Top Right", "Top Left", "Middle" } };
                    Settings[3] = new MenuOption { DisplayName = "Config", _type = "STRINGslider", StringArray = Configs.GetConfigFileNames() };
                    Settings[4] = new MenuOption { DisplayName = "Load Config", _type = "button", AssociatedString = "loadconfig" };
                    Settings[5] = new MenuOption { DisplayName = "Save Config", _type = "button", AssociatedString = "saveconfig" };
                    Settings[6] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    ColourSettings = new MenuOption[6];
                    ColourSettings[0] = new MenuOption { DisplayName = "MenuColour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue", "RGB" } };
                    ColourSettings[1] = new MenuOption { DisplayName = "Ghost Colour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[2] = new MenuOption { DisplayName = "Beam Colour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[3] = new MenuOption { DisplayName = "ESP Colour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[4] = new MenuOption { DisplayName = "Ghost Opacity", _type = "STRINGslider", StringArray = new string[] { "100%", "80%", "60%", "30%", "20%", "0%" } };
                    ColourSettings[5] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    ModSettings = new MenuOption[4];
                    ModSettings[0] = new MenuOption { DisplayName = "Movement Settings", _type = "submenu", AssociatedString = "MovementSettings" };
                    ModSettings[1] = new MenuOption { DisplayName = "Visual Settings", _type = "submenu", AssociatedString = "VisualSettings" };
                    ModSettings[2] = new MenuOption { DisplayName = "Player Settings", _type = "submenu", AssociatedString = "PlayerSettings" };
                    ModSettings[3] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    MovementSettings = new MenuOption[12];
                    MovementSettings[0] = new MenuOption { DisplayName = "WASD Fly Speed", _type = "STRINGslider", StringArray = new string[] { "5", "7", "10", "13", "16" } };
                    MovementSettings[1] = new MenuOption { DisplayName = "FloatMonkey Ammount", _type = "STRINGslider", StringArray = new string[] { "1.1", "1.2", "1.4", "1.6", "1.8", "2", "2.2", "2.4", "2.6", "2.8", "3", "3.2", "3.4", "3.6", "3.8", "4", "Anti Grav" } };
                    MovementSettings[2] = new MenuOption { DisplayName = "WallWalk Ammount", _type = "STRINGslider", StringArray = new string[] { "6.8", "7", "7.5", "7.8", "8", "8.5", "8.8", "9", "9.5", "9.8" } };
                    MovementSettings[3] = new MenuOption { DisplayName = "Timer Speed", _type = "STRINGslider", StringArray = new string[] { "1.03x", "1.06x", "1.09x", "1.1x", "1.13x", "1.16x", "1.19x", "1.2x", "1.23x", "1.26", "1.29", "1.3x", "2x", "3x", "4x", "5x" } };
                    MovementSettings[4] = new MenuOption { DisplayName = "ExcelFly Speed", _type = "STRINGslider", StringArray = new string[] { "Super Slow", "Slow", "Medium", "Fast", "Super Fast" } };
                    MovementSettings[5] = new MenuOption { DisplayName = "Speed Ammount", _type = "STRINGslider", StringArray = new string[] { "7", "7.2", "7.4", "7.6", "7.8", "8", "8.2", "8.4", "8.6" } };//, "8.8", "9", "No Limit" } }; //quick "Fix" but apperantly anything above was detected... -Lars
                    MovementSettings[6] = new MenuOption { DisplayName = "Speed (LG) Ammount", _type = "STRINGslider", StringArray = new string[] { "7", "7.2", "7.4", "7.6", "7.8", "8", "8.2", "8.4", "8.6" } };//, "8.8", "9", "No Limit" } };
                    MovementSettings[7] = new MenuOption { DisplayName = "Speed (RG) Ammount", _type = "STRINGslider", StringArray = new string[] { "7", "7.2", "7.4", "7.6", "7.8", "8", "8.2", "8.4", "8.6" } };//, "8.8", "9", "No Limit" } };
                    MovementSettings[8] = new MenuOption { DisplayName = "Near Speed Ammount", _type = "STRINGslider", StringArray = new string[] { "7", "7.2", "7.4", "7.6", "7.8", "8", "8.2", "8.4", "8.6" } };//, "8.8", "9", "No Limit" } };
                    MovementSettings[9] = new MenuOption { DisplayName = "Near Speed Distance", _type = "STRINGslider", StringArray = new string[] { "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25" } };
                    MovementSettings[10] = new MenuOption { DisplayName = "Near Pulse Distance", _type = "STRINGslider", StringArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" } };
                    MovementSettings[10] = new MenuOption { DisplayName = "Near Pulse Ammount", _type = "STRINGslider", StringArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" } };
                    MovementSettings[11] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    VisualSettings = new MenuOption[4];
                    VisualSettings[0] = new MenuOption { DisplayName = "First Person FOV", _type = "STRINGslider", StringArray = new string[] { "60", "70", "80", "90", "100", "110", "120", "130", "140" } };
                    VisualSettings[1] = new MenuOption { DisplayName = "Tracer Position", _type = "STRINGslider", StringArray = new string[] { "RHand", "LHand", "Head", "Screen" } };
                    VisualSettings[2] = new MenuOption { DisplayName = "Tracer Size", _type = "STRINGslider", StringArray = new string[] { "Extremely Small", "Super Small", "Small", "Medium", "Large", "Giant", "Huge" } };
                    VisualSettings[3] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    PlayerSettings = new MenuOption[3];
                    PlayerSettings[0] = new MenuOption { DisplayName = "TagAura Ammount", _type = "STRINGslider", StringArray = new string[] { "Really Close", "Close", "Legit", "Semi Legit", "Semi Blatant", "Blatant", "Rage" } };
                    PlayerSettings[1] = new MenuOption { DisplayName = "HitBoxes Radius", _type = "STRINGslider", StringArray = new string[] { "Really Close", "Close", "Legit", "Semi Legit", "Semi Blatant", "Blatant", "Rage" } };
                    PlayerSettings[2] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };


                    MenuState = "Main";
                    CurrentViewingMenu = MainMenu;
                }

                UpdateMenuState(new MenuOption(), null, null);

                CustomConsole.LogToConsole("[COLOSSAL] Updated Menu State");
            }
            catch (Exception ex) {
                CustomConsole.LogToConsole("[COLOSSAL] " + ex.ToString());
            }
            
        }
        public static void Load() {
            if (!agreement)
            {
                if(GameObject.Find("CLIENT_HUB_AGREEMENT") == null) //watch as this breaks the whole menu
                    Menu.LoadOnce();
                Menu.HUDObj2.transform.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
                Menu.HUDObj2.transform.rotation = Menu.MainCamera.transform.rotation;
                bool state = SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand);
                bool state2 = SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand);
                if (state && state2 && !Menu.menutogglecooldown)
                {
                    Menu.menutogglecooldown = true;
                    Menu.agreement = true;
                    UnityEngine.Object.Destroy(GameObject.Find("CLIENT_HUB_AGREEMENT"));
                    Menu.LoadOnce();
                }
                else
                    Menu.menutogglecooldown = false;
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    Menu.menutogglecooldown = true;
                    Menu.agreement = true;
                    UnityEngine.Object.Destroy(GameObject.Find("CLIENT_HUB_AGREEMENT"));
                    Menu.LoadOnce();
                    return;
                }
            }
            else
            {
                bool state3 = SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand);
                bool state4 = SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand);
                if (state3 && state4 && !Menu.menutogglecooldown)
                {
                    Menu.menutogglecooldown = true;
                    Menu.HUDObj2.active = !Menu.HUDObj2.active;
                    Menu.GUIToggled = !Menu.GUIToggled;

                    Menu.UpdateMenuState(new MenuOption(), null, null);
                }
                if (!state3 && !state4 && Menu.menutogglecooldown)
                    Menu.menutogglecooldown = false;
                if (Menu.GUIToggled)
                {
                    Menu.HUDObj2.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
                    Menu.HUDObj2.transform.rotation = Menu.MainCamera.transform.rotation;


                    //KEYBOARD CONTROLS
                    Keyboard current = Keyboard.current;
                    if (current.upArrowKey.wasPressedThisFrame)
                    {
                        Menu.inputcooldown = true;
                        if (Menu.SelectedOptionIndex == 0)
                            Menu.SelectedOptionIndex = Menu.CurrentViewingMenu.Count<MenuOption>() - 1;
                        else
                            Menu.SelectedOptionIndex--;
                        Menu.UpdateMenuState(new MenuOption(), null, null);
                    }
                    if (current.downArrowKey.wasPressedThisFrame)
                    {
                        Menu.inputcooldown = true;
                        if (Menu.SelectedOptionIndex + 1 == Menu.CurrentViewingMenu.Count<MenuOption>())
                            Menu.SelectedOptionIndex = 0;
                        else
                            Menu.SelectedOptionIndex++;
                        Menu.UpdateMenuState(new MenuOption(), null, null);
                    }
                    if (current.enterKey.wasPressedThisFrame)
                    {
                        Menu.inputcooldown = true;
                        Menu.UpdateMenuState(Menu.CurrentViewingMenu[Menu.SelectedOptionIndex], null, "optionhit");
                    }
                    if (CurrentViewingMenu[SelectedOptionIndex]._type == "STRINGslider")
                    {
                        if (current.leftArrowKey.wasPressedThisFrame)
                        {
                            if (CurrentViewingMenu[SelectedOptionIndex].stringsliderind == 0)
                                CurrentViewingMenu[SelectedOptionIndex].stringsliderind = CurrentViewingMenu[SelectedOptionIndex].StringArray.Count() - 1;
                            else
                                CurrentViewingMenu[SelectedOptionIndex].stringsliderind = CurrentViewingMenu[SelectedOptionIndex].stringsliderind - 1;
                            Menu.inputcooldown = true;
                        }
                        if (current.rightArrowKey.wasPressedThisFrame)
                        {
                            if ((CurrentViewingMenu[SelectedOptionIndex].stringsliderind + 1) == CurrentViewingMenu[SelectedOptionIndex].StringArray.Count())
                                CurrentViewingMenu[SelectedOptionIndex].stringsliderind = 0;
                            else
                                CurrentViewingMenu[SelectedOptionIndex].stringsliderind = CurrentViewingMenu[SelectedOptionIndex].stringsliderind + 1;
                            Menu.inputcooldown = true;
                        }
                        UpdateMenuState(new MenuOption(), null, null);
                    }


                    //VR CONTROLS
                    bool rightGrab = ControllerInputPoller.instance.rightGrab;
                    if (SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand))
                    {
                        bool trigger = SteamVR_Actions.gorillaTag_RightTriggerClick.GetState(SteamVR_Input_Sources.RightHand);
                        if (trigger && !Menu.inputcooldown)
                        {
                            Menu.inputcooldown = true;
                            if (Menu.SelectedOptionIndex + 1 == Menu.CurrentViewingMenu.Count<MenuOption>())
                                Menu.SelectedOptionIndex = 0;
                            else
                                Menu.SelectedOptionIndex++;
                            Menu.UpdateMenuState(new MenuOption(), null, null);
                        }
                        if (!trigger && !rightGrab && Menu.inputcooldown)
                            Menu.inputcooldown = false;

                        if (CurrentViewingMenu[SelectedOptionIndex]._type == "STRINGslider")
                        {
                            if (rightGrab && !Menu.inputcooldown)
                            {
                                if ((CurrentViewingMenu[SelectedOptionIndex].stringsliderind + 1) == CurrentViewingMenu[SelectedOptionIndex].StringArray.Count())
                                    CurrentViewingMenu[SelectedOptionIndex].stringsliderind = 0;
                                else
                                    CurrentViewingMenu[SelectedOptionIndex].stringsliderind = CurrentViewingMenu[SelectedOptionIndex].stringsliderind + 1;
                                Menu.inputcooldown = true;
                            }
                            UpdateMenuState(new MenuOption(), null, null);
                        }
                        if (rightGrab && !Menu.inputcooldown)
                        {
                            Menu.inputcooldown = true;
                            Menu.UpdateMenuState(Menu.CurrentViewingMenu[Menu.SelectedOptionIndex], null, "optionhit");
                        }
                    }
                }
                //PluginConfig.anticrash = MainMenu[8].AssociatedBool;
                PluginConfig.noti = MainMenu[7].AssociatedBool;
                PluginConfig.overlay = MainMenu[8].AssociatedBool;
                PluginConfig.csghostclient = MainMenu[9].AssociatedBool;
                PluginConfig.tooltips = MainMenu[10].AssociatedBool;
                PluginConfig.showstartup = MainMenu[11].AssociatedBool;

                //Movement
                PluginConfig.excelfly = Movement[0].AssociatedBool;
                PluginConfig.tfly = Movement[1].AssociatedBool;
                PluginConfig.wallwalk = Movement[2].AssociatedBool;
                PluginConfig.speed = Speed[0].AssociatedBool;
                PluginConfig.speedlg = Speed[1].AssociatedBool;
                PluginConfig.speedrg = Speed[2].AssociatedBool;
                PluginConfig.nearspeed = Speed[3].AssociatedBool;
                PluginConfig.platforms = Movement[4].AssociatedBool;
                PluginConfig.upsidedownmonkey = Movement[5].AssociatedBool;
                PluginConfig.wateryair = Movement[6].AssociatedBool;
                PluginConfig.longarms = Movement[7].AssociatedBool;
                PluginConfig.SpinBot = Movement[8].AssociatedBool;
                PluginConfig.WASDFly = Movement[9].AssociatedBool;
                //Movement2
                PluginConfig.Timer = Movement2[0].AssociatedBool;
                PluginConfig.FloatyMonkey = Movement2[1].AssociatedBool;
                PluginConfig.ClimbableGorillas = Movement2[2].AssociatedBool;

                //Visual
                PluginConfig.chams = Visual[0].AssociatedBool;
                PluginConfig.boxesp = Visual[1].AssociatedBool;
                PluginConfig.hollowboxesp = Visual[2].AssociatedBool;
                PluginConfig.whyiseveryonelookingatme = Visual[4].AssociatedBool;
                PluginConfig.noexpressions = Visual[5].AssociatedBool;
                PluginConfig.tracers = Visual[6].AssociatedBool;
                PluginConfig.boneesp = Visual[7].AssociatedBool;
                PluginConfig.firstperson = Visual[8].AssociatedBool;

                //Player
                PluginConfig.nofinger = Player[0].AssociatedBool;
                PluginConfig.taggun = Player[1].AssociatedBool;
                PluginConfig.legmod = Player[2].AssociatedBool;
                PluginConfig.creepermonkey = Player[3].AssociatedBool;
                PluginConfig.ghostmonkey = Player[4].AssociatedBool;
                PluginConfig.invismonkey = Player[5].AssociatedBool;
                PluginConfig.tagaura = Player[6].AssociatedBool;
                PluginConfig.tagall = Player[7].AssociatedBool;
                PluginConfig.freezemonkey = Player[8].AssociatedBool;
                PluginConfig.desync = Player[9].AssociatedBool;

                //Modders
                PluginConfig.breaknametags = Modders[0].AssociatedBool;
                PluginConfig.breakmodcheckers = Modders[1].AssociatedBool;
                PluginConfig.pccheckbypass = Modders[2].AssociatedBool;
                PluginConfig.fakequestmenu = Modders[3].AssociatedBool;

                //Settings
                PluginConfig.MenuPos = Settings[2].stringsliderind;
                //Colour Settings
                PluginConfig.MenuColour = ColourSettings[0].stringsliderind;
                PluginConfig.GhostColour = ColourSettings[1].stringsliderind;
                PluginConfig.BeamColour = ColourSettings[2].stringsliderind;
                PluginConfig.ESPColour = ColourSettings[3].stringsliderind;
                PluginConfig.GhostOpacity = ColourSettings[4].stringsliderind;
                //Misc Settings
                PluginConfig.WASDFlySpeed = MovementSettings[0].stringsliderind;
                PluginConfig.FloatMonkeyAmmount = MovementSettings[1].stringsliderind;
                PluginConfig.WallWalkAmmount = MovementSettings[2].stringsliderind;
                PluginConfig.TimerSpeed = MovementSettings[3].stringsliderind;
                PluginConfig.ExcelFlySpeed = MovementSettings[4].stringsliderind;
                PluginConfig.speedammount = MovementSettings[5].stringsliderind;
                PluginConfig.speedlgammount = MovementSettings[6].stringsliderind;
                PluginConfig.speedrgammount = MovementSettings[7].stringsliderind;
                PluginConfig.nearspeedmmount = MovementSettings[8].stringsliderind;
                PluginConfig.nearspeeddistance = MovementSettings[9].stringsliderind;
                PluginConfig.NearPulseDistance = MovementSettings[10].stringsliderind;

                PluginConfig.FirstPersonFOV = VisualSettings[0].stringsliderind;
                PluginConfig.TracerPosition = VisualSettings[1].stringsliderind;
                PluginConfig.TracerSize = VisualSettings[2].stringsliderind;

                PluginConfig.TagAuraAmmount = PlayerSettings[0].stringsliderind;
                PluginConfig.hitboxesradius = PlayerSettings[1].stringsliderind;


                string ToDraw = Plugin.sussy ? $"<color={MenuColour}>SUSSY : {MenuState}</color>\n" : $"<color={MenuColour}>COLOSSAL : {MenuState}</color>\n";
                int i = 0;
                if (CurrentViewingMenu != null)
                {
                    foreach (MenuOption opt in CurrentViewingMenu)
                    {
                        if (SelectedOptionIndex == i)
                            ToDraw = ToDraw + "> ";
                        ToDraw = ToDraw + opt.DisplayName;

                        if (opt._type == "toggle")
                        {
                            if (opt.AssociatedBool == true)
                            {
                                ToDraw = ToDraw + $" <color={MenuColour}>[ON]</color>";
                                //ToDraw = ToDraw + $" <color={MenuColourString}>[ON]</color>";
                            }
                            else
                                ToDraw = ToDraw + " <color=red>[OFF]</color>";
                        }
                        if (opt._type == "STRINGslider")
                            ToDraw = ToDraw + ": " + opt.StringArray[opt.stringsliderind] + " [" + (opt.stringsliderind + 1).ToString() + "/" + opt.StringArray.Length.ToString() + "]";
                        ToDraw = ToDraw + "\n";
                        i++;
                    }
                    Testtext.text = ToDraw;
                }
                else
                    Debug.Log("Null for some reason");


                if (PluginConfig.MenuRGB)
                    menurgb += Time.deltaTime;
                else
                {
                    if (menurgb != 0)
                        menurgb = 0;
                }
                if (PluginConfig.MenuRGB)
                {
                        MenuColourString = "magenta";
                    if (menurgb >= 0.2f)
                        MenuColourString = "red";
                    if (menurgb >= 0.3f)
                        MenuColourString = "green";
                    if (menurgb >= 0.4f)
                        MenuColourString = "blue";
                    if (menurgb >= 0.5f)
                        MenuColourString = "cyan";
                    if (menurgb >= 0.6f)
                        MenuColourString = "yellow";

                    if (menurgb >= 0.6f)
                        menurgb = 0;
                }
            }
        }
        static void UpdateMenuState(MenuOption option, string _MenuState, string OperationType) {
            try {
                ToolTips.HandToolTips(MenuState, SelectedOptionIndex);

                if (OperationType == "optionhit") 
                {
                    if (option._type == "submenu") 
                    {
                        if (option.AssociatedString == "Movement")
                            CurrentViewingMenu = Movement;
                        if (option.AssociatedString == "Movement2")
                            CurrentViewingMenu = Movement2;
                        if (option.AssociatedString == "Visual")
                            CurrentViewingMenu = Visual;
                        if (option.AssociatedString == "Player")
                            CurrentViewingMenu = Player;
                        if (option.AssociatedString == "Computer")
                            CurrentViewingMenu = Computer;
                        if (option.AssociatedString == "Modders")
                            CurrentViewingMenu = Modders;
                        if (option.AssociatedString == "Account")
                            CurrentViewingMenu = Account;
                        if (option.AssociatedString == "Settings")
                            CurrentViewingMenu = Settings;

                        if (option.AssociatedString == "Speed")
                        {
                            CurrentViewingMenu = Speed;
                            Debug.Log("<color=magenta>Speed...</color>");
                        }

                        if (option.AssociatedString == "ColourSettings")
                            CurrentViewingMenu = ColourSettings;
                        if (option.AssociatedString == "ModSettings")
                            CurrentViewingMenu = ModSettings;
                        if (option.AssociatedString == "MovementSettings")
                            CurrentViewingMenu = MovementSettings;
                        if (option.AssociatedString == "VisualSettings")
                            CurrentViewingMenu = VisualSettings;
                        if (option.AssociatedString == "PlayerSettings")
                            CurrentViewingMenu = PlayerSettings;

                        if (option.AssociatedString == "Back")
                            CurrentViewingMenu = MainMenu;

                        MenuState = option.AssociatedString;
                        SelectedOptionIndex = 0;
                    }
                    if (option._type == "toggle") {
                        if (option.AssociatedBool == false) 
                        {
                            option.AssociatedBool = true;
                            CustomConsole.LogToConsole($"\nToggled {option.DisplayName} : {option.AssociatedBool}");
                            Notifacations.SendNotification($"<color={MenuColour}>[TOGGLED]</color> {option.DisplayName} : {option.AssociatedBool}");
                        }
                        else 
                        {
                            option.AssociatedBool = false;
                            CustomConsole.LogToConsole($"\nToggled {option.DisplayName} : {option.AssociatedBool}");
                            Notifacations.SendNotification($"<color={MenuColour}>[TOGGLED]</color> {option.DisplayName} : {option.AssociatedBool}");
                        }
                    }
                    if (option._type == "button")
                    {
                        //Computer
                        if (option.AssociatedString == "disconnect")
                        {
                            PhotonNetwork.Disconnect();
                        }
                        if (option.AssociatedString == "randomidentity")
                        {
                            string[] names =
                            {
                                "COLOSSUS",
                                "123",
                                "PP",
                                "PBBV",
                                "SKILLISSUE",
                                "IMAGINE",
                                "SREN17",
                                "YOURMOM",
                                "GUMMIES",
                                "WATCH",
                                "MOUSE",
                                "BOZO",
                                "KEYS",
                                "PINE",
                                "LEMMING",
                                "ELECTRONIC",
                                "BODA",
                                "TTTPIG",
                                "TTTPIGFAN",
                                "555999",
                                "83459230",
                                "923059439",
                                "IJ48FNSF",
                                "MF4J8T9J",
                                "J3VU",
                                "3993NF39",
                                "FEMBOY",
                                "RAWR",
                                "MEOW",
                            };
                            System.Random rand = new System.Random();
                            int index = rand.Next(names.Length);
                            PhotonNetwork.LocalPlayer.NickName = names[index];
                            GorillaComputer.instance.currentName = names[index];
                            GorillaComputer.instance.savedName = names[index];
                            PlayerPrefs.SetString("GorillaLocomotion.PlayerName", names[index]);
                        }
                        if (option.AssociatedString == "join GTC")
                        {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("GTC");
                        }
                        if (option.AssociatedString == "join TTT")
                        {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("TTT");
                        }
                        if (option.AssociatedString == "join YTTV")
                        {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("YTTV");
                        }
                        if (option.AssociatedString == "moddedcasual")
                        {
                            GorillaComputer.instance.currentGameMode.Value = "MODDED_MODDED_CASUALCASUAL";
                        }
                        if (option.AssociatedString == "moddedinfection")
                        {
                            GorillaComputer.instance.currentGameMode.Value = "MODDED_MODDED_DEFAULTINFECTION";
                        }
                        if (option.AssociatedString == "daytime")
                        {
                            BetterDayNightManager.instance.SetTimeOfDay(1);
                        }
                        if (option.AssociatedString == "nighttime")
                        {
                            BetterDayNightManager.instance.SetTimeOfDay(0);
                        }

                        //Account
                        if (option.AssociatedString == "disconnectplayfab")
                        {
                            PhotonNetwork.Disconnect();
                            PlayFabClientAPI.ForgetAllCredentials();
                        }


                        if (option.AssociatedString == "loadconfig")
                        {
                            Configs.LoadConfig($"{Configs.folderPath}\\{Settings[3].StringArray[Settings[3].stringsliderind]}.json");
                        }
                        if (option.AssociatedString == "saveconfig")
                            Configs.SaveConfig();
                    }


                    switch (ColourSettings[0].stringsliderind)
                    {
                        case 0:
                            if (PluginConfig.MenuRGB)
                                PluginConfig.MenuRGB = false;
                            MenuColour = "magenta";
                            break;
                        case 1:
                            if (PluginConfig.MenuRGB)
                                PluginConfig.MenuRGB = false;
                            MenuColour = "red";
                            break;
                        case 2:
                            if (PluginConfig.MenuRGB)
                                PluginConfig.MenuRGB = false;
                            MenuColour = "yellow";
                            break;
                        case 3:
                            if (PluginConfig.MenuRGB)
                                PluginConfig.MenuRGB = false;
                            MenuColour = "green";
                            break;
                        case 4:
                            if (PluginConfig.MenuRGB)
                                PluginConfig.MenuRGB = false;
                            MenuColour = "blue";
                            break;
                        case 5:
                            PluginConfig.MenuRGB = true;
                            break;
                    }
                    switch (Settings[2].stringsliderind)
                    {
                        case 0:
                            Testtext.rectTransform.localPosition = new Vector3(-2.4f, 1f, 2f);
                            break;
                        case 1:
                            Testtext.rectTransform.localPosition = new Vector3(-2.4f, 1f, 0f);
                            break;
                        case 2:
                            Testtext.rectTransform.localPosition = new Vector3(-0.8f, 0f, 0f);
                            break;
                    }
                }
            } catch {
            }
        }
    }
}