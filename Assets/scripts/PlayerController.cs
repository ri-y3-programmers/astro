using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    private float rotate_speed = 3f;
    private float forward_speed = 7f;
    private float deceleration = 0.99f;
    
    void Start() {
	rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
	if (Input.GetButton("player_left"))
	    transform.Rotate(Vector3.forward * rotate_speed);

	if (Input.GetButton("player_right"))
	    transform.Rotate(Vector3.back * rotate_speed);

	if (Input.GetButton("player_forward"))
	    rb.velocity = transform.up * forward_speed;
	else
	    rb.velocity = deceleration * rb.velocity;
    }
}
