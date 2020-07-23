using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Podesavanja : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown dropdown;

    Resolution[] rezolucije;

    private void Start()
    {
        rezolucije = Screen.resolutions;
        dropdown.ClearOptions();

        List<string> opcije = new List<string>();
        int brojac = 0;

        for (int i = 0; i < rezolucije.Length; i++)
        {
            string opcija = rezolucije[i].width + "x" + rezolucije[i].height;
            opcije.Add(opcija);

            if (rezolucije[i].height == Screen.height && rezolucije[i].width == Screen.width)
            {
                brojac = i;
            }
        }

        dropdown.AddOptions(opcije);
        dropdown.value = brojac;
        dropdown.RefreshShownValue();
    }

    public void PodesiRezoluciju(int index)
    {
        Resolution rezolucija = rezolucije[index];
        Screen.SetResolution(rezolucija.width, rezolucija.height, Screen.fullScreen);
    }

    public void PodesiZvuk(float jacina)
    {
        audioMixer.SetFloat("jacina", Mathf.Log10(jacina) * 20);
    }

    public void CeoEkran(bool ceoEkran)
    {
        Screen.fullScreen = ceoEkran;
    }
}
