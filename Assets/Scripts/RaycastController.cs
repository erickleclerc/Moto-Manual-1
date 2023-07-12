using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    /// <summary>
    /// For the main menu scene, select buttons by pointing at them with the controller and pulling the trigger.
    /// </summary>

    public LineRenderer lineRenderer;
    public LayerMask layerMask;
    private VRInputActions inputActions;
    [SerializeField] private TextMeshProUGUI titleText;

    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }


    void Update()
    {
        Ray ray = new Ray(transform.position + offset, transform.up * -1);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            GameObject hitObject = hit.collider.gameObject;


            if (inputActions.MotorcycleControls.TriggerMenu.IsPressed())
            {
                hitObject.GetComponent<Button>().onClick.Invoke();

                if (hitObject.gameObject.name == "Start Button")
                    titleText.text = "Good Luck!";

                if (hitObject.gameObject.name == "Exit Button")
                    titleText.text = "Goodbye!";


            }
            //Handle the raycast hit
            //Debug.Log("Hit object: " + hit.collider.gameObject.name);

            // Update the line renderer positions
            lineRenderer.SetPositions(new Vector3[] { transform.position + offset, hit.point });
        }
        else
        {
            // No hit, update the line renderer positions
            lineRenderer.SetPositions(new Vector3[] { transform.position + offset, transform.position + transform.up * -1 * 10f });
        }

        Debug.DrawRay(transform.position + offset, transform.up * -1 * 10f, Color.yellow);
    }
}

