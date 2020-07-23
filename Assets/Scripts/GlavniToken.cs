using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlavniToken : MonoBehaviour
{
    public Sprite lice;
    public Sprite ledja;
    public Sprite spojena;
    public SpriteRenderer spriteRenderer;
    public int indeks;
    KontrolerIgre kontrolerIgre;
    public string drzava = "";
    public List<Sprite> listaSprite;


    public AudioSource klik;

    private void Start()
    {
        foreach(Sprite s in kontrolerIgre.pomocna)
        {
            listaSprite.Add(s);
        }
    }

    public void OnMouseDown()
    {
        kontrolerIgre.brojac++;
        klik.Play();
        if (kontrolerIgre.brojac <= 2)
        {
            if (spriteRenderer.sprite == ledja)
            {
                kontrolerIgre.listaTokena.Add(this);
                spriteRenderer.sprite = listaSprite[indeks];

                if (kontrolerIgre.brojac == 2)
                {
                    StartCoroutine(kontrolerIgre.Provera(kontrolerIgre.SpojeneDveIste(kontrolerIgre.listaTokena)));
                }
            }
            else if (spriteRenderer.sprite != ledja && spriteRenderer.sprite != spojena)
            {
                spriteRenderer.sprite = ledja;
                kontrolerIgre.brojac = 0;
                kontrolerIgre.listaTokena.Clear();
            }
            else
            {
                spriteRenderer.sprite = spojena;
                kontrolerIgre.brojac--;
            } 
        }
    }

    private void Awake()
    {
        kontrolerIgre = GameObject.Find("KontrolerIgre").GetComponent<KontrolerIgre>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
