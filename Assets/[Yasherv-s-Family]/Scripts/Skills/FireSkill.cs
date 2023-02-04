using Character;
using UnityEngine;


namespace YashervsFamaily.Scripts.Skills
{ 
    public class FireSkill : SkillBase
    {
        public ParticleSystem hitParticle;
        private Collider _collider;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            if(damageable.GetCharacterType is CharacterType.Player) return;
            _rigidbody.velocity = Vector3.zero;
            _collider.enabled = false;
            damageable.TakeDamage(10);
            hitParticle.Play();
        }
    }
}

