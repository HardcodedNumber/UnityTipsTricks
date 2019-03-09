using Source.Runtime.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Source.Edit
{
    /// <summary>
    /// Draws attributes for <see cref="UnityEngine.Object"/>
    /// </summary>
    [CanEditMultipleObjects, CustomEditor(typeof(UnityEngine.Object), true)]
	public sealed class ObjectInspectorOverride : Editor
	{
		/// <summary>
		/// Draw the default inspector and buttons from the current type
		/// </summary>
		public override void OnInspectorGUI()
		{
			DrawFieldsAndRequirements();
			DrawButtonAttributes();
		}

		/// <summary>
		/// Find all the <see cref="ButtonAttribute"/> for a given type and draw them
		/// </summary>
		private void DrawButtonAttributes()
		{
			var methods = target.GetType()
				.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				.Where(method => method.GetParameters().Length == 0);

			foreach (var method in methods) {
				var buttonAttribute = (ButtonAttribute)Attribute.GetCustomAttribute(method, typeof(ButtonAttribute));

				if (buttonAttribute != null) {
					GUILayout.Space(buttonAttribute.PixelSpacing);

					var buttonName = buttonAttribute.ButtonName;

					if (string.IsNullOrEmpty(buttonName)) {
						buttonName = Regex.Replace(method.Name, "([a-z])([A-Z])", "$1 $2");
					}
					
					if (GUILayout.Button(buttonName)) {
						foreach (var t in targets) {
							method.Invoke(t, null);
						}
					}
				}
			}
		}
	
		private void DrawFieldsAndRequirements()
		{
			var serializeProperty = serializedObject.GetIterator();

			if (serializeProperty.NextVisible(true)) {
				do {
					EditorGUILayout.PropertyField(serializeProperty, true);
					var fieldInfo = target.GetType().GetField(serializeProperty.name, 
						BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

					if (fieldInfo != null) {
						var requiredField = (RequiredFieldAttribute)fieldInfo.GetCustomAttribute(typeof(RequiredFieldAttribute));

						if (requiredField != null && serializeProperty.objectReferenceValue == null) {
							var isMandatory = requiredField.RequiredType == RequiredFieldType.Mandatory;
							var messageType = isMandatory ? MessageType.Error : MessageType.Warning;
							var message = $"{serializeProperty.displayName} {(isMandatory ? "must" : "should")} be assigned!";

							if (!string.IsNullOrEmpty(requiredField.CustomMessage))
								message = requiredField.CustomMessage;

							EditorGUILayout.HelpBox(message, messageType);
						}
					}
				}
				while (serializeProperty.NextVisible(false));
			}
		
			serializedObject.ApplyModifiedProperties();
		}
	}
}