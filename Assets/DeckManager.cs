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
using YashervsFamaily.Scripts.Skills;
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

    private void OnSkill(SkillsEnum obj)
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
    
    private IEnumerator Deck()
    {
        while (true)
        {
            Debug.Log("Start Cards");
            var selectCards = Cards.ToList();
        
            selectCards.RemoveAt(Random.Range(0,Cards.Count));
        
            selectCards.Shuffle();
        
            for (var i = 0; i < 3; i++)
            {
                Debug.Log("Card");
                var spawnCard = Instantiate(selectCards[i],DeckTransform.position,Quaternion.identity,CardsTransform);
                spawnCard.transform.localScale = Vector3.one * 0.55f;
                spawnCard.transform.DOScale(Vector3.one,1f);
                spawnCard.transform.DOLocalMove(CardPointsList[i].CardPoint,1f);
                spawnCard.transform.DORotateQuaternion(CardPointsList[i].CardRotation,1f);
                spawnedCards.Add(spawnCard.GetComponent<Card>());
                yield return new WaitForSeconds(1f);
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

            SelectedCard.transform.DOMoveY(SelectedCard.transform.position.y + 1f,.25f);
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