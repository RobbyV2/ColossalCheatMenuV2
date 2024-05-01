using BepInEx;
using Colossal.Menu;
using Colossal.Menu.ClientHub;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Playables;
namespace Colossal.Menu
{
    public static class PluginConfig
    {
        public static bool excelfly = false;
        public static bool tfly = false;
        public static bool wallwalk = false;
        public static bool speed = false;
        public static bool speedlg = false;
        public static bool speedrg = false;
        public static bool nearspeed = false;
        public static bool platforms = false;
        public static bool upsidedownmonkey = false;
        public static bool wateryair = false;
        public static bool longarms = false;
        public static bool SpinBot = false;
        public static bool WASDFly = false;
        public static bool FloatyMonkey = false;
        public static bool Timer = false;
        public static bool ClimbableGorillas = false;
        public static bool NearPulse = false;

        // Group 2
        public static bool chams = false;
        public static bool boxesp = false;
        public static bool hollowboxesp = false;
        public static bool whyiseveryonelookingatme = false;
        public static bool noexpressions = false;
        public static bool tracers = false;
        public static bool boneesp = false;
        public static bool firstperson = false;

        // Group 3
        public static bool nofinger = false;
        public static bool taggun = false;
        public static bool legmod = false;
        public static bool creepermonkey = false;
        public static bool ghostmonkey = false;
        public static bool invismonkey = false;
        public static bool tagaura = false;
        public static bool tagall = false;
        public static bool freezemonkey = false;
        public static bool desync = false;
        public static bool hitboxes = false;

        // Group 4
        public static bool breaknametags = false;
        public static bool breakmodcheckers = false;
        public static bool pccheckbypass = false;
        public static bool fakequestmenu = false;

        //group 5
        public static int MenuPos = 0;
        public static int MenuColour = 0;
        public static bool MenuRGB = false;
        public static int GhostColour = 0;
        public static int BeamColour = 0;
        public static int ESPColour = 0;
        public static int GhostOpacity = 2;

        public static int WASDFlySpeed = 2;
        public static int FloatMonkeyAmmount = 0;
        public static int TagAuraAmmount = 2;
        public static int WallWalkAmmount = 2;
        public static int TimerSpeed = 0;
        public static int FirstPersonFOV = 0;
        public static int ExcelFlySpeed = 0;
        public static int TracerPosition = 0;
        public static int TracerSize = 0;
        public static int hitboxesradius = 0;
        public static int speedammount = 0;
        public static int speedlgammount = 0;
        public static int speedrgammount = 0;
        public static int nearspeedmmount = 0;
        public static int nearspeeddistance = 0;
        public static int NearPulseDistance = 0;
        public static int NearPulseAmmount = 0;

        //group 6
        public static bool noti = true;
        public static bool overlay = true;
        public static bool csghostclient = true;
        public static bool tooltips = true;
        public static bool showstartup = true;
    }

    internal class Configs : MonoBehaviour
    {
        public static string folderPath = "Colossal";
        public static string fileExtension = ".json";
        public static string fileName = "NewConfig";

        public static string[] GetConfigFileNames()
        {
            string[] result;
            try
            {
                string[] files = Directory.GetFiles(Configs.folderPath, "*" + Configs.fileExtension);
                string[] array = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    array[i] = Path.GetFileNameWithoutExtension(files[i]);
                }
                result = array;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting config file names: " + ex.Message);
                result = new string[]
                {
                    "Error"
                };
            }
            return result;
        }

