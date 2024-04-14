using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float puntos = 0;
    [SerializeField] private float vida = 100;
    public static Action<float> updatevida;
    public Action isEnd;
    public SelectorSO Selector;
    PlayerSO playerSO;
    private float velocityPlayer = 0;
    public GameObject Nave;
    private void Awake()
    {
        vida = 100;
    }
    private void Start()
    {
        playerSO = Selector.playerSelected;
        Nave.GetComponent<SpriteRenderer>().sprite = playerSO.playerSprite;
        velocityPlayer = playerSO.playerVelocity;
        isEnd += EndGame;
    }
    private void Update()
    {
        puntos += (velocityPlayer * Time.deltaTime);
    }
    public float GetPoints()
    {
        return puntos;
    }
    public float GetVida()
    {
        return vida;
    }
    public void SetVida(float currentVida)
    {
        vida = currentVida;
    }
    private void EndGame()
    {
        vida = 100;
        SceneManager.LoadScene(3);
    }
}
