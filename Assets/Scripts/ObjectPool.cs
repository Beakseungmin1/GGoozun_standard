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
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
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
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.

    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
    }
}
