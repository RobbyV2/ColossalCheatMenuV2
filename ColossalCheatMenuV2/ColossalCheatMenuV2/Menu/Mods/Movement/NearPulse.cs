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
                        float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.head.headTransform.position);
                        if (vrrig.mainSkin.material.name.ToLower().Contains("fected") && distance <= PluginConfig.NearPulseDistance)
                        {
                            GorillaTagger.Instance.gameObject.GetComponent<Rigidbody>().AddExplosionForce(PluginConfig.NearPulseAmmount * 1000, vrrig.head.headTransform.position, PluginConfig.NearPulseDistance * 1000);
                        }
                    }
                }
                //can someone fix this
            }
            else
                Destroy(Plugin.holder.GetComponent<NearPulse>());;
        }
    }
}