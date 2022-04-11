using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject objectToPool;

    [SerializeField] protected int poolSize;

    protected Queue<GameObject> objectPool;

    [SerializeField] private Transform spawnedObjectsParent;

    private void Awake() => objectPool = new Queue<GameObject>();

    public void Initialize(GameObject objectToPool, int poolSize = 6)
    {
        this.objectToPool = objectToPool;
        this.poolSize = poolSize;
    }

    public GameObject CreateObject()
    {
        CreateObjectParentIfNeeded();

        GameObject spawnedObject = null;


        if (objectPool.Count < poolSize)
        {
            spawnedObject = Instantiate(objectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + objectToPool.name + "_" + objectPool.Count;
            spawnedObject.transform.SetParent(spawnedObjectsParent);
        }
        else
        {
            spawnedObject = objectPool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(false);
        }

        objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }

    private void CreateObjectParentIfNeeded()
    {
        if (spawnedObjectsParent == null)
        {
            string name = "ObjectPool_" + objectToPool.name;
            var parentObject = GameObject.Find(name);
            
            if (parentObject != null)
                spawnedObjectsParent = parentObject.transform;
            else
                spawnedObjectsParent = new GameObject(name).transform;
        }
    }
}
