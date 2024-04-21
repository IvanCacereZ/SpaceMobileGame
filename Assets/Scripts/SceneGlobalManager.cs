using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalManager : MonoBehaviour
{
    private static bool gameLost = false;
    [SerializeField] private static AudioManager audioController;
    private void Start()
    {
        audioController = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioController.ReproduceLobbyMusic();
    }
    public static void LoadScene()
    {
        SceneManager.LoadSceneAsync("LoadScene", LoadSceneMode.Additive);
    }

    public static void LoadMenuScene()
    {
        UnloadGameScene();
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
        audioController.ReproduceLobbyMusic();
    }

    public static void LoadSelectorScene()
    {
        if (IsSceneLoaded("Menu"))
        {
            SceneManager.UnloadSceneAsync("Menu");
        }
        UnloadGameScene();
        if(IsSceneLoaded("Game"))
            SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("CharacterSelector", LoadSceneMode.Additive);
    }

    public static void LoadGameScene()
    {
        audioController.ReproduceGameMusic();
        if (!IsSceneLoaded("Game") && !IsSceneLoaded("Result"))
        {
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
            if (gameLost)
            {
                SceneManager.LoadSceneAsync("Result", LoadSceneMode.Additive);
            }
        }
    }

    public static void UnloadGameScene()
    {
        if (IsSceneLoaded("Game") || IsSceneLoaded("Result"))
        {
            SceneManager.UnloadSceneAsync("Game");
            SceneManager.UnloadSceneAsync("Result");
            gameLost = false;
        }
    }

    public static void UnloadSelectorScreenScene()
    {
        SceneManager.UnloadSceneAsync("CharacterSelector");
    }

    public static bool IsSceneLoaded(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        return scene.isLoaded;
    }

    public static void PlayerLost()
    {
        gameLost = true;
        if (IsSceneLoaded("Game"))
        {
            SceneManager.LoadSceneAsync("Result", LoadSceneMode.Additive);
        }
    }
}
