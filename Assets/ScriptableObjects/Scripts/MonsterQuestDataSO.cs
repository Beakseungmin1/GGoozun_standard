using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterQuestDataSO", menuName = "Scriptable Object/QuestData/MonsterQuestData", order = 1)]
public class MonsterQuestDataSO : QuestDataSO
{
    public float NeedKillMonster;
    public string KillMonserName;
}
