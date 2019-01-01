using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject effect;
    void Start()
    {
        
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)
		{ 
			FindObjectOfType<GameController>().AddCoin();
            Instantiate(effect).transform.position = transform.position;
            Destroy(transform.parent.gameObject);
		}
	}
}
