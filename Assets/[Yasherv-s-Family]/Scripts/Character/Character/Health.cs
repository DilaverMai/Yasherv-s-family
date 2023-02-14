using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Character
{
    [System.Serializable]
    public class Health:MonoBehaviour,IDamageable,IInitializable
    {
        public CharacterType CharacterType;
        public UnityAction OnHealthChange;
        public UnityAction OnHit;
        public UnityAction OnDeath;
    
        public int MaxHealth;
        public int CurrentHealth;
        public bool isDead => CurrentHealth <= 0;
        
        public Image HealthBarRed;
        public Image HealthBarWhite;
        public Transform HealthBarTransform;
        public CharacterAnimation<CharacterAnimations> CharacterAnimation;

        public ParticleSystem hitParticle;
        public ParticleSystem dieParticle;

        public CharacterType GetCharacterType
        {
            get => CharacterType;
        }

        private void Update()
        {
            HealthBarTransform.transform.LookAt(Camera.main.transform);
        }

        public void SetBar(int health,int maxHealth)
        {
            DOTween.Kill("HpBar");
            var fillAmount = (float)health / maxHealth;
            HealthBarRed.fillAmount = fillAmount;
            HealthBarRed.transform.DOScale(Vector3.one * 1.1f, .1f).SetLoops(2, LoopType.Yoyo).SetId("HpBar");
            HealthBarWhite.DOFillAmount(fillAmount,.1f).SetId("HpBar").SetDelay(0.25f);
        }

        private void Start()
        {
            Initialize();
        }
        

        public void TakeDamage(int damage)
        {
            if(isDead) return;
            
            CurrentHealth -= damage;
            OnHealthChange?.Invoke();

            if(CurrentHealth < 0)
                CurrentHealth = 0;

            SetBar(CurrentHealth, MaxHealth);
            if (isDead)
            {
                OnDeath?.Invoke();
                CharacterAnimation.PlayAnimation(CharacterAnimations.Death);
                dieParticle.Play();
                transform.DOScale(Vector3.zero, .5f).SetDelay(0.5f);
                DOVirtual.DelayedCall( 2f, () =>
                {
                    gameObject.SetActive(false);
                    if (CharacterType == CharacterType.Player)
                    {
                        SceneManager.LoadScene("Menu");
                    }
                });
            }
            else
            {
                CharacterAnimation.PlayAnimation(CharacterAnimations.Hit);
                hitParticle.Play();
                OnHit?.Invoke();
            }
        }
        
        public void Initialize()
        {
            CurrentHealth = MaxHealth;
        }
    }
}

public interface IUpdater
{
    void OnUpdate();
}