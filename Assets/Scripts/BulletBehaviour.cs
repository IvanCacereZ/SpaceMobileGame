using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletBehaviour : MonoBehaviour
{
    private float velocidad = 1.0f;
    private DynamicObjectPooling objectPool;
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (velocidad * Time.deltaTime), transform.position.y);
        if (transform.position.x >= 10)
        {
            ReturnToPool();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor"))
        {
            ReturnToPool();
        }
        else if (collision.CompareTag("Alien"))
        {
            ReturnToPool();
        }
    }
    public void InitVariables()
    {
        velocidad = 1.0f;
    }
    public void SetObjectPool(DynamicObjectPooling pool)
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
