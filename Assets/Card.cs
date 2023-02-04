using UnityEngine;
using YashervsFamaily.Scripts.Skills;
using UnityEngine.UI;
    
public class Card: MonoBehaviour
{
    public CardData cardData;
    public SkillBase skillData;
    
    public Image CardImage;
    public Text CardName;
    public Text CardDescription;
    
    public void DesignCard()
    {
        CardImage.sprite = cardData.CardImage.sprite;
        CardName.text = cardData.CardName;
        CardDescription.text = cardData.CardDescription;
    }
}