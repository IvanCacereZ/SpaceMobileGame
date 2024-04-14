using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectPooling : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject objPrefab;
    public GameObject GetObjetc()
    {
        GameObject tmp;
        if(objectPool.Count > 0)
        {
            tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            tmp.GetComponent<BulletBehaviour>().InitVariables();
            return tmp;
        }
        else
        {
            tmp = Instantiate(objPrefab, transform.position, transform.rotation);
            tmp.GetComponent<BulletBehaviour>().SetObjectPool(this);
            tmp.GetComponent<BulletBehaviour>().InitVariables();
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(true);
            return tmp;
        }
    }
    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
    }
}
