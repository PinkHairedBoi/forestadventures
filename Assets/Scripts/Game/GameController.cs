using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController _instance;
    public CoinController CoinController;
	public HeartController HeartController;
	public StarsController StarsController;

    public float speed = 40f;
	public GameObject PlayerPrefab;

	GameObject player;
	CharacterController2D controller;
	float horizontalSpeed = 0f;
	bool isLeft = false;
	bool isRight = false;
	bool isJump = false;

	public GameObject endPanel;
	public GameObject losePanel;

	public float HorizontalSpeed { get => horizontalSpeed; set { if (player == null) return; horizontalSpeed = value; if (value != 0) player.GetComponent<Animator>().SetBool("isRunning", true); else player.GetComponent<Animator>().SetBool("isRunning", false); } }

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

	void Start()
	{
		_instance = this;
		SpawnPlayer();
	}
	
	void Update()
	{
		if (player == null) return;
		HorizontalSpeed = (isLeft ? -1 : 0) + (isRight ? 1 : 0);
		controller.Move(HorizontalSpeed * speed * Time.deltaTime, false, isJump);
	}

	public void SpawnPlayer()
	{
		if (player == null)
		{
			player = Instantiate(PlayerPrefab);
			player.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
			controller = player.GetComponent<CharacterController2D>();
			FindObjectOfType<CameraController>().player = player.transform;
		}
	}

	public void AddCoin()
	{
        CoinController.Add();
	}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

	public void LoseGame()
	{
		OpenLosePanel();
	}

	public void EndGame()
    {
        Invoke("OpenEndPanel", 1f);
    }

	public HeartController GetHealth()
	{
		return HeartController;
	}

    void OpenEndPanel()
    {
        StarsController.SetStars(CoinController.GetStars());
        endPanel.SetActive(true);
    }

	void OpenLosePanel()
	{
		losePanel.SetActive(true);
	}
}
