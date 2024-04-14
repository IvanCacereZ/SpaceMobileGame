using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMeteorObjectPooling : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject objPrefab;
    public int maxQuantity;
    private void Start()
    {
        InstantiateObjects();
    }
    public void InstantiateObjects()
    {
        GameObject tmp;
        for (int i = 0; i < maxQuantity; i++)
        {
            tmp = Instantiate(objPrefab, transform.position, transform.rotation);
            tmp.GetComponent<MeteorBehaviour>().SetObjectPool(this);
            objectPool.Add(tmp);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
        }
    }
    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            tmp.GetComponent<MeteorBehaviour>().InitVariables();
            return tmp;
        }
        else
        {
            Debug.Log("No hay mas objetos");
            return null;
        }
    }
    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
    }
}
