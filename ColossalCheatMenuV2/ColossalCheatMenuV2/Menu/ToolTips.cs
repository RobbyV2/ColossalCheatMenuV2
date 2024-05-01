using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Colossal.Menu
{
    internal class ToolTips : MonoBehaviour
    {
        public static string[] MainMenutips = new string[]
        {
            $"<color={Menu.MenuColour}>Submenu</color>\nMovement mods",
            $"<color={Menu.MenuColour}>Submenu</color>\nVisual mods",
            $"<color={Menu.MenuColour}>Submenu</color>\nPlayer mods",
            $"<color={Menu.MenuColour}>Submenu</color>\nComputer mods",
            $"<color={Menu.MenuColour}>Submenu</color>\nModders mods",
            $"<color={Menu.MenuColour}>Submenu</color>\nAccount mods",
            $"<color={Menu.MenuColour}>Submenu</color>\nMenu settings",
            $"<color={Menu.MenuColour}>Passive</color>\nToggles noti",
            $"<color={Menu.MenuColour}>Passive</color>\nToggles overlay",
            $"<color={Menu.MenuColour}>Passive</color>\nToggles all colossal visuals",
            $"<color={Menu.MenuColour}>Passive</color>\nToggles tooltips",
            $"<color={Menu.MenuColour}>Passive</color>\nToggles the startup animation",
        };

        public static string[] Movementtips = new string[]
        {
            $"<color={Menu.MenuColour}>Primary Buttons</color>\nFly Like IronMan",
            $"<color={Menu.MenuColour}>L Secondary & L Joystick</color>\nFly in your hands direction",
            $"<color={Menu.MenuColour}>R Grip</color>\nPoint palms towards walls to stick",
            $"<color={Menu.MenuColour}>Submenu</color>\nDisplays Speed Options",
            $"<color={Menu.MenuColour}>R Grip & L Grip</color>\nJump on air",
            $"<color={Menu.MenuColour}>Passive</color>\nFlip upside down",
            $"<color={Menu.MenuColour}>R Grip & L Grip</color>\nSwim in air",
            $"<color={Menu.MenuColour}>R Joystick > L Trigger & R Trigger</color>\nScale the world",
            $"<color={Menu.MenuColour}>Passive</color>\nConstantly spins your ss rig",
            $"<color={Menu.MenuColour}>W & A & S & D</color>\nFly when not in vr",
        };
        public static string[] Movement2tips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nSpeed up time",
            $"<color={Menu.MenuColour}>R Secondary</color>\nScale gravity",
            $"<color={Menu.MenuColour}>L Or R Grip</color>\nClimb Gorillas",
        };
        public static string[] Speedtips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nAdds a speed boost",
            $"<color={Menu.MenuColour}>L Grip</color>\nAdds a speed boost",
            $"<color={Menu.MenuColour}>R Grip</color>\nAdds a speed boost",
            $"<color={Menu.MenuColour}>R Grip</color>\nAdds a speed boost when near infected",
        };

        public static string[] Visualtips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nHighlight monkies through walls",
            $"<color={Menu.MenuColour}>Passive</color>\nHighlight monkies through walls",
            $"<color={Menu.MenuColour}>Passive</color>\nHighlight monkies through walls",
            $"<color={Menu.MenuColour}>Passive</color>\nChange the sky colour",
            $"<color={Menu.MenuColour}>Passive</color>\nMake everyone look at you",
            $"<color={Menu.MenuColour}>Passive</color>\nTurn off facial features",
            $"<color={Menu.MenuColour}>Passive</color>\nPoints tracers at monkies",
            $"<color={Menu.MenuColour}>Passive</color>\nHighlight monkies through walls",
        };

        public static string[] Playertips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nRemoves hand animations",
            $"<color={Menu.MenuColour}>R Joystick</color>\nTag with a gun",
            $"<color={Menu.MenuColour}>Passive</color>\nAdds legs",
            $"<color={Menu.MenuColour}>L Trigger & R Trigger</color>\nPoints and looks at monkies",
            $"<color={Menu.MenuColour}>R Secondary</color>\nFreezes ss rig",
            $"<color={Menu.MenuColour}>L Secondary</color>\nGo invis",
            $"<color={Menu.MenuColour}>Passive</color>\nAutomatically tags nearest monkey",
            $"<color={Menu.MenuColour}>Passive</color>\nTags all monkies",
            $"<color={Menu.MenuColour}>L Grip</color>\nFreeze ss rig and move",
            $"<color={Menu.MenuColour}>Passive</color>\nDesyncs hitbox and visual position",
            $"<color={Menu.MenuColour}>Passive</color>\nIncreases how far you can tag from",
        };

        public static string[] Moddertips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nBreaks nametag mods",
            $"<color={Menu.MenuColour}>Passive</color>\nBreaks modcheck mods",
            $"<color={Menu.MenuColour}>Passive</color>\nDisables Igloo to pass a PC check",
            $"<color={Menu.MenuColour}>Passive</color>\nMoves hands like quest menu is open",
        };

        public static string[] Computertips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nDisconnects from room",
            $"<color={Menu.MenuColour}>Passive</color>\nRandomly changes name",
            $"<color={Menu.MenuColour}>Passive</color>\nJoins code GTC",
            $"<color={Menu.MenuColour}>Passive</color>\nJoins code TTT",
            $"<color={Menu.MenuColour}>Passive</color>\nJoins code YTTV",
            $"<color={Menu.MenuColour}>Passive</color>\nSets gamemode to modded",
            $"<color={Menu.MenuColour}>Passive</color>\nSets gamemode to modded",
        };

        public static string[] Accounttips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nDisconnect from playfab",
            $"<color={Menu.MenuColour}>Passive</color>\nChange server region",
            $"<color={Menu.MenuColour}>Passive</color>\nChange server region",
            $"<color={Menu.MenuColour}>Passive</color>\nChange server region",
        };

        public static string[] Settingstips = new string[]
        {
            $"<color={Menu.MenuColour}>Submenu</color>\nMenu Colour options",
            $"<color={Menu.MenuColour}>Submenu</color>\nMod options",
            $"<color={Menu.MenuColour}>Passive</color>\nMenu position",
            $"<color={Menu.MenuColour}>Passive</color>\nConfig to load",
            $"<color={Menu.MenuColour}>Passive</color>\nLoad selected config",
            $"<color={Menu.MenuColour}>Passive</color>\nSave menu settings",
        };
        public static string[] SettingsColourtips = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nGUI colour",
            $"<color={Menu.MenuColour}>Passive</color>\nExtra rig colour",
            $"<color={Menu.MenuColour}>Passive</color>\nTagging beam colour",
            $"<color={Menu.MenuColour}>Passive</color>\nESP colour",
            $"<color={Menu.MenuColour}>Passive</color>\nExtra rig opacity",
        };
        public static string[] SettingsMovement = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nWASD speed",
            $"<color={Menu.MenuColour}>Passive</color>\nGravity ammount",
            $"<color={Menu.MenuColour}>Passive</color>\nWall walk strength",
            $"<color={Menu.MenuColour}>Passive</color>\nGame speed",
            $"<color={Menu.MenuColour}>Passive</color>\nExcel Fly Speed",
            $"<color={Menu.MenuColour}>Passive</color>\nSpeed boost ammount",
            $"<color={Menu.MenuColour}>Passive</color>\nSpeed boost ammount",
            $"<color={Menu.MenuColour}>Passive</color>\nSpeed boost ammount",
            $"<color={Menu.MenuColour}>Passive</color>\nNear speed boost ammount",
            $"<color={Menu.MenuColour}>Passive</color>\nNear speed boost distance",
        };
        public static string[] SettingsVisual = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nCamera Mod FOV",
            $"<color={Menu.MenuColour}>Passive</color>\nTracer Position",
            $"<color={Menu.MenuColour}>Passive</color>\nTracer Beam Size",
        };
        public static string[] SettingsPlayer = new string[]
        {
            $"<color={Menu.MenuColour}>Passive</color>\nAura distance",
            $"<color={Menu.MenuColour}>Passive</color>\nHow far you can tag from",
        };


        public static GameObject HUDObj;
        public static GameObject HUDObj2;
        static GameObject MainCamera;
        static Text Testtext;
        private static TextAnchor textAnchor = TextAnchor.UpperRight;
        static Material AlertText = new Material(Shader.Find("GUI/Text Shader"));
        static Text NotifiText;
        private static GameObject TestText;

        public void Update()
        {
            if(HUDObj2 != null)
            {
                HUDObj2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                HUDObj2.transform.LookAt(GorillaTagger.Instance.headCollider.transform);
                HUDObj2.transform.rotation *= Quaternion.Euler(0, 180, 0);
            }
        }
        private static string[] GetTooltipArray(string category)
        {
            switch (category)
            {
                case "Main":
                    return MainMenutips;
                case "Back":
                    return MainMenutips;
                case "Movement":
                    return Movementtips;
                case "Movement2":
                    return Movement2tips;
                case "Speed":
                    return Speedtips;
                case "Visual":
                    return Visualtips;
                case "Player":
                    return Playertips;
                case "Modders":
                    return Moddertips;
                case "Computer":
                    return Computertips;
                case "Account":
                    return Accounttips;
                case "Settings":
                    return Settingstips;
                case "ColourSettings":
                    return SettingsColourtips;
                case "MovementSettings":
                    return SettingsMovement;
                case "VisualSettings":
                    return SettingsVisual;
                case "PlayerSettings":
                    return SettingsPlayer;
                default:
                    return null;
            }
        }
        public static void HandToolTips(string category, int selectedIndex)
        {
            if (Menu.GUIToggled && PluginConfig.tooltips)
            {
                if(Menu.agreement)
                {
                    //CustomConsole.LogToConsole("[COLOSSAL] Spawning ToolTips");

                    MainCamera = GameObject.Find("Main Camera");
                    if (HUDObj == null)
                    {
                        HUDObj = new GameObject();
                        HUDObj2 = new GameObject();
                        HUDObj2.name = "CLIENT_HUB_TOOLTIP";
                        HUDObj.name = "CLIENT_HUB_TOOLTIP";
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
                        HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0.3f, 0.2f, 2.2f);
                        var Temp = HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
                        Temp.y = -270f;
                        HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
                        HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(Temp);
                    }

                    string[] tooltipArray = GetTooltipArray(category);

                    if (tooltipArray != null && selectedIndex >= 0 && selectedIndex < tooltipArray.Length)
                    {
                        string tooltipText = tooltipArray[selectedIndex];

                        if (!string.IsNullOrWhiteSpace(tooltipText))
                        {
                            if (TestText == null)
                            {
                                TestText = new GameObject();
                                TestText.transform.parent = HUDObj.transform;
                                Testtext = TestText.AddComponent<Text>();
                                Testtext.fontSize = 10;
                                Testtext.font = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().font;
                                Testtext.rectTransform.sizeDelta = new Vector2(260, 300);
                                Testtext.rectTransform.localScale = new Vector3(0.004f, 0.004f, 0.1f);
                                Testtext.rectTransform.localPosition = new Vector3(2.15f, -0.7f, 0.1f);
                                Testtext.material = AlertText;
                                NotifiText = Testtext;
                                Testtext.alignment = TextAnchor.UpperLeft;
                            }

                            Testtext.text = tooltipText;
                        }
                        else
                        {
                            if (TestText != null)
                                Testtext.text = "";
                            else
                                CustomConsole.LogToConsole("[COLOSSAL] ToolTip is null");
                        }
                    }
                    else
                    {
                        if (TestText != null)
                            Testtext.text = "";
                    }
                }
            }
            else
            {
                if (TestText != null)
                    Testtext.text = "";
                else
                    CustomConsole.LogToConsole("[COLOSSAL] ToolTip is null");
            }
        }
    }
}
