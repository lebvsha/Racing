using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackwardPedalController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite[] _pedals = new Sprite[1];
    public CarController Car;
    public void OnPointerDown(PointerEventData eventData) 
    {
        GetComponent<Image>().sprite = _pedals[1];
        Car._moveBackward = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = _pedals[0];
        Car._moveBackward = false;
    }
}
