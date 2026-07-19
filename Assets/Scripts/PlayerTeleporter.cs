using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerTeleporter : MonoBehaviour
{
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void TeleportTo(Transform destination)
    {
        controller.enabled = false;
        transform.SetPositionAndRotation(destination.position, destination.rotation);
        controller.enabled = true;
    }
}