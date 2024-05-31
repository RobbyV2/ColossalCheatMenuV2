﻿using Colossal.Menu;
using Colossal.Menu.ClientHub;
using GorillaNetworking;
using GTAG_NotificationLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class AntiReport : MonoBehaviour
    {
        public void Update()
        {
            if(PluginConfig.antireport != 0 && PhotonNetwork.InRoom)
            {
                foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
                {
                    if (gorillaPlayerScoreboardLine.linePlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        Transform transform = gorillaPlayerScoreboardLine.reportButton.gameObject.transform;
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (vrrig != GorillaTagger.Instance.offlineVRRig)
                            {
                                float distance = 0.45f;
                                if (Vector3.Distance(vrrig.rightHandTransform.position, transform.position) < distance || Vector3.Distance(vrrig.leftHandTransform.position, transform.position) < distance)
                                {
                                    Notifacations.SendNotification($"<color=red>[ANTIREPORT]</color> {vrrig.playerName} Attempted");

                                    switch (PluginConfig.antireport)
                                    {
                                        case 1:
                                            PhotonNetwork.Disconnect();
                                            break;
                                        case 2:
                                            string currentroom = PhotonNetwork.CurrentRoom.Name;
                                             PhotonNetwork.Disconnect();
                                             PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(currentroom, JoinType.Solo);
                                            break;
                                        case 3:
                                            PhotonNetwork.Disconnect();
                                            PhotonNetwork.JoinRandomRoom();
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
