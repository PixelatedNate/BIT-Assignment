using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int speed;

    public Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody.velocity = transform.right * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
