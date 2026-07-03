using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI targetsText;

    float time;
    bool running;

    int remainingTargets;

    public bool isLevelScene;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        time = 0;
        running = isLevelScene;

        if (isLevelScene)
        {
            Target[] targets = Object.FindObjectsByType<Target>(FindObjectsSortMode.None);
            remainingTargets = targets.Length;
            UpdateUI();
        }
    }

    void Update()
    {
        if (!isLevelScene) return;

        if (!running) return;

        time += Time.deltaTime;
        timerText.text = "Time: " + time.ToString("F2");
    }

    public void TargetHit()
    {
        if (!isLevelScene) return;

        remainingTargets--;
        UpdateUI();

        if (remainingTargets <= 0)
        {
            StopTimer();
        }
    }

    public void StopTimer()
    {
        running = false;
    }

    void UpdateUI()
    {
        if (targetsText != null)
        {
            targetsText.text = "Targets: " + remainingTargets;
        }
    }
}