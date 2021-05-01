using UnityEngine;
using UnityEditor;

namespace AValentini.Helpers.EditorScripts
{
    public class ProjectStructureGenerator : EditorWindow
    {
        [MenuItem("Helpers/Generate Project Structure")]
        public static void GenerateProjectStructure()
        {
            GetWindow(typeof(ProjectStructureGenerator), true, "Folders Generation Window");
            Debug.Log("Complete");
        }

        bool scenesEnabled = true,
            scriptsEnabled = true,
            modelsEnabled = true,
            prefabsEnabled = true,
            editorEnabled = true,
            fontsEnabled = true,
            materialsEnabled = true;

        void OnGUI()
        {
            GUILayout.Label("Folders structure", EditorStyles.boldLabel);
            scenesEnabled = EditorGUILayout.Toggle("Scenes", scenesEnabled);
            scriptsEnabled = EditorGUILayout.Toggle("Scripts", scriptsEnabled);
            modelsEnabled = EditorGUILayout.Toggle("Models", modelsEnabled);
            prefabsEnabled = EditorGUILayout.Toggle("Prefabs", prefabsEnabled);
            editorEnabled = EditorGUILayout.Toggle("Editor", editorEnabled);
            fontsEnabled = EditorGUILayout.Toggle("Fonts", fontsEnabled);
            materialsEnabled = EditorGUILayout.Toggle("Materials", materialsEnabled);
            if (GUILayout.Button("Create structure"))
            {
                CreateFolderStructure();
            }
        }

        void CreateFolderStructure()
        {
            if (scenesEnabled && !AssetDatabase.IsValidFolder("Assets/Scenes")) AssetDatabase.CreateFolder("Assets", "Scenes");
            if (scriptsEnabled && !AssetDatabase.IsValidFolder("Assets/Scripts")) AssetDatabase.CreateFolder("Assets", "Scripts");
            if (modelsEnabled && !AssetDatabase.IsValidFolder("Assets/Models")) AssetDatabase.CreateFolder("Assets", "Models");
            if (prefabsEnabled && !AssetDatabase.IsValidFolder("Assets/Prefabs")) AssetDatabase.CreateFolder("Assets", "Prefabs");
            if (editorEnabled && !AssetDatabase.IsValidFolder("Assets/Editor")) AssetDatabase.CreateFolder("Assets", "Editor");
            if (fontsEnabled && !AssetDatabase.IsValidFolder("Assets/Fonts")) AssetDatabase.CreateFolder("Assets", "Fonts");
            if (materialsEnabled && !AssetDatabase.IsValidFolder("Assets/Materials")) AssetDatabase.CreateFolder("Assets", "Materials");
        }
    }
}
