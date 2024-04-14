using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Selector", menuName = "ScriptableObjects/Settings/Selector", order = 2)]
public class SelectorSO : ScriptableObject
{
    public PlayerSO playerSelected;
    public bool GameMode = true;
    public void SelectPlayer(PlayerSO currentPlayer)
    {
        playerSelected = currentPlayer;
    }
    public void SelectGameMode(Button currentButton)
    {
        GameMode = !GameMode;
        if(GameMode) 
        {
            currentButton.image.color = Color.green;
            currentButton.GetComponentInChildren<Text>().text = "Acelerometro";
        }
        else
        {
            currentButton.image.color = Color.cyan;
            currentButton.GetComponentInChildren<Text>().text = "Giroscopio";
        }
    }
}
