using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CrashChecker : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;


    [SerializeField] private TextMeshProUGUI crashMessage, errorMessages, objectiveText, outOfBounds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OtherVehicle") || other.CompareTag("Building") || other.CompareTag("OutOfBounds"))
        {
            errorMessages.gameObject.SetActive(false);
            objectiveText.gameObject.SetActive(false);
            crashMessage.gameObject.SetActive(true);
            outOfBounds.gameObject.SetActive(false);
            crashMessage.text = "You Crashed! Try Again.";

            Destroy(other.gameObject);

            if (gameManager.currentState == GameManager.State.SpeedLesson)
            {
                vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
                vrRig.GetComponent<MotorcycleController>().currentGear = 1;
                vrRig.transform.position = gameManager.startingPosition;
                gameManager.audioInstructions.PlayInstruction(18);
            }
            else
            {
            StartCoroutine(CrashMessage());
            }
        }
    }

    IEnumerator CrashMessage()
    {
        Time.timeScale = 0f;                       

        yield return new WaitForSecondsRealtime(5f);

        Time.timeScale = 1f;

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
