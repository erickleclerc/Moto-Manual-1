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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VRInputActions.MotorcycleControls.MainMenu.IsPressed())
        {
            SceneManager.LoadScene(0);
        }
    }
}
