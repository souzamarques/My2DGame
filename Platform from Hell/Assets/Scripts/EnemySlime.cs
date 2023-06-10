using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private bool walkLeft = true;
    private float timer;

    public int health = 2;
    public int damage = 1;
    public float speed;
    public float walkTime;

    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer >= walkTime)
        {
            walkLeft = !walkLeft;
            timer = 0f;
        }

        if(walkLeft)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rb.velocity = Vector2.left * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rb.velocity = Vector2.right * speed;
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {    
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
}
