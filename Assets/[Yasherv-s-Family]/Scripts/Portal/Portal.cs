using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character.Player;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    [SerializeField] private Image blurPanel;
    [SerializeField] private Transform nextTransform;


    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out Player player)) return;
        player.gameObject.SetActive(false);
        player.gameObject.transform.SetPositionAndRotation(nextTransform.position, nextTransform.rotation);
        player.gameObject.SetActive(true);
        blurPanel.DOColor(new Color(0, 0, 0, 0), 2f).From(new Color(0, 0, 0, 255));
        //StartCoroutine(OpenPanel());
    }
/*
    private IEnumerator OpenPanel()
    {
        blurPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        blurPanel.SetActive(false);
    }
    */
}
