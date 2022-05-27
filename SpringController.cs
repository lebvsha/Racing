using System.Collections;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    [SerializeField] private Sprite[] _springs = new Sprite[1];
    public GameObject Target;
    public bool IsSpringActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsSpringActivated)
        {
            if (collision.CompareTag("Wheel"))
            {
                Target = collision.transform.parent.gameObject;
                StartCoroutine(SpringForce());
            }
            else if (collision.CompareTag("Car"))
            {
                Target = collision.transform.gameObject;
                StartCoroutine(SpringForce());
            }
        }
    }

    private IEnumerator SpringForce()
    {
        IsSpringActivated = true;
        yield return new WaitForSeconds(0.1f);
        Target.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100f), ForceMode2D.Impulse);
        GetComponent<SpriteRenderer>().sprite = _springs[1];
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = _springs[0];
        IsSpringActivated = false;
        Target = null;
    }
}
