using UnityEngine;

public class AudioInstructions : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClipArray;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
  
    public void PlayInstruction(int audioSequence)
    {
            //avoid playing multiple instructions at once
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.PlayOneShot(audioClipArray[audioSequence]);
    }
}
