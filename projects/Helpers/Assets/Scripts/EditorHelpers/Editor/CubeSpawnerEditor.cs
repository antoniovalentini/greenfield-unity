using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace AValentini.Helpers.EditorHelpers
{
    [CustomEditor (typeof (CubeSpawner))]
    public class CubeSpawnerEditor : Editor
    {
        ReorderableList list;

        void OnEnable ()
        {

            list = new ReorderableList (serializedObject,
                    serializedObject.FindProperty ("cubes"),
                    true, true, true, true)
            {
                drawHeaderCallback = (Rect rect) =>
                {
                    EditorGUI.LabelField (rect, "Cubes Pool");
                },

                drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    var element = list.serializedProperty.GetArrayElementAtIndex (index);
                    rect.y += 2;
                    EditorGUI.PropertyField (
                        new Rect (rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
                        element.FindPropertyRelative ("edge"), GUIContent.none);
                    EditorGUI.PropertyField (
                        new Rect (rect.x + 60, rect.y, rect.width - 60 - 60, EditorGUIUtility.singleLineHeight),
                        element.FindPropertyRelative ("name"), GUIContent.none);
                    EditorGUI.PropertyField (
                        new Rect (rect.x + rect.width - 60, rect.y, 60, EditorGUIUtility.singleLineHeight),
                        element.FindPropertyRelative ("color"), GUIContent.none);
                }
            };
        }

        public override void OnInspectorGUI ()
        {
            EditorGUILayout.Space ();
            serializedObject.Update ();
            list.DoLayoutList ();
            serializedObject.ApplyModifiedProperties ();
        }
    }
}