using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headlight : MonoBehaviour
{

    private Light headlight;

    // Start is called before the first frame update
    void Start()
    {
        //set light to 6000 kelvin. Standard for bikes
        headlight = GetComponent<Light>();
        headlight.color = Mathf.CorrelatedColorTemperatureToRGB(6000);
    }

}