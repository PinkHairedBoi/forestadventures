using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)
			Player._instance.Kill();

	}
}
