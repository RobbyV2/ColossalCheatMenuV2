using BepInEx;
using Colossal.Menu;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class Timer : MonoBehaviour
    {
        public static float timespeed;
        public void Update()
        {
            if (PluginConfig.Timer)
            {
                switch (PluginConfig.TimerSpeed)
                {
                    case 0:
                        timespeed = 1.03f;
                        break;
                    case 1:
                        timespeed = 1.06f;
                        break;
                    case 2:
                        timespeed = 1.09f;
                        break;
                    case 3:
                        timespeed = 1.1f;
                        break;
                    case 4:
                        timespeed = 1.13f;
                        break;
                    case 5:
                        timespeed = 1.16f;
                        break;
                    case 6:
                        timespeed = 1.19f;
                        break;
                    case 7:
                        timespeed = 1.2f;
                        break;
                    case 8:
                        timespeed = 1.23f;
                        break;
                    case 9:
                        timespeed = 1.26f;
                        break;
                    case 10:
                        timespeed = 1.29f;
                        break;
                    case 11:
                        timespeed = 1.3f;
                        break;
                    case 12:
                        timespeed = 2f;
                        break;
                    case 13:
                        timespeed = 3f;
                        break;
                    case 14:
                        timespeed = 4f;
                        break;
                    case 15:
                        timespeed = 5f;
                        break;
                }

                Time.timeScale = timespeed;
            }
            else
            {
                if(Time.timeScale != 1)
                    Time.timeScale = 1;

                Destroy(holder.GetComponent<Timer>());
            }
        }
    }
}
