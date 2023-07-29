using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ResetLevel : MonoBehaviour
{
    VRInputActions VRInputActions;

    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }


    void Update()
    {
        //Right Controller thumbstick clicked
        if (VRInputActions.MotorcycleControls.ResetScene.WasPressedThisFrame() || Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Resetting level");  
        }
    }
}
