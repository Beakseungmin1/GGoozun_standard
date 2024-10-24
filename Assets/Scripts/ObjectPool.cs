using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public Dictionary<string, List<GameObject>> Pools;
    public int poolSize = 300;

    void Start()
    {
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        foreach (var pol in Pools)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject Arrow = Instantiate(prefab);
                pool.Add(Arrow);
                Arrow.SetActive(false);
            }
            Pools.Add(pol.ToString(), pool);
        }
    }

    public GameObject Get()
    {
        foreach(var pol in pool)
        {
            if (!pol.activeSelf)
            {
                pol.SetActive(true);
                return pol;
            }
        }
        return null;
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.

    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        // 게임오브젝트를 deactive한다.
    }
}
