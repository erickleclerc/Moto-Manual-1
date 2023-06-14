using UnityEngine;
using TMPro;

public class KeepHandOnHandleBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Rigidbody rb;

    public bool isRightHandOnHandleBar = false;
    public bool isLeftHandOnHandleBar = false;


    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 1 && isLeftHandOnHandleBar == false || rb.velocity.magnitude > 1 && isRightHandOnHandleBar == false)
        {
            text.text = "Keep both hands on the handlebar";
        }
        else if (rb.velocity.magnitude > 1 && isLeftHandOnHandleBar == true && isRightHandOnHandleBar == true)
        {
            text.text = "";
        }
        else
        {
            text.text = "";
        }
    }
}
