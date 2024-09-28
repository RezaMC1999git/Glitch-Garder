using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<Eraser>();
        foreach (Eraser button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
