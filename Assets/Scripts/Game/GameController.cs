using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public float speed = 40f;
	public GameObject PlayerPrefab;

	GameObject Player;
	CharacterController2D controller;
	float horizontalSpeed = 0f;
	bool isLeft = false;
	bool isRight = false;
	bool isJump = false;

	public float HorizontalSpeed { get => horizontalSpeed; set { if (Player == null) return; horizontalSpeed = value; if (value != 0) Player.GetComponent<Animator>().SetBool("isRunning", true); else Player.GetComponent<Animator>().SetBool("isRunning", false); } }

	public void OnPointerDown(bool i)
	{
		if (i)
			isRight = true;
		else
			isLeft = true;
	}

	public void OnPointerUp(bool i)
	{
		if (i)
			isRight = false;
		else
			isLeft = false;
	}

	public void OnJump(bool b)
	{
		isJump = b;
	}

	void Update()
	{
		if (Player == null) return;
		HorizontalSpeed = (isLeft ? -1 : 0) + (isRight ? 1 : 0);
		controller.Move(HorizontalSpeed * speed * Time.deltaTime, false, isJump);
	}

	public void SpawnPlayer()
	{
		if (Player == null)
		{
			Player = Instantiate(PlayerPrefab);
			controller = Player.GetComponent<CharacterController2D>();
			FindObjectOfType<CameraController>().player = Player.transform;
		}
	}

	void Start()
	{
		SpawnPlayer();
	}
}
