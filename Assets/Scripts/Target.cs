using UnityEngine;

public class Target : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Hit()
    {
        GameManager.instance.TargetHit();

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        audioSource.Play();

        Destroy(gameObject, audioSource.clip.length);
    }
}