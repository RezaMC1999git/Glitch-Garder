using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject def = other.gameObject;
        if (def.GetComponent<GraveStone>()) 
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
            Debug.Log(def.name);
        }
        else if (def.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(def);
        }
    }
}
