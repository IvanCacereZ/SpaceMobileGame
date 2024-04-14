using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void ChangeSceneName(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ChangeSceneIndex(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void CloseGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
