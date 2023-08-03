using UnityEngine;

public class LessonOneComplete : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;


    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentState == GameManager.State.SpeedLesson)
        {
            if (vrRig.GetComponent<Rigidbody>().velocity.magnitude > 40f)
            {
                Reset();
                gameManager.audioInstructions.PlayInstruction(18);
            }
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.currentState == GameManager.State.SpeedLesson)
        {
            gameManager.stateIsComplete = true;

            Reset();
        }
    }

    //probably do a camera fade out and in when resetting position for next state



    private void Reset()
    {
        vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vrRig.GetComponent<MotorcycleController>().currentGear = 1;
        vrRig.transform.position = gameManager.startingPosition;
    }
}
