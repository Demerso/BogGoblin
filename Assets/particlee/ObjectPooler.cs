using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pObjects;
    public GameObject objToPool;
    public int amountToPool;
    int x = 0;
    public static ObjectPooler SharedInstance;
    private void Awake()
    {
        SharedInstance = this;
    }
    private void Start()
    {
        pObjects = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
        {
           
            GameObject obj = (GameObject)Instantiate(objToPool);
            obj.SetActive(false);
            
            pObjects.Add(obj);
        }
        
    }

    public GameObject GetPooledObject()
    {
     
        for(int i = 0; i < pObjects.Count; i++)
        {
            
            if (!pObjects[i].activeInHierarchy)
            {
                
                x++;
                return pObjects[i];
            }
        }
        
        return null;
    }
    public void DestroyFirst()
    {
        //Debug.Log(x);
        x = x % amountToPool;
        pObjects[x].SetActive(false);
    }

    
}
