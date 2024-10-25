using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public GameObject prefab;
    private List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> Pooldict;
    public int poolSize = 300;

    void Start()
    {
        Pooldict = new Dictionary<string, Queue<GameObject>>();

        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        foreach (var pol in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pol.size; i++)
            {
                GameObject objet = Instantiate(pol.prefab);
                objet.SetActive(false);
                queue.Enqueue(objet);
            }
            Pooldict.Add(pol.tag, queue);
        }
    }

    public GameObject Get(string tag)
    {
        if (!Pooldict.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = Pooldict[tag].Dequeue();
        Pooldict[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.

    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);

        // ���ӿ�����Ʈ�� deactive�Ѵ�.
    }
}
