using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private GameObject _menu;
    private AsyncOperation _loadingSceneOperation;

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        Instance = this;
    }

    public IEnumerator LoadSceneCur(int _sceneID, Action<int> action)
    {
        action?.Invoke(_sceneID);
        yield return 0;
    }
    public IEnumerator Load(int _sceneID) 
    {
            _panel.SetActive(true);
            yield return new WaitForSeconds(1f);
            _loadingSceneOperation = SceneManager.LoadSceneAsync(_sceneID);
            while (!_loadingSceneOperation.isDone)
            {
                _loadingText.text = "Loading... " + (_loadingSceneOperation.progress * 100).ToString() + "%";
                yield return 0;
            }
            
            _panel.SetActive(false);
            _loadingText.text = "";
            yield return new WaitForSeconds(1f);
    }
}
