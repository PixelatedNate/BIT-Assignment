using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private int healAmount;
    [SerializeField]
    private int damageAmount;
    [SerializeField]
    private string Effect;

    private void Awake()
    {

    }

    //item effects happen here
    void OnTriggerEnter2D(Collider2D col)
    {

        //set heal amount in editor if item heals
        if (col.gameObject.tag == "Player") {
            if (healAmount!=0) {
                col.gameObject.GetComponent<PlayerController>().PlayerHealed(healAmount);
            }

        //set damage amount in editor if item damages
            if (damageAmount!=0)
            {
                col.gameObject.GetComponent<PlayerController>().PlayerDamaged(damageAmount);
            }

        //apply programable effects here by checking if conditions met
            if (Effect!=null) {

                //example condition here
                if (Effect=="redProjectile") {
                    col.gameObject.transform.GetChild(0).gameObject.GetComponent<PlayerWeapon>().updateProjectile(2, Color.red);

                }

            }

            this.gameObject.SetActive(false);
        }
       

    }

}
