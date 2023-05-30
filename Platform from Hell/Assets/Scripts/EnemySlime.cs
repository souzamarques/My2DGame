using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private float timer;
    private bool walkLeft = true;

    public float speed;
    public float walkTime;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
