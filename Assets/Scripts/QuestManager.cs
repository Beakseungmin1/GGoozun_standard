using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    private List<QuestDataSO> questlist = new List<QuestDataSO>();
    [SerializeField] private QuestDataSO QuestDataSO;
    [SerializeField] private QuestDataSO QuestDataSO2;

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

    private void Start()
    {
        questlist.Add(QuestDataSO);
        questlist.Add(QuestDataSO2);

        for (int i = 0; i < questlist.Count; i++)
        {
            if (questlist[i] is MonsterQuestDataSO monsterquest)
            {
                Debug.Log($"* Quest {i + 1} - {monsterquest.QuestName} �ּ� ���� {monsterquest.QuestRequiredLevel}\n" +
                    $"{monsterquest.KillMonserName} �� {monsterquest.NeedKillMonster}���� ����");
            }
            else if (questlist[i] is EncounterQuestDataSO counterquest)
            {
                Debug.Log($"* Quest {i + 1} - {counterquest.QuestName} �ּ� ���� {counterquest.QuestRequiredLevel}\n" +
                    $"{counterquest.targetNPC} �� ��ȭ�ϱ�");
            }
        }

    }


}
