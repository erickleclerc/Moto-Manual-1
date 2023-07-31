using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    VRInputActions VRInputActions;

    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }
    void Update()
    {
        //Menu Button on Left Controller
        if (VRInputActions.MotorcycleControls.MainMenu.IsPressed())
        {
            SceneManager.LoadScene(0);
        }
    }
}
