using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UcitajKontinente : MonoBehaviour
{
    public Animator tranzicija;
    public float vreme = 1f;
    public void UcitajScenu()
    {
        StartCoroutine(UcitajScenu("KontinentiScena"));
    }

    IEnumerator UcitajScenu(string nazivScene)
    {
        tranzicija.SetTrigger("Start");
        yield return new WaitForSeconds(vreme);
        SceneManager.LoadScene(nazivScene);
    }
}
