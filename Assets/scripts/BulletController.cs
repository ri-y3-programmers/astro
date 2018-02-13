using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private Rigidbody2D rb;
    private GameObject player;

    public float speed = 100f;

    void Start() {
	player = GameObject.FindWithTag("player_1");
	rb = GetComponent<Rigidbody2D>();
	rb.velocity = transform.up * speed;
    }
}
