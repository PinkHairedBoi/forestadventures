using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	[SerializeField] private float sleepTime = 2f;
	[SerializeField] private float chargedTime = 2f;
	[SerializeField] private float moveTime = 1f;
	readonly float moveRange = 0.25f;

	float startPos;
	float attackPos;

	bool isCharged = true;
	bool isMoving;

	float timer = 0f;
	// Start is called before the first frame update
	void Start()
    {
		timer = sleepTime;
		startPos = transform.localPosition.y;
		attackPos = startPos + moveRange;
	}

    void Update()
    {
		if (timer > 0)
		{ 
			timer -= Time.deltaTime;
		}

		if (timer <= 0)
		{
			if(isMoving)
			{
				isMoving = false;
				timer = isCharged ? chargedTime : sleepTime;
			}
			else
			{
				isCharged = !isCharged;
				isMoving = true;
				timer = moveTime;
			}
		}

		if (isMoving)
		{
			transform.localPosition += new Vector3(0, (isCharged ? moveRange : -moveRange) / moveTime * Time.deltaTime, 0);
		}
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)
			Destroy(collision.gameObject);
	}
}
