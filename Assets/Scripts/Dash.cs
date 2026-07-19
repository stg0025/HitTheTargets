using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Dash : MonoBehaviour
{
    public Camera cam;
    public float dashSpeed = 25f;
    public float dashDuration = 0.15f;
    public float cooldown = 0.8f;
    public float fovKick = 15f;
    public float fovKickTime = 0.12f;
    public bool IsDashing => dashing;

    CharacterController controller;
    float defaultFov;
    float cooldownTimer;
    bool dashing;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (cam != null) defaultFov = cam.fieldOfView;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Keyboard.current.leftShiftKey.wasPressedThisFrame && cooldownTimer <= 0f && !dashing)
        {
            StartCoroutine(DoDash());
        }
    }

    System.Collections.IEnumerator DoDash()
    {
        dashing = true;
        cooldownTimer = cooldown;

        Vector3 dir = transform.forward;
        // fall back to camera forward flattened if you want strafe-based dash instead:
        // Vector3 dir = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;

        float elapsed = 0f;
        if (cam != null) cam.fieldOfView = defaultFov + fovKick;

        while (elapsed < dashDuration)
        {
            controller.Move(dir * dashSpeed * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        float fovElapsed = 0f;
        while (fovElapsed < fovKickTime)
        {
            if (cam != null)
                cam.fieldOfView = Mathf.Lerp(defaultFov + fovKick, defaultFov, fovElapsed / fovKickTime);
            fovElapsed += Time.deltaTime;
            yield return null;
        }
        if (cam != null) cam.fieldOfView = defaultFov;

        dashing = false;
    }
}