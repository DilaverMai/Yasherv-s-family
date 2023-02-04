using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.Skills;
using Object = UnityEngine.Object;

namespace YashervsFamaily.Scripts.Character.Player
{
    public class PlayerSkills : MonoBehaviour
    {
        public _Yasherv_s_Family_.Scripts.Character.Player player;
        
        [SerializeField] private GameObject iceParticle;
        [SerializeField] private GameObject shakeParticle;
        [SerializeField] private GameObject fireParticle;
        [SerializeField] private GameObject shieldParticle;
        [SerializeField] private GameObject dashParticle;
        
        private SkillState currenSkillState;
        
        private SkillState iceSkillState;
        private SkillState shakeSkillState;
        private SkillState fireSkillState;
        private SkillState shieldSkillState;
        private SkillState dashSkillState;

        [SerializeField] public LayerMask layerMask;
        [Range(0f, 10f), SerializeField] public float radius;

        private Action<PlayerSkills> OnIceParticleSkill;
        private Action<PlayerSkills> OnShakeParticleSkill;
        private Action<PlayerSkills> OnFireParticleSkill;
        private Action<PlayerSkills> OnShieldParticleSkill;
        private Action<PlayerSkills> OnDashParticleSkill;

        public static Action OnIceSkill;
        public static Action OnShakeSkill;
        public static Action OnFireSkill;
        public static Action OnShieldSkill;
        public static Action OnDashSkill;

        private void Awake()
        {
            iceSkillState = new IceSkillState(iceParticle);
            shakeSkillState = new ShakeSkillState(shakeParticle);
            fireSkillState = new FireSkillState(fireParticle);
            shieldSkillState = new ShieldSkillState(shieldParticle);
            dashSkillState = new DashSkillState(dashParticle);
        }

        private void OnEnable()
        {
            OnIceParticleSkill += ((IceSkillState)iceSkillState).ParticlePlay;
            OnShakeParticleSkill += ((ShakeSkillState)shakeSkillState).ParticlePlay;
            OnFireParticleSkill += ((FireSkillState)fireSkillState).ParticlePlay;
            OnShieldParticleSkill += ((ShieldSkillState)shieldSkillState).ParticlePlay;
            OnDashParticleSkill += ((DashSkillState)dashSkillState).ParticlePlay;

            OnIceSkill += IceSkill;
            OnShieldSkill += ShakeSkill;
            OnFireSkill += FireSkill;
            OnShieldSkill += ShieldSkill;
            OnDashSkill += DashSkill;
        }

        private void OnDisable()
        {
            OnIceParticleSkill -= ((IceSkillState)iceSkillState).ParticlePlay;
            OnShakeParticleSkill -= ((ShakeSkillState)shakeSkillState).ParticlePlay;
            OnFireParticleSkill -= ((FireSkillState)fireSkillState).ParticlePlay;
            OnShieldParticleSkill -= ((ShieldSkillState)shieldSkillState).ParticlePlay;
            OnDashParticleSkill -= ((DashSkillState)dashSkillState).ParticlePlay;
            
            OnIceSkill -= IceSkill;
            OnShieldSkill -= ShakeSkill;
            OnFireSkill -= FireSkill;
            OnShieldSkill -= ShieldSkill;
            OnDashSkill -= DashSkill;
        }

        private void IceSkill()
        {
            OnIceParticleSkill?.Invoke(this);
        }

        private void ShakeSkill()
        {
            OnShakeParticleSkill?.Invoke(this);
        }

        private void FireSkill()
        {
            OnFireParticleSkill?.Invoke(this);
        }

        private void ShieldSkill()
        {
            OnShieldParticleSkill?.Invoke(this);
        }

        private void DashSkill()
        {
            OnDashParticleSkill?.Invoke(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print(player.GetCloseEnemies(radius,layerMask).Count);
                iceSkillState.ParticlePlay(this);
            }
        }
    }
}

public abstract class SkillState
{
    protected GameObject Particle;
    public abstract void ParticlePlay(PlayerSkills playerSkills);
}

[System.Serializable]
public class IceSkillState : SkillState
{
    public IceSkillState(GameObject particle)
    {
        this.Particle = particle;
    }

    public override void ParticlePlay(PlayerSkills playerSkills)
    {
        for (int i = 0; i < playerSkills.player.GetCloseEnemies(playerSkills.radius,playerSkills.layerMask).Count; i++)
        {
            var particle = Object.Instantiate(this.Particle,playerSkills.transform.position,Quaternion.identity);
            var tempList = playerSkills.player.GetCloseEnemies(playerSkills.radius,playerSkills.layerMask);
            particle.transform.LookAt(tempList[i].transform);
            particle.GetComponent<Rigidbody>().velocity = particle.transform.TransformDirection(Vector3.forward * 20f);
        }
    }
}

[System.Serializable]
public class ShakeSkillState : SkillState
{
    public ShakeSkillState(GameObject particle)
    {
        this.Particle = particle;
    }
    public override void ParticlePlay(PlayerSkills playerSkills)
    {
        for (int i = 0; i < playerSkills.player.GetCloseEnemies(playerSkills.radius,playerSkills.layerMask).Count; i++)
        {
            var particle = Object.Instantiate(this.Particle,playerSkills.transform.position,Quaternion.identity);
            var tempList = playerSkills.player.GetCloseEnemies(playerSkills.radius,playerSkills.layerMask);
            particle.transform.LookAt(tempList[i].transform);
            particle.GetComponent<Rigidbody>().velocity = particle.transform.TransformDirection(Vector3.forward * 20f);
        }
    }
}
[System.Serializable]
public class FireSkillState : SkillState
{
    public FireSkillState(GameObject particle)
    {
        this.Particle = particle;
    }

    public override void ParticlePlay(PlayerSkills playerSkills)
    {
        Particle.GetComponent<ParticleSystem>().Play();
    }
}

[System.Serializable]
public class ShieldSkillState : SkillState
{
    public ShieldSkillState(GameObject particle)
    {
        this.Particle = particle;
    }
    
    public override void ParticlePlay(PlayerSkills playerSkills)
    {
        Particle.GetComponent<ParticleSystem>().Play();
    }
}

[System.Serializable]
public class DashSkillState : SkillState
{
    public DashSkillState(GameObject particle)
    {
        this.Particle = particle;
    }

    public override void ParticlePlay(PlayerSkills playerSkills)
    {
        //TODO Dash
    }
}