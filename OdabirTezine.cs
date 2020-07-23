using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OdabirTezine : MonoBehaviour
{
    public Toggle lako;
    public Toggle srednje;
    public Toggle tesko;
    public int tezina;

    IgraTezina igraTezina;

    public Animator tranzicija;
    public float vreme = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        igraTezina = GameObject.Find("IgraTezina").GetComponent<IgraTezina>();
        tezina = 1;
    }

    public void DodeliTezinu()
    {
        if (lako.isOn)
        {
            tezina = 1;
        }
        else if (srednje.isOn)
        {
            tezina = 2;
        }
        else if (tesko.isOn)
        {
            tezina = 3;
        }
    }

    public void UpaliZastavaZastava()
    {
        igraTezina.Igra = 1;
        igraTezina.Tezina = tezina;
        UcitajScenu();
    }

    public void UpaliZastavaMapa()
    {
        igraTezina.Igra = 2;
        igraTezina.Tezina = tezina;
        UcitajScenu();
    }

    public void UpaliZastavaGrb()
    {
        igraTezina.Igra = 3;
        igraTezina.Tezina = tezina;
        UcitajScenu();
    }

    public void UcitajScenu()
    {
        StartCoroutine(UcitajScenu("GameplayScena"));
    }

    IEnumerator UcitajScenu(string nazivScene)
    {
        tranzicija.SetTrigger("Start");
        yield return new WaitForSeconds(vreme);
        SceneManager.LoadScene(nazivScene);
    }
}
