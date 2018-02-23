using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    private bool rotating = true;
    private GameObject bullet;

    private string key_forward;
    private string key_left;
    private string key_right;
    private string key_shoot;

    public float rotate_speed = 4f;
    public float max_forward_speed = 7f;
    public float min_forward_speed = 5f;
    public float deceleration = 0.99f;
    public GameObject bullet_prefab;
    
    void Start() {
	rb = GetComponent<Rigidbody2D>();
	rb.freezeRotation = true;
	key_forward = tag + "_forward";
	key_left = tag + "_left";
	key_right = tag + "_right";
	key_shoot = tag + "_shoot";
    }

    void Update() {
	if (Input.GetButton(key_left)) {
	    rotating = true;
	    transform.Rotate(Vector3.forward * rotate_speed);
	}

	if (Input.GetButton(key_right)) {
	    rotating = true;
	    transform.Rotate(Vector3.back * rotate_speed);
	}

	if (!Input.GetButton(key_left) && !Input.GetButton(key_right)) {
	    rotating = false;
	}

	if (Input.GetButton(key_forward)) {
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
