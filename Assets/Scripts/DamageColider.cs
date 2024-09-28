using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<LivesDisplay>().DecreaseLives();
        Destroy(other.gameObject);
    }
}
