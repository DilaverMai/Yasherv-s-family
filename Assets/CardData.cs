using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "Card/CardData", order = 0)]
public class CardData: ScriptableObject
{
    public Image CardImage;
    public string CardName;
    public string CardDescription;
}