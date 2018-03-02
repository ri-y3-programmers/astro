using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player_transform;
    public int depth = -10;

    void LateUpdate() {
	transform.position = player_transform.position + new Vector3(0, 0, depth);
    }
}
