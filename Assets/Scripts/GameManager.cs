using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Rules of biking: If complete stop/ 0 velocity and the clutch is not engaged, the bike will stall, unless in neutral
    /// 
    /// Any Stall resets the current state
    /// </summary>
    /// 
    [Serializable]
    public enum State { DonHelmet, Key, IdentifyComponents, FreeRoam }

    public State currentState = State.DonHelmet;


    [Serializable]
    public enum Step { Throttle, KillSwitch, FuelInjector, FrontBrake, BackBrake, Clutch, ShifterUp, ShifterDown, HeadlightOn, HeadlightOff, RightTurnSignal, LeftTurnSignal, TurnSignalOff, Horn }
    public Step currentStep = Step.Throttle;

    [SerializeField] private GameObject[] components;
    private LerpEmission currentEmitterOnBike, currentEmitterOnController;
   


    [SerializeField] private TextMeshProUGUI objectiveText;
    private string objectiveString = "Objective: ";
    [SerializeField] AudioInstructions audioInstructions; 
    public bool canPlayInstruction = true;

    public bool stateIsComplete = false;
    public bool stepIsComplete = false;

    public GameObject[] otherVehicles;

    //Visual Aides
    [SerializeField] private Toggle keyInToggle;
    [SerializeField] private Toggle killSwitchToggle;
    [SerializeField] private Toggle pushStartToggle;
    [SerializeField] GameObject oculusControllerParentGO;
    private float timer = 7f;

    void Start()
    {
        oculusControllerParentGO.SetActive(false);
    }

    void Update()
    {
        Debug.Log("can play instruction" + canPlayInstruction);
        switch (currentState)
        {
            case State.DonHelmet:
                //Message in HUD saying to put on helmet. Once contact, change state to IdentifyComponents
                Debug.Log("Don Helmet");
                objectiveText.text = objectiveString + "Put On Your Helmet";
                CheckCanPlayNextInstruction(0);
                TransitionToNextState();
                break;

            case State.Key:
                //Message in HUD saying to put key in ignition. Once contact, change state to IdentifyComponents
                Debug.Log("Key");
                keyInToggle.gameObject.SetActive(true);
                objectiveText.text = objectiveString + "Grab the key and place it in the igniton";
                CheckCanPlayNextInstruction(1);
                HighlightComponent(7);
                TransitionToNextState();
                break;
            case State.IdentifyComponents:
                //Message in HUD saying to identify throttle, clutch, brakes, horn, kill switch, turning signals, gear shift. Once all are identified, change state
                Debug.Log("Identify Components");
                killSwitchToggle.gameObject.SetActive(true);
                pushStartToggle.gameObject.SetActive(true);
                oculusControllerParentGO.SetActive(true);

                switch (currentStep)
                {
                    case Step.Throttle:
                        objectiveText.text = objectiveString + "Touch the Throttle";
                        CheckCanPlayNextInstruction(2);
                        HighlightComponent(0);
                        //HighlightOnController(99);
                        break;
                    case Step.KillSwitch:
                        objectiveText.text = objectiveString + "Flick the Kill Switch DOWN";
                        CheckCanPlayNextInstruction(3);
                        HighlightComponent(1);
                        HighlightOnController(8);
                        break;
                    case Step.FuelInjector:
                        objectiveText.text = objectiveString + "Tap the Push Start Button";
                        CheckCanPlayNextInstruction(4);
                        HighlightComponent(2);
                        HighlightOnController(9);
                        break;
                    case Step.FrontBrake:
                        objectiveText.text = objectiveString + "Pull IN the Front Brake";
                        CheckCanPlayNextInstruction(5);
                        HighlightComponent(3);
                        HighlightOnController(10);
                        break;
                    case Step.BackBrake:
                        objectiveText.text = objectiveString + "Touch the Back Brake With Your Right Foot";
                        CheckCanPlayNextInstruction(6);
                        HighlightComponent(99);
                        HighlightOnController(99);
                        break;
                    case Step.Clutch:
                        objectiveText.text = objectiveString + "Pull IN the Clutch";
                        CheckCanPlayNextInstruction(7);
                        HighlightComponent(4);
                        HighlightOnController(11);
                        break;
                    case Step.ShifterUp:
                        objectiveText.text = objectiveString + "While Keeping the clutch IN... hit the Shifter UP With Your Left Foot";
                        CheckCanPlayNextInstruction(8);
                        HighlightComponent(99);
                        HighlightOnController(99);
                        break;
                    case Step.ShifterDown:
                        objectiveText.text = objectiveString + "While Keeping the clutch IN... hit the Shifter DOWN With Your Foot";
                        CheckCanPlayNextInstruction(9);
                        HighlightComponent(99);
                        HighlightOnController(99);
                        break;
                    case Step.HeadlightOn:
                        objectiveText.text = objectiveString + "Flick the Headlight UP With Your Controller";
                        CheckCanPlayNextInstruction(10);
                        HighlightComponent(5);
                        HighlightOnController(12);
                        break;
                    case Step.HeadlightOff:
                        objectiveText.text = objectiveString + "Flick the Headlight DOWN With Your Controller";
                        CheckCanPlayNextInstruction(11);
                        HighlightComponent(5);
                        HighlightOnController(12);
                        break;
                    case Step.RightTurnSignal:
                        objectiveText.text = objectiveString + "Flick the Turn Signal to the RIGHT";
                        CheckCanPlayNextInstruction(12);
                        HighlightComponent(6);
                        HighlightOnController(12);
                        break;
                    case Step.LeftTurnSignal:
                        objectiveText.text = objectiveString + "Flick the Turn Signal to the LEFT";
                        CheckCanPlayNextInstruction(13);
                        HighlightComponent(6);
                        HighlightOnController(12);
                        break;
                    case Step.TurnSignalOff:
                        objectiveText.text = objectiveString + "PUSH IN the Turn Signal to turn off";
                        CheckCanPlayNextInstruction(14);
                        HighlightComponent(6);
                        HighlightOnController(12);
                        break;
                    case Step.Horn:
                        objectiveText.text = objectiveString + "Tap the Horn";
                        CheckCanPlayNextInstruction(15);
                        HighlightOnController(13);
                        break;
                        //the turn signal off will change the state to FirstGearRide
                }

                TransitionToNextStep();

                TransitionToNextState();
                break;
            case State.FreeRoam:

                //Enable all the AI cars and bikes and if you collide with them, restart the scene with a message saying you crashed. Stay in this state.

                oculusControllerParentGO.SetActive(false);
                CheckCanPlayNextInstruction(16);
                keyInToggle.gameObject.SetActive(false);
                killSwitchToggle.gameObject.SetActive(false);
                pushStartToggle.gameObject.SetActive(false);
                oculusControllerParentGO.SetActive(false);

                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    objectiveText.gameObject.SetActive(false);
                }

                
                foreach (GameObject vehicle in otherVehicles)
                {
                    vehicle.SetActive(true);
                }

                Debug.Log("Free Roam");
                objectiveText.text = objectiveString + "Roam free!";
                break;
        }

    }

    private void CheckCanPlayNextInstruction(int audioClip)
    {
        if (canPlayInstruction)
        {
            audioInstructions.PlayInstruction(audioClip);
            canPlayInstruction = false;
        }
    }


    private void HighlightComponent(int index)
    {
        //skips the first emitter pass because it hasn't been assigned yet. 99 for components that won't be highlighted like the shifter and turn signal
        if (currentEmitterOnBike != null || index == 99)
        {
            currentEmitterOnBike.isHighlighted = false;
        }

        if (index != 99)
        {
            currentEmitterOnBike = components[index].GetComponent<LerpEmission>();
            currentEmitterOnBike.isHighlighted = true;
        }

    }

    private void HighlightOnController(int index)
    {
        if (currentEmitterOnController != null || index == 99)
        {
            currentEmitterOnController.isHighlighted = false;
        }

        if (index != 99)
        {
            currentEmitterOnController = components[index].GetComponent<LerpEmission>();
            currentEmitterOnController.isHighlighted = true;
        }
    }

    private void TransitionToNextStep()
    {
        if (stepIsComplete)
        {
            canPlayInstruction = true;
            currentStep++;
            stepIsComplete = false;
        }
    }

    private void TransitionToNextState()
    {
        if (stateIsComplete)
        {
            canPlayInstruction = true;
            stateIsComplete = false;
            currentState++;

            

        }

        
    }
}
