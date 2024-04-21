using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public Slider vidaSlider;
    public Text vidaText;
    public Text PuntosText;
    private float _Puntos;
    private float _Life;
    public Text[] scoreList;
    public HighScoreSO scoreManager;
    private void Start()
    {
        if(gameManager != null)
        {
            GameManager.updatevida += UpdateVidaUI;
            _Life = gameManager.GetVida();
            vidaText.text = _Life.ToString();
            vidaSlider.value = _Life;
        }
        if(scoreManager != null)
        {
            UpdateTextScores();
        }
    }
    private void Update()
    {
        if (gameManager == null)
        {
            return;
        }
        
        _Puntos = gameManager.GetPoints();
        PuntosText.text = "Distancia: " + (int) _Puntos;
    }
    private void UpdateVidaUI(float dmg)
    {
        if (vidaText == null)
        {
            vidaText = GameObject.Find("vidaText").GetComponent<Text>();
        }
        _Life = Mathf.Clamp(gameManager.GetVida() - dmg, 0, 100);
        gameManager.SetVida(_Life);
        vidaText.text = _Life.ToString();
        vidaSlider.value = _Life;
        if (_Life == 0)
        {
            gameManager.isEnd?.Invoke();
        }
    }
    public void UpdateTextScores()
    {
        for(int i = 0; i < scoreManager.GetScores().Count; i++)
        {
            scoreList[i].text = scoreManager.GetScores()[i].ToString();
        }
    }
}
