using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;
using System.Collections;
using UnityEngine.Rendering;

public class ShockwaveController : MonoBehaviour
{
    [SerializeField] private VisualEffect shockwave;
    [SerializeField] private InputAction shockwaveAction = new InputAction(binding: "<keyboard>/space");
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private VisualEffect charge;
    [SerializeField] private float chargeTime = 0.6f;

    private bool isCharging = false;

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
        charge.Stop();
    }

    private void Update()
    {
        if (shockwaveAction.WasPressedThisFrame() && !isCharging)
        {
            StartCoroutine(ShockwaveRoutine());
        }
    }

    private IEnumerator ShockwaveRoutine()
    {
        isCharging = true;

        // チャージ開始
        charge.Play();

        // チャージが終わるまで待機
        yield return new WaitForSeconds(chargeTime);

        // チャージ終了
        charge.Stop();

        // 衝撃波発動
        shockwave.Play();

        // カメラシェイク
        cameraShake.Shake();

        isCharging = false;
    }
}
