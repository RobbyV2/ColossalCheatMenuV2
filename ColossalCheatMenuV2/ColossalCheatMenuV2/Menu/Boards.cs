using System;
using Colossal;
using GorillaNetworking;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Colossal.Menu
{
    internal class Boards : MonoBehaviour
    {
        public static GorillaLevelScreen[] joinScreens;

        public static Material boardmat;
        public static Material defaultboardmat;

        public static bool tempbool = false;

        public static string joinscreentext;
        public static string coctext;
        public static string defaultcoctext;

        private float rainbowtext;
        private static string textcolour = "magenta";
        public void Start()
        {
            Boards.defaultboardmat = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/motdscreen").GetComponent<Renderer>().material;
            Boards.defaultcoctext = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text;
            Boards.boardmat = new Material(Shader.Find("GorillaTag/UberShader"));
            Boards.boardmat.color = new Color(0.6f, 0f, 0.8f);
        }

        public void Update()
        {
            if (!PluginConfig.fullghostmode)
            {
                if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("TreeRoom").gameObject.activeSelf && !Boards.tempbool)
                {
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/forestatlas (combined by EdMeshCombinerSceneProcessor)").GetComponent<Renderer>().material = Boards.boardmat;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/screen").GetComponent<Renderer>().material = Boards.boardmat;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = Boards.boardmat;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = Boards.boardmat;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = Boards.boardmat;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = Boards.boardmat;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = Boards.boardmat;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd/motdtext").GetComponent<Text>().color = Color.cyan;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().color = Color.cyan;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().text = "UPDATES";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenForest").GetComponent<Text>().color = Color.cyan;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCave").GetComponent<Text>().color = Color.cyan;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCity Front").GetComponent<Text>().color = Color.cyan;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCanyon").GetComponent<Text>().color = Color.cyan;
                    CustomConsole.LogToConsole("[COLOSSAL] Loaded Colours!");
                    Boards.tempbool = true;
                }
                coctext = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features and undetected mods. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base\nStarry: Dev/Tester</color><color=cyan>\nWM/Will: No Fingers/Full Bright\nAntic/ChatGPT: Tester\nCunzaki: Tester\nMios: Tester/Pain In The Ass\n\nCurrent Menu Version: {Plugin.version}</color>";
                if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("TreeRoom").gameObject.activeSelf)
                {
                    this.rainbowtext += Time.deltaTime;
                    if (this.rainbowtext >= 0.1f)
                    {
                        Boards.textcolour = "magenta";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "<color=" + Boards.textcolour + ">COLOSSAL CHEAT MENU V2</color>";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = Boards.coctext;
                    }
                    if (this.rainbowtext >= 0.2f)
                    {
                        Boards.textcolour = "red";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "<color=" + Boards.textcolour + ">COLOSSAL CHEAT MENU V2</color>";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = Boards.coctext;
                    }
                    if (this.rainbowtext >= 0.3f)
                    {
                        Boards.textcolour = "green";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "<color=" + Boards.textcolour + ">COLOSSAL CHEAT MENU V2</color>";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = Boards.coctext;
                    }
                    if (this.rainbowtext >= 0.4f)
                    {
                        Boards.textcolour = "blue";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "<color=" + Boards.textcolour + ">COLOSSAL CHEAT MENU V2</color>";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = Boards.coctext;
                    }
                    if (this.rainbowtext >= 0.5f)
                    {
                        Boards.textcolour = "cyan";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "<color=" + Boards.textcolour + ">COLOSSAL CHEAT MENU V2</color>";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = Boards.coctext;
                    }
                    if (this.rainbowtext >= 0.6f)
                    {
                        Boards.textcolour = "yellow";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "<color=" + Boards.textcolour + ">COLOSSAL CHEAT MENU V2</color>";
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = Boards.coctext;
                    }
                    if (this.rainbowtext >= 0.6f)
                    {
                        this.rainbowtext = 0f;
                        return;
                    }
                }
            }
            else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("TreeRoom").gameObject.activeSelf && Boards.tempbool)
            {
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/forestatlas (combined by EdMeshCombinerSceneProcessor)").GetComponent<Renderer>().material = Boards.defaultboardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/screen").GetComponent<Renderer>().material = Boards.defaultboardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = Boards.defaultboardmat;
                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = Boards.defaultboardmat;
                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = Boards.defaultboardmat;
                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = Boards.defaultboardmat;
                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = Boards.defaultboardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd/motdtext").GetComponent<Text>().color = Color.white;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().color = Color.white;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().text = "MESSAGE OF THE DAY";
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenForest").GetComponent<Text>().color = Color.white;
                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCave").GetComponent<Text>().color = Color.white;
                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCity Front").GetComponent<Text>().color = Color.white;
                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCanyon").GetComponent<Text>().color = Color.white;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = "CODE OF CONDUCT";
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = Boards.defaultcoctext;
                CustomConsole.LogToConsole("[COLOSSAL] Loaded Colours! real");
                Boards.tempbool = false;
            }
        }
    }
}
