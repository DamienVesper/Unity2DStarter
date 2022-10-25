using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Vector3 movement;
    public Rigidbody2D rb;

    // Update is called once per frame.
    void Update () {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    // Update is called once per tick.
    void FixedUpdate () {
        rb.velocity = movement * speed;
    }
}
