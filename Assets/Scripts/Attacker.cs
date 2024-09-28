using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float MoveSpeed = 1f;
    GameObject currentTarget;
    public void SetMovementSpeed(float speed) 
    {
        MoveSpeed = speed;
    }
    private void Awake()
    {
        FindObjectOfType<levelController>().AttackerSpawn();
    }
    private void OnDestroy()
    {
        levelController lc = FindObjectOfType<levelController>();
        if (lc != null)
            lc.AttackerKilled();
    }
    void Update()
    {
        transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (!currentTarget)
            GetComponent<Animator>().SetBool("IsAttacking", false);
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }
    public void StrikeCurrentTarget(float damage) 
    {
        if (!currentTarget)
            return;
        Health health =currentTarget.GetComponent<Health>();
        if (health)
            health.DamageDealer(damage);
    }
}
