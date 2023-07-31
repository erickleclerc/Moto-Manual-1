using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TextMeshProUGUI speedometerText;

    private int speed;
    void Update()
    {
        speed = (int)rb.velocity.magnitude;
        speedometerText.text = speed.ToString();
    }
}
