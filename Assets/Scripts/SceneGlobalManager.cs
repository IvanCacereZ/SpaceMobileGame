using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneGlobalManager : MonoBehaviour
{
    public float fadeDuration = 2f;
    public string FirstSceneName;
    private static string currentScene;
    public Image imageLogo;
    public Image background;
    [SerializeField] private static AudioManager audioController;
    private void Start()
    {
        audioController = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        if (IsSceneLoaded(FirstSceneName) == false)
        {
            SceneManager.LoadSceneAsync(FirstSceneName, LoadSceneMode.Additive);
        }

        if (imageLogo != null || background != null)
        {
            StartCoroutine(FadeOutRoutine());
        }
    }
    public static void LoadScene(string nameScene)
    {
        if (IsSceneLoaded(nameScene))
        {
            SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
            currentScene = nameScene;
        }
    }

    public static void UnloadScene(string nameScene)
    {
        if (IsSceneLoaded(nameScene))
            SceneManager.UnloadSceneAsync(nameScene);
    }
    public static void UnloadCurrentScene()
    {
        if (IsSceneLoaded(currentScene))
            SceneManager.UnloadSceneAsync(currentScene);
    }

    public static bool IsSceneLoaded(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        return scene.isLoaded;
    }
    IEnumerator FadeOutRoutine()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            imageLogo.color = new Color(imageLogo.color.r, imageLogo.color.g, imageLogo.color.b, alpha);
            background.color = new Color(background.color.r, background.color.g, background.color.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        imageLogo.color = new Color(imageLogo.color.r, imageLogo.color.g, imageLogo.color.b, 0f);
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0f);
        imageLogo.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }
}
