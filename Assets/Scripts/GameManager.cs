using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;




public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Rules of biking: If complete stop/ 0 velocity and the clutch is not engaged, the bike will stall, unless in neutral
    /// 
    /// Any Stall resets the current state
    /// </summary>
    /// 
    [Serializable]
    public enum State { DonHelmet, Key, IdentifyComponents, FirstGearRide, FreeRoam }

    public State currentState = State.DonHelmet;


    [Serializable]
    public enum Step { Throttle, KillSwitch, FuelInjector, FrontBrake, BackBrake, Clutch, ShifterUp, ShifterDown, HeadlightOn, HeadlightOff, RightTurnSignal, LeftTurnSignal, TurnSignalOff }
    public Step currentStep = Step.Throttle;

    [SerializeField] private GameObject[] components;
    private LerpEmission currentEmitter;


    [SerializeField] private TextMeshProUGUI objectiveText;
    private string objectiveString = "Objective: ";

    public bool stateIsComplete = false;
    public bool stepIsComplete = false;

    public GameObject[] otherVehicles;


    private void Awake()
    {
        
    }

    void Start()
    {

    }

    void Update()
    {
        switch (currentState)
        {
            case State.DonHelmet:
                //Message in HUD saying to put on helmet. Once contact, change state to IdentifyComponents
                Debug.Log("Don Helmet");
                objectiveText.text = objectiveString + "Put On Your Helmet";
                TransitionToNextState();
                break;

            case State.Key:
                //Message in HUD saying to put key in ignition. Once contact, change state to IdentifyComponents
                Debug.Log("Key");
                objectiveText.text = objectiveString + "Grab the key and place it in the igniton";
                HighlightComponent(7);
                TransitionToNextState();
                break;
            case State.IdentifyComponents:
                //Message in HUD saying to identify throttle, clutch, brakes, horn, kill switch, turning signals, gear shift. Once all are identified, change state
                Debug.Log("Identify Components");

                switch (currentStep)
                {
                    case Step.Throttle:
                        objectiveText.text = objectiveString + "Touch the Throttle";
                        HighlightComponent(0);
                        break;
                    case Step.KillSwitch:
                        objectiveText.text = objectiveString + "Touch the Kill Switch";
                        HighlightComponent(1);
                        break;
                    case Step.FuelInjector:
                        objectiveText.text = objectiveString + "Touch the Fuel Injector";
                        HighlightComponent(2);
                        break;
                    case Step.FrontBrake:
                        objectiveText.text = objectiveString + "Touch the Front Brake";
                        HighlightComponent(3);
                        break;
                    case Step.BackBrake:
                        objectiveText.text = objectiveString + "Touch the Back Brake With Your Right Foot";
                        HighlightComponent(99);
                        break;
                    case Step.Clutch:
                        objectiveText.text = objectiveString + "Touch the Clutch";
                        HighlightComponent(4);
                        break;
                    case Step.ShifterUp:
                        objectiveText.text = objectiveString + "While Keeping the clutch IN, hit the Shifter Up With Your Left Foot";
                        HighlightComponent(99);
                        break;
                    case Step.ShifterDown:
                        objectiveText.text = objectiveString + "While Keeping the clutch IN, hit the Shifter Down With Your Foot";
                        HighlightComponent(99);
                        break;
                    case Step.HeadlightOn:
                        objectiveText.text = objectiveString + "Flick the Headlight Up With Your Controller";
                        HighlightComponent(5);
                        break;
                    case Step.HeadlightOff:
                        objectiveText.text = objectiveString + "Flick the Headlight Down With Your Controller";
                        HighlightComponent(5);
                        break;
                    case Step.RightTurnSignal:
                        objectiveText.text = objectiveString + "Touch the Right Turn Signal";
                        HighlightComponent(6);
                        break;
                    case Step.LeftTurnSignal:
                        objectiveText.text = objectiveString + "Touch the Left Turn Signal";
                        break;
                    case Step.TurnSignalOff:
                        objectiveText.text = objectiveString + "Touch the Turn Signal Off";
                        break;

                        //the turn signal off will change the state to FirstGearRide
                }

                TransitionToNextStep();

                TransitionToNextState();
                break;
            case State.FirstGearRide:
                //Message in HUD to simply ride locked in 1st gear through cones. If no collision, change state to LearningShifting. If collision, restart state
                Debug.Log("First Gear Ride");
                objectiveText.text = objectiveString + "Time for your first gear ride!";


                TransitionToNextState();
                break;
            case State.FreeRoam:
                //Message in HUD to free roam. Ride around the map, practice shifting, braking, turning, etc. If collision, restart state


                //Enable all the AI cars and bikes and if you collide with them, restart the scene with a message saying you crashed. Stay in this state.

                

                
                foreach (GameObject vehicle in otherVehicles)
                {
                    vehicle.SetActive(true);
                }

                Debug.Log("Free Roam");
                objectiveText.text = objectiveString + "Start your bike and roam free!";
                break;
        }

    }

    private void HighlightComponent(int index)
    {
        //skips the first emitter pass because it hasn't been assigned yet. 99 for components that won't be highlighted like the shifter and turn signal
        if (currentEmitter != null || index == 99)
        {
            currentEmitter.isHighlighted = false;
            
        }

        if (index != 99)
        {
            currentEmitter = components[index].GetComponent<LerpEmission>();
            currentEmitter.isHighlighted = true;
        }
    }

    private void TransitionToNextStep()
    {
        if (stepIsComplete)
        {
            currentStep = currentStep + 1;
            stepIsComplete = false;
        }
    }

    private void TransitionToNextState()
    {
        if (stateIsComplete)
        {
            objectiveText.text = "Excellent!";
            stateIsComplete = false;
            currentState++;
            
        }
    }
}
