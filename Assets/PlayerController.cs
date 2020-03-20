using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float jumpHeight;
    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {   
        playerRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        speed=10.0f;
        jumpHeight=6.0f;
    }

    // Update is called once per frame
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
if(playerRigidBody.transform.position.y<1){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
}
    
    }
}
