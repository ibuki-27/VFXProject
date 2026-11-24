using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class ShockwaveController : MonoBehaviour
{
    [SerializeField] private VisualEffect shockwave;
    [SerializeField] private InputAction shockwaveAction = new InputAction(binding: "<keyboard>/space");
    [SerializeField] private CameraShake cameraShake;

    private void OnEnable()
    {
        shockwaveAction.Enable();
    }

    private void OnDisable()
    {
        shockwaveAction.Disable();
    }

    private void Start()
    {
        shockwave.Stop();
    }

    private void Update()
    {
        if (shockwaveAction.WasPressedThisFrame())
        {
            shockwave.Play();
            cameraShake.Shake();
        }
    }
}
