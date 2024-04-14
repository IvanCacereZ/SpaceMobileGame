using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Settings/Player", order = 1)]
public class PlayerSO : ScriptableObject
{
    public Sprite playerSprite;
    public float playerVelocity;
    public float GenerationMeteorSpeed;
    public float GenerationAlienSpeed;
}
