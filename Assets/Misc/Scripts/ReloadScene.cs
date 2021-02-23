using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private void OnGUI() {
        if (GUI.Button(new Rect(100, 100, 100, 100), "Reload Scene")) {
            SceneManager.LoadScene("Scene");
        }
    }
}
