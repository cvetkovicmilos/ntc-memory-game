using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UcitajEvropskeIgre : MonoBehaviour
{
    public Animator tranzicija;
    public float vreme = 1f;
    public void UcitajScenu()
    {
        StartCoroutine(UcitajScenu("IgreEvropa"));
    }

    IEnumerator UcitajScenu(string nazivScene)
    {
        tranzicija.SetTrigger("Start");
        yield return new WaitForSeconds(vreme);
        SceneManager.LoadScene(nazivScene);
    }
}
