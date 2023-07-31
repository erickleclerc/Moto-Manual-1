using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    /// <summary>
    /// Could be used to preserve data like username and scores. Game Manager is a good candidate for this. Singleton Principal for moving across scenes/ lessons.
    /// </summary>

    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameManager");

        if (objects.Length > 1)
        {

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
