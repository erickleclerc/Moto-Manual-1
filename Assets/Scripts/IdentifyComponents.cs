using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifyComponents : MonoBehaviour
{
    /// <summary>
    /// This will go on each component that needs to be identified
    /// 
    /// Will flash until the player either touches it or uses the controller to select it
    /// </summary>

    [SerializeField] private GameManager gameManager;

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
        // If the certain Step is... and the material is flashing, then reference the game manager and set the step to complete

        //if (other.gameObject.tag == "RightHand" && gameManager.currentStep == .... && material is glowing || other.gameObject.tag == "LeftHand")
        //{
        //    gameManager.stepIsComplete = true;
        //}
    }
}
