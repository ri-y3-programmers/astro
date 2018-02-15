using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private Rigidbody2D rb;
    private GameObject player;

    public GameObject self;
    public float speed = 100f;
    public float destroy_threshold = 100f;

    void Start() {
	player = GameObject.FindWithTag("player_1");
	rb = GetComponent<Rigidbody2D>();
	rb.velocity = transform.up * speed;
    }

    void Update() {
	if (Mathf.Abs(transform.position.x) > destroy_threshold ||
	    Mathf.Abs(transform.position.y) > destroy_threshold) {
	    Object.Destroy(this.self);
	}
    }
}
