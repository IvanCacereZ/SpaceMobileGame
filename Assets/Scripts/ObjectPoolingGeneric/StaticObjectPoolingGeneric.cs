using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPooling<T> : MonoBehaviour where T : Component
{
    public List<T> objectPool;
    public T objPrefab;
    public int maxQuantity;

    protected virtual void Start()
    {
        InstantiateObjects();
    }

    public virtual void InstantiateObjects()
    {
        objectPool = new List<T>();
        for (int i = 0; i < maxQuantity; i++)
        {
            T obj = Instantiate(objPrefab, transform.position, transform.rotation);
            obj.gameObject.SetActive(false);
            objectPool.Add(obj);
            obj.transform.SetParent(transform);
        }
    }

    public virtual T GetObject()
    {
        if (objectPool.Count > 0)
        {
            T obj = objectPool[0];
            objectPool.RemoveAt(0);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            Debug.Log("No hay más objetos");
            return null;
        }
    }

    public virtual void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        objectPool.Add(obj);
    }
}
