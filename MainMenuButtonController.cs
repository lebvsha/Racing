using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtonController : MonoBehaviour, IPointerDownHandler
{
    public int ID;
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(SceneLoader.Instance.LoadSceneCur(ID, 
        (ID) =>
        {
            if (ID <= PlayerPrefs.GetInt("CurrentLevel"))
            {
                StartCoroutine(SceneLoader.Instance.Load(ID));
            }
        }));
    }
}
