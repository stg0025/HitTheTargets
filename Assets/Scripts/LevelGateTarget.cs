using UnityEngine;

public class LevelGateTarget : MonoBehaviour
{
    AudioSource audioSource;
    Collider col;
    MeshRenderer meshRenderer;
    bool revealed;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

        col.enabled = false;
        meshRenderer.enabled = false;
    }

    void Update()
    {
        if (revealed) return;

        if (GameManager.instance.AllTargetsCleared())
        {
            revealed = true;
            col.enabled = true;
            meshRenderer.enabled = true;
        }
    }

    public void Hit()
    {
        if (!revealed) return;

        if (audioSource != null) audioSource.Play();

        col.enabled = false;
        meshRenderer.enabled = false;

        GameManager.instance.AdvanceLevel();
    }
}