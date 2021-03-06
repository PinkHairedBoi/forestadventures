﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScreen : MonoBehaviour
{
	public GameObject bg;
	public GameObject levelName;
	public GameObject backButton;
	public static LevelScreen _instance;
	public TMP_Text lname;
	public StarsController starsController;

    public void Open()
	{
		Level l = Level.choosen;
		
		lname.text = "<color=#CF0000>Stage 1-" + l.lvl + "</color>\n" + l.lname;
		starsController.Set(l.stars);
		bg.SetActive(true);
		gameObject.SetActive(true);
		levelName.SetActive(false);
		backButton.SetActive(false);
	}

	public void Close()
	{
		bg.SetActive(false);
		gameObject.SetActive(false);
		levelName.SetActive(true);
		backButton.SetActive(true);
	}

	public void Play()
	{
		Level.difficulty = Level.choosen.lvl;
		SceneManager.LoadScene("Level" + Level.difficulty.ToString());
	}
}
