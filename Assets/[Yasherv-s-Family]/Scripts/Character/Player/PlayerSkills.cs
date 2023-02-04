using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.Skills;
using Object = UnityEngine.Object;

namespace YashervsFamaily.Scripts.Character.Player
{
    public class PlayerSkills : MonoBehaviour
    {
        public _Yasherv_s_Family_.Scripts.Character.Player.Player player;

        public static Action<SkillsEnum, Vector3> OnSkill;

        [SerializeField] private GameObject iceParticle;
        [SerializeField] private GameObject shakeParticle;
        [SerializeField] private GameObject fireParticle;
        [SerializeField] public GameObject shieldParticle;
        [SerializeField] private GameObject dashParticle;

        private SkillState currenSkillState;

        private SkillState iceSkillState;
        private SkillState shakeSkillState;
        private SkillState fireSkillState;
        private SkillState shieldSkillState;
        private SkillState dashSkillState;

        [SerializeField] public LayerMask layerMask;
        [Range(0f, 10f), SerializeField] public float radius;

        public static Action<Vector3> OnIceSkill;
        public static Action<Vector3> OnShakeSkill;
        public static Action<Vector3> OnFireSkill;
        public static Action<Vector3> OnShieldSkill;
        public static Action OnDashSkill;

        private void Awake()
        {
            iceSkillState = new IceSkillState(iceParticle);
            shakeSkillState = new ShakeSkillState(shakeParticle);
            fireSkillState = new FireSkillState(fireParticle);
            shieldSkillState = new ShieldSkillState(shieldParticle);
            dashSkillState = new DashSkillState(dashParticle);
        }

        private void InvokeBySkill(SkillsEnum skill, Vector3 pos)
        {
            switch (skill)
            {
                case SkillsEnum.Shield:
                    OnShieldSkill?.Invoke(pos);
                    break;
                case SkillsEnum.Fire:
                    Debug.Log("Fire");
                    OnFireSkill?.Invoke(pos);
                    break;
                case SkillsEnum.Ice:
                    OnIceSkill?.Invoke(pos);
                    break;
                case SkillsEnum.Lightning:
                    break;
                case SkillsEnum.Poison:
                    break;
                case SkillsEnum.Earth:
                    OnShakeSkill?.Invoke(pos);
                    break;
                case SkillsEnum.Wind:
                    break;
                case SkillsEnum.Water:
                    break;
                case SkillsEnum.Dark:
                    break;
                case SkillsEnum.Light:
                    break;
                case SkillsEnum.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(skill), skill, null);
            }
        }

        private void OnEnable()
        {
            OnIceSkill += IceSkill;
            OnShakeSkill += ShakeSkill;
            OnFireSkill += FireSkill;
            OnShieldSkill += ShieldSkill;
            // OnDashSkill += DashSkill;

            OnSkill += InvokeBySkill;
        }

        private void OnDisable()
        {
            OnIceSkill -= IceSkill;
            OnShakeSkill -= ShakeSkill;
            OnFireSkill -= FireSkill;
            OnShieldSkill -= ShieldSkill;
            // OnDashSkill -= DashSkill;

            OnSkill -= InvokeBySkill;
        }

        private void IceSkill(Vector3 vector3)
        {
            ((IceSkillState)iceSkillState).ParticlePlay(this, vector3);
        }

        private void ShakeSkill(Vector3 vector3)
        {
            ((ShakeSkillState)shakeSkillState).ParticlePlay(this, vector3);
        }

        private void FireSkill(Vector3 vector3)
        {
            ((FireSkillState)fireSkillState).ParticlePlay(this, vector3);
        }

        private void ShieldSkill(Vector3 vector3)
        {
            ((ShieldSkillState)shieldSkillState).ParticlePlay(this, vector3);
        }

        // private void DashSkill()
        // {
        //     ((FireSkillState.DashSkillState)dashSkillState).ParticlePlay(this);
        // }
    }
}

public abstract class SkillState
{
    protected GameObject Particle;
    public abstract void ParticlePlay(PlayerSkills playerSkills, Vector3 position);
}

[System.Serializable]
public class IceSkillState : SkillState
{
    public IceSkillState(GameObject particle)
    {
        this.Particle = particle;
    }

    public override void ParticlePlay(PlayerSkills playerSkills, Vector3 pos)
    {
        playerSkills.StartCoroutine(Fire(playerSkills, pos));
    }

    IEnumerator Fire(PlayerSkills playerSkills, Vector3 pos)
    {
        for (int i = 0; i < 3; i++)
        {
            pos.y += i * 10f;
            var particle = Object.Instantiate(this.Particle, playerSkills.transform.position, Quaternion.Euler(pos));
            particle.GetComponent<Rigidbody>().velocity = particle.transform.forward * 20f;
            yield return new WaitForSeconds(0.15f);
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

    public override void ParticlePlay(PlayerSkills playerSkills, Vector3 pos)
    {
        Particle.GetComponent<ParticleSystem>().Play();
        Particle.GetComponent<ShakeSkill>().PlayAnimation();
    }


}

[System.Serializable]
public class FireSkillState : SkillState
{
    public FireSkillState(GameObject particle)
    {
        this.Particle = particle;
    }

    public override void ParticlePlay(PlayerSkills playerSkills, Vector3 pos)
    {
        playerSkills.StartCoroutine(Fire(playerSkills, pos));
    }

    IEnumerator Fire(PlayerSkills playerSkills, Vector3 pos)
    {
        for (int i = 0; i < 3; i++)
        {
            var particle = Object.Instantiate(this.Particle, playerSkills.transform.position, Quaternion.Euler(pos));
            // var tempList = playerSkills.player.GetCloseEnemies(playerSkills.radius,playerSkills.layerMask);
            // particle.transform.LookAt(tempList[i].transform.position + Vector3.up);
            particle.GetComponent<Rigidbody>().velocity = particle.transform.forward * 20f;
            yield return new WaitForSeconds(0.15f);
        }
    }
}

[System.Serializable]
public class ShieldSkillState : SkillState
{
    public ShieldSkillState(GameObject particle)
    {
        this.Particle = particle;
    }

    public override void ParticlePlay(PlayerSkills playerSkills, Vector3 position)
    {
        // Particle.transform.SetPositionAndRotation(playerSkills.transform.position, playerSkills.transform.rotation);
        // Particle.GetComponent<ParticleSystem>().Play();
        Particle.GetComponent<ShieldSkill>().StartFunction();
    }
}

[System.Serializable]
public class DashSkillState : SkillState
{
    public DashSkillState(GameObject particle)
    {
        this.Particle = particle;
    }

    public override void ParticlePlay(PlayerSkills playerSkills, Vector3 position)
    {
        //TODO Dash
    }
}