using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI rankText;
    public Gun gun;
    public AudioSource backgroundMusic;
    public AudioSource victoryMusic;
    public MonoBehaviour[] scriptsToDisable;

    void Awake()
    {
        if (panel != null) panel.SetActive(false);
    }

    public void Show(float finalTime, string rank)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (gun != null) gun.enabled = false;

        foreach (var script in scriptsToDisable)
        {
            if (script != null) script.enabled = false;
        }

        if (backgroundMusic != null) backgroundMusic.Stop();
        if (victoryMusic != null) victoryMusic.Play();

        if (panel != null) panel.SetActive(true);
        if (finalTimeText != null) finalTimeText.text = "Time: " + finalTime.ToString("F2");
        if (rankText != null) rankText.text = "Rank: " + rank;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}