using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private Rigidbody2D rb;

    public string shooter;
    public float speed = 100f;
    public float destroy_threshold = 100f;

    void Start() {
	rb = GetComponent<Rigidbody2D>();
	rb.velocity = transform.up * speed;
    }

    void Update() {
	if (Mathf.Abs(transform.position.x) > destroy_threshold ||
	    Mathf.Abs(transform.position.y) > destroy_threshold) {
	    Destroy(gameObject);
	}
    }
}
