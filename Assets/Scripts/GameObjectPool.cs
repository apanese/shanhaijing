using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool:MonoBehaviour { 
    // Start is called before the first frame update
    [SerializeField]
    private GameObject monsterprefab;
    public bool UsePools;
    private Queue<GameObject> pool; 
    public GameObjectPool()
    {
    
    }
    public void Awake()
    {
        
    }
    public GameObject Create()
    {
        GameObject go;
        if (pool == null)
        {
            pool = new Queue<GameObject>();
        }
        if(pool.Count == 0)
        {
            go = Instantiate(monsterprefab,GameManager.Instance.position1,Quaternion.identity);
            
        }else
        {
            go = pool.Dequeue();
            go.SetActive(true);
        }
        return go;
    }
    public void DestoryGO(GameObject go)
    {
        if (pool == null)
        {
            pool = new Queue<GameObject>();
        }
        pool.Enqueue(go);
        go.SetActive(false);
        go.transform.parent = transform;
    }
}
