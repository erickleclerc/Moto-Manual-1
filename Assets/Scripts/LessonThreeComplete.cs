using UnityEngine;

public class LessonThreeComplete : MonoBehaviour
{
    [SerializeField] Light sunlightIntensity;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;
    [SerializeField] private GameObject headlightGO;

    [SerializeField] private bool headlightIsOn = false;
   

    // Start is called before the first frame update
    void Start()
    {
        //RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (headlightGO.activeInHierarchy)
        {
            headlightIsOn = true;
        }
        else
        {
            headlightIsOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.currentState == GameManager.State.GearLesson && headlightIsOn)
        {
            gameManager.stateIsComplete = true;

            Reset();

            //REStore sunlight
            Destroy(gameObject);
        }
        else
        {
            Reset();
            gameManager.audioInstructions.PlayInstruction(18);
        }
    }

    //probably do a camera fade out and in when resetting position for next state



    private void Reset()
    {
        vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vrRig.GetComponent<MotorcycleController>().currentGear = 1;
        vrRig.transform.position = gameManager.startingPosition;
    }

    private void FadeSunlight()
    {

    }

    private void RestoreSunlight()
    {

    }
}
