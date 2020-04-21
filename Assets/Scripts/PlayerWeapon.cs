using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    private int pdamage;    
    [SerializeField]
    private GameObject BulletType;
    GameObject Projectile;
    public Color ProjectileColour;
    private Vector2? bTrajectory;
    private float bTrajectileFall;
    private String bEffect;



    // Start is called before the first frame update
    void Awake()
    {
        pdamage = 1;
        ProjectileColour = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }



    public void updateProjectile(String Effect,int damage, Color colour)
    {
        pdamage = damage;

        ProjectileColour = colour;

    }

    public void updateProjectile(String Effect,int damage, Color colour, Vector2? Trajectory, float TrajectileFall)
    {
        pdamage = damage;
        bTrajectory = Trajectory;
        bTrajectileFall = TrajectileFall;
        bEffect = Effect;
        ProjectileColour = colour;

    }

    void FixedUpdate()
    {
    }


    void Shoot()
    {
        //Create a bullet object
        Projectile = Instantiate(BulletType, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        //load custom bullet attributes here
        Projectile.GetComponent<Bullet>().setEffect(bEffect);
        Projectile.GetComponent<Bullet>().setDamage(pdamage);
        Projectile.GetComponent<Bullet>().setProjectileColour(ProjectileColour);
        Projectile.GetComponent<Bullet>().setTrajectory(bTrajectory);
        Projectile.GetComponent<Bullet>().setTrajectileFall(bTrajectileFall);
    }

}

