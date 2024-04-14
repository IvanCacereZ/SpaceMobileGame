using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class MeteorBehaviour : MonoBehaviour
{
    public SelectorSO templatePlayer;
    public float MdamageValue = 10f;
    private float velocidad = 1.0f;
    private StaticMeteorObjectPooling objectPool;

    void Update()
    {
        transform.position = new Vector2(transform.position.x - (velocidad * Time.deltaTime), transform.position.y);
        if(transform.position.x <= -10)
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
            GameManager.updatevida?.Invoke(MdamageValue);
            ReturnToPool();
        }
    }
    public void InitVariables()
    {
        velocidad = templatePlayer.playerSelected.GenerationMeteorSpeed;
    }
    public void SetObjectPool(StaticMeteorObjectPooling pool)
    {
        objectPool = pool;
    }
    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        if (objectPool != null)
        {
            objectPool.SetObject(gameObject);
        }
    }
}
