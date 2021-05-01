using UnityEditor;
using UnityEngine;

namespace AValentini.Helpers.EditorScripts
{
    public class HeavySceneGenerator : Editor
    {
        [MenuItem("Helpers/HeavyScene")]
        public static void MakeThisSceneHeavy()
        {
            var canvas = FindObjectOfType<Canvas>();
            var container = new GameObject().transform;
            container.SetParent(canvas.transform);
            container.name = "Heavy Container";

            for (int i = 0; i < 1000; i++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.SetParent(container);
            }

            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        }
    }
}