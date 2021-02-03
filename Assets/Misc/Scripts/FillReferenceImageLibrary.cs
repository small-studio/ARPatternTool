#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

class FillReferenceImageLibrary : Editor {
    [MenuItem("SMALL/Add patterns to library")]
    public static void SetPattern() {
        int i = 0;
        var library = (XRReferenceImageLibrary) AssetDatabase.LoadAssetAtPath("Assets/Misc/Data/ReferenceImageLibrary.asset", typeof(XRReferenceImageLibrary));
        UnityEngine.Object[] textureArray = Resources.LoadAll("Patterns", typeof(Texture2D));

        if (textureArray.Length == 0) {
            EditorUtility.DisplayDialog("No Pattern Founded", "Please add pattern in Resources/Patterns folder", "Ok", "");
            return;
        }

        EditorUtility.SetDirty(library);

        while (i < textureArray.Length) {
            Texture2D texture = (Texture2D) textureArray[i];
            if (library.count <= i) {
                UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.Add(library);
            }

            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.SetTexture(library, i, texture, true);
            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.SetSize(library, i, new Vector2(0.1f, 0.1f));
            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.SetName(library, i, texture.name);
            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.SetSpecifySize(library, i, true);
            i++;
        }

        while (i < library.count) {
            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.RemoveAt(library, i);
        }
        if (EditorUtility.DisplayDialog("Pattern Added", "Pattern has been added to library, Do you wish to continue to build menu ? :)", "Yes", "No")) {
            EditorWindow.GetWindow(Type.GetType("UnityEditor.BuildPlayerWindow,UnityEditor"));
        }
    }
}
#endif