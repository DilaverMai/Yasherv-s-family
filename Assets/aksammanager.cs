using System;
using _Yasherv_s_Family_.Scripts.Character.Player;
using UnityEngine;

public class aksammanager : MonoBehaviour
{
    public Transform aksamyemegi;
    public Transform agac;
    public Transform agacsonrasiaicalak;

    public Transform tpPoint;

    private void Awake()
    {
        aksamyemegi.gameObject.SetActive(false);
        agac.gameObject.SetActive(true);
        agacsonrasiaicalak.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            aksamyemegi.gameObject.SetActive(true);
            agac.gameObject.SetActive(false);
            agacsonrasiaicalak.gameObject.SetActive(true);
            SpeechManager.SpeechGirl.Invoke(4);
            other.gameObject.SetActive(false);
            transform.position = tpPoint.position;
            other.gameObject.SetActive(true);
        }
    }
}
