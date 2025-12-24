using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVenomance : MonoBehaviour
{

    [SerializeField] Venomancer venomancer;
    public bool isVenom = false;
    public float venomDuration = 5f; // сколько секунд длится эффект
    private float venomTimer = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Venom"))
        {
            if (!isVenom)
            {
                isVenom = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Venom"))
        {
            isVenom = false;
        }
    }

    private void Update()
    {
        if (isVenom)
        {
            // Увеличиваем таймер, пока эффект активен
            venomTimer += Time.deltaTime;

            if (venomTimer >= venomDuration)
            {
                // Таймер истек, эффект завершается
                isVenom = false;
                venomTimer = 0f;
                Debug.Log("Эффект яда закончился!");
                venomancer.EndVenoms();
            }
        }
    }
}
