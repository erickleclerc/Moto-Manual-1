using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    /// <summary>
    /// Launch the menu to the training scene (attached to a button in the UI)
    /// </summary>

    [SerializeField] private AudioSource audioSource;

        private float targetVolume = 0f;
        private float volumeDecrement = 0.05f;

    public void LoadNext()
    {
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
        audioSource.Stop(); 

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
