using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Source.Edit.InspectorOverride
{
    /// <summary>
    /// Draw Reset buttons for position, rotation and scale
    /// </summary>
    [CanEditMultipleObjects, CustomEditor(typeof(Transform), true)]
    public sealed class TransformInspectorOverride : Editor
    {
        private const int MaxResetButtonWidth = 40;

        private SerializedProperty _localPosition;
        private SerializedProperty _localRotation;
        private SerializedProperty _localScale;

        private void OnEnable()
        {
            _localPosition = serializedObject.FindProperty("m_LocalPosition");
            _localRotation = serializedObject.FindProperty("m_LocalRotation");
            _localScale = serializedObject.FindProperty("m_LocalScale");
        }

       public override void OnInspectorGUI()
       {
           using (var group = new EditorGUILayout.HorizontalScope()) {
                EditorGUILayout.PropertyField(_localPosition);

                if (GUILayout.Button("Reset", GUILayout.MaxWidth(MaxResetButtonWidth))) {
                    _localPosition.vector3Value = Vector3.zero;
                }
           }

           using (var group = new EditorGUILayout.HorizontalScope()) {
                var euler = _localRotation.quaternionValue.eulerAngles;
                
                euler = EditorGUILayout.Vector3Field("Local Rotation", euler);
                _localRotation.quaternionValue = Quaternion.Euler(euler);

                if (GUILayout.Button("Reset", GUILayout.MaxWidth(MaxResetButtonWidth))) {
                    _localRotation.quaternionValue = Quaternion.identity;
                }
           }

           using (var group = new EditorGUILayout.HorizontalScope()) {
                EditorGUILayout.PropertyField(_localScale);

                if (GUILayout.Button("Reset", GUILayout.MaxWidth(MaxResetButtonWidth))) {
                    _localScale.vector3Value = Vector3.one;
                }
           }

            EditorGUILayout.Space();

            if (GUILayout.Button("Reset Transfrom")) {
                _localPosition.vector3Value = Vector3.zero;
                _localRotation.quaternionValue = Quaternion.identity;
                _localScale.vector3Value = Vector3.one;
            }

           serializedObject.ApplyModifiedProperties();
       }
    }
}