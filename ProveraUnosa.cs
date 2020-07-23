using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProveraUnosa : MonoBehaviour
{
    KontrolerIgre kontrolerIgre;

    private void Start()
    {
        kontrolerIgre = GameObject.Find("KontrolerIgre").GetComponent<KontrolerIgre>();
    }

    public void OnMouseDown()
    {        
        if (kontrolerIgre.ProveriKarteSaIzborom(kontrolerIgre.pogodjeno))
        {
            kontrolerIgre.kliknuto = true;
            kontrolerIgre.listaDrzava.Clear();
            kontrolerIgre.brojac = 0;
            kontrolerIgre.pogodjeno = false;

            StartCoroutine(VratiKliknuto());
            StartCoroutine(PrikaziPoruku(true));
        }
        else
        {

            StartCoroutine(PrikaziPoruku(false));
        }
    }

    IEnumerator VratiKliknuto()
    {
        yield return new WaitForSeconds(1);
        kontrolerIgre.kliknuto = false;
    }

    IEnumerator PrikaziPoruku(bool pogodak)
    {
        if (pogodak)
        {
            //kontrolerIgre.odgovor.text = "Погодак!";
            //yield return new WaitForSeconds(3);
            //kontrolerIgre.odgovor.text = "";
        }
        else
        {
            //kontrolerIgre.odgovor.text = "Промашај!";
            //yield return new WaitForSeconds(3);
            //kontrolerIgre.odgovor.text = "";
        }
        yield return new WaitForSeconds(3);
    }
}
