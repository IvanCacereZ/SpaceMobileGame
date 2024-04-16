using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelector : MonoBehaviour
{
    public void ChangeScene(int Scene)
    {
        switch (Scene)
        {
            case 0:
                Debug.Log("No se puede cargar la escena splash");
                break;
            case 1:
                Debug.Log("No se puede cargar la escena SceneGlobalManager por que ya esta cargada");
                break;
            case 2:
                SceneGlobalManager.LoadMenuScene();
                SceneGlobalManager.UnloadGameScene();
                break; 
            case 3:
                SceneGlobalManager.LoadSelectorScene();
                SceneGlobalManager.UnloadGameScene();
                break;
            case 4:
                SceneGlobalManager.LoadGameScene();
                SceneGlobalManager.UnloadSelectorScreenScene();
                break;
            case 5:
                Debug.Log("No se puede cargar la escena Result");
                break;
        }
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
