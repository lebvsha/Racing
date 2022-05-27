using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ForwardPedalController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite[] _pedals = new Sprite[1];
    public CarController Car;
    public void OnPointerDown(PointerEventData eventData) 
    {
        GetComponent<Image>().sprite = _pedals[1];
        Car._moveFarward = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = _pedals[0];
        Car._moveFarward = false;
    }
}
