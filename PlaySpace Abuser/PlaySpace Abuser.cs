using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using HarmonyLib;
using BepInEx;
using GorillaLocomotion;

namespace PlayerMovementController
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Update", MethodType.Normal)]
    public class PlayerMovementControllerPatch
    {
        private const float MovementSpeed = 10f;
        private static void Update()
        {
            bool isGripButtonPressed = false;
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, devices);

            if (devices.Count > 0 && devices[0].TryGetFeatureValue(CommonUsages.gripButton, out isGripButtonPressed) && isGripButtonPressed)
            {
                Player.Instance.transform.position += Player.Instance.bodyCollider.transform.forward * Time.deltaTime * MovementSpeed;
            }
        }
    }
}
