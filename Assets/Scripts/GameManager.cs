using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Rules of biking: If complete stop/ 0 velocity and the clutch is not engaged, the bike will stall, unless in neutral
    /// 
    /// Any Stall resets the current state
    /// </summary>
    public enum State { DonHelmet, IdentifyComponents, StartBike, RevBike, FirstGearRide, LearningShifting, FreeRoam}
    State currentState = State.DonHelmet;

    void Start()
    {
        
    }

    void Update()
    {
        if (currentState == State.DonHelmet)
        {
            //Message in HUD saying to put on helmet. Once contact, change state to IdentifyComponents
            Debug.Log("Don Helmet");
        }
        else if (currentState == State.IdentifyComponents)
        {
            //Message in HUD saying to identify throttle, clutch, brakes, horn, kill switch, turning signals, gear shift. Once all are identified, change state to StartBike
            Debug.Log("Identify Components");
        }
        else if (currentState == State.StartBike)
        {
            //Message in HUD saying to grab the floating key, place in ignition. Once contact, pull in clutch, flip kill switch, press starter = bike is started, change state to RevBike
            Debug.Log("Start Bike");
        }
        else if (currentState == State.RevBike)
        {
            //Message in HUD saying to rev bike between 2000-3000 RPM for 5 seconds (test control). Once in range, change state to FirstGearRide
            Debug.Log("Rev Bike");
        }
        else if (currentState == State.FirstGearRide)
        {
            //Message in HUD to simply ride locked in 1st gear through cones. If no collision, change state to LearningShifting. If collision, restart state
            Debug.Log("First Gear Ride");
        }
        else if (currentState == State.LearningShifting)
        {
            //Message in HUD to learning shifting. Start in Neutral, pull in clutch, shift to 1st, throttle. While riding, shift to next gear when rpm is between 3000-5000. Too early, fail. Too late, fail, reset.
            Debug.Log("Learning Shifting");
        }
        else if (currentState == State.FreeRoam)
        {
            //Message in HUD to free roam. Ride around the map, practice shifting, braking, turning, etc. If collision, restart state
            Debug.Log("Free Roam");
        }
        else
        {
            Debug.Log("Error");
        }
    }
        
      
}
