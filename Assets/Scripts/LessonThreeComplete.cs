using System.Collections;
using UnityEngine;

public class LessonThreeComplete : MonoBehaviour
{
    [SerializeField] Light sunlightIntensity;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;
    [SerializeField] private GameObject headlightGO;
    [SerializeField] private GameObject conesParentGO;

    [SerializeField] private bool headlightIsOn = false;

    private float initalIntensity;
    private float targetIntensity = 0.1f;
    private float duration = 4f;

    void Start()
    {
        initalIntensity = sunlightIntensity.intensity;
    }

    void Update()
    {
        if (gameManager.currentState == GameManager.State.DarkLesson)
        {
            conesParentGO.SetActive(true);
        }

        if (headlightGO.GetComponent<Light>().enabled == true)
        {
            headlightIsOn = true;
        }
        else
        {
            headlightIsOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.currentState == GameManager.State.DarkLesson && headlightIsOn == true)
        {
            StopAllCoroutines();
            StartCoroutine(RestoreSunlight());
            gameManager.stateIsComplete = true;
            conesParentGO.SetActive(false);

            Reset();
            Debug.Log("Success");
            
            
        }
        else
        {
            Reset();
            gameManager.audioInstructions.PlayInstruction(18);
            Debug.Log("Failed");
        }
    }

    private void Reset()
    {
        vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vrRig.GetComponent<MotorcycleController>().currentGear = 1;
        vrRig.transform.position = gameManager.startingPosition;
    }

    public IEnumerator FadeSunlight()
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float time = elapsedTime / duration;

            float newIntensity = Mathf.Lerp(initalIntensity, targetIntensity, time);

            sunlightIntensity.intensity = newIntensity;
            RenderSettings.skybox.SetFloat("_Exposure", newIntensity);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sunlightIntensity.intensity = targetIntensity;
        gameManager.isAllowed = false;
        yield return null;
    }

    public IEnumerator RestoreSunlight()
    {
        Debug.Log("Restoring Sunlight");
        float elapsedTime = 0;
        float currentIntensity = sunlightIntensity.intensity;

        while (elapsedTime < duration)
        {
            float time = elapsedTime / duration;

            float newIntensity = Mathf.Lerp(0, 1, time);

            sunlightIntensity.intensity = newIntensity;
            RenderSettings.skybox.SetFloat("_Exposure", newIntensity);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        sunlightIntensity.intensity = initalIntensity;

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
