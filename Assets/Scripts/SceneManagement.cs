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

    public void LoadNext()
    {
        //stop the coroutine to load next scene

        StartCoroutine(LoadingScreen());
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
