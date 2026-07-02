using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI targetsText;

    float time;
    bool running;

    int totalTargets;
    int remainingTargets;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        time = 0;
        running = true;

        Target[] targets = Object.FindObjectsByType<Target>(FindObjectsSortMode.None);
        totalTargets = targets.Length;
        remainingTargets = totalTargets;

        UpdateUI();
    }

    void Update()
    {
        if (!running) return;

        time += Time.deltaTime;
        timerText.text = "Time: " + time.ToString("F2");
    }

    public void TargetHit()
    {
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
        targetsText.text = "Targets: " + remainingTargets;
    }
}