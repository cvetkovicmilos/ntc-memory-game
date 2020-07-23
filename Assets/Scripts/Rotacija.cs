using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacija : MonoBehaviour
{
    public Sprite rot1;
    public Sprite rot2;
    SpriteRenderer spriteRenderer;

    private void OnMouseDown()
    {
        if (spriteRenderer.sprite == rot1)
        {
            spriteRenderer.sprite = rot2;
        }
        else
        {
            spriteRenderer.sprite = rot1;
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
