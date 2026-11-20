using System.Collections;
using UnityEngine;
public class EnergyTower : MonoBehaviour
{
    public int incomeValue;
    public float interval;
    public GameObject EnergyIcon;
       void Start()
    {
        Debug.Log("EnergyTower");
        StartCoroutine(Interval());
    }
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        IncreaseIncome();
        StartCoroutine(Interval());
    }
    public void IncreaseIncome()
    {
        Energysystem.instance.Gain(incomeValue);
        StartCoroutine(CoinIndication());
    }  
    IEnumerator CoinIndication()
    {
        EnergyIcon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        EnergyIcon.SetActive(false);
    }
}