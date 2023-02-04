using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DeckManager : Singleton<DeckManager>
{
    public Card SelectedCard;
    private Coroutine _coroutine;
    
    public List<GameObject> Cards;
    public List<CardPoints> CardPointsList;
    public RectTransform DeckTransform;
    public RectTransform CardsTransform;
    
    private List<Card> spawnedCards = new List<Card>();

    [System.Serializable]
    public struct CardPoints
    {
        public Vector3 CardPoint;
        public Quaternion CardRotation;
    }
    
    [Button]
    public void test()
    {
        StartCoroutine(Deck());
    }
    
    private IEnumerator Deck()
    {
        while (true)
        {
            var selectCards = Cards.ToList();
        
            selectCards.RemoveAt(Random.Range(0,Cards.Count));
        
            selectCards.Shuffle();
        
            for (var i = 0; i < 3; i++)
            {
                var spawnCard = Instantiate(selectCards[i],DeckTransform.position,Quaternion.identity,CardsTransform);
                spawnCard.transform.localScale = Vector3.one * 0.55f;
                spawnCard.transform.DOScale(Vector3.one,1f);
                spawnCard.transform.DOLocalMove(CardPointsList[i].CardPoint,1f);
                spawnCard.transform.DORotateQuaternion(CardPointsList[i].CardRotation,1f);
                spawnedCards.Add(spawnCard.GetComponent<Card>());
                yield return new WaitForSeconds(1f);
            }

            // _coroutine =
            //wait selector coroutine
            yield return  StartCoroutine(Selecter());
        }
    }
    
    private IEnumerator Selecter()
    {
        while (SelectedCard != null)
        {
            yield return null;
        }

        if (spawnedCards.Count == 0) yield break;
        
        SelectedCard = spawnedCards[0];
        SelectedCard.transform.SetSiblingIndex(spawnedCards.Count - 1);

        SelectedCard.transform.DOMoveY(SelectedCard.transform.position.y + 1f,.25f);
        SelectedCard.transform.DOScale(Vector3.one * 1.25f,.5f);
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