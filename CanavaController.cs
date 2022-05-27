using System.Collections;
using UnityEngine;

public class CanavaController : MonoBehaviour
{
    public CarController Target;
    public bool IsCanavaActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsCanavaActivated)
        {
            if (collision.CompareTag("Wheel"))
            {
                StartCoroutine(FuelUp());
            }
            else if (collision.CompareTag("Car"))
            {
                StartCoroutine(FuelUp());
            }
        }
    }

    private IEnumerator FuelUp()
    {
        IsCanavaActivated = true;
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);
        Target.Health += 10;
        print("t");
    }
}
