using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.Skills;

public class FireObstacle : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IceSkill iceSkill))
        {
            _particleSystem.Stop();
        }
        if(_particleSystem.isStopped) return;
        if (!other.TryGetComponent(out PlayerSkills playerSkills)) return;
        if (!other.TryGetComponent(out IDamageable damageable)) return;
        damageable.TakeDamage(10);  
    }
}
