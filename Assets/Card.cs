using UnityEngine;
using YashervsFamaily.Scripts.Skills;
using UnityEngine.UI;
    

public enum SkillsEnum
{
    Shield,
    Fire,
    Ice,
    Lightning,
    Poison,
    Earth,
    Wind,
    Water,
    Dark,
    Light,
    None
}
public class Card: MonoBehaviour
{
    public SkillsEnum SkillEnums;
    // public CardData cardData;
    // public SkillBase skillData;
    
    // public Image CardImage;
    // public Text CardName;
    // public Text CardDescription;
    //
    // public void DesignCard()
    // {
    //     CardImage.sprite = cardData.CardImage.sprite;
    //     CardName.text = cardData.CardName;
    //     CardDescription.text = cardData.CardDescription;
    // }
}