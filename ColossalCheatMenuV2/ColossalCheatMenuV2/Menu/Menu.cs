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
using Colossal.Patches;
using ColossalCheatMenuV2.Menu;
using Newtonsoft.Json;
using Unity.XR.OpenVR.SimpleJSON;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Colossal.Menu 
{
    public class MenuOption 
    {
        public string DisplayName;
        public string _type;
        public bool AssociatedBool;
        public string AssociatedString;
        public float AssociatedFloat;
        public int AssociatedInt;
        public string[] StringArray;
        public int stringsliderind;
    }

    public class Menu 
    {
        public static bool GUIToggled = true;


        public static GameObject MenuHub;
        public static Text MenuHubText;

        public static GameObject AgreementHub;
        public static Text AgreementHubText;


        public static string MenuColour = "magenta";
        public static float menurgb = 0;

        public static string MenuState = "Main";
        public static int SelectedOptionIndex = 0;
        public static MenuOption[] CurrentViewingMenu = null;
        public static MenuOption[] MainMenu;
        public static MenuOption[] Movement;
        public static MenuOption[] Movement2;
        public static MenuOption[] Visual;
        public static MenuOption[] Player;
        public static MenuOption[] Computer;
        public static MenuOption[] Exploits;
        public static MenuOption[] Saftey;
        public static MenuOption[] Settings;

        public static MenuOption[] Speed;

        public static MenuOption[] TagAura;
        public static MenuOption[] Presets;

        public static MenuOption[] ColourSettings;
        public static MenuOption[] ModSettings;
        public static MenuOption[] MovementSettings;
        public static MenuOption[] VisualSettings;
        public static MenuOption[] PlayerSettings;


        public static bool inputcooldown = false;
        public static bool menutogglecooldown = false;
        public static bool agreement = false;

        public static void LoadOnce() {
            try 
            {
                if (!agreement) 
                    (AgreementHub, AgreementHubText) = GUICreator.CreateTextGUI("<color=magenta><CONTROLS></color>\nLeft Joystick Click (Hold): Control\nRight Grip: Select\nRight Trigger: Scroll\nBoth Joysticks: Toggle UI\n\n<color=magenta><CONTROLS (PC)></color>\nEnterKey: Select\nArrowKey (Up): Move Up\nArrowKey (Down): Move Down\n\n<color=cyan>Press Both Joysticks Or Enter...</color>", "AgreementHub", TextAnchor.MiddleCenter, new Vector3(0, 0f, 2));
                else 
                {
                    // Adding once the menu has been made or like whatever because it causes errors
                    if (Plugin.holder.GetComponent<SpeedMod>() == null)
                        Plugin.holder.AddComponent<SpeedMod>();
                    if (Plugin.holder.GetComponent<SkyColour>() == null)
                        Plugin.holder.AddComponent<SkyColour>();
                    if (Plugin.holder.GetComponent<AntiReport>() == null)
                        Plugin.holder.AddComponent<AntiReport>();

                    // Adding here so you dont see them before you accepted the aggreement
                    if (Plugin.holder.GetComponent<Overlay>() == null)
                        Plugin.holder.AddComponent<Overlay>();

                    if (Plugin.holder.GetComponent<Notifacations>() == null)
                        Plugin.holder.AddComponent<Notifacations>();

                    if (Plugin.holder.GetComponent<ToolTips>() == null)
                        Plugin.holder.AddComponent<ToolTips>();


                    (MenuHub, MenuHubText) = GUICreator.CreateTextGUI("", "MenuHub", TextAnchor.UpperLeft, new Vector3(0, 0.4f, 3.6f));


                    MainMenu = new MenuOption[11];
                    MainMenu[0] = new MenuOption { DisplayName = "Movement", _type = "submenu", AssociatedString = "Movement" };
                    MainMenu[1] = new MenuOption { DisplayName = "Visual", _type = "submenu", AssociatedString = "Visual" };
                    MainMenu[2] = new MenuOption { DisplayName = "Player", _type = "submenu", AssociatedString = "Player" };
                    MainMenu[3] = new MenuOption { DisplayName = "Computer", _type = "submenu", AssociatedString = "Computer" };
                    MainMenu[4] = new MenuOption { DisplayName = "Exploits", _type = "submenu", AssociatedString = "Exploits" };
                    MainMenu[5] = new MenuOption { DisplayName = "Saftey", _type = "submenu", AssociatedString = "Saftey" };
                    MainMenu[6] = new MenuOption { DisplayName = "Settings", _type = "submenu", AssociatedString = "Settings" };
                    MainMenu[7] = new MenuOption { DisplayName = "Notifications", _type = "toggle", AssociatedBool = PluginConfig.Notifications };
                    MainMenu[8] = new MenuOption { DisplayName = "Overlay", _type = "toggle", AssociatedBool = PluginConfig.overlay };
                    MainMenu[9] = new MenuOption { DisplayName = "Full Ghost Mode", _type = "toggle", AssociatedBool = PluginConfig.fullghostmode };
                    MainMenu[10] = new MenuOption { DisplayName = "Tool Tips", _type = "toggle", AssociatedBool = PluginConfig.tooltips };

                    Movement = new MenuOption[12];
                    Movement[0] = new MenuOption { DisplayName = "ExcelFly", _type = "toggle", AssociatedBool = PluginConfig.excelfly };
                    Movement[1] = new MenuOption { DisplayName = "TFly", _type = "toggle", AssociatedBool = PluginConfig.tfly };
                    Movement[2] = new MenuOption { DisplayName = "WallWalk", _type = "toggle", AssociatedBool = PluginConfig.wallwalk };
                    Movement[3] = new MenuOption { DisplayName = "Speed", _type = "submenu", AssociatedString = "Speed" };
                    Movement[4] = new MenuOption { DisplayName = "Platforms", _type = "toggle", AssociatedBool = PluginConfig.platforms };
                    Movement[5] = new MenuOption { DisplayName = "UpsideDown Monkey", _type = "toggle", AssociatedBool = PluginConfig.upsidedownmonkey };
                    Movement[6] = new MenuOption { DisplayName = "WateryAir", _type = "toggle", AssociatedBool = PluginConfig.wateryair };
                    Movement[7] = new MenuOption { DisplayName = "LongArms", _type = "toggle", AssociatedBool = PluginConfig.longarms };
                    Movement[8] = new MenuOption { DisplayName = "[BROKEN] SpinBot", _type = "toggle", AssociatedBool = PluginConfig.SpinBot };
                    Movement[9] = new MenuOption { DisplayName = "WASDFly", _type = "toggle", AssociatedBool = PluginConfig.WASDFly };
                    Movement[10] = new MenuOption { DisplayName = "Next ->", _type = "submenu", AssociatedString = "Movement2" };
                    Movement[11] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };
                    Movement2 = new MenuOption[6];
                    Movement2[0] = new MenuOption { DisplayName = "Timer", _type = "toggle", AssociatedBool = PluginConfig.Timer };
                    Movement2[1] = new MenuOption { DisplayName = "FloatyMonkey", _type = "toggle", AssociatedBool = PluginConfig.FloatyMonkey };
                    Movement2[2] = new MenuOption { DisplayName = "Climbable Gorillas", _type = "toggle", AssociatedBool = PluginConfig.ClimbableGorillas };
                    Movement2[3] = new MenuOption { DisplayName = "Near Pulse", _type = "toggle", AssociatedBool = PluginConfig.NearPulse };
                    Movement2[4] = new MenuOption { DisplayName = "Player Scale", _type = "toggle", AssociatedBool = PluginConfig.PlayerScale };
                    Movement2[5] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };
                    Speed = new MenuOption[5];
                    Speed[0] = new MenuOption { DisplayName = "Speed", _type = "toggle", AssociatedBool = PluginConfig.speed };
                    Speed[1] = new MenuOption { DisplayName = "Speed (LG)", _type = "toggle", AssociatedBool = PluginConfig.speedlg };
                    Speed[2] = new MenuOption { DisplayName = "Speed (RG)", _type = "toggle", AssociatedBool = PluginConfig.speedrg };
                    Speed[3] = new MenuOption { DisplayName = "Near Speed", _type = "toggle", AssociatedBool = PluginConfig.nearspeed };
                    Speed[4] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Visual = new MenuOption[11];
                    Visual[0] = new MenuOption { DisplayName = "Chams", _type = "toggle", AssociatedBool = PluginConfig.chams };
                    Visual[1] = new MenuOption { DisplayName = "BoxESP", _type = "toggle", AssociatedBool = PluginConfig.boxesp };
                    Visual[2] = new MenuOption { DisplayName = "HollowBoxESP", _type = "toggle", AssociatedBool = PluginConfig.hollowboxesp };
                    Visual[3] = new MenuOption { DisplayName = "Sky Colour", _type = "STRINGslider", StringArray = new string[] { "Default", "Purple", "Red", "Cyan", "Green", "Black" } };
                    Visual[4] = new MenuOption { DisplayName = "WhyIsEveryoneLookingAtMe", _type = "toggle", AssociatedBool = PluginConfig.whyiseveryonelookingatme };
                    Visual[5] = new MenuOption { DisplayName = "No Expressions", _type = "toggle", AssociatedBool = PluginConfig.noexpressions };
                    Visual[6] = new MenuOption { DisplayName = "Tracers", _type = "toggle", AssociatedBool = PluginConfig.tracers };
                    Visual[7] = new MenuOption { DisplayName = "BoneESP", _type = "toggle", AssociatedBool = PluginConfig.boneesp };
                    Visual[8] = new MenuOption { DisplayName = "First Person", _type = "toggle", AssociatedBool = PluginConfig.firstperson };
                    Visual[9] = new MenuOption { DisplayName = "Full Bright", _type = "toggle", AssociatedBool = PluginConfig.fullbright };
                    Visual[10] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Player = new MenuOption[12];
                    Player[0] = new MenuOption { DisplayName = "NoFinger", _type = "toggle", AssociatedBool = PluginConfig.nofinger };
                    Player[1] = new MenuOption { DisplayName = "TagGun", _type = "toggle", AssociatedBool = PluginConfig.taggun };
                    Player[2] = new MenuOption { DisplayName = "[BROKEN] LegMod", _type = "toggle", AssociatedBool = PluginConfig.legmod };
                    Player[3] = new MenuOption { DisplayName = "CreeperMonkey", _type = "toggle", AssociatedBool = PluginConfig.creepermonkey };
                    Player[4] = new MenuOption { DisplayName = "GhostMonkey", _type = "toggle", AssociatedBool = PluginConfig.ghostmonkey };
                    Player[5] = new MenuOption { DisplayName = "InvisMonkey", _type = "toggle", AssociatedBool = PluginConfig.invismonkey };
                    Player[6] = new MenuOption { DisplayName = "TagAura", _type = "toggle", AssociatedBool = PluginConfig.tagaura };
                    Player[7] = new MenuOption { DisplayName = "TagAll", _type = "toggle", AssociatedBool = PluginConfig.tagall };
                    Player[8] = new MenuOption { DisplayName = "[BROKEN] FreezeMonke", _type = "toggle", AssociatedBool = PluginConfig.freezemonkey };
                    Player[9] = new MenuOption { DisplayName = "Desync", _type = "toggle", AssociatedBool = PluginConfig.desync };
                    Player[10] = new MenuOption { DisplayName = "HitBoxes", _type = "toggle", AssociatedBool = PluginConfig.hitboxes };
                    Player[11] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Exploits = new MenuOption[5];
                    Exploits[0] = new MenuOption { DisplayName = "Break NameTags", _type = "toggle", AssociatedBool = PluginConfig.breaknametags };
                    Exploits[1] = new MenuOption { DisplayName = "Break ModCheckers", _type = "toggle", AssociatedBool = PluginConfig.breakmodcheckers };
                    Exploits[2] = new MenuOption { DisplayName = "Pc Check Bypass", _type = "toggle", AssociatedBool = PluginConfig.pccheckbypass };
                    Exploits[3] = new MenuOption { DisplayName = "Fake Quest Menu", _type = "toggle", AssociatedBool = PluginConfig.fakequestmenu };
                    Exploits[4] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Computer = new MenuOption[7];
                    Computer[0] = new MenuOption { DisplayName = "Disconnect", _type = "button", AssociatedString = "disconnect" };
                    Computer[1] = new MenuOption { DisplayName = "Join GTC", _type = "button", AssociatedString = "join GTC" };
                    Computer[2] = new MenuOption { DisplayName = "Join TTT", _type = "button", AssociatedString = "join TTT" };
                    Computer[3] = new MenuOption { DisplayName = "Join YTTV", _type = "button", AssociatedString = "join YTTV" };
                    Computer[4] = new MenuOption { DisplayName = "Modded Casual", _type = "button", AssociatedString = "moddedcasual" };
                    Computer[5] = new MenuOption { DisplayName = "Modded Infection", _type = "button", AssociatedString = "moddedinfection" };
                    Computer[6] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Saftey = new MenuOption[4];
                    Saftey[0] = new MenuOption { DisplayName = "Panic", _type = "toggle", AssociatedBool = PluginConfig.Panic };
                    Saftey[1] = new MenuOption { DisplayName = "AntiReport", _type = "STRINGslider", StringArray = new string[] { "Off", "Disconnect", "Reconnect", "Join Random" } };
                    Saftey[2] = new MenuOption { DisplayName = "RandomIdentity", _type = "button", AssociatedString = "randomidentity" };
                    Saftey[3] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    Settings = new MenuOption[7];
                    Settings[0] = new MenuOption { DisplayName = "Colour Settings", _type = "submenu", AssociatedString = "ColourSettings" };
                    Settings[1] = new MenuOption { DisplayName = "Mod Settings", _type = "submenu", AssociatedString = "ModSettings" };
                    Settings[2] = new MenuOption { DisplayName = "MenuPosition", _type = "STRINGslider", StringArray = new string[] { "Top Left", "Middle", "Top Right" } };
                    Settings[3] = new MenuOption { DisplayName = "Config", _type = "STRINGslider", StringArray = new string[0] };
                    Settings[4] = new MenuOption { DisplayName = "Load Config", _type = "button", AssociatedString = "loadconfig" };
                    Settings[5] = new MenuOption { DisplayName = "Save Config", _type = "button", AssociatedString = "saveconfig" };
                    Settings[6] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    ColourSettings = new MenuOption[8];
                    ColourSettings[0] = new MenuOption { DisplayName = "MenuColour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[1] = new MenuOption { DisplayName = "Ghost Colour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[2] = new MenuOption { DisplayName = "Beam Colour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[3] = new MenuOption { DisplayName = "ESP Colour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[4] = new MenuOption { DisplayName = "Ghost Opacity", _type = "STRINGslider", StringArray = new string[] { "100%", "80%", "60%", "30%", "20%", "0%" } };
                    ColourSettings[5] = new MenuOption { DisplayName = "HitBoxes Opacity", _type = "STRINGslider", StringArray = new string[] { "100%", "80%", "60%", "30%", "20%", "0%" } };
                    ColourSettings[6] = new MenuOption { DisplayName = "HitBoxes Colour", _type = "STRINGslider", StringArray = new string[] { "Purple", "Red", "Yellow", "Green", "Blue" } };
                    ColourSettings[7] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    ModSettings = new MenuOption[4];
                    ModSettings[0] = new MenuOption { DisplayName = "Movement Settings", _type = "submenu", AssociatedString = "MovementSettings" };
                    ModSettings[1] = new MenuOption { DisplayName = "Visual Settings", _type = "submenu", AssociatedString = "VisualSettings" };
                    ModSettings[2] = new MenuOption { DisplayName = "Player Settings", _type = "submenu", AssociatedString = "PlayerSettings" };
                    ModSettings[3] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

                    MovementSettings = new MenuOption[13];
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
                    MovementSettings[11] = new MenuOption { DisplayName = "Near Pulse Ammount", _type = "STRINGslider", StringArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" } };
                    MovementSettings[12] = new MenuOption { DisplayName = "<- Back", _type = "submenu", AssociatedString = "Back" };

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
                if(AgreementHub == null) //watch as this breaks the whole menu
                    Menu.LoadOnce();

                if (Controls.LeftJoystick() && Controls.RightJoystick() && !Menu.menutogglecooldown || Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    Menu.menutogglecooldown = true;
                    Menu.agreement = true;
                    UnityEngine.Object.Destroy(AgreementHub);
                    Menu.LoadOnce();
                }
            }
            else
            {
                if (Controls.LeftJoystick() && Controls.RightJoystick() && !Menu.menutogglecooldown)
                {
                    Menu.menutogglecooldown = true;
                    MenuHub.active = !MenuHub.active;
                    Menu.GUIToggled = !Menu.GUIToggled;

                    Menu.UpdateMenuState(new MenuOption(), null, null);
                }
                if (!Controls.LeftJoystick() && !Controls.RightJoystick() && Menu.menutogglecooldown)
                    Menu.menutogglecooldown = false;
                if (Menu.GUIToggled)
                {
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
                            if (CurrentViewingMenu[SelectedOptionIndex].DisplayName == Settings[3].DisplayName)
                            {
                                int arrayLength = CurrentViewingMenu[SelectedOptionIndex].StringArray.Count();
                                // Checking if stringsliderind is within the bounds of StringArray
                                if (CurrentViewingMenu[SelectedOptionIndex].stringsliderind > 0)
                                    CurrentViewingMenu[SelectedOptionIndex].stringsliderind--;
                                else
                                    // Handle the case when stringsliderind is at the beginning of the array
                                    CurrentViewingMenu[SelectedOptionIndex].stringsliderind = arrayLength - 1; // or any other appropriate action
                                inputcooldown = true;
                            }
                            else
                            {
                                foreach (var prop in typeof(PluginConfig).GetFields(BindingFlags.Public | BindingFlags.Static))
                                {
                                    if (prop.Name.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower() == CurrentViewingMenu[SelectedOptionIndex].DisplayName.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower())
                                    {
                                        object currentValue = prop.GetValue(null);
                                        int? currentIntValue = currentValue as int?;

                                        if (currentIntValue.HasValue)
                                        {
                                            int newValue = currentIntValue.Value - 1;
                                            int stringArrayCount = CurrentViewingMenu[SelectedOptionIndex].StringArray.Length;

                                            if (newValue >= stringArrayCount)
                                                newValue = 0;

                                            prop.SetValue(null, newValue);

                                            //CustomConsole.LogToConsole($"\nIncremented {CurrentViewingMenu[SelectedOptionIndex].DisplayName} : {newValue}");
                                        }
                                        else
                                        {
                                            Debug.LogError($"Field '{prop.Name}' is not of type int.");
                                        }

                                        break;
                                    }
                                }
                            }

                            Menu.inputcooldown = true;
                        }
                        if (current.rightArrowKey.wasPressedThisFrame)
                        {
                            if (CurrentViewingMenu[SelectedOptionIndex].DisplayName == Settings[3].DisplayName)
                            {
                                int arrayLength = CurrentViewingMenu[SelectedOptionIndex].StringArray.Count();
                                // Checking if stringsliderind is within the bounds of StringArray
                                if (CurrentViewingMenu[SelectedOptionIndex].stringsliderind < arrayLength - 1)
                                    CurrentViewingMenu[SelectedOptionIndex].stringsliderind++;
                                else
                                    // Handle the case when stringsliderind is at the end of the array
                                    CurrentViewingMenu[SelectedOptionIndex].stringsliderind = 0; // or any other appropriate action
                                inputcooldown = true;
                            }
                            else
                            {
                                foreach (var prop in typeof(PluginConfig).GetFields(BindingFlags.Public | BindingFlags.Static))
                                {
                                    if (prop.Name.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower() == CurrentViewingMenu[SelectedOptionIndex].DisplayName.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower())
                                    {
                                        object currentValue = prop.GetValue(null);
                                        int? currentIntValue = currentValue as int?;

                                        if (currentIntValue.HasValue)
                                        {
                                            int newValue = currentIntValue.Value + 1;
                                            int stringArrayCount = CurrentViewingMenu[SelectedOptionIndex].StringArray.Length;

                                            if (newValue >= stringArrayCount)
                                                newValue = 0;

                                            prop.SetValue(null, newValue);

                                            //CustomConsole.LogToConsole($"\nIncremented {CurrentViewingMenu[SelectedOptionIndex].DisplayName} : {newValue}");
                                        }
                                        else
                                        {
                                            Debug.LogError($"Field '{prop.Name}' is not of type int.");
                                        }

                                        break;
                                    }
                                }
                            }

                            Menu.inputcooldown = true;
                        }
                        UpdateMenuState(new MenuOption(), null, null);
                    }


                    //VR CONTROLS
                    if (Controls.LeftJoystick())
                    {
                        if (Controls.RightTrigger() && !Menu.inputcooldown)
                        {
                            Menu.inputcooldown = true;
                            if (Menu.SelectedOptionIndex + 1 == Menu.CurrentViewingMenu.Count<MenuOption>())
                                Menu.SelectedOptionIndex = 0;
                            else
                                Menu.SelectedOptionIndex++;
                            Menu.UpdateMenuState(new MenuOption(), null, null);
                        }
                        if (!Controls.RightTrigger() && !ControllerInputPoller.instance.rightGrab && Menu.inputcooldown)
                            Menu.inputcooldown = false;

                        if (CurrentViewingMenu[SelectedOptionIndex]._type == "STRINGslider")
                        {
                            if (ControllerInputPoller.instance.rightGrab && !Menu.inputcooldown)
                            {
                                if (CurrentViewingMenu[SelectedOptionIndex].DisplayName == Settings[3].DisplayName)
                                {
                                    int arrayLength = CurrentViewingMenu[SelectedOptionIndex].StringArray.Count();
                                    // Checking if stringsliderind is within the bounds of StringArray
                                    if (CurrentViewingMenu[SelectedOptionIndex].stringsliderind < arrayLength - 1)
                                        CurrentViewingMenu[SelectedOptionIndex].stringsliderind++;
                                    else
                                        // Handle the case when stringsliderind is at the end of the array
                                        CurrentViewingMenu[SelectedOptionIndex].stringsliderind = 0; // or any other appropriate action
                                    inputcooldown = true;
                                }
                                else
                                {
                                    foreach (var prop in typeof(PluginConfig).GetFields(BindingFlags.Public | BindingFlags.Static))
                                    {
                                        if (prop.Name.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower() == CurrentViewingMenu[SelectedOptionIndex].DisplayName.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower())
                                        {
                                            object currentValue = prop.GetValue(null);
                                            int? currentIntValue = currentValue as int?;

                                            if (currentIntValue.HasValue)
                                            {
                                                int newValue = currentIntValue.Value + 1;
                                                int stringArrayCount = CurrentViewingMenu[SelectedOptionIndex].StringArray.Length;

                                                if (newValue >= stringArrayCount)
                                                    newValue = 0;

                                                prop.SetValue(null, newValue);

                                                //CustomConsole.LogToConsole($"\nIncremented {CurrentViewingMenu[SelectedOptionIndex].DisplayName} : {newValue}");
                                            }
                                            else
                                            {
                                                Debug.LogError($"Field '{prop.Name}' is not of type int.");
                                            }

                                            break;
                                        }
                                    }
                                }

                                Menu.inputcooldown = true;
                            }
                            UpdateMenuState(new MenuOption(), null, null);
                        }
                        if (ControllerInputPoller.instance.rightGrab && !Menu.inputcooldown)
                        {
                            Menu.inputcooldown = true;
                            Menu.UpdateMenuState(Menu.CurrentViewingMenu[Menu.SelectedOptionIndex], null, "optionhit");
                        }
                    }
                }
                //PluginConfig.anticrash = MainMenu[8].AssociatedBool;
                MainMenu[7].AssociatedBool = PluginConfig.Notifications;
                MainMenu[8].AssociatedBool = PluginConfig.overlay;
                MainMenu[9].AssociatedBool = PluginConfig.fullghostmode;
                MainMenu[10].AssociatedBool = PluginConfig.tooltips;

                //Movement
                Movement[0].AssociatedBool = PluginConfig.excelfly;
                Movement[1].AssociatedBool = PluginConfig.tfly;
                Movement[2].AssociatedBool = PluginConfig.wallwalk;
                Speed[0].AssociatedBool = PluginConfig.speed;
                Speed[1].AssociatedBool = PluginConfig.speedlg;
                Speed[2].AssociatedBool = PluginConfig.speedrg;
                Speed[3].AssociatedBool = PluginConfig.nearspeed;
                Movement[4].AssociatedBool = PluginConfig.platforms;
                Movement[5].AssociatedBool = PluginConfig.upsidedownmonkey;
                Movement[6].AssociatedBool = PluginConfig.wateryair;
                Movement[7].AssociatedBool = PluginConfig.longarms;
                Movement[8].AssociatedBool = PluginConfig.SpinBot;
                Movement[9].AssociatedBool = PluginConfig.WASDFly;
                //Movement2
                Movement2[0].AssociatedBool = PluginConfig.Timer;
                Movement2[1].AssociatedBool = PluginConfig.FloatyMonkey;
                Movement2[2].AssociatedBool = PluginConfig.ClimbableGorillas;
                Movement2[3].AssociatedBool = PluginConfig.NearPulse;
                Movement2[4].AssociatedBool = PluginConfig.PlayerScale;

                //Visual
                Visual[0].AssociatedBool = PluginConfig.chams;
                Visual[1].AssociatedBool = PluginConfig.boxesp;
                Visual[2].AssociatedBool = PluginConfig.hollowboxesp;
                Visual[3].stringsliderind = PluginConfig.skycolour;
                Visual[4].AssociatedBool = PluginConfig.whyiseveryonelookingatme;
                Visual[5].AssociatedBool = PluginConfig.noexpressions;
                Visual[6].AssociatedBool = PluginConfig.tracers;
                Visual[7].AssociatedBool = PluginConfig.boneesp;
                Visual[8].AssociatedBool = PluginConfig.firstperson;
                Visual[9].AssociatedBool = PluginConfig.fullbright;

                //Player
                Player[0].AssociatedBool = PluginConfig.nofinger;
                Player[1].AssociatedBool = PluginConfig.taggun;
                Player[2].AssociatedBool = PluginConfig.legmod;
                Player[3].AssociatedBool = PluginConfig.creepermonkey;
                Player[4].AssociatedBool = PluginConfig.ghostmonkey;
                Player[5].AssociatedBool = PluginConfig.invismonkey;
                Player[6].AssociatedBool = PluginConfig.tagaura;
                Player[7].AssociatedBool = PluginConfig.tagall;
                Player[8].AssociatedBool = PluginConfig.freezemonkey;
                Player[9].AssociatedBool = PluginConfig.desync;
                Player[10].AssociatedBool = PluginConfig.hitboxes;

                //Modders
                Exploits[0].AssociatedBool = PluginConfig.breaknametags;
                Exploits[1].AssociatedBool = PluginConfig.breakmodcheckers;
                Exploits[2].AssociatedBool = PluginConfig.pccheckbypass;
                Exploits[3].AssociatedBool = PluginConfig.fakequestmenu;

                // Safety
                Saftey[0].AssociatedBool = PluginConfig.Panic;
                Saftey[1].stringsliderind = PluginConfig.antireport;

                //Settings
                Settings[2].stringsliderind = PluginConfig.MenuPosition;
                //Colour Settings
                ColourSettings[0].stringsliderind = PluginConfig.MenuColour;
                ColourSettings[1].stringsliderind = PluginConfig.GhostColour;
                ColourSettings[2].stringsliderind = PluginConfig.BeamColour;
                ColourSettings[3].stringsliderind = PluginConfig.ESPColour;
                ColourSettings[4].stringsliderind = PluginConfig.GhostOpacity;
                ColourSettings[5].stringsliderind = PluginConfig.HitBoxesOpacity;
                ColourSettings[6].stringsliderind = PluginConfig.HitBoxesColour;
                //Misc Settings
                MovementSettings[0].stringsliderind = PluginConfig.WASDFlySpeed;
                MovementSettings[1].stringsliderind = PluginConfig.FloatMonkeyAmmount;
                MovementSettings[2].stringsliderind = PluginConfig.WallWalkAmmount;
                MovementSettings[3].stringsliderind = PluginConfig.TimerSpeed;
                MovementSettings[4].stringsliderind = PluginConfig.ExcelFlySpeed;
                MovementSettings[5].stringsliderind = PluginConfig.speedammount;
                MovementSettings[6].stringsliderind = PluginConfig.speedlgammount;
                MovementSettings[7].stringsliderind = PluginConfig.speedrgammount;
                MovementSettings[8].stringsliderind = PluginConfig.nearspeedammount;
                MovementSettings[9].stringsliderind = PluginConfig.nearspeeddistance;
                MovementSettings[10].stringsliderind = PluginConfig.NearPulseDistance;
                MovementSettings[11].stringsliderind = PluginConfig.NearPulseAmmount;

                VisualSettings[0].stringsliderind = PluginConfig.FirstPersonFOV;
                VisualSettings[1].stringsliderind = PluginConfig.TracerPosition;
                VisualSettings[2].stringsliderind = PluginConfig.TracerSize;

                PlayerSettings[0].stringsliderind = PluginConfig.TagAuraAmmount;
                PlayerSettings[1].stringsliderind = PluginConfig.hitboxesradius;


                string ToDraw = Plugin.sussy ? $"<color={MenuColour}>SUSSY : {MenuState}</color>\n" : $"<color={MenuColour}>COLOSSAL.LOL : {MenuState}</color>\n";
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
                            }
                            else
                                ToDraw = ToDraw + " <color=red>[OFF]</color>";
                        }
                        if (opt._type == "STRINGslider")
                            ToDraw = ToDraw + ": " + opt.StringArray[opt.stringsliderind] + " [" + (opt.stringsliderind + 1).ToString() + "/" + opt.StringArray.Length.ToString() + "]";
                        ToDraw = ToDraw + "\n";
                        i++;
                    }
                    //Testtext.text = ToDraw;
                    MenuHubText.text = ToDraw;
                }
                else
                    Debug.Log("Null for some reason");
            }
        }
        static void UpdateMenuState(MenuOption option, string _MenuState, string OperationType) {
            try {
                ToolTips.HandToolTips(MenuState, SelectedOptionIndex);
                Settings[3].StringArray = Configs.GetConfigFileNames();

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
                        if (option.AssociatedString == "Exploits")
                            CurrentViewingMenu = Exploits;
                        if (option.AssociatedString == "Saftey")
                            CurrentViewingMenu = Saftey;
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

                        var values = new Dictionary<string, object>();
                        foreach (var prop in typeof(PluginConfig).GetFields(BindingFlags.Public | BindingFlags.Static))
                        {
                            values[prop.Name] = prop.GetValue(null);

                            //Debug.Log(prop.Name);

                            if (values.ContainsKey(prop.Name))
                            {
                                object parsedValue = values[prop.Name];
                                bool parsedBoolValue = (bool)parsedValue;

                                if (prop.Name.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower() == option.DisplayName.Replace(" ", "").Replace("(", "").Replace(")", "").ToLower())
                                {
                                    // Toggle the boolean value in PluginConfig based on the display name of the MenuOption
                                    prop.SetValue(null, !parsedBoolValue);
                                   // Debug.Log($"Set boolean field '{prop.Name}' to '{!parsedBoolValue}'.");

                                    CustomConsole.LogToConsole($"\nToggled {option.DisplayName} : {!parsedBoolValue}");
                                    Notifacations.SendNotification($"<color={MenuColour}>[TOGGLED]</color> {option.DisplayName} : {!parsedBoolValue}");
                                }
                            }
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
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("GTC", JoinType.Solo);
                        }
                        if (option.AssociatedString == "join TTT")
                        {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("TTT", JoinType.Solo);
                        }
                        if (option.AssociatedString == "join YTTV")
                        {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("YTTV", JoinType.Solo);
                        }
                        if (option.AssociatedString == "moddedcasual")
                        {
                            GorillaComputer.instance.currentGameMode.Value = "MODDED_MODDED_CASUALCASUAL";
                        }
                        if (option.AssociatedString == "moddedinfection")
                        {
                            GorillaComputer.instance.currentGameMode.Value = "MODDED_MODDED_DEFAULTINFECTION";
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


                    if(PluginConfig.MenuColour != 6)
                    {
                        if (menurgb != 0)
                            menurgb = 0;
                    }
                    switch (PluginConfig.MenuColour)
                    {
                        case 0:
                            MenuColour = "magenta";
                            break;
                        case 1:
                            MenuColour = "red";
                            break;
                        case 2:
                            MenuColour = "yellow";
                            break;
                        case 3:
                            MenuColour = "green";
                            break;
                        case 4:
                            MenuColour = "blue";
                            break;
                    }
                    switch (PluginConfig.MenuPosition)
                    {
                        case 0:
                            MenuHubText.alignment = TextAnchor.UpperLeft;
                            Notifacations.NotiHubText.alignment = TextAnchor.UpperRight;
                            break;
                        case 1:
                            MenuHubText.alignment = TextAnchor.MiddleCenter;
                            Notifacations.NotiHubText.alignment = TextAnchor.UpperLeft;
                            break;
                        case 2:
                            MenuHubText.alignment = TextAnchor.UpperRight;
                            Notifacations.NotiHubText.alignment = TextAnchor.UpperLeft;
                            break;
                    }
                }
            } catch {
            }
        }
    }
}