using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;

    private void laodScene()
    {
        Application.LoadLevel("Game");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        StartButton.onClick.AddListener(laodScene);
        ExitButton.onClick.AddListener(ExitGame);
    }
}