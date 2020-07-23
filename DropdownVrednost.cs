using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownVrednost : MonoBehaviour
{
    KontrolerIgre kontrolerIgre;
    // Start is called before the first frame update
    void Start()
    {
        kontrolerIgre = GameObject.Find("KontrolerIgre").GetComponent<KontrolerIgre>();
    }

    public void VratiVrednost(int vrednost)
    {
        if (vrednost == 0)
        {
            kontrolerIgre.odabranaDrzava = "србија";
        }
        else if (vrednost == 1)
        {
            kontrolerIgre.odabranaDrzava = "немачка";
        }
        else if (vrednost == 2)
        {
            kontrolerIgre.odabranaDrzava = "италија";
        }
        else if (vrednost == 3)
        {
            kontrolerIgre.odabranaDrzava = "шведска";
        }
    }
}
