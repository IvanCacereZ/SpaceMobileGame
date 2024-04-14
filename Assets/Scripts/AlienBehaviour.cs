using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class AlienBehaviour : MonoBehaviour
{
    public SelectorSO templatePlayer;
    public float AdamageValue = 10f;
    private float velocidad = 1.0f;
    private StaticAlienObjectPooling objectPool;
    void Update()
    {
        transform.position = new Vector2(transform.position.x - (velocidad * Time.deltaTime), transform.position.y);
        if (transform.position.x <= -10)
        {
            ReturnToPool();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
            ReturnToPool();
        else if (collision.CompareTag("Player"))
        {
            GameManager.updatevida?.Invoke(AdamageValue);
            ReturnToPool();
        }
    }
    public void InitVariables()
    {
        velocidad = templatePlayer.playerSelected.GenerationAlienSpeed;
    }
    public void SetObjectPool(StaticAlienObjectPooling pool)
    {
        objectPool = pool;
    }
    private void ReturnToPool()
    {
        //GameManager.updatevida -= updateVida;
        gameObject.SetActive(false);
        if (objectPool != null)
        {
            objectPool.SetObject(gameObject);
        }
    }
}
