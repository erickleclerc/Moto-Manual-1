using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CrashChecker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI crashMessage, errorMessages, objectiveText;
    [SerializeField] private bool debug;

    void Update()
    {
        if (debug)
        {
            errorMessages.gameObject.SetActive(false);
            objectiveText.gameObject.SetActive(false);
            crashMessage.gameObject.SetActive(true);
            crashMessage.text = "You Crashed! Try Again.";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OtherVehicle"))
        {
            //Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.name);
            errorMessages.gameObject.SetActive(false);
            objectiveText.gameObject.SetActive(false);
            crashMessage.gameObject.SetActive(true);
            crashMessage.text = "You Crashed! Try Again.";

            StartCoroutine(CrashMessage());
        }
    }


    IEnumerator CrashMessage()
    {
        Time.timeScale = 0f;                       

        yield return new WaitForSecondsRealtime(5f);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
