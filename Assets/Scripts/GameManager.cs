using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI targetsText;

    [Header("Level containers, in order")]
    public GameObject[] levelContainers;
    public int[] targetsPerLevel = { 3, 9, 20 };

    [Header("Player teleport — index 0 unused, player starts there already")]
    public PlayerTeleporter player;
    public Transform[] levelSpawnPoints;

    [Header("End screen")]
    public EndScreenUI endScreen;
    public float goldTime = 60f;
    public float silverTime = 90f;

    float time;
    bool running;
    int remainingTargets;
    int currentLevel;

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
            currentLevel = 0;
            ActivateLevel(currentLevel);
        }
    }

    void Update()
    {
        if (!isLevelScene || !running) return;

        time += Time.deltaTime;
        timerText.text = "Time: " + time.ToString("F2");
    }

    void ActivateLevel(int index)
    {
        for (int i = 0; i < levelContainers.Length; i++)
        {
            levelContainers[i].SetActive(i == index);
        }

        remainingTargets = targetsPerLevel[index];
        UpdateUI();
    }

    public void TargetHit()
    {
        if (!isLevelScene) return;

        remainingTargets--;
        UpdateUI();
    }

    public bool AllTargetsCleared()
    {
        return remainingTargets <= 0;
    }

    public void AdvanceLevel()
    {
        currentLevel++;

        if (currentLevel >= levelContainers.Length)
        {
            StopTimer();
            if (endScreen != null) endScreen.Show(time, GetRank());
            return;
        }

        ActivateLevel(currentLevel);

        if (player != null && currentLevel < levelSpawnPoints.Length && levelSpawnPoints[currentLevel] != null)
        {
            player.TeleportTo(levelSpawnPoints[currentLevel]);
        }
    }

    string GetRank()
    {
        if (time <= goldTime) return "GOLD";
        if (time <= silverTime) return "SILVER";
        return "BRONZE";
    }

    public void StopTimer()
    {
        running = false;
    }

    void UpdateUI()
    {
        if (targetsText != null)
            targetsText.text = "Targets: " + remainingTargets;
    }
}