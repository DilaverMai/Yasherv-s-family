using _Yasherv_s_Family_.Scripts.Character;

namespace Character
{
    public class StandartEnemy : EnemyBase
    {
        public override void OnSpawn()
        {
            // HealthSystem.Initialize();
            //
            // HealthSystem.OnDeath += () => AnimationSystem.PlayAnimation(EnemyAnimationList.Death);
        }
        
        public override void OnDeath()
        {
            // HealthSystem.OnDeath -= () => AnimationSystem.PlayAnimation(EnemyAnimationList.Death);
        }
    }
}

public class EnemyNav
{
    
}