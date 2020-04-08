using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Direction
    {
        right,
        left
    }

    //Serialize Field will show the variables in the Unity Inspector and is generally used whilst developing to allow for quick alterations to variable values
    // before hard-coding it once it is discovered what values feel good.
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpHeight;
    private Rigidbody2D playerRigidBody;
    private Animator anim;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private bool isSlippery;
    private Direction playerFacing;
   
    
    // Component referencing can be done in Awake, which is called upon boot-up of the program.
    void Awake()
    {   
        playerRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded=true;
        isSlippery=false;
    }

    // Start is called during the first frame that *this* script is active.
    // It's good to initialize variables in Start.
    private void Start()
    {

    }

    // Fixed Update is used for anything physics related. Call all methods that manipulate or use physics here.
    // Fixed Update, like "Regular" Update, is called every frame.
    private void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            Movement();
        }
        if(Input.GetButtonDown("Jump") && isGrounded==true)
        {
            
            Jump();
            
        }
    
    }



    // "Regular" Update is used for anything *not* physics related. Call all methods that have nothing to do with physics here.
    // Like Fixed Update, "Regular Update" is called every frame.
    private void Update()
    {
        
        Animate();
        Flip();
    }

    // Sets a temporary float to whatever the Horizontal input of the player is, multiplies it by the speed value, and then assigns
    // the resulting value to our RigidBody's X velocity. We also ensure our Vertical isn't effected by simply stating that the value is
    // what ever the current value is on the Y axis.
    //addforce if on a slippery tilemap
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        playerRigidBody.velocity = new Vector2(horizontal * Time.deltaTime, playerRigidBody.velocity.y);

        if (isSlippery==true)
        {
              if(Input.GetAxis("Horizontal") > 0.1)
              {
                 playerRigidBody.AddForce(transform.right * 4, ForceMode2D.Impulse);

              }
                 if(Input.GetAxis("Horizontal") < -0.1)
        {
                 playerRigidBody.AddForce(-transform.right * 4, ForceMode2D.Impulse);

        }
        }

    }

void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Entered");
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
        if (collision.gameObject.CompareTag("slippery"))
    {
        isGrounded = true;
    }
            if (collision.gameObject.CompareTag("slippery"))
    {
        isSlippery=true;
    }
}
void OnCollisionExit2D(Collision2D collision)
{
    Debug.Log("Exited");
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
    }
        if (collision.gameObject.CompareTag("slippery"))
    {
        isSlippery=false;
    }
}

    // Similar to Movement, it handles the Jumping via applying a value to the Y axis of the Rigidbody.
    void Jump()
    {
        float vertical = jumpHeight * Time.deltaTime;
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, vertical);
    }

    // Checks if the player moves the character left or right and flips the graphics to the appropriate orientation.
    void Flip()
    {
        //Checks to see if the player is already facing the right way
        //If not, rotate him. The rotate is need for the Bullet Spawn Point. If we just create a new vector
        //The spawn point will not rotate and you can only shoot right
        if (Input.GetAxis("Horizontal") > 0.1 && playerFacing != Direction.right)
        {
            playerFacing = Direction.right;
            transform.Rotate(0, 180, 0);

        }
        else if(Input.GetAxis("Horizontal") < -0.1 && playerFacing != Direction.left)
        {
            playerFacing = Direction.left;
            transform.Rotate(0, 180, 0);
            
        }
        
    }

    void Animate()
    {
        if(playerRigidBody.velocity != Vector2.zero )
        {
            anim.Play("Player_Run");
        }
        else
        {
            anim.Play("Player_Idle");
        }
    }
}
