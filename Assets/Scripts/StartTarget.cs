using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTarget : MonoBehaviour
{
    AudioSource audioSource;
    bool triggered;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Hit()
    {
        if (triggered) return;

        triggered = true;

        if (audioSource != null)
        {
            audioSource.Play();
        }

        Invoke("LoadLevel", 0.2f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("Levels");
    }
}