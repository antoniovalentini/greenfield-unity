using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AValentini.Helpers.Async
{
    public class SceneManagerAsync : MonoBehaviour
    {
        public Text progressText;
        public Slider slider;
        public GameObject loadingScreen;

        void OnValidate()
        {
            if (loadingScreen == null)
                Debug.LogError("Select a LOADING SCREEN to display the progress", this);
            if (progressText == null)
                Debug.LogError("Select a TEXT to display the progress", this);
            if (slider == null)
                Debug.LogError("Select a SLIDER to display the progress", this);
        }

        public void LoadLevel(int sceneIndex)
        {
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }

        IEnumerator LoadSceneAsync(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

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
}
