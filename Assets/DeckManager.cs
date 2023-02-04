using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public Image SelecetedImage;
    public List<Image> SkillImages;
    private Coroutine _coroutine;
    
    public List<Card> Cards;
    public List<CardPoints> CardPointsList;
    public RectTransform DeckTransform;

    public GameObject CardPrefab;
    
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
        var selectCards = Cards.ToList();
        
        while (selectCards.Count > 3)
        {
            selectCards.RemoveAt(Random.Range(0,Cards.Count));
        }
        
        selectCards.Shuffle();

       
        for (int i = 0; i < 3; i++)
        {
            var spawnCard = Instantiate(CardPrefab,DeckTransform.position,Quaternion.identity);
            spawnCard.transform.DOMove(CardPointsList[0].CardPoint,1f);
            spawnCard.transform.DORotateQuaternion(CardPointsList[0].CardRotation,1f);
            yield return new WaitForSeconds(1f);
            CardPointsList.RemoveAt(0);
        }
        
        // var rand = new int[] { 0,1,2 }.ToList();
        // rand.Shuffle();
        //
        // while (rand.Count != 0)
        // {
        //     if (Input.GetKeyDown(KeyCode.Q))
        //     {
        //         SelecetedImage = SkillImages[rand[0]];
        //         SelecetedImage.transform.DOMoveY(SelecetedImage.transform.position.y +10,1f);
        //         SelecetedImage.transform.DOScale(Vector3.one,.5f);
        //         rand.RemoveAt(0);
        //         yield break;
        //     }
        //     yield return null;
        // }
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