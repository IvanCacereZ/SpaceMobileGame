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
    private void Start()
    {
        GameManager.updatevida += UpdateVidaUI;
        _Life = gameManager.GetVida();
        vidaText.text = _Life.ToString();
        vidaSlider.value = _Life;
    }
    private void Update()
    {
        _Puntos = gameManager.GetPoints();
        PuntosText.text = "Distancia: " + (int) _Puntos;
    }
    private void UpdateVidaUI(float dmg)
    {
        _Life = Mathf.Clamp(gameManager.GetVida() - dmg, 0, 100);
        gameManager.SetVida(_Life);
        vidaText.text = _Life.ToString();
        vidaSlider.value = _Life;
        if(_Life == 0)
        {
            gameManager.isEnd?.Invoke();
        }
    }
}
