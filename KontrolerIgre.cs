using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class KontrolerIgre : MonoBehaviour
{
    GameObject token;
    IgraTezina igraTezina;
    public static System.Random random = new System.Random();
    int pom = 0;
    int krajnjeVreme;

    public string drzavaSaKartica = ".";
    public string odabranaDrzava = ".";
    public bool pogodjeno;
    public bool kliknuto = false;

    public int brojac = 0;
    public int provera = 0;
    public List<Sprite> listaPodignutih;
    public List<string> listaDrzava;

    DateTime pocetnoVreme;
    DateTime trenutnoVreme;

    int najboljeVreme;

    public AudioSource tacno;
    public AudioSource netacno;

    public TextMeshProUGUI vreme;
    public TextMeshProUGUI ostvrarenoVreme;
    public TextMeshProUGUI rekord;

    public int brojTacnoSpojenih;
    public bool kraj;

    public OdabirTezine odabirTezine;
    public int tezina;
    public int igra;

    public List<Sprite> listaOdabranih;
    public List<int> odabrani = new List<int>();

    public List<Sprite> pomocna;

    public List<Sprite> zastave = new List<Sprite>();
    public List<Sprite> zastave2 = new List<Sprite>();
    public List<Sprite> mape = new List<Sprite>();
    public List<Sprite> grbovi = new List<Sprite>();

    public int[] niz;
    public List<int> indeksi;
    public List<GlavniToken> listaTokena = new List<GlavniToken>();

    [SerializeField] Canvas staro;
    [SerializeField] Canvas novo;

    private void Start()
    {
        GlavniToken glavniToken = token.GetComponent<GlavniToken>();
        pocetnoVreme = DateTime.Now;
        brojTacnoSpojenih = 0;
        kraj = false;
        float xPozicija;
        float yPozicija;
        staro.enabled = true;
        novo.enabled = false;

        najboljeVreme = PlayerPrefs.GetInt(igra.ToString() + tezina.ToString() + "Rekord");
        rekord.text = (najboljeVreme / 60).ToString("00") + ":" + (najboljeVreme - (najboljeVreme / 60) * 60).ToString("00");

        foreach (Sprite s in listaOdabranih)
        {
            pomocna.Add(s);
        }        

        int duzinaListe = listaOdabranih.Count;

        if (tezina == 1)
        {
            xPozicija = -4f;
            yPozicija = 3.5f;

            for (int i = 0; i < duzinaListe; i++)
            {
                pom = random.Next(0, indeksi.Count);
                var temp = Instantiate(token, new Vector3(xPozicija, yPozicija, -5), Quaternion.identity);
                temp.GetComponent<GlavniToken>().indeks = indeksi[pom];
                indeksi.Remove(indeksi[pom]);

                if ((i + 1) % 4 == 0 && i > 2)
                {
                    xPozicija = -4;
                    yPozicija -= 2.4f;
                }
                else
                {
                    xPozicija += 2.5f;
                }
            }
        }

        if (tezina == 2)
        {
            xPozicija = -6.5f;
            yPozicija = 3.5f;

            for (int i = 0; i < duzinaListe; i++)
            {
                pom = random.Next(0, indeksi.Count);
                var temp = Instantiate(token, new Vector3(xPozicija, yPozicija, -5), Quaternion.identity);
                temp.GetComponent<GlavniToken>().indeks = indeksi[pom];
                temp.transform.localScale = temp.transform.localScale / 1.15f;
                indeksi.Remove(indeksi[pom]);

                if ((i + 1) % 6 == 0 && i > 4)
                {
                    xPozicija = -6.5f;
                    yPozicija -= 2.4f;
                }
                else
                {
                    xPozicija += 2.5f;
                }
            }
        }

        if (tezina == 3)
        {
            xPozicija = -7.5f;
            yPozicija = 3.5f;

            for (int i = 0; i < duzinaListe; i++)
            {
                pom = random.Next(0, indeksi.Count);
                var temp = Instantiate(token, new Vector3(xPozicija, yPozicija, -5), Quaternion.identity);
                temp.GetComponent<GlavniToken>().indeks = indeksi[pom];
                temp.transform.localScale = temp.transform.localScale / 1.25f;
                indeksi.Remove(indeksi[pom]);

                if ((i + 1) % 8 == 0 && i > 6)
                {
                    xPozicija = -7.5f;
                    yPozicija -= 2.4f;
                }
                else
                {
                    xPozicija += 2f;
                }
            }
        }
    }

    public List<Sprite> VratiListuOdabranih(int igra, int tezina)
    {
        List<Sprite> lista = new List<Sprite>();

        if (tezina == 1)
        {
            int k = 8;
            var items = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            indeksi = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            var selected = new List<int>();
            double needed = k;
            double available = items.Count;
            var rand = new System.Random();
            while (selected.Count < k)
            {
                if (rand.NextDouble() < needed / available)
                {
                    selected.Add(items[(int)available - 1]);
                    needed--;
                }
                available--;
            }
            odabrani = selected;

            if (igra == 1)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(zastave2[i]);
                    }
                }
            }

            if (igra == 2)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(mape[i]);
                    }
                }
            }

            if (igra == 3)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(grbovi[i]);
                    }
                }
            }
        }

        if (tezina == 2)
        {
            int k = 12;
            var items = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            indeksi = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 });
            var selected = new List<int>();
            double needed = k;
            double available = items.Count;
            var rand = new System.Random();
            while (selected.Count < k)
            {
                if (rand.NextDouble() < needed / available)
                {
                    selected.Add(items[(int)available - 1]);
                    needed--;
                }
                available--;
            }
            odabrani = selected;

            if (igra == 1)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(zastave2[i]);
                    }
                }
            }

            if (igra == 2)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(mape[i]);
                    }
                }
            }

            if (igra == 3)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(grbovi[i]);
                    }
                }
            }
        }

        if (tezina == 3)
        {
            int k = 16; 
            var items = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            indeksi = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 });
            var selected = new List<int>();
            double needed = k;
            double available = items.Count;
            var rand = new System.Random();
            while (selected.Count < k)
            {
                if (rand.NextDouble() < needed / available)
                {
                    selected.Add(items[(int)available - 1]);
                    needed--;
                }
                available--;
            }
            odabrani = selected;

            if (igra == 1)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(zastave2[i]);
                    }
                }
            }

            if (igra == 2)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(mape[i]);
                    }
                }
            }

            if (igra == 3)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (odabrani.Contains(i))
                    {
                        lista.Add(zastave[i]);
                        lista.Add(grbovi[i]);
                    }
                }
            }
        }
        return lista;
    }
    
    public bool SpojeneDveIste(List<GlavniToken> lista)
    {
        if (lista[0].spriteRenderer.sprite.name.Split('-')[0].Equals(lista[1].spriteRenderer.sprite.name.Split('-')[0]))
        {
            return true;
        }
        return false;
    }

    public bool ProveriKarteSaIzborom(bool provera)
    {
        if(provera)
        {
            if(drzavaSaKartica.Contains(odabranaDrzava))
            {
                return true;
            }
        }
        return false;
    }


    private void Awake()
    {
        token = GameObject.Find("Token");
        igraTezina = GameObject.Find("IgraTezina").GetComponent<IgraTezina>();

        igra = igraTezina.Igra;
        tezina = igraTezina.Tezina;

        listaOdabranih = VratiListuOdabranih(igra, tezina);
    }

    public IEnumerator Provera(bool parametar)
    {
        yield return new WaitForSeconds(0.5f);
        if (parametar)
        {
            brojac = 0;
            foreach (GlavniToken gt in listaTokena)
            {
                gt.spriteRenderer.sprite = gt.spojena;
            }
            listaTokena.Clear();
            tacno.Play();
            ProveraKraja();
        }
        else
        {
            brojac = 0;
            foreach (GlavniToken gt in listaTokena)
            {
                gt.spriteRenderer.sprite = gt.ledja;
            }
            listaTokena.Clear();
            netacno.Play();
        }
    }

    private void ProveraKraja()
    {
        brojTacnoSpojenih++;
        if (brojTacnoSpojenih == odabrani.Count)
        {
            kraj = true;
        }
    }

    private void Update()
    {
        if (!kraj)
        {
            trenutnoVreme = DateTime.Now;
            krajnjeVreme = (int)(trenutnoVreme - pocetnoVreme).TotalSeconds;
            int minute = (int)(trenutnoVreme - pocetnoVreme).TotalMinutes;

            vreme.text = minute.ToString("00") + ":" + (krajnjeVreme - minute * 60).ToString("00"); 
        }
        
        if (kraj)
        {
            staro.enabled = false;
            novo.enabled = true;
            ostvrarenoVreme.text = (krajnjeVreme/60).ToString("00") + ":" + (krajnjeVreme - (krajnjeVreme / 60) * 60).ToString("00");

            if (krajnjeVreme < PlayerPrefs.GetInt(igra.ToString() + tezina.ToString() + "Rekord", 1000))
            {
                PlayerPrefs.SetInt(igra.ToString() + tezina.ToString() + "Rekord", krajnjeVreme);
            }
        }
    }
}
