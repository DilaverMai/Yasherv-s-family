using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AttackerData", menuName = "AttackerData", order = 0)]
public class SkillData: ScriptableObject
{
    public float CoolDown;
    public float SkillRange;
    public int SkillDamage;

    public GameObject Prefab;

    public UnityEvent OnSkillUse;
}