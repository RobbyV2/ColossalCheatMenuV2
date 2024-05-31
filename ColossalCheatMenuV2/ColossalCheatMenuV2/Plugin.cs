using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using Colossal.Menu;
using Colossal.Menu.ClientHub;
using Colossal.Menu.ClientHub.Notifacation;
using Colossal.Mods;
using Colossal.Patches;
using ColossalCheatMenuV2.Menu;
using ColossalCheatMenuV2.Mods;
using GorillaNetworking;
using Newtonsoft.Json.Linq;
using Photon.Pun;
using PlayFab;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEngine.Random;
using static Valve.VR.SteamVR_ExternalCamera;

namespace Colossal 
{
    public class Plugin : MonoBehaviour 
    {
        public static GameObject holder;
        public static Font gtagfont;

        public static float version = 5.9f;

        public static bool sussy = false;
        public static bool oculus = false;

        public static float playtime = 0;
        public static string playtimestring;

        public void Start()
        {
            CustomConsole.LogToConsole("[COLOSSAL] Plugin Start Call");


            AutoUpdate();


            CustomConsole.LogToConsole("[COLOSSAL] Spawned Holder");
            holder = new GameObject();
            holder.name = "Holder";
            holder.AddComponent<Boards>();
            holder.AddComponent<EventNotifacation>();
            holder.AddComponent<JoinNotifacation>();
            holder.AddComponent<LeaveNotifacation>();
            holder.AddComponent<MasterChangeNotifacation>();
            holder.AddComponent<Configs>();
            holder.AddComponent<Controls>();
            holder.AddComponent<GUICreator>();


            string[] oculusDlls = Directory.GetFiles(Environment.CurrentDirectory, "OculusXRPlugin.dll", SearchOption.AllDirectories);
            if (oculusDlls.Length > 0)
                oculus = true;


            gtagfont = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().font;

            if (gtagfont != null && holder != null) // Me after writing semi good code 😭 -Colossus
            {
                Menu.Menu.LoadOnce();
                CustomConsole.LogToConsole("[COLOSSAL] Loaded menu start");

                Overlay.SpawnOverlay();
                CustomConsole.LogToConsole("[COLOSSAL] Loaded overlay");
                
                Notifacations.SpawnNoti();
                CustomConsole.LogToConsole("[COLOSSAL] Loaded noti");
            }
        }
        public void Update() 
        {
            Menu.Menu.Load();
            Dictionary<Type, bool> componentConditions = new Dictionary<Type, bool>
                {
                    { typeof(CustomConsole), true },
                    { typeof(ThisGuyIsUsingColossal), true },
                    { typeof(LongArm), PluginConfig.longarms },
                    { typeof(WhyIsEveryoneLookingAtMe), PluginConfig.whyiseveryonelookingatme },
                    { typeof(ExcelFly), PluginConfig.excelfly },
                    { typeof(WateryAir), PluginConfig.wateryair },
                    { typeof(FreezeMonkey), PluginConfig.freezemonkey },
                    { typeof(Platforms), PluginConfig.platforms },
                    { typeof(TFly), PluginConfig.tfly },
                    { typeof(UpsideDownMonkey), PluginConfig.upsidedownmonkey },
                    { typeof(Chams), PluginConfig.chams },
                    { typeof(HollowBoxEsp), PluginConfig.hollowboxesp },
                    { typeof(BoxEsp), PluginConfig.boxesp },
                    { typeof(CreeperMonkey), PluginConfig.creepermonkey },
                    { typeof(GhostMonkey), PluginConfig.ghostmonkey },
                    { typeof(InvisMonkey), PluginConfig.invismonkey },
                    { typeof(LegMod), PluginConfig.legmod },
                    { typeof(TagGun), PluginConfig.taggun },
                    { typeof(TagAll), PluginConfig.tagall },
                    { typeof(BreakModChecker), PluginConfig.breakmodcheckers },
                    { typeof(BreakNameTags), PluginConfig.breaknametags },
                    { typeof(SpinBot), PluginConfig.SpinBot },
                    { typeof(Desync), PluginConfig.desync },
                    { typeof(FakeQuestMenu), PluginConfig.fakequestmenu },
                    { typeof(WASDFly), PluginConfig.WASDFly },
                    { typeof(FloatyMonkey), PluginConfig.FloatyMonkey },
                    { typeof(TagAura), PluginConfig.tagaura },
                    { typeof(WallWalk), PluginConfig.wallwalk },
                    { typeof(Timer), PluginConfig.Timer },
                    { typeof(Tracers), PluginConfig.tracers },
                    { typeof(BoneESP), PluginConfig.boneesp },
                    { typeof(firstperson), PluginConfig.firstperson },
                    { typeof(ClimbableGorillas), PluginConfig.ClimbableGorillas },
                    { typeof(HitBoxes), PluginConfig.hitboxes },
                    { typeof(NearPulse), PluginConfig.NearPulse },
                    { typeof(PlayerScale), PluginConfig.PlayerScale },
                    { typeof(FullBright), PluginConfig.fullbright },
                    { typeof(Panic), PluginConfig.Panic },
                };
            foreach (var kvp in componentConditions)
            {
                if (holder != null)
                {
                    if (kvp.Value && holder.GetComponent(kvp.Key) == null)
                    {
                        holder.AddComponent(kvp.Key);
                    }
                }
                else
                {
                    CustomConsole.LogToConsole("[COLOSSAL] Holder is null");
                    holder = new GameObject();
                }
            }


            // Playtime counter
            playtime += Time.deltaTime;

            int hours = (int)(playtime / 3600);
            int minutes = (int)((playtime % 3600) / 60);
            int seconds = (int)(playtime % 60);

            playtimestring = "";
            if (hours > 0)
                playtimestring += hours.ToString("00") + ":";
            if (minutes > 0 || hours > 0)
                playtimestring += minutes.ToString("00") + ":";
            playtimestring += seconds.ToString("00");
        }

