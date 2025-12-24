using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoilAuger : MonoBehaviour
{
    [SerializeField] private Drill _drill;

    [SerializeField] private Transform leftGrip;
    [SerializeField] private Transform rightGrip;

    public HandSnapToGrip leftHand;
    public HandSnapToGrip rightHand;

    [SerializeField] GameObject hole;

    public float digDepth = 0.1f;     
    public float digSpeed = 0.5f;      
    public float rotationSpeed = 360f; 
  
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isDigging = false;

    void Start()
    {
        startPos = transform.localPosition;
        targetPos = startPos - new Vector3(0, digDepth, 0);
    }

    void Update()
    {
        if (isDigging)
        {
            
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            // плавное опускание
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition,
                targetPos,
                digSpeed * Time.deltaTime
            );

            // ѕроверка: если достиг глубины, остановить движение
            if (Vector3.Distance(transform.localPosition, targetPos) < 0.001f)
            {
                hole.SetActive(false);
                Destroy(gameObject.GetComponent<XRSimpleInteractable>());
                gameObject.AddComponent<XRGrabInteractable>();
                gameObject.AddComponent<XRSimpleInteractable>();
                gameObject.GetComponent<Rigidbody>().useGravity = true;

                isDigging = false; // останавливаем движение
                transform.localPosition = targetPos; // фиксируем точное положение

                leftHand.Release();
                rightHand.Release();

                _drill.EndDrill();               
            }
        }
    }

    // ¬ызов по событию grab или кнопке
    public void StartDigging()
    {
        isDigging = true;
        leftHand.Snap(leftGrip);
        rightHand.Snap(rightGrip);
    }
}
