using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sosomar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject def = other.gameObject;
        if (def.GetComponent<Defender>())
            GetComponent<Attacker>().Attack(def);
    }
}
