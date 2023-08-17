using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectPooler : SingletonManager<ObjectPooler>
{
    [System.Serializable]
    public class Pool
    {
        [SerializeField] GameObject _prefab;
        [SerializeField] string _tag;
        [SerializeField] int _size;

        public GameObject Prefab
        {
            get { return _prefab; }
            set { _prefab = value; }
        }
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
    }

    [SerializeField] List<Pool> _pools;
    public List<Pool> Pools
    {
        get { return _pools; }
        set { _pools = value; }
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
