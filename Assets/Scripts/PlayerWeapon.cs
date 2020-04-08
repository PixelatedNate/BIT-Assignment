using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform BulletSpawnPoint;

    //We can later change this to a different bullet if we want
    public GameObject BulletType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }

    void FixedUpdate()
    { 
    }


    void Shoot()
    {
        //Create a bullet object
        Instantiate(BulletType, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
    }

}
    
