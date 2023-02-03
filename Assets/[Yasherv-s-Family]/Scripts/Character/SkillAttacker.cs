using Character;
using Unity.Collections;

[System.Serializable]
public class SkillAttacker: Attacker,ISkillable
{
    public SkillData skillData;
    
    public void UseSkill()
    {
        skillData.OnSkillUse?.Invoke();
    }
}