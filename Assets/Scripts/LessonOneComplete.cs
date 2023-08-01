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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.currentState == GameManager.State.SpeedLesson)
        {
            gameManager.stateIsComplete = true;
            vrRig.transform.position = gameManager.startingPosition;

            Destroy(gameObject);
        }
    }

    //probably do a camer a fade out and in when resetting position for next state

}
