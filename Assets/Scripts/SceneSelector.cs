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
                Debug.Log("No se puede cargar la escena SceneAditive por que ya esta cargada");
                break;
            /*case 1:
                SceneGlobalManager.LoadScene("Nombre de la escena");
                SceneGlobalManager.UnloadCurrentScene();
                break;
            case 2:
                break; 
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;*/
            default:
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
