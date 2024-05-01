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
    public class FloatyMonkey : MonoBehaviour
    {
        private float ammount;
        public void Update()
        {
            if (PluginConfig.FloatyMonkey)
            {
                switch (PluginConfig.FloatMonkeyAmmount)
                {
                    case 0:
                        ammount = 1.1f;
                        break;
                    case 1:
                        ammount = 1.2f;
                        break;
                    case 2:
                        ammount = 1.4f;
                        break;
                    case 3:
                        ammount = 1.6f;
                        break;
                    case 4:
                        ammount = 1.8f;
                        break;
                    case 5:
                        ammount = 2;
                        break;
                    case 6:
                        ammount = 2.2f;
                        break;
                    case 7:
                        ammount = 2.4f;
                        break;
                    case 8:
                        ammount = 2.6f;
                        break;
                    case 9:
                        ammount = 2.8f;
                        break;
                    case 10:
                        ammount = 3;
                        break;
                    case 11:
                        ammount = 3.2f;
                        break;
                    case 12:
                        ammount = 3.4f;
                        break;
                    case 13:
                        ammount = 3.6f;
                        break;
                    case 14:
                        ammount = 3.8f;
                        break;
                    case 15:
                        ammount = 4f;
                        break;
                    case 16:
                        //ammount = 10;
                        ammount = -Physics.gravity.y; // think this is more accurate
                        break;
                }

                if (ControllerInputPoller.instance.rightControllerSecondaryButton)
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (ammount / Time.deltaTime)), ForceMode.Acceleration);
            }
            else
            {
                Destroy(holder.GetComponent<FloatyMonkey>());
            }
        }
    }
}
