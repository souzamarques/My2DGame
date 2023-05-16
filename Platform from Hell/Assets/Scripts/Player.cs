using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if(movement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(movement < 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }

    void Jump()
    {

    }
}
