using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Projectile,gun;
    AttackerSpawner myLaneSpawner;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    Animator animator;

    private void Start()
    {
       SetLaneSpawner();
       animator = GetComponent<Animator>();
       CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner sps in spawners) 
        {
            bool ISCloseEnough = (Mathf.Abs(sps.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (ISCloseEnough)
                myLaneSpawner = sps;
        }
    }

    private void Update()
    {
      if (IsAttackerInMyLane())
            animator.SetBool("IsAttacking", true);
      else
            animator.SetBool("IsAttacking", false);
    }

    private bool IsAttackerInMyLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    public void Fire() 
    {
      GameObject prj = Instantiate(Projectile, gun.transform.position, Quaternion.identity) as GameObject;
      prj.transform.parent = projectileParent.transform;
    }
}
