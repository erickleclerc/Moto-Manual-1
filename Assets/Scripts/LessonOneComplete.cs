using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonOneComplete : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vrRig.GetComponent<Rigidbody>().velocity.magnitude > 40f)
        {
            Reset();
            gameManager.audioInstructions.PlayInstruction(18);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.currentState == GameManager.State.SpeedLesson)
        {
            gameManager.stateIsComplete = true;

            Reset();

            Destroy(gameObject);
        }
    }

    //probably do a camer a fade out and in when resetting position for next state



    private void Reset()
    {
        vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vrRig.GetComponent<MotorcycleController>().currentGear = 1;
        vrRig.transform.position = gameManager.startingPosition;
    }
}
