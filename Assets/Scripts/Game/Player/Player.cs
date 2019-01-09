using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]float godModeTime = 5f;

	public static Player _instance;
	HeartController Health;

	void Start()
	{
		_instance = this;
		Health = GameController._instance.GetHealth();
	}

	bool godMode;
    // Start is called before the first frame update
    void GodMode()
	{
		Invoke("DisableGodMode", godModeTime);
		godMode = true;
		GetComponent<Animator>().Play("Blink", 1);
	}

	void DisableGodMode()
	{
		GetComponent<Animator>().Play("Idle", 1);
		godMode = false;
	}

	public bool IsGod()
	{
		return godMode;
	}

	public void Damage()
	{
		if (!godMode)
		{
			Health.Add(-1);
			if(Health.Get() > 0)
			{
				GodMode();
			}
			else
			{
				GameController._instance.LoseGame();
				Destroy(gameObject);
			}
		}
	}

	public void Kill()
	{
		Health.Add(-Health.Get());
		GameController._instance.LoseGame();
		Destroy(gameObject);
	}
}
