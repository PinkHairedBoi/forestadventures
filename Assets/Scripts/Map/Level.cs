using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
	public static int difficulty;
	public static Level choosen;

	public int lvl;
	public string lname;
	public StarsController starsController;
	public int stars { get { return starsController.Get(); } }
	bool selected;

	public void OnClick()
	{
		if (choosen != null && choosen != this)
			choosen.Deselect();
		if (choosen == this)
			LevelScreen._instance.Open();
		else if(choosen != this)
		{
			choosen = this;
			choosen.Select();
		}
	}

	public void Select()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		LevelsManager.levelName.text = "<color=#CF0000>Stage 1-" + lvl + "</color>\n" + lname;
	}

	public void Deselect()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}

	private void Start()
	{
		if (PlayerPrefs.HasKey("Lvl" + lvl + "stars"))
		{
			starsController.Set(PlayerPrefs.GetInt("Lvl" + lvl + "stars"));
		}
		else
		{
			PlayerPrefs.SetInt("Lvl" + lvl + "stars", 0);
			starsController.Set(0);
		}
	}
}
