using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform target;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<S_PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 moveDirection = target.position - gameObject.transform.position;
        rb.velocity = moveDirection.normalized * speed;
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        S_PlayerMovement playerMovement = col.gameObject.GetComponent<S_PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.OnHit();
            S_ScoreText.score++;
            Destroy(this.gameObject);
        }
    }
}
