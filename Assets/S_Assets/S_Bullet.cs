using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bullet : MonoBehaviour
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
        S_Enemy enemy = col.gameObject.GetComponent<S_Enemy>();
        if (enemy != null)
        {
            enemy.OnHit();
            S_ScoreText.score++;
            Destroy(this.gameObject);
        }
    }
}
