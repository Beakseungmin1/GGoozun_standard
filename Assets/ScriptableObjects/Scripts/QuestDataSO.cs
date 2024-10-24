using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultQuestDataSO", menuName = "Scriptable Object/QuestData", order = 0)]

public class QuestDataSO : ScriptableObject
{
    public string QuestName;
    public float QuestRequiredLevel;
    public int QuestNPC;
    public List<int> QuestPrerequisites;




}
