using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    private bool rotating = true;

    public float rotate_speed = 4f;
    public float max_forward_speed = 7f;
    public float min_forward_speed = 5f;
    public float deceleration = 0.99f;
    public GameObject bullet_prefab;
    
    void Start() {
	rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
	if (Input.GetButton("player_left")) {
	    rotating = true;
	    transform.Rotate(Vector3.forward * rotate_speed);
	}

	if (Input.GetButton("player_right")) {
	    rotating = true;
	    transform.Rotate(Vector3.back * rotate_speed);
	}

	if (!Input.GetButton("player_left") && !Input.GetButton("player_right")) {
	    rotating = false;
	}

	if (Input.GetButton("player_forward")) {
	    if (rotating) {
		rb.velocity = transform.up * min_forward_speed;
	    }
	    else {
		rb.velocity = transform.up * max_forward_speed;
	    }
	}
	else {
	    rb.velocity = deceleration * rb.velocity;
	}

	if (Input.GetButtonDown(key_shoot)) {
	    bullet = Instantiate(bullet_prefab, transform.position, transform.rotation);
	    bullet.GetComponent<BulletController>().shooter = this.tag;
	}
    }

    void OnTriggerEnter2D(Collider2D other) {
	string shooter = other.gameObject.GetComponent<BulletController>().shooter;
	if (other.CompareTag("bullet") && shooter != tag) {
	    Destroy(other.gameObject);
	    Destroy(this.gameObject);
	}
    }
}
