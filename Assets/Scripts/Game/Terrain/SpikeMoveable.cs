using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoveable : MonoBehaviour
{
	enum MoveDir
	{
		Down = -1, Up = 1
	}

	[SerializeField] private float speed = 2f;
	[SerializeField] private float downTime = 2f;
	[SerializeField] private float upTime = 2f;

	float downPos;
	float upPos;

	bool pause = true;
	float timer;

	MoveDir dir = MoveDir.Up;
	

	// Start is called before the first frame update
	void Start()
    {
		float size = GetComponent<SpriteRenderer>().bounds.size.y;
		upPos = transform.position.y;
		downPos = upPos - size * 1.1f;
		transform.position = new Vector2(transform.position.x, downPos);
		timer = downTime;
	}

    void Update()
    {
		if (!pause)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + (int)dir * speed * Time.deltaTime);
			if (dir == MoveDir.Up && transform.position.y >= upPos)
			{
				transform.position = new Vector2(transform.position.x, upPos);
				timer = upTime;
				dir = MoveDir.Down;
				pause = true;
			}
			if (dir == MoveDir.Down && transform.position.y <= downPos)
			{
				transform.position = new Vector2(transform.position.x, downPos);
				timer = downTime;
				dir = MoveDir.Up;
				pause = true;
			}
		}
		if(pause)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
				pause = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)
			Player._instance.Damage();
			
	}
}
