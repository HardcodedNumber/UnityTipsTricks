using System.IO;
using UnityEditor;
using UnityEngine;

namespace Source.Edit
{
    public static class CopyAssetPath
    {
        [MenuItem(EditorUtilities.AssetsMenuLocation + "Copy Full Path", false, 60)]
        private static void CopyFullPath()
        {
            var selection = Selection.activeObject;
            var selectionPath = AssetDatabase.GetAssetPath(selection);
            var path = Application.dataPath.Replace("Assets", string.Empty);
            
            path = Path.Combine(path, selectionPath);

            Debug.Log($"Copied! {path}");
            EditorGUIUtility.systemCopyBuffer = path;
        }

        [MenuItem(EditorUtilities.AssetsMenuLocation + "Copy Full Path", true)]
        private static bool ValidateCopyFullPath()
        {
            var selection = Selection.activeObject;
            var selectionPath = AssetDatabase.GetAssetPath(selection);

            return !selectionPath.Contains("Package");
        }
    }
}