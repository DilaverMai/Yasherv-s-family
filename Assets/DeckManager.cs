using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.SkillProgress;
using Random = UnityEngine.Random;

public class DeckManager : Singleton<DeckManager>
{
    public Card SelectedCard;
    private Coroutine _coroutine;
    
    public List<GameObject> Cards;
    public List<CardPoints> CardPointsList;
    public RectTransform DeckTransform;
    public RectTransform CardsTransform;
    
    private List<Card> spawnedCards = new List<Card>();

    [Serializable]
    public struct CardPoints
    {
        public Vector3 CardPoint;
        public Quaternion CardRotation;
    }

    private void Start()
    {
        StartCoroutine(Deck());
    }

    private void OnEnable()
    {
        PlayerSkills.OnSkill += OnSkill;
    }

    private void OnSkill(SkillsEnum obj, Vector3 vector3)
    {
        ClearCard();
    }

    private void OnDisable()
    {
        PlayerSkills.OnSkill -= OnSkill;
    }

    [Button]
    public void ClearCard()
    {
        spawnedCards.RemoveAt(0);
        SelectedCard.transform.DOScale(Vector3.zero,.25f).OnComplete(() =>
        {
            Destroy(SelectedCard.gameObject);
            SelectedCard = null;
        });
    }

    private bool HaveCard()
    {
        return !SkillManager.Instance.IsFireCollected && !SkillManager.Instance.IsIceCollected &&
                !SkillManager.Instance.IsShakeCollected
                && !SkillManager.Instance.IsShieldCollected;
    }
    
    private IEnumerator Deck()
    {
        while (true)
        {
            Debug.Log("Start Cards");
            var selectCards = Cards.ToList();
        
            selectCards.RemoveAt(Random.Range(0,Cards.Count));

            yield return new WaitUntil(()=> HaveCard() == false);
            
            if (!SkillManager.Instance.IsFireCollected)
            {
                foreach (var card in selectCards)
                {
                    if (card.GetComponent<Card>().SkillEnums == SkillsEnum.Fire)
                    {
                        selectCards.Remove(card);
                    }
                }                
            }
            
            if (!SkillManager.Instance.IsIceCollected)
            {
                foreach (var card in selectCards)
                {
                    if (card.GetComponent<Card>().SkillEnums == SkillsEnum.Ice)
                    {
                        selectCards.Remove(card);
                    }
                }                
            }
            
            if (!SkillManager.Instance.IsShakeCollected)
            {
                foreach (var card in selectCards)
                {
                    if (card.GetComponent<Card>().SkillEnums == SkillsEnum.Earth)
                    {
                        selectCards.Remove(card);
                    }
                }                
            }
            
            if (!SkillManager.Instance.IsShieldCollected)
            {
                foreach (var card in selectCards)
                {
                    if (card.GetComponent<Card>().SkillEnums == SkillsEnum.Shield)
                    {
                        selectCards.Remove(card);
                    }
                }                
            }

            
            selectCards.Shuffle();
        
            for (var i = 0; i <selectCards.Count; i++)
            {
                Debug.Log("Card");
                var spawnCard = Instantiate(selectCards[i],DeckTransform.position,Quaternion.identity,CardsTransform);
                spawnCard.transform.localScale = Vector3.one * 0.55f;
                spawnCard.transform.DOScale(Vector3.one,.5f);
                spawnCard.transform.DOLocalMove(CardPointsList[i].CardPoint,.5f);
                spawnCard.transform.DORotateQuaternion(CardPointsList[i].CardRotation,.5f);
                spawnedCards.Add(spawnCard.GetComponent<Card>());
                yield return new WaitForSeconds(.5f);
            }

            _coroutine = StartCoroutine(Selecter());
            //wait selector coroutine
            
            yield return new WaitUntil(()=> _coroutine == null);
        }
    }
    
    private IEnumerator Selecter()
    {
        while (spawnedCards.Count > 0)
        {
            yield return new WaitUntil(()=> SelectedCard == null);
        
            if(spawnedCards.Count == 0) break;
            SelectedCard = spawnedCards[0];
            SelectedCard.transform.SetSiblingIndex(spawnedCards.Count - 1);

            SelectedCard.transform.DOMoveY(SelectedCard.transform.position.y + 100f,.25f);
            SelectedCard.transform.DOScale(Vector3.one * 1.25f,.5f);
        }
        
        _coroutine = null;
    }
}

public static class CardExtension
{
    public static void Shuffle<T>(this IList<T> list)
    {
        var rng = new System.Random();
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}