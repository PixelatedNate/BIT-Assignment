using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject playerObject;
    [SerializeField]
    private int speed;
    private int damage;
    public Rigidbody2D rbody;

    private void Awake()
    {
       
    }


    // Start is called before the first frame update
    void Start()
    {
        
        playerObject = GameObject.Find("Player");
        rbody.velocity = transform.right * speed;
        if (playerObject.transform.position.x > rbody.transform.position.x)
        {
           rbody.AddForce(transform.right * speed);
        }
       else if (playerObject.transform.position.x < rbody.transform.position.x)
        {
            rbody.AddForce(-transform.right * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setDamage(int pdamage) {
        
  
        damage = pdamage;

    }

    public void setProjectileColour(Color ProjectileColour1)
    {

        gameObject.GetComponent<SpriteRenderer>().color = ProjectileColour1;
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Contact was made!");
        Destroy(gameObject);
        if (col.gameObject.tag == "Destroyable" )
        {
            Destroy(col.gameObject);

        }
       else if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().EnemyDamaged(damage);

            int enemyHealth = col.gameObject.GetComponent<EnemyController>().getEnemyHealth();
          
            if (enemyHealth < 1)
            {
                Destroy(col.gameObject);

            

            }
        }
    }
}
