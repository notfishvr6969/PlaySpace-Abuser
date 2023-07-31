using UnityEngine;
using UnityEngine.XR;
using HarmonyLib;
using GorillaLocomotion;

namespace PlaySpaceAbuser
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class PlayerMovementControllerPatch
    {
        private static void Update()
        {
            Prefix();
        }
        private static void Prefix()
        {
            InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.gripButton, out bool rightGripButton);
            if (rightGripButton)
            {
                Player.Instance.transform.position += Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 5f;
            }
        }
    }
}