        public void AutoUpdate()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(directoryPath, "*ColossalCheatMenu*.dll", SearchOption.AllDirectories);

            if (files.Length > 0)
            {
                string filePath = files[0];
                CustomConsole.LogToConsole($"[COLOSSAL] Found CCM: {filePath}");

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Version Stuff (Auto Updater)
                        string rawDataVersion = client.GetStringAsync("https://raw.githubusercontent.com/ColossusYTTV/ColossalCheatMenuV2/main/AutoUpdate/version.txt").Result;
                        CustomConsole.LogToConsole($"[COLOSSAL] Current version on server: {rawDataVersion}");
                        CustomConsole.LogToConsole($"[COLOSSAL] Current version on Local: {version}");

                        float serverVersion;
                        if (float.TryParse(rawDataVersion, out serverVersion))
                        {
                            if (version < serverVersion)
                            {
                                CustomConsole.LogToConsole("[COLOSSAL] Local is on an old update. Will Update on restart...");

                                string serverFileUrl = "https://github.com/ColossusYTTV/ColossalCheatMenuV2/raw/main/AutoUpdate/ColossalCheatMenuV2.dll";
                                string tempFilePath = Path.GetTempFileName();

                                using (WebClient webClient = new WebClient())
                                {
                                    try
                                    {
                                        webClient.DownloadFile(serverFileUrl, tempFilePath);
                                        CustomConsole.LogToConsole("[COLOSSAL] Downloaded new CCM version.");

                                        File.Delete(filePath);
                                        CustomConsole.LogToConsole("[COLOSSAL] Deleted old menu dll.");

                                        File.Move(tempFilePath, filePath);
                                        CustomConsole.LogToConsole("[COLOSSAL] Moved new menu dll into place.");
                                    }
                                    catch (WebException ex)
                                    {
                                        CustomConsole.LogToConsole($"[COLOSSAL] Error downloading file: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                CustomConsole.LogToConsole("[COLOSSAL] Local is up-to-date!");
                            }
                        }
                        else
                        {
                            CustomConsole.LogToConsole("[COLOSSAL] Failed to parse server version.");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        CustomConsole.LogToConsole("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                CustomConsole.LogToConsole("[COLOSSAL] No matching file found.");
            }
        }
    }
}