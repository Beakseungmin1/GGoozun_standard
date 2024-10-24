using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    GameObject QuestManager = new GameObject();
                    QuestManager.AddComponent<QuestManager>();
                }
                return instance;
            }
            else
            {
                return instance;
            }
        }
        set { instance = Instance; }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }
}
