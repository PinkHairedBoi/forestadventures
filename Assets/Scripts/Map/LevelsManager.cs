using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
	public static Sprite[] starTypes;
	public static TMP_Text levelName;
	public Sprite[] _starTypes;
	public LevelScreen ls;
	public TMP_Text _levelName;

    void Awake()
    {
		levelName = _levelName;
		starTypes = _starTypes;
		LevelScreen._instance = ls;
    }

	public void OnBack()
	{
		SceneManager.LoadScene("Menu");
	}
}
