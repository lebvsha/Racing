using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private int _currentLevel = 0;

    private void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        if (_currentLevel == 0)
        {
            _currentLevel = 1;
            PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
        }
        else if (_currentLevel > 2)
            _currentLevel = 2;
    }
}
