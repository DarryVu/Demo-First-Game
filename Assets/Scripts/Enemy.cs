using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]  float moveSpeed;
    bool moveLeft = true;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dirX = transform.localPosition;
        if (moveLeft) dirX.x -= moveSpeed * Time.deltaTime;
        else dirX.x += moveSpeed * Time.deltaTime;
        transform.localPosition = dirX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.x > 0)
        {
            moveLeft = true;
            flip();
        }else
        {
            moveLeft = false;
            flip();
        }
    }

    public void flip()
    {
        moveLeft = !moveLeft;
        Vector2 face = transform.localScale;
        face.x *= -1;
        transform.localScale = face;
    }
}
