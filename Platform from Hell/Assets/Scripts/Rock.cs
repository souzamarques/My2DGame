using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public bool isRight;
    public int damage = 1;
    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    void FixedUpdate()
    {
        if(isRight)
        {
            rb.velocity = Vector2.right * speed;
        }
        else
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemySlime>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
