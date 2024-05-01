using Colossal.Menu;
using Colossal.Mods;
using Colossal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ColossalCheatMenuV2.Mods
{
    class NearPulse : MonoBehaviour
    {
        public void Update()
        {
            if (PluginConfig.NearPulse)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.isOfflineVRRig && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.ToLower().Contains("fected"))
                    {
                        float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position);
                        if (vrrig.mainSkin.material.name.ToLower().Contains("fected") && distance <= PluginConfig.NearPulseDistance)
                        {
                            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddExplosionForce(PluginConfig.NearPulseAmmount, vrrig.head.headTransform.position, PluginConfig.NearPulseDistance);
                        }
                    }
                }
            }
            else
                Destroy(Plugin.holder.GetComponent<NearPulse>());;
        }
    }
}