using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainLoading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    ZenjectSceneLoader _sceneLoader;

    [Inject]
    void AfterInject(ZenjectSceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    void Start()
    {
        Debug.LogFormat("SceneLoader is null={0}", _sceneLoader == null);
    }

    public void LoadSceneAdditive()
    {
        StartCoroutine(LoadSceneAdditiveAsync());
    }

    IEnumerator LoadSceneAdditiveAsync()
    {
        AsyncOperation operation = _sceneLoader.LoadSceneAsync("HeavyScene", UnityEngine.SceneManagement.LoadSceneMode.Additive);

        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / .9f);

            if (slider != null)
                slider.value = progress;

            if (progressText != null)
                progressText.text = string.Format("{0:0}%", progress * 100f);

            yield return null;
        }
    }
}
