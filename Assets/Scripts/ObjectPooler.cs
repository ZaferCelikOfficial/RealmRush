using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPooler : MonoBehaviour
{
    //[SerializeField] List<GameObject> pool = new List<GameObject>();
    [SerializeField] [Range(0,50)]int PoolSize = 5;
    [SerializeField] GameObject Enemy;
    [SerializeField] [Range(0.1f, 20)] float SpawnTimer=2f;
    GameObject[] pool;
    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(InstantiateObjects());
    }
    void PopulatePool()
    {
        pool = new GameObject[PoolSize];
        for(int i=0;i<pool.Length;i++)
        {
            pool[i] = Instantiate(Enemy, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectinPool()
    {
        for (int j =0 ; j < pool.Length;j++)
        {
            if (pool[j].activeInHierarchy==false) { pool[j].SetActive(true);return; }
        }
    }
    IEnumerator InstantiateObjects()
    {
        while (true)
        {
            EnableObjectinPool();         
            yield return new WaitForSeconds(SpawnTimer);

        }
    }
}