        public void Start()
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            else if (Directory.GetFiles(folderPath).Length == 0)
                SaveConfig();
        }

        public static void SaveConfig()
        {
            try
            {
                string[] existingFiles = Directory.GetFiles(folderPath, "*" + fileExtension);

                int nextFileNumber = 1;
                while (existingFiles.Any(file => Path.GetFileNameWithoutExtension(file).EndsWith(nextFileNumber.ToString())))
                {
                    nextFileNumber++;
                }

                string newFileName = $"{fileName}_{nextFileNumber}{fileExtension}";

                string filePath = Path.Combine(folderPath, newFileName);

                List<object> values = new List<object>
                        {
                            // Group 1
                            PluginConfig.excelfly,
                            PluginConfig.tfly,
                            PluginConfig.wallwalk,
                            PluginConfig.speed,
                            PluginConfig.speedlg,
                            PluginConfig.speedrg,
                            PluginConfig.nearspeed,
                            PluginConfig.platforms,
                            PluginConfig.upsidedownmonkey,
                            PluginConfig.wateryair,
                            PluginConfig.longarms,
                            PluginConfig.SpinBot,
                            PluginConfig.WASDFly,
                            PluginConfig.FloatyMonkey,
                            //PluginConfig.Timer, //this wasnt here before but i dont wanna break something lmao
                            PluginConfig.TimerSpeed,
                            PluginConfig.ClimbableGorillas,

                            // Group 2
                            PluginConfig.chams,
                            PluginConfig.boxesp,
                            PluginConfig.hollowboxesp,
                            PluginConfig.whyiseveryonelookingatme,
                            PluginConfig.noexpressions,
                            PluginConfig.tracers,
                            PluginConfig.boneesp,
                            PluginConfig.firstperson,

                            // Group 3
                            PluginConfig.nofinger,
                            PluginConfig.taggun,
                            PluginConfig.legmod,
                            PluginConfig.creepermonkey,
                            PluginConfig.ghostmonkey,
                            PluginConfig.invismonkey,
                            PluginConfig.tagaura,
                            PluginConfig.tagall,
                            PluginConfig.freezemonkey,
                            PluginConfig.desync,
                            PluginConfig.hitboxes,

                            // Group 4
                            PluginConfig.breaknametags,
                            PluginConfig.breakmodcheckers,
                            PluginConfig.pccheckbypass,
                            PluginConfig.fakequestmenu,

                            //group 5
                            PluginConfig.noti,
                            PluginConfig.overlay,
                            PluginConfig.csghostclient,
                            PluginConfig.tooltips,
                            PluginConfig.showstartup,

                            //group 6
                            PluginConfig.MenuColour,
                            PluginConfig.MenuPos,
                            PluginConfig.GhostColour,
                            PluginConfig.BeamColour,
                            PluginConfig.ESPColour,
                            PluginConfig.GhostOpacity,

                            //ground 7
                            PluginConfig.WASDFlySpeed,
                            PluginConfig.FloatMonkeyAmmount,
                            PluginConfig.WallWalkAmmount,
                            PluginConfig.TimerSpeed,
                            PluginConfig.ExcelFlySpeed,
                            PluginConfig.speedammount,
                            PluginConfig.speedlgammount,
                            PluginConfig.speedrgammount,
                            PluginConfig.nearspeedmmount,
                            PluginConfig.nearspeeddistance,
                            PluginConfig.NearPulseDistance,
                            PluginConfig.NearPulseAmmount,
                           
                            //group 8
                            PluginConfig.FirstPersonFOV,
                            PluginConfig.TracerPosition,
                            PluginConfig.TracerSize,

                            //group 9
                            PluginConfig.TagAuraAmmount,
                            PluginConfig.hitboxesradius,
                        };

                string jsonContent = JsonConvert.SerializeObject(values, Formatting.Indented);

                File.WriteAllText(filePath, jsonContent);

                Notifacations.SendNotification($"<color=blue>[CONFIG]</color> SAVED : {filePath}");
                Console.WriteLine($"saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving plugin configuration: {ex.Message}");
            }

        }

        public static void LoadConfig(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                List<object> values = JsonConvert.DeserializeObject<List<object>>(json);

                if (values.Count != 67)
                {
                    Console.WriteLine($"Error loading plugin configuration from {filePath}: Incorrect number of values.");
                    Notifacations.SendNotification($"<color=blue>[CONFIG]</color> ERROR : {filePath}");

                    for (int i = 0; i < values.Count; i++)
                    {
                        Debug.Log($"Value at index {i}: {values[i]}");
                    }
                    return;
                }

                //for (int i = 0; i < values.Count; i++)
                //{
                //    Debug.Log($"Value at index {i}: {values[i]}");
                //}

                Menu.Movement[0].AssociatedBool = Convert.ToBoolean(values[0]);
                Menu.Movement[1].AssociatedBool = Convert.ToBoolean(values[1]);
                Menu.Movement[2].AssociatedBool = Convert.ToBoolean(values[2]);
                Menu.Speed[0].stringsliderind = Convert.ToInt32(values[3]);
                Menu.Speed[1].stringsliderind = Convert.ToInt32(values[4]);
                Menu.Speed[2].stringsliderind = Convert.ToInt32(values[5]);
                Menu.Speed[3].stringsliderind = Convert.ToInt32(values[6]);
                Menu.Movement[4].AssociatedBool = Convert.ToBoolean(values[7]);
                Menu.Movement[5].AssociatedBool = Convert.ToBoolean(values[8]);
                Menu.Movement[6].AssociatedBool = Convert.ToBoolean(values[9]);
                Menu.Movement[7].AssociatedBool = Convert.ToBoolean(values[10]);
                Menu.Movement[8].AssociatedBool = Convert.ToBoolean(values[11]);
                Menu.Movement[9].AssociatedBool = Convert.ToBoolean(values[12]);
                Menu.Movement2[1].AssociatedBool = Convert.ToBoolean(values[13]);
                Menu.Movement2[0].AssociatedBool = Convert.ToBoolean(values[14]);
                Menu.Movement2[2].AssociatedBool = Convert.ToBoolean(values[15]);
                Menu.Movement2[3].AssociatedBool = Convert.ToBoolean(values[16]);

                Menu.Visual[0].AssociatedBool = Convert.ToBoolean(values[17]);
                Menu.Visual[1].AssociatedBool = Convert.ToBoolean(values[18]);
                Menu.Visual[2].AssociatedBool = Convert.ToBoolean(values[19]);
                Menu.Visual[4].AssociatedBool = Convert.ToBoolean(values[20]);
                Menu.Visual[5].AssociatedBool = Convert.ToBoolean(values[21]);
                Menu.Visual[6].AssociatedBool = Convert.ToBoolean(values[22]);
                Menu.Visual[7].AssociatedBool = Convert.ToBoolean(values[23]);
                Menu.Visual[8].AssociatedBool = Convert.ToBoolean(values[24]);

                Menu.Player[0].AssociatedBool = Convert.ToBoolean(values[25]);
                Menu.Player[1].AssociatedBool = Convert.ToBoolean(values[26]);
                Menu.Player[2].AssociatedBool = Convert.ToBoolean(values[27]);
                Menu.Player[3].AssociatedBool = Convert.ToBoolean(values[28]);
                Menu.Player[4].AssociatedBool = Convert.ToBoolean(values[29]);
                Menu.Player[5].AssociatedBool = Convert.ToBoolean(values[30]);
                Menu.Player[6].AssociatedBool = Convert.ToBoolean(values[31]);
                Menu.Player[7].AssociatedBool = Convert.ToBoolean(values[32]);
                Menu.Player[8].AssociatedBool = Convert.ToBoolean(values[33]);
                Menu.Player[9].AssociatedBool = Convert.ToBoolean(values[34]);
                Menu.Player[10].AssociatedBool = Convert.ToBoolean(values[35]);

                Menu.Modders[0].AssociatedBool = Convert.ToBoolean(values[36]);
                Menu.Modders[1].AssociatedBool = Convert.ToBoolean(values[37]);
                Menu.Modders[2].AssociatedBool = Convert.ToBoolean(values[38]);
                Menu.Modders[3].AssociatedBool = Convert.ToBoolean(values[39]);

                Menu.MainMenu[7].AssociatedBool = Convert.ToBoolean(values[40]);
                Menu.MainMenu[8].AssociatedBool = Convert.ToBoolean(values[41]);
                Menu.MainMenu[9].AssociatedBool = Convert.ToBoolean(values[42]);
                Menu.MainMenu[10].AssociatedBool = Convert.ToBoolean(values[43]);
                Menu.MainMenu[11].AssociatedBool = Convert.ToBoolean(values[44]);

                Menu.ColourSettings[0].stringsliderind = Convert.ToInt32(values[45]);
                Menu.Settings[2].stringsliderind = Convert.ToInt32(values[46]);
                Menu.ColourSettings[1].stringsliderind = Convert.ToInt32(values[47]);
                Menu.ColourSettings[2].stringsliderind = Convert.ToInt32(values[48]);
                Menu.ColourSettings[3].stringsliderind = Convert.ToInt32(values[49]);
                Menu.ColourSettings[4].stringsliderind = Convert.ToInt32(values[50]);

                Menu.MovementSettings[0].stringsliderind = Convert.ToInt32(values[51]);
                Menu.MovementSettings[1].stringsliderind = Convert.ToInt32(values[52]);
                Menu.MovementSettings[2].stringsliderind = Convert.ToInt32(values[53]);
                Menu.MovementSettings[3].stringsliderind = Convert.ToInt32(values[54]);
                Menu.MovementSettings[4].stringsliderind = Convert.ToInt32(values[55]);
                Menu.MovementSettings[5].stringsliderind = Convert.ToInt32(values[56]);
                Menu.MovementSettings[6].stringsliderind = Convert.ToInt32(values[57]);
                Menu.MovementSettings[7].stringsliderind = Convert.ToInt32(values[58]);
                Menu.MovementSettings[8].stringsliderind = Convert.ToInt32(values[59]);
                Menu.MovementSettings[9].stringsliderind = Convert.ToInt32(values[60]);
                Menu.MovementSettings[10].stringsliderind = Convert.ToInt32(values[61]);
                Menu.MovementSettings[11].stringsliderind = Convert.ToInt32(values[62]);

                Menu.VisualSettings[0].stringsliderind = Convert.ToInt32(values[63]);
                Menu.VisualSettings[1].stringsliderind = Convert.ToInt32(values[64]);
                Menu.VisualSettings[2].stringsliderind = Convert.ToInt32(values[65]);

                Menu.PlayerSettings[0].stringsliderind = Convert.ToInt32(values[66]);
                Menu.PlayerSettings[1].stringsliderind = Convert.ToInt32(values[67]);


                Notifacations.SendNotification($"<color=blue>[CONFIG]</color> LOADED : {Menu.Settings[3].StringArray[Menu.Settings[3].stringsliderind]}");
                Console.WriteLine($"loaded {Menu.Settings[3].StringArray[Menu.Settings[3].stringsliderind]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading plugin configuration from {filePath}: {ex.Message}");
            }

        }
    }
}