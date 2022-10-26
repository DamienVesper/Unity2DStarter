using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed; // The constant velocity of the player when in motion.
    private Vector3 movement; // The vector storing the normalized velocity quantity of the player.
    public Rigidbody2D rb; // The rigidbody attached to the player.

    void Update () {
        // Set movement vector to normalized input.
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate () {
        // Set velocity to movement vector multiplied by a scalar.
        rb.velocity = movement * speed;
    }
}
