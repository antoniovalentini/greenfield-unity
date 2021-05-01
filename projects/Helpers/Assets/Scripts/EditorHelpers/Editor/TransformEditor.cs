using UnityEditor;
using UnityEngine;

namespace AValentini.Helpers.EditorHelpers
{
    [CanEditMultipleObjects, CustomEditor (typeof (Transform))]
    public class TransformEditor : Editor
    {
        const float FIELD_WIDTH = 212.0f;
        const bool WIDE_MODE = true;

        const float POSITION_MAX = 100000.0f;

        static GUIContent positionGUIContent = new GUIContent (LocalString ("Position")
                                                                     , LocalString ("The local position of this Game Object relative to the parent."));
        static GUIContent rotationGUIContent = new GUIContent (LocalString ("Rotation")
                                                                     , LocalString ("The local rotation of this Game Object relative to the parent."));
        static GUIContent scaleGUIContent = new GUIContent (LocalString ("Scale")
                                                                     , LocalString ("The local scaling of this Game Object relative to the parent."));

        static string positionWarningText = LocalString ("Due to floating-point precision limitations, it is recommended to bring the world coordinates of the GameObject within a smaller range.");
        static string positionNaNWarningText = LocalString ("Position is NaN.");
        static string scaleNaNWarningText = LocalString ("Scale is NaN.");

        SerializedProperty _positionProperty;
        SerializedProperty _rotationProperty;
        SerializedProperty _scaleProperty;

        static string LocalString (string text)
        {
            return LocalizationDatabase.GetLocalizedString (text);
        }

        Transform targetTransform;
        public void OnEnable ()
        {
            targetTransform = target as Transform;
            this._positionProperty = this.serializedObject.FindProperty ("m_LocalPosition");
            this._rotationProperty = this.serializedObject.FindProperty ("m_LocalRotation");
            this._scaleProperty = this.serializedObject.FindProperty ("m_LocalScale");
        }

        public override void OnInspectorGUI ()
        {
            this.AddResetButton ();
            EditorGUIUtility.wideMode = WIDE_MODE;
            EditorGUIUtility.labelWidth = EditorGUIUtility.currentViewWidth - FIELD_WIDTH; // align field to right of inspector

            this.serializedObject.Update ();

            EditorGUILayout.PropertyField (this._positionProperty, positionGUIContent);
            this.RotationPropertyField (this._rotationProperty, rotationGUIContent);
            EditorGUILayout.PropertyField (this._scaleProperty, scaleGUIContent);

            if (!ValidatePosition (targetTransform.position))
            {
                EditorGUILayout.HelpBox (positionWarningText, MessageType.Warning);
            }
            else if (IsNaN (targetTransform.position))
            {
                EditorGUILayout.HelpBox (positionNaNWarningText, MessageType.Warning);
            }
            else if (IsNaN (targetTransform.localScale))
            {
                EditorGUILayout.HelpBox (scaleNaNWarningText, MessageType.Warning);
            }

            this.serializedObject.ApplyModifiedProperties ();
        }

        void AddResetButton ()
        {
            if (GUILayout.Button ("Reset Transform"))
            {
                targetTransform.position = Vector3.zero;
                targetTransform.rotation = Quaternion.identity;
                targetTransform.localScale = Vector3.one;
            }
        }

        bool ValidatePosition (Vector3 position)
        {
            if (Mathf.Abs (position.x) > POSITION_MAX) return false;
            if (Mathf.Abs (position.y) > POSITION_MAX) return false;
            if (Mathf.Abs (position.z) > POSITION_MAX) return false;
            return true;
        }

        void RotationPropertyField (SerializedProperty rotationProperty, GUIContent content)
        {
            Transform transform = (Transform)this.targets[0];
            Quaternion localRotation = transform.localRotation;
            foreach (Object t in (Object[])this.targets)
            {
                if (!SameRotation (localRotation, ((Transform)t).localRotation))
                {
                    EditorGUI.showMixedValue = true;
                    break;
                }
            }

            EditorGUI.BeginChangeCheck ();

            Vector3 eulerAngles = EditorGUILayout.Vector3Field (content, localRotation.eulerAngles);

            if (EditorGUI.EndChangeCheck ())
            {
                Undo.RecordObjects (this.targets, "Rotation Changed");
                foreach (Object obj in this.targets)
                {
                    Transform t = (Transform)obj;
                    t.localEulerAngles = eulerAngles;
                }
                rotationProperty.serializedObject.SetIsDifferentCacheDirty ();
            }

            EditorGUI.showMixedValue = false;
        }

        readonly float EPSILON = 0.0001f;
        bool SameRotation (Quaternion rot1, Quaternion rot2)
        {
            if (System.Math.Abs (rot1.x - rot2.x) > EPSILON) return false;
            if (System.Math.Abs (rot1.y - rot2.y) > EPSILON) return false;
            if (System.Math.Abs (rot1.z - rot2.z) > EPSILON) return false;
            if (System.Math.Abs (rot1.w - rot2.w) > EPSILON) return false;
            return true;
        }

        bool IsNaN (Vector3 v)
        {
            return float.IsNaN (v.x) || float.IsNaN (v.y) || float.IsNaN (v.z);
        }
    }
}
