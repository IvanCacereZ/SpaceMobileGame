using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalManager : MonoBehaviour
{
    public static void LoadMenuScene()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
    }
    public static void LoadSelectorScene()
    {
        SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("CharacterSelector", LoadSceneMode.Additive);
    }
    public static void LoadGameScene()
    {
        if (IsSceneLoaded("Game") == false && IsSceneLoaded("Result") == false)
        {
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("Result", LoadSceneMode.Additive);
        }
    }

    public static void UnloadGameScene()
    {
        SceneManager.UnloadSceneAsync("Game");
        SceneManager.UnloadSceneAsync("Result");
    }
    public static void UnloadSelectorScreenScene()
    {
        SceneManager.UnloadSceneAsync("CharacterSelector");
    }
    public static void UnloadSplashScreenScene()
    {
        SceneManager.UnloadSceneAsync("SplashScreen");
    }
    public static bool IsSceneLoaded(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        return scene.isLoaded;
    }
}
