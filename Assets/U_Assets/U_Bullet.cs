using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Bullet : MonoBehaviour
{
    private Rigidbody2D rb; 

    public float speed = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 dir)
    {
        rb.velocity = dir.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        U_Enemy enemy = col.gameObject.GetComponent<U_Enemy>();
        if (enemy != null)
        {
            enemy.OnHit();
            U_ScoreText.score++;
            Destroy(this.gameObject);
        }
    }
}
