using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //member variables here
    private float speed;
    private float jumpHeight;
    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {   
        //initalize member variables
        playerRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        speed=10.0f;
        jumpHeight=6.0f;
    }

    // Update is called once per frame
    //movement input is handled here
    void Update()
    {
        if(Input.GetKey("d")){
            
             
            GetComponent<ConstantForce2D>().relativeForce = new Vector3(speed, 0, 1);
           
        }
        if(Input.GetKey("a")){
            
             
            GetComponent<ConstantForce2D>().relativeForce = new Vector3(-speed, 0, 1);
           
        }
        else if(Input.GetKeyUp("a")||Input.GetKeyUp("d")){
            GetComponent<ConstantForce2D>().relativeForce = new Vector3(0, 0, 1);

         }
         //Temporary ground solution implemented here till better created
         //raycasting is a potential fix
    if(playerRigidBody.transform.position.y<1){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
}
    
    }
}
