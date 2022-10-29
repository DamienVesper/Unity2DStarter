using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour {
    private Vector2 mousePos; // A vector quantity containing current mouse position on the screen.
    private Vector3 offset = new Vector3(0.875f, 0, 0); // The offset of the gun relative to the player.

    private GameObject player; // The player's object.
    public new Camera camera; // The camera attached to the scene.
    public Rigidbody2D rb; // The Rigidbody of the gun.

    void Start () {
        // Set references.
        camera = Camera.main;
        player = GameObject.Find("Player");
    }

    void Update () {
        // Set references.
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate () {
        // The point on the scene the gun should face.
        Vector3 playerPos = player.transform.position;
        Vector2 focusPoint = mousePos - new Vector2(playerPos.x, playerPos.y);

        // Calculate the angle of a line that passes through the focus point.
        // From unit circle knowledge this is just a linear function with slope equivalent to tangent of the angle.
        // Using this we can use the magnitude of the vector as a line between the gun and cursor position, and it's slope will be tangent of the angle.
        // Taking the inverse gives the angle that the gun should point at, in radians. This is then converted to degrees.
        float gunDirection = Mathf.Atan2(focusPoint.y, focusPoint.x) * Mathf.Rad2Deg;
        rb.rotation = gunDirection; // Set the rotation of the gun to determined angle.

        // Move the gun to player position with certain offset.
        // The offset is calculated by rotating the offset vector by gunDirection along the z-axis.
        rb.MovePosition(playerPos + (Quaternion.Euler(0, 0, rb.rotation) * offset));
    }
}
