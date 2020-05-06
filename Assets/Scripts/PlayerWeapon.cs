using System;
using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    private int pdamage;
    [SerializeField]
    private GameObject BulletType;
    private GameObject Projectile;
    public Color ProjectileColour;
    private Vector2? bTrajectory;
    private float bTrajectileFall;
    private String bEffect;
    [SerializeField]
    private float battackSpeed;
    private GameObject timer;
  
    private bool canFire;



    public void setCanFire(bool tempCanFire){

        canFire = tempCanFire;

}

    // Start is called before the first frame update
    void Awake()
    {
        battackSpeed =0.5f;
           canFire = true;
        pdamage = 1;
        ProjectileColour = Color.white;
        timer = GameObject.Find("Player");
    }

    private IEnumerator resetAttackSpeed(float time)
    {

        //time to sleep for
        yield return new WaitForSeconds(time);
        canFire = true;


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (canFire==true) {
                Shoot();
                canFire = false;
                StartCoroutine(resetAttackSpeed(battackSpeed));

            }
        }


    }



    public void updateProjectile(String Effect,int damage, Color colour, float attackSpeed)
    {
        pdamage = damage;
        Debug.Log(attackSpeed);
        ProjectileColour = colour;

        battackSpeed = attackSpeed;

    }

    public void updateProjectile(String Effect,int damage, Color colour, Vector2? Trajectory, float TrajectileFall, float attackSpeed)
    {
     
        pdamage = damage;
        bTrajectory = Trajectory;
        bTrajectileFall = TrajectileFall;
        bEffect = Effect;
        ProjectileColour = colour;
        battackSpeed = attackSpeed;

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

