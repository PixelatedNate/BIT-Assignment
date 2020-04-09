using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject playerObject;
    [SerializeField]
    private int speed;

    public Rigidbody2D rbody;

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

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Contact was made!");
        Destroy(gameObject);
        if (col.gameObject.tag == "Destroyable" || col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);

        }
    }
}
