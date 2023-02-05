using System;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public  List<GameObject> Balls;
    
    public static Action<SkillsEnum> OnSkill;

    private void Start()
    {
        Balls[0].SetActive(false);
        Balls[1].SetActive(false);
        Balls[2].SetActive(false);
        Balls[3].SetActive(false);
    }

    private void OnEnable()
    {
        OnSkill += OnOpenSkill;
    }

    private void OnDisable()
    {
        OnSkill -= OnOpenSkill;
    }

    private void OnOpenSkill(SkillsEnum obj)
    {
        switch (obj)
        {
            case SkillsEnum.Shield:
                Balls[3].SetActive(true);
                break;
            case SkillsEnum.Fire:
                Balls[0].SetActive(true);
                break;
            case SkillsEnum.Ice:
                Balls[1].SetActive(true);
                break;
            case SkillsEnum.Lightning:
                break;
            case SkillsEnum.Poison:
                break;
            case SkillsEnum.Earth:
                Balls[2].SetActive(true);
                break;
            case SkillsEnum.Wind:
                break;
            case SkillsEnum.Water:
                break;
            case SkillsEnum.Dark:
                break;
            case SkillsEnum.Light:
                break;
            case SkillsEnum.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
        }
    }
}
