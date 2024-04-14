using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public SelectorSO templatePlayer;
    public StaticAlienObjectPooling alienOP;
    public StaticMeteorObjectPooling meteorOP;
    public float minY = 0f;
    public float maxY = 10f;
    public float spawnX = 20f;
    private float intervaloMeteorGeneracion = 1f;
    private float intervaloAlienGeneracion = 1f;
    void Start()
    {
        intervaloMeteorGeneracion = templatePlayer.playerSelected.GenerationMeteorSpeed;
        intervaloAlienGeneracion = templatePlayer.playerSelected.GenerationMeteorSpeed;
        InvokeRepeating("GenerarMeteorito", 0f, intervaloMeteorGeneracion);
        InvokeRepeating("GenerarAlien", 0f, intervaloAlienGeneracion);
    }
    void GenerarMeteorito()
    {
        float posY = Random.Range(minY, maxY);
        GameObject meteor = meteorOP.GetObject();
        meteor.transform.position = new Vector2(spawnX, posY);
    }
    void GenerarAlien()
    {
        float posY = Random.Range(minY, maxY);
        GameObject alien = alienOP.GetObject();
        alien.transform.position = new Vector2(spawnX, posY);
    }
}
