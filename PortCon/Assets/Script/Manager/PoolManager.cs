using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int y = 0 ; y <objectToPool.Length; y++)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool[y]);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

    }

    public GameObject GetPooledObject(string Tag)
    {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == Tag)
                {
                
                    return pooledObjects[i];
                }
            } 
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
