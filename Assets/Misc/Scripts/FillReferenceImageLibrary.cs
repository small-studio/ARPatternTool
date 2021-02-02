#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

class FillReferenceImageLibrary : Editor {
    [MenuItem("SMALL/Set Pattern")]
    public static void SetPattern() {
        int i = 0;
        var library = (XRReferenceImageLibrary) AssetDatabase.LoadAssetAtPath("Assets/Misc/Data/ReferenceImageLibrary.asset", typeof(XRReferenceImageLibrary));
        Object[] textureArray = Resources.LoadAll("Patterns", typeof(Texture2D));

        EditorUtility.SetDirty(library);

        while (i < textureArray.Length) {
            Texture2D texture = (Texture2D) textureArray[i];
            if (library.count < i) {
                UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.Add(library);
            }

            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.SetTexture(library, i, texture, true);
            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.SetSize(library, i, new Vector2(0.1f, 0.1f));
            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.SetName(library, i, texture.name);
            i++;
        }

        while (i < library.count) {
            UnityEditor.XR.ARSubsystems.XRReferenceImageLibraryExtensions.RemoveAt(library, i);
        }

    }
}
#endif