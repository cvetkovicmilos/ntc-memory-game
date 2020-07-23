using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UcitajPocetnu : MonoBehaviour
{
    public Animator tranzicija;
    public float vreme = 1f;
    public void UcitajPocetak()
    {
        StartCoroutine(UcitajScenu("PocetnaScena"));
    }

    IEnumerator UcitajScenu(string nazivScene)
    {
        tranzicija.SetTrigger("Start");
        yield return new WaitForSeconds(vreme);
        SceneManager.LoadScene(nazivScene);
    }
}
