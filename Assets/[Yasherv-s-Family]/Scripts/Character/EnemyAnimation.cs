using Character;
using DG.Tweening;
using UnityEngine;

namespace _Yasherv_s_Family_.Scripts.Character
{
    public enum EnemyAnimations
    {
        Idle,
        Walk,
        Attack,
        Hit,
        Death
    }

    public class EnemyAnimation : CharacterAnimation<EnemyAnimations>
    {
        public Tween ShakeAnimation(float time,Vector3 strength)
        {
            DOTween.Kill("ShakeAnimation" + gameObject.GetInstanceID());
            return transform.DOShakeScale(time, strength).SetId("ShakeAnimation" + gameObject.GetInstanceID());
        }
    }
}