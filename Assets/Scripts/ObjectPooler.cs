using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> pooledEnemy = null;
    private List<GameObject> pooledBullet = null;
    [SerializeField] private GameObject pooledEnemyObject = null;
    [SerializeField] private GameObject pooledBulletObject = null;
    [SerializeField] private int pooledAmount = 20;
    [SerializeField] private bool willGrow = false;

    private void Start()
    {
        pooledEnemy = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledEnemyObject);
            obj.SetActive(false);
            pooledEnemy.Add(obj);
        }
        pooledBullet = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledBulletObject);
            obj.SetActive(false);
            pooledBullet.Add(obj);
        }
    }

    public GameObject GetPooledEnemyObject()
    {
        if (willGrow == true && (pooledEnemy[pooledEnemy.Count - 1].activeInHierarchy == true))
        {
            GameObject obj = Instantiate(pooledEnemyObject);
            obj.SetActive(false);
            pooledEnemy.Add(obj);
        }
        for (int i = 0; i < pooledEnemy.Count; i++)
        {
            if (!pooledEnemy[i].activeInHierarchy)
            {
                return pooledEnemy[i];
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
}
