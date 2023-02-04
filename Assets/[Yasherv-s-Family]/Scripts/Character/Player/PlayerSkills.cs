using System;
using UnityEngine;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.Skills;
using Object = UnityEngine.Object;

namespace YashervsFamaily.Scripts.Character.Player
{
    public class PlayerSkills : MonoBehaviour
    {
        public _Yasherv_s_Family_.Scripts.Character.Player.Player player;
        
        public static Action<SkillsEnum> OnSkill;

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

        // private Action<PlayerSkills> OnIceParticleSkill;
        // private Action<PlayerSkills> OnShakeParticleSkill;
        // private Action<PlayerSkills> OnFireParticleSkill;
        // private Action<PlayerSkills> OnShieldParticleSkill;
        // private Action<PlayerSkills> OnDashParticleSkill;

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

        private void InvokeBySkill(SkillsEnum skill)
        {
            Debug.Log("InvokeBySkill");
            Debug.Log(skill.ToString());
            switch (skill)
            {
                case SkillsEnum.Shield:
                    OnShieldSkill?.Invoke();
                    break;
                case SkillsEnum.Fire:
                    Debug.Log("Fire");
                    OnFireSkill?.Invoke();
                    break;
                case SkillsEnum.Ice:
                    OnIceSkill?.Invoke();
                    break;
                case SkillsEnum.Lightning:
                    break;
                case SkillsEnum.Poison:
                    break;
                case SkillsEnum.Earth:
                    OnShakeSkill?.Invoke();
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
            // OnIceParticleSkill += 
            // OnShakeParticleSkill += 
            // OnFireParticleSkill += 
            // OnShieldParticleSkill += 
            // OnDashParticleSkill += 

            OnIceSkill += IceSkill;
            OnShieldSkill += ShakeSkill;
            OnFireSkill += FireSkill;
            OnShieldSkill += ShieldSkill;
            OnDashSkill += DashSkill;
            
            OnSkill += InvokeBySkill;
        }

        private void OnDisable()
        {
            // OnIceParticleSkill -= ((IceSkillState)iceSkillState).ParticlePlay;
            // OnShakeParticleSkill -= ((ShakeSkillState)shakeSkillState).ParticlePlay;
            // OnFireParticleSkill -= ((FireSkillState)fireSkillState).ParticlePlay;
            // OnShieldParticleSkill -= ((ShieldSkillState)shieldSkillState).ParticlePlay;
            // OnDashParticleSkill -= ((DashSkillState)dashSkillState).ParticlePlay;
            
            OnIceSkill -= IceSkill;
            OnShieldSkill -= ShakeSkill;
            OnFireSkill -= FireSkill;
            OnShieldSkill -= ShieldSkill;
            OnDashSkill -= DashSkill;
            
            OnSkill -= InvokeBySkill;
        }

        private void IceSkill()
        {
            ((IceSkillState)iceSkillState).ParticlePlay(this);
            // OnIceParticleSkill?.Invoke(this);
        }

        private void ShakeSkill()
        {
            // OnShakeParticleSkill?.Invoke(this);
            ((ShakeSkillState)shakeSkillState).ParticlePlay(this);
        }

        private void FireSkill()
        {
            Debug.Log("Fire Fire Fire");
            ((FireSkillState)fireSkillState).ParticlePlay(this);
            //OnFireParticleSkill?.Invoke(this);
        }

        private void ShieldSkill()
        {
            ((ShieldSkillState)shieldSkillState).ParticlePlay(this);
            //OnShieldParticleSkill?.Invoke(this);
        }

        private void DashSkill()
        {
            ((DashSkillState)dashSkillState).ParticlePlay(this);
            //OnDashParticleSkill?.Invoke(this);
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
        //         iceSkillState.ParticlePlay(this);
        //     }
        //
        //     if (Input.GetKeyDown(KeyCode.Q))
        //     {
        //         fireSkillState.ParticlePlay(this);
        //     }
        //
        //     if (Input.GetKeyDown(KeyCode.R))
        //     {
        //         shakeSkillState.ParticlePlay(this);
        //     }
        //     
        // }
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
        var particle = Object.Instantiate(this.Particle,playerSkills.transform.position,Quaternion.identity);
        playerSkills.player.GetCloseEnemies(playerSkills.radius,playerSkills.layerMask);
        
        // for (int i = 0; i < enemyList.Count; i++)
        // {
        //     var tempList = playerSkills.player.GetCloseEnemies(playerSkills.radius,playerSkills.layerMask);
        //     particle.transform.LookAt(tempList[i].transform);
        //     particle.GetComponent<Rigidbody>().velocity = particle.transform.TransformDirection(Vector3.forward * 20f);
        // }
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
        Particle.transform.SetPositionAndRotation(playerSkills.transform.position, playerSkills.transform.rotation);
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
        Particle.transform.SetPositionAndRotation(playerSkills.transform.position, playerSkills.transform.rotation);
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