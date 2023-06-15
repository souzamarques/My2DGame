using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isJumping;
    private bool doubleJump;
    private bool isThrow;
    private float movement;

    public int health = 3;
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private Animator anim;

    public GameObject rock;
    public Transform rockPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameController.instance.UpdateLives(health);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        ThrowRock();
    }

    void FixedUpdate()
    {
        Move();    
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if(movement > 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(movement < 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        if((movement == 0) && (!isJumping) && (!isThrow))
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 2);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if(doubleJump)
                {
                    anim.SetInteger("transition", 2);
                    rb.AddForce(new Vector2(0, jumpForce * 2), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void ThrowRock()
    {
        StartCoroutine("ThrowThrow");
    }

    IEnumerator ThrowThrow()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            isThrow = true;
            anim.SetInteger("transition", 3);
            GameObject Rock = Instantiate(rock, rockPoint.position, rockPoint.rotation);

            if(transform.rotation.y == 0)
            {
                Rock.GetComponent<Rock>().isRight = true;
            }

            if(transform.rotation.y == 180)
            {
                Rock.GetComponent<Rock>().isRight = false;
            }

            yield return new WaitForSeconds(0.15f);
            isThrow = false;
            anim.SetInteger("transition", 0);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);
        anim.SetTrigger("hit");

        if (transform.rotation.eulerAngles.y == 0)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        
        if (transform.rotation.eulerAngles.y == 180)
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 3)
        {
            isJumping = false;
        }    
    }
}