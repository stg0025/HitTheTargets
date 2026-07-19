using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public AudioSource gunAudio;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffectPrefab;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        gunAudio.Play();

        if (muzzleFlash != null) muzzleFlash.Play();

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (impactEffectPrefab != null)
            {
                GameObject impact = Instantiate(impactEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2f);
            }

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) { target.Hit(); return; }

            LevelGateTarget gate = hit.transform.GetComponent<LevelGateTarget>();
            if (gate != null) { gate.Hit(); return; }

            StartTarget startTarget = hit.transform.GetComponent<StartTarget>();
            if (startTarget != null) { startTarget.Hit(); }
        }
    }
}