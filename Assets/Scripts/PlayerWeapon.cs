using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    private int pdamage;

    //We can later change this to a different bullet if we want
    [SerializeField]
    private GameObject BulletType;
    GameObject Projectile;
    private Color ProjectileColour;



    // Start is called before the first frame update
    void Awake()
    {
        pdamage = 1;
        ProjectileColour = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }

   public void updateProjectile(int damage,Color colour) {
        pdamage = damage;
        ProjectileColour = colour;

    }

    void FixedUpdate()
    { 
    }


    void Shoot()
    {
        //Create a bullet object
        Projectile = Instantiate(BulletType, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        Projectile.GetComponent<Bullet>().setDamage(pdamage);
        Projectile.GetComponent<Bullet>().setProjectileColour(ProjectileColour);
    }

}
    
