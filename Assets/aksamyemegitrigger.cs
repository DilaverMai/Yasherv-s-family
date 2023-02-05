using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character.Player;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aksamyemegitrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            SpeechManager.SpeechGirl.Invoke(3);
            DOVirtual.DelayedCall(5, () =>
                SceneManager.LoadScene("Menu")
            );
        }
    }
}
