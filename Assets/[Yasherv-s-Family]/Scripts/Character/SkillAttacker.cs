using _Yasherv_s_Family_.Scripts.Character.Attack;

namespace _Yasherv_s_Family_.Scripts.Character
{
    [System.Serializable]
    public class SkillAttacker: Attacker,ISkillable
    {
        public SkillData skillData;
    
        public void UseSkill()
        {
            skillData.OnSkillUse?.Invoke();
        }
    }
}