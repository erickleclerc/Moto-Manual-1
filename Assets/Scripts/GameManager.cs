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
    public enum State { DonHelmet, IdentifyComponents, FirstGearRide, FreeRoam }

    public State currentState = State.DonHelmet;


    [Serializable]
    public enum Step { Throttle, KillSwitch, FuelInjector, FrontBrake, BackBrake, Clutch, ShifterUp, ShifterDown, HeadlightOn, HeadlightOff, RightTurnSignal, LeftTurnSignal, TurnSignalOff }
    public Step currentStep = Step.Throttle;

    [SerializeField] private TextMeshProUGUI objectiveText;
    private string objectiveString = "Objective: ";

    public bool stateIsComplete = false;
    public bool stepIsComplete = false;

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
            case State.IdentifyComponents:
                //Message in HUD saying to identify throttle, clutch, brakes, horn, kill switch, turning signals, gear shift. Once all are identified, change state
                Debug.Log("Identify Components");

                switch (currentStep)
                {
                    case Step.Throttle:
                        objectiveText.text = objectiveString + "Touch the Throttle";
                        break;
                    case Step.KillSwitch:
                        objectiveText.text = objectiveString + "Touch the Kill Switch";
                        break;
                    case Step.FuelInjector:
                        objectiveText.text = objectiveString + "Touch the Fuel Injector";
                        break;
                    case Step.FrontBrake:
                        objectiveText.text = objectiveString + "Touch the Front Brake";
                        break;
                    case Step.BackBrake:
                        objectiveText.text = objectiveString + "Touch the Back Brake";
                        break;
                    case Step.Clutch:
                        objectiveText.text = objectiveString + "Touch the Clutch";
                        break;
                    case Step.ShifterUp:
                        objectiveText.text = objectiveString + "Touch the Shifter Up";
                        break;
                    case Step.ShifterDown:
                        objectiveText.text = objectiveString + "Touch the Shifter Down";
                        break;
                    case Step.HeadlightOn:
                        objectiveText.text = objectiveString + "Touch the Headlight On";
                        break;
                    case Step.HeadlightOff:
                        objectiveText.text = objectiveString + "Touch the Headlight Off";
                        break;
                    case Step.RightTurnSignal:
                        objectiveText.text = objectiveString + "Touch the Right Turn Signal";
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
                Debug.Log("Free Roam");
                objectiveText.text = objectiveString + "Start your bike and roam free!";
                break;
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
            currentState = currentState + 1;
            stateIsComplete = false;
        }
    }
}
