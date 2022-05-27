using UnityEngine;
using UnityEngine.SceneManagement;

public class BillyController : MonoBehaviour
{
    public int ID;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wheel") || collision.CompareTag("Car"))
        {
            if (ID <= 2)
            {
                PlayerPrefs.SetInt("CurrentLevel", ID + 1);
                SceneManager.LoadSceneAsync(ID + 1);
            }
            else
                SceneManager.LoadSceneAsync(0);
        }
    }
}
