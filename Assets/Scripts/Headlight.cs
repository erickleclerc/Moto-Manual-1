using UnityEngine;

public class Headlight : MonoBehaviour
{
    private Light headlight;

    void Start()
    {
        //set light to 6000 kelvin. Standard for bikes
        headlight = GetComponent<Light>();
        headlight.color = Mathf.CorrelatedColorTemperatureToRGB(6000);
    }
}