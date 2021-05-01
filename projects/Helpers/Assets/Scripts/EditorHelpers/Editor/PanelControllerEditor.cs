using UnityEngine;
using UnityEditor;
using System;

namespace AValentini.Helpers.EditorHelpers
{
    [CustomEditor (typeof (PanelController))]
    public class PanelControllerEditor : Editor
    {
        string labelContent = string.Empty;
        bool fold = true;

        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI ();

            WarningMessages ();

            EditorGUILayout.Space ();

            DropDownMenu ();

            EditorGUILayout.LabelField (string.Format ("Clicked on: {0}", labelContent));

            EditorGUILayout.Space ();

            var pc = target as PanelController;
            fold = EditorGUILayout.InspectorTitlebar (fold, pc.transform);
            if (fold)
            {
                EditorGUILayout.Vector4Field ("Detailed Rotation",
                        QuaternionToVector4 (pc.transform.localRotation));
            }

            EditorGUILayout.Space ();
        }

        void DropDownMenu ()
        {
            var menu = new GenericMenu ();
            menu.AddItem (new GUIContent ("Item1"), false, GetMenuItemMessage, "Item1");
            menu.AddItem (new GUIContent ("Item2"), false, GetMenuItemMessage, "Item2");
            menu.AddItem (new GUIContent ("Item3"), false, GetMenuItemMessage, "Item3");
            if (EditorGUILayout.DropdownButton (new GUIContent ("Click me!"), FocusType.Passive))
            {
                menu.ShowAsContext ();
            }
        }

        void WarningMessages ()
        {
            EditorGUILayout.HelpBox ("Standard Message", MessageType.None);
            EditorGUILayout.HelpBox ("Info Message", MessageType.Info);
            EditorGUILayout.HelpBox ("Warning Message", MessageType.Warning);
            EditorGUILayout.HelpBox ("Error Message", MessageType.Error);
        }

        void GetMenuItemMessage (object v)
        {
            labelContent = v.ToString ();
        }

        Vector4 QuaternionToVector4 (Quaternion q)
        {
            return new Vector4 (q.x, q.y, q.z, q.w);
        }
    }
}