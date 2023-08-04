using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The full lesson plan sequence
    /// </summary>
    [Serializable]
    public enum State { DonHelmet, Key, IdentifyComponents, SpeedLesson, GearLesson, DarkLesson, FreeRoam }
    public State currentState = State.DonHelmet;

    [Serializable]
    public enum Step { ReferenceImages, Throttle, KillSwitch, FuelInjector, FrontBrake, BackBrake, Clutch, ShifterUp, ShifterDown, HeadlightOn, HeadlightOff, RightTurnSignal, LeftTurnSignal, TurnSignalOff, Horn }
    public Step currentStep = Step.Throttle;

    [SerializeField] private GameObject[] components;
    private LerpEmission currentEmitterOnBike, currentEmitterOnController;

    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private GameObject panel;
    private string objectiveString = "Objective: ";
    public AudioInstructions audioInstructions; 
    public bool canPlayInstruction = true;

    public bool stateIsComplete = false;
    public bool stepIsComplete = false;

    public GameObject[] otherVehicles;

    //Visual Aides
    [SerializeField] GameObject oculusControllerParentGO;
    [SerializeField] GameObject rightControllerJoystick;
    [SerializeField] GameObject leftControllerJoystick;
    private float timer = 7f;
    private float timer2 = 7f;
    private float timer3 = 7f;
    private float timer4 = 7f;

    public Vector3 startingPosition;

    public bool isAllowed = true;

    void Start()
    {
        oculusControllerParentGO.SetActive(false);
    }

    void Update()
    {
        //Debug.Log("CAN PLAY AUDIO?: " + canPlayInstruction);
        switch (currentState)
        {
            case State.DonHelmet:
                //Message in HUD saying to put on helmet. Once contact, change state to IdentifyComponents
                objectiveText.text = objectiveString + "Put On Your Helmet";
                CheckCanPlayNextInstruction(0);
                TransitionToNextState();
                break;

            case State.Key:
                //Message in HUD saying to put key in ignition. Once contact, change state to IdentifyComponents
                objectiveText.text = objectiveString + "Grab the key and place it in the igniton";
                CheckCanPlayNextInstruction(1);
                HighlightComponent(7);
                TransitionToNextState();
                break;
            case State.IdentifyComponents:
                //Message in HUD saying to identify throttle, clutch, brakes, horn, kill switch, turning signals, gear shift. Once all are identified, change state
                oculusControllerParentGO.SetActive(true);

                switch (currentStep)
                {
                    case Step.ReferenceImages:
                        objectiveText.text = objectiveString + "Hold the Y button with your left palm up";
                        CheckCanPlayNextInstruction(21);
                        HighlightOnController(14);
                        break;
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
                        rightControllerJoystick.GetComponent<Animator>().SetBool("FlickDown", true);
                        break;
                    case Step.FuelInjector:
                        objectiveText.text = objectiveString + "Tap the Push Start Button";
                        CheckCanPlayNextInstruction(4);
                        HighlightComponent(2);
                        HighlightOnController(9);
                        rightControllerJoystick.GetComponent<Animator>().SetBool("FlickDown", false);
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
                        objectiveText.text = objectiveString + "While Keeping the clutch IN hit the Shifter UP With Your Left Foot";
                        CheckCanPlayNextInstruction(8);
                        HighlightComponent(99);
                        HighlightOnController(99);
                        break;
                    case Step.ShifterDown:
                        objectiveText.text = objectiveString + "While Keeping the clutch IN hit the Shifter DOWN With Your Foot";
                        CheckCanPlayNextInstruction(9);
                        HighlightComponent(99);
                        HighlightOnController(99);
                        break;
                    case Step.HeadlightOn:
                        objectiveText.text = objectiveString + "Flick the Headlight UP With Your Controller";
                        CheckCanPlayNextInstruction(10);
                        HighlightComponent(5);
                        HighlightOnController(12);

                        //animate the L controller
                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickUp", true);

                        break;
                    case Step.HeadlightOff:
                        objectiveText.text = objectiveString + "Flick the Headlight DOWN With Your Controller";
                        CheckCanPlayNextInstruction(11);
                        HighlightComponent(5);
                        HighlightOnController(12);

                        //animate the L controller. Cancel other bool, enable flick down bool
                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickUp", false);
                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickDown", true);
                        break;
                    case Step.RightTurnSignal:
                        objectiveText.text = objectiveString + "Flick the Turn Signal to the RIGHT";
                        CheckCanPlayNextInstruction(12);
                        HighlightComponent(6);
                        HighlightOnController(12);

                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickDown", false);
                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickRight", true);
                        break;
                    case Step.LeftTurnSignal:
                        objectiveText.text = objectiveString + "Flick the Turn Signal to the LEFT";
                        CheckCanPlayNextInstruction(13);
                        HighlightComponent(6);
                        HighlightOnController(12);

                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickRight", false);
                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickLeft", true);
                        break;
                    case Step.TurnSignalOff:
                        objectiveText.text = objectiveString + "PUSH IN the Turn Signal to turn off";
                        CheckCanPlayNextInstruction(14);
                        HighlightComponent(6);
                        HighlightOnController(12);

                        leftControllerJoystick.GetComponent<Animator>().SetBool("FlickLeft", false);
                        leftControllerJoystick.GetComponent<Animator>().SetBool("PushIn", true);
                        break;
                    case Step.Horn:
                        objectiveText.text = objectiveString + "Tap the Horn";
                        CheckCanPlayNextInstruction(15);
                        HighlightComponent(99);
                        HighlightOnController(13);

                        leftControllerJoystick.GetComponent<Animator>().SetBool("PushIn", false);
                        break;
                        //the turn signal off will change the state to FirstGearRide
                }

                TransitionToNextStep();

                TransitionToNextState();
                break;
            case State.SpeedLesson:
                objectiveText.text = objectiveString + "Ride straight without crashing or speeding going over the speed limit";
                CheckCanPlayNextInstruction(17);
                oculusControllerParentGO.SetActive(false);

                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    panel.SetActive(false);
                }

                TransitionToNextState();
                break;
            case State.GearLesson:
                objectiveText.text = objectiveString + "Ride to the end while reaching FOURTH gear";
                CheckCanPlayNextInstruction(19);

                timer2 -= Time.deltaTime;
                if (timer2 > 0)
                {
                    panel.SetActive(true);
                }
                else if (timer2 < 0)
                {
                    panel.SetActive(false);
                }
                
                TransitionToNextState();
                break;
            case State.DarkLesson:
                objectiveText.text = objectiveString + "Ride to the end and do not hit the cones";
                CheckCanPlayNextInstruction(20);

                if (isAllowed)
                {
                    StartCoroutine(GameObject.Find("Lesson 1,2,3 End Point").GetComponent<LessonThreeComplete>().FadeSunlight());
                }

                timer3 -= Time.deltaTime;
                if (timer3 > 0)
                {
                    panel.SetActive(true);
                }
                else if (timer3 < 0)
                {
                    panel.SetActive(false);
                }

                TransitionToNextState();
                break;
            case State.FreeRoam:
                oculusControllerParentGO.SetActive(false);
                objectiveText.text = objectiveString + "Roam free!";
                CheckCanPlayNextInstruction(16);

                timer4 -= Time.deltaTime;
                if (timer4 > 0)
                {
                    panel.SetActive(true);
                }
                else if (timer4 < 0)
                {
                    panel.SetActive(false);
                }

                foreach (GameObject vehicle in otherVehicles)
                {
                    vehicle.SetActive(true);
                }

                break;
        }
    }

    private void CheckCanPlayNextInstruction(int audioClip)
    {
        if (canPlayInstruction)
        {
            canPlayInstruction = false;
            audioInstructions.PlayInstruction(audioClip);
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
            objectiveText.gameObject.SetActive(true);
        }
    }
}
