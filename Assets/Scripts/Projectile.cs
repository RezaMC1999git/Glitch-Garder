using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage = 100;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] AudioClip SFX;

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);    
    }
    public int GetDamage()
    {
        return damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var healths = other.GetComponent<Health>();
        if (healths != null) 
        {
            healths.DamageDealer(damage);
            AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
        
    }
}
