using UnityEngine;

public class ShovelDigging : MonoBehaviour
{
    [Header("Dig settings")]
    public float rotationAngle = 45f;
    public float digDepth = 0.2f;
    public float speed = 2f;

    private bool isDigging = false;

    private Quaternion startRotation;
    private Quaternion targetRotation;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Update()
    {
        if (!isDigging) return;

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime * speed
        );

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPosition,
            Time.deltaTime * speed
        );
    }

    // КОГДА НАЧАЛИ КОПАТЬ
    public void StartDigging()
    {
        // 🔥 ВАЖНО: сохраняем ТЕКУЩЕЕ положение
        startRotation = transform.localRotation;
        startPosition = transform.localPosition;

        targetRotation = startRotation * Quaternion.Euler(-rotationAngle, 0, 0);
        targetPosition = startPosition + Vector3.down * digDepth;

        isDigging = true;
    }

    // КОГДА ОТПУСТИЛИ КНОПКУ
    public void StopDigging()
    {
        isDigging = false;

        transform.localRotation = startRotation;
        transform.localPosition = startPosition;
    }
}
