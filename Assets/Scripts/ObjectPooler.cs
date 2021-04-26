using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> pooledEnemyA = null;
    private List<GameObject> pooledEnemyB = null;
    private List<GameObject> pooledBullet = null;
    private List<GameObject> pooledItem = null;
    [SerializeField] private GameObject pooledEnemyAObject = null;
    [SerializeField] private GameObject pooledEnemyBObject = null;
    [SerializeField] private GameObject pooledBulletObject = null;
    [SerializeField] private GameObject pooledItemObject = null;
    [SerializeField] private int enemyPooledAmount = 20;
    [SerializeField] private int otherPooledAmount = 10;
    [SerializeField] private bool willGrow = false;

    private void Start()
    {
        PoolObject();
    }

    private void PoolObject()
    {
        pooledEnemyA = new List<GameObject>();
        for (int i = 0; i < enemyPooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledEnemyAObject);
            obj.SetActive(false);
            pooledEnemyA.Add(obj);
        }
        pooledEnemyB = new List<GameObject>();
        for (int i = 0; i < enemyPooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledEnemyBObject);
            obj.SetActive(false);
            pooledEnemyB.Add(obj);
        }
        pooledBullet = new List<GameObject>();
        for (int i = 0; i < otherPooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledBulletObject);
            obj.SetActive(false);
            pooledBullet.Add(obj);
        }
        pooledItem = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(pooledItemObject);
            obj.SetActive(false);
            pooledItem.Add(obj);
        }
    }

    public GameObject GetPooledEnemyAObject()
    {
        if (willGrow == true && (pooledEnemyA[pooledEnemyA.Count - 1].activeInHierarchy == true))
        {
            GameObject obj = Instantiate(pooledEnemyAObject);
            obj.SetActive(false);
            pooledEnemyA.Add(obj);
        }
        for (int i = 0; i < pooledEnemyA.Count; i++)
        {
            if (!pooledEnemyA[i].activeInHierarchy)
            {
                return pooledEnemyA[i];
            }
        }
        return null;
    }

    public GameObject GetPooledEnemyBObject()
    {
        if (willGrow == true && (pooledEnemyB[pooledEnemyB.Count - 1].activeInHierarchy == true))
        {
            GameObject obj = Instantiate(pooledEnemyBObject);
            obj.SetActive(false);
            pooledEnemyB.Add(obj);
        }
        for (int i = 0; i < pooledEnemyB.Count; i++)
        {
            if (!pooledEnemyB[i].activeInHierarchy)
            {
                return pooledEnemyB[i];
            }
        }
        return null;
    }

    public GameObject GetPooledBulletObject()
    {
        if (willGrow == true && (pooledBullet[pooledBullet.Count - 1].activeInHierarchy == true))
        {
            GameObject obj = Instantiate(pooledBulletObject);
            obj.SetActive(false);
            pooledBullet.Add(obj);
        }
        for (int i = 0; i < pooledBullet.Count; i++)
        {
            if (!pooledBullet[i].activeInHierarchy)
            {
                return pooledBullet[i];
            }
        }
        return null;
    }

    public GameObject GetPooledItemObject()
    {
        if (willGrow == true && (pooledItem[pooledItem.Count - 1].activeInHierarchy == true))
        {
            GameObject obj = Instantiate(pooledItemObject);
            obj.SetActive(false);
            pooledItem.Add(obj);
        }
        for (int i = 0; i < pooledItem.Count; i++)
        {
            if (!pooledItem[i].activeInHierarchy)
            {
                return pooledItem[i];
            }
        }
        return null;
    }
}
