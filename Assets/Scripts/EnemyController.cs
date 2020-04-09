using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enemy can only move left and right, so store these options as an enum
    //This enum also returns an int when deciding direction
    enum Direction:int
    {
        Right = 2,
        Left = -2
    }

    [SerializeField]
    private float speed;
    [SerializeField]
    private int enemyHealth;
    [SerializeField]
    private int eDamage;

    [SerializeField]
    private Direction direction = Direction.Right;

    //Will hold the game object to detect the end of a platform
    //This object will be a child of the enemy
    public Transform groundDetector;

  
 

    private void Awake()
    {
        
    }
    void Update()
    { 

    }

    public int getEnemyHealth() {
        return enemyHealth;
    }

    public void EnemyDamaged(int Damage)
    {
       enemyHealth -= Damage;
 

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Movement();
        Detect_Edge();
    }

    void Movement()
    {
        if(direction == Direction.Right)
        {
            //Cast the enum as an int to get the value (2 or -2)
            transform.Translate((int)Direction.Right * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            transform.Translate((int)Direction.Left * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
       
        //Enemy Touches Player
        if (col.gameObject.tag == "Player" )
        {
 
                col.gameObject.GetComponent<PlayerController>().PlayerDamaged(eDamage);

        }
    }



    void Detect_Edge()
    {
        //Create a raycast variable that is looking down and shooting a ray downward
        RaycastHit2D is_ground = Physics2D.Raycast(groundDetector.position, Vector2.down);

        //If the ray doesn't collides with something, it means there is no platform, so change direction
        if(is_ground.collider == false)
        {
            if(direction == Direction.Right)
            {
                direction = Direction.Left;
            }
            else
            {
                direction = Direction.Right;
            }
        }
    }
}
