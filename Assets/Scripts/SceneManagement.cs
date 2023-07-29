using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    /// <summary>
    /// This is the script that will launch the menu to the training scene (probably attached to a button in the UI)
    /// 
    /// Also, a function to go from the training scene to the first course.
    /// 
    /// </summary>
    /// 

    [SerializeField] private AudioSource audioSource;

        private float targetVolume = 0f;
        private float volumeDecrement = 0.05f;

    public void LoadNext()
    {
        //stop the coroutine to load next scene

        StartCoroutine(FadeOutAudio());

        StartCoroutine(LoadingScreen());
    }

    IEnumerator FadeOutAudio()
    {
        while (audioSource.volume > targetVolume)
        {
            audioSource.volume -= volumeDecrement * Time.deltaTime;
            yield return null;
        }

        // Ensure volume reaches zero
        audioSource.volume = targetVolume;

        // Stop the audio clip or deactivate the audio object
        audioSource.Stop(); // Or gameObject.SetActive(false);

    }

    IEnumerator LoadingScreen()
    {
       


        //start the coroutine for a loading screen
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ToMainMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        StartCoroutine(FadeOutAudio());

        StartCoroutine(QuitGameCoroutine());
    }

  IEnumerator QuitGameCoroutine()
    {
        yield return new WaitForSeconds(2);

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
