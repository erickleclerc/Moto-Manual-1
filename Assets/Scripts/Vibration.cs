using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class Vibration : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand"))
        {
            Vibrate(InputSystem.GetDevice<XRController>(CommonUsages.RightHand));
        }
        else if (other.gameObject.CompareTag("LeftHand"))
        {
            Vibrate(InputSystem.GetDevice<XRController>(CommonUsages.LeftHand));
        }
    }

    private static void Vibrate(XRController device)
    {
        var command = UnityEngine.InputSystem.XR.Haptics.SendHapticImpulseCommand.Create(0, 1, 0.1f);
        device.ExecuteCommand(ref command);
        //Debug.Log(device.name);
    }
}