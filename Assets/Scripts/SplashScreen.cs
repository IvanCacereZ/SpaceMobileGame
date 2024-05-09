using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public float fadeDuration = 2f;
    public string FirstSceneName;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        if (SceneGlobalManager.IsSceneLoaded(FirstSceneName) == false)
        {
            
        }
        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        gameObject.SetActive(false);
    }
}
