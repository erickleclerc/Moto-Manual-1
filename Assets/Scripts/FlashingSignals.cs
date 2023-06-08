using UnityEngine;

public class FlashingSignals : MonoBehaviour
{
    [SerializeField] private float flashSpeed = 1f;
    [SerializeField] private float flashIntensity = 1f;

    private Light signal;

    void Start()
    {
        signal = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        signal.intensity = Mathf.PingPong(Time.time * flashSpeed, flashIntensity);  
    }
}
