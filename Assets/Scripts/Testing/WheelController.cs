
using TMPro;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    VRInputActions VRInputActions;
    private Rigidbody rb;

    float rpm;
    public float torqueAmount = 1000f;

    [SerializeField] private TextMeshProUGUI rpmText;

    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (VRInputActions.MotorcycleControls.Throttle.IsPressed())
        {
            Vector3 torque = Vector3.right * torqueAmount;
            rb.AddTorque(torque, ForceMode.Force);
        }

        rpm = (rb.angularVelocity.magnitude * 60) / (2 * Mathf.PI);
        //Debug.Log($"RPM : { rpm}");

        int rpmInt = (int)rpm;

        if (rpmText != null)
        rpmText.text = rpmInt.ToString();
    }
}
