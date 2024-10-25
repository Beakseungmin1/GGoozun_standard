using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    private List<QuestDataSO> questlist = new List<QuestDataSO>();
    [SerializeField] private QuestDataSO QuestDataSO;
    [SerializeField] private QuestDataSO QuestDataSO2;

    // [구현사항 2] 정적 프로퍼티 정의
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

    // [구현사항 3] 인스턴스 검사 로직
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
                Debug.Log($"* Quest {i + 1} - {monsterquest.QuestName} 최소 레벨 {monsterquest.QuestRequiredLevel}\n" +
                    $"{monsterquest.KillMonserName} 를 {monsterquest.NeedKillMonster}마리 소탕");
            }
            else if (questlist[i] is EncounterQuestDataSO counterquest)
            {
                Debug.Log($"* Quest {i + 1} - {counterquest.QuestName} 최소 레벨 {counterquest.QuestRequiredLevel}\n" +
                    $"{counterquest.targetNPC} 과 대화하기");
            }
        }

    }


}
