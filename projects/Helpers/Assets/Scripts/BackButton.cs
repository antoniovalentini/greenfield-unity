using UnityEngine;
using UnityEngine.SceneManagement;

namespace AValentini.Helpers.Async
{
    public class BackButton : MonoBehaviour
    {
        public void BackToLoadingScene ()
        {
            SceneManager.LoadScene (0);
        }
    }
}