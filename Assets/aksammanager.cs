using UnityEngine;

public class aksammanager : MonoBehaviour
{
    public Transform aksamyemegi;
    public Transform agac;
    public Transform agacsonrasiaicalak;

    public Transform tpPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        aksamyemegi.gameObject.SetActive(true);
        agac.gameObject.SetActive(false);
        agacsonrasiaicalak.gameObject.SetActive(true);
        
        other.gameObject.SetActive(false);
        transform.position = tpPoint.position;
        other.gameObject.SetActive(true);
    }
}
