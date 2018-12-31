using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
	public Slider sl;
	public GameObject tip;

	bool sceneLoaded = false;
	AsyncOperation async;

	void Start()
    {
		StartCoroutine("LoadMainMenu");
	}
	
	IEnumerator LoadMainMenu()
	{
		async = SceneManager.LoadSceneAsync("Menu");
		async.allowSceneActivation = false;
		while (async.progress < .9f)
		{
			sl.value = async.progress;
			yield return null;
		}
		sl.value = 1f;
		Invoke("processNext", 0.5f);
	}

	void processNext()
	{
		sceneLoaded = true;
		sl.gameObject.SetActive(false);
		tip.SetActive(true);
	}

	public void GoToMainMenu()
	{

		if (sceneLoaded) { async.allowSceneActivation = true; }
	}
}
