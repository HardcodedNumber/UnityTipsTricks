using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Source.Edit
{
    /// <summary>
    /// Helpers for interacting with the editor
    /// </summary>
    public static class EditorUtilities
    {
        public const string ToolsMenuLocation = "Tools/";

        public const string AssetsMenuLocation = "Assets/";
        
        public static List<T> FindAssets<T>(string filter) where T : Object
        {
            var assetsFound = AssetDatabase.FindAssets(filter);
            List<T> assets = new List<T>();

            for (int i = 0; i < assetsFound.Length; ++i) {
                var path = AssetDatabase.GUIDToAssetPath(assetsFound[i]);

                //Ignore any package assets
                if (path.Contains("Packages"))
                    continue;

                assets.Add(AssetDatabase.LoadAssetAtPath<T>(path));
            }

            return assets;
        }
    }
}