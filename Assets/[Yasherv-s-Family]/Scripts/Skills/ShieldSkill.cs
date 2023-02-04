using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Player;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

public class ShieldSkill : SkillBase
{
    public override void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        //TODO Shild eklendiğinde..
    }
}
