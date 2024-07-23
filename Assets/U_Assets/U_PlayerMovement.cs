using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class U_PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 input;
    public float speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        rb.velocity = input * speed;
    }

    public void OnHit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
