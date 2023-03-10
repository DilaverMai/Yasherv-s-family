using System;
using UnityEngine;

namespace Character
{
    public enum CharacterAnimations
    {
        Idle,
        Walk,
        Attack,
        Hit,
        Death
    }
    
    
    [Serializable]
    public abstract class CharacterAnimation<T>:MonoBehaviour, IAnimable<T> where T:Enum
    {
        public Animator Anim;
    
        public void PlayAnimation(T animEnum,int layer = 0,float normalizedTime = 1f,float normalizedTransitionTime = 0.15f)
        {
            if(CheckAnim(ref animEnum))
                Anim.CrossFade(animEnum.ToString(), normalizedTransitionTime, layer, normalizedTime);
            else 
                Anim.CrossFade(animEnum.ToString(), normalizedTransitionTime, layer);
        }
        

        public bool CheckAnim(ref T animEnum)
        {
            return Anim.GetCurrentAnimatorStateInfo(0).IsName(animEnum.ToString());
        }

        public virtual void SetSpeed(float speed = 0)
        {
            Anim.SetFloat("Speed", speed);
        }
    }
}