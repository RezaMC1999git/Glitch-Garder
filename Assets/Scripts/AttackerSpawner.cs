using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minTimeToRespawn = 1f;
    [SerializeField] float MaxTimeToRespawn = 5f;
    [SerializeField] Attacker[] attackerPrefab;
    void Start()
    {
        StartCoroutine(WaitAndSpawn());
    }

    public void StopSpwan() 
    {
        spawn = false;
    }
    IEnumerator WaitAndSpawn() 
    {
        while (spawn) 
        {
            yield return new WaitForSeconds(Random.Range(minTimeToRespawn, MaxTimeToRespawn));
            Spawn();
        }
    }
    IEnumerator WaitForWaitAndSpawn() 
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(WaitAndSpawn());
    }
    private void Spawn() 
    {
        int i = Random.Range(0, attackerPrefab.Length);
        Attacker atc = Instantiate(attackerPrefab[i], transform.position, Quaternion.identity) as Attacker;
        atc.transform.parent = transform;
    }
}
