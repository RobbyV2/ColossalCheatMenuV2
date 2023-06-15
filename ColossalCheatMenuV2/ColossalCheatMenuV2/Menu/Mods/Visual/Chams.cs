﻿using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class Chams : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.chams && PhotonNetwork.InRoom)
            {
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>())
                {
                    if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !vrrig.photonView.IsMine)
                    {
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = new Color(1f, 0f, 0f, 0.4f);
                        }
                        if (!vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = new Color(1f, 0f, 1f, 0.4f);
                        }
                        if (!vrrig.mainSkin.material.name.Contains("fected") && vrrig.photonView.Controller.CustomProperties.ContainsValue("colossal"))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = ThisGuyIsUsingColossal.colour;
                        }
                        if (!vrrig.mainSkin.material.name.Contains("fected") && vrrig.photonView.Controller.IsMasterClient)
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = new Color(0f, 1f, 0f, 0.4f);
                        }
                    }
                }
                ThrowableBug[] bug = GameObject.FindObjectsOfType<ThrowableBug>();
                foreach (ThrowableBug bugthing in bug) {
                    GameObject parentObject =  bugthing.GetComponentInParent<Transform>().gameObject;
                    parentObject.GetComponentInChildren<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    parentObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 0, 0.4f);
                }
            }
            else
            {
                foreach (VRRig vrrig2 in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>())
                {
                    if (!vrrig2.isOfflineVRRig && !vrrig2.isMyPlayer && !vrrig2.photonView.IsMine)
                    {
                        if (vrrig2.mainSkin.material.shader == Shader.Find("GUI/Text Shader") && !vrrig2.isOfflineVRRig)
                        {
                            foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in UnityEngine.Object.FindObjectOfType<GorillaScoreBoard>().lines)
                            {
                                if (gorillaPlayerScoreboardLine.linePlayer == vrrig2.photonView.Controller && gorillaPlayerScoreboardLine.linePlayer != PhotonNetwork.LocalPlayer)
                                {
                                    vrrig2.mainSkin.material = vrrig2.materialsToChangeTo[gorillaPlayerScoreboardLine.currentMatIndex];
                                    break;
                                }
                            }
                        }
                    }
                }
                ThrowableBug[] bug = GameObject.FindObjectsOfType<ThrowableBug>();
                foreach (ThrowableBug bugthing in bug) {
                    GameObject parentObject = bugthing.GetComponentInParent<Transform>().gameObject;
                    if (parentObject.GetComponentInChildren<Renderer>().material.shader == Shader.Find("GUI/Text Shader")) {
                        parentObject.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Standard");
                        parentObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1, 1f);
                    }
                }
            }
        }
    }
}