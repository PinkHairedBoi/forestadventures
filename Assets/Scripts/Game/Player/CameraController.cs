using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform player;
    void FixedUpdate()
    {
		if (!player) return;
		Vector3 pos = transform.position;
		pos.x = player.transform.position.x;
		pos.y = player.transform.position.y;
		transform.position = pos;
    }
}
