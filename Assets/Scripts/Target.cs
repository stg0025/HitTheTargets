using UnityEngine;

public class Target : MonoBehaviour
{
    public static int TargetsRemaining;

    private void Start()
    {
        TargetsRemaining++;
    }

    public void Hit()
    {
        TargetsRemaining--;
        Destroy(gameObject);
    }
}
