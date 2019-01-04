using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject settingsMenu;
	public Slider musicSlider;
	public Slider soundSlider;
	public Slider effectsSlider;
	public Image vibroImage;

	public Sprite[] checkboxSprites;

	float music;
	float sound;
	float effects;
	bool vibro;

	public float Music { get => music; set { music = value; PlayerPrefs.SetFloat("music", value); } }
	public float Sound { get => sound; set { sound = value; PlayerPrefs.SetFloat("sound", value); } }
	public float Effects { get => effects; set { effects = value; PlayerPrefs.SetFloat("effects", value); } }
	public bool Vibro { get => vibro; set { vibro = value; PlayerPrefs.SetInt("vibro", value ? 1 : 0); } }

	void Start()
	{
		music = PlayerPrefs.GetFloat("music"); musicSlider.value = music;
		sound = PlayerPrefs.GetFloat("sound"); soundSlider.value = sound;
		effects = PlayerPrefs.GetFloat("effects"); effectsSlider.value = effects;
		vibro = PlayerPrefs.GetInt("vibro") == 1; vibroImage.sprite = checkboxSprites[vibro ? 1 : 0];
	}

	public void LoadGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void LoadMap()
	{
		SceneManager.LoadScene("Map");
	}

	public void SettingsButton()
	{
		mainMenu.SetActive(!mainMenu.activeSelf);
		settingsMenu.SetActive(!mainMenu.activeSelf);
	}

	public void VibroButton()
	{
		Vibro = !Vibro;
		vibroImage.sprite = checkboxSprites[vibro ? 1 : 0];
	}

	public void MusicSlider(float f)
	{
		Music = f;
	}

	public void SoundSlider(float f)
	{
		Sound = f;
	}

	public void EffectsSlider(float f)
	{
		Effects = f;
	}

	public void ExitButton()
	{
		Application.Quit();
	}
}
