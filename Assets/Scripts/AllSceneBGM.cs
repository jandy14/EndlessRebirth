using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AllSceneBGM : MonoBehaviour {

	private static GameObject musicBox;
	private static float timer;

	public GameObject musicSource;
	public float delay;
	void Start ()
	{
		if(musicBox && SceneManager.GetActiveScene().name == "WasteOfLife")
		{
			Destroy(musicBox);
		}
	}
	void Update ()
	{
		if (!musicBox && timer > delay && SceneManager.GetActiveScene().name != "WasteOfLife" && SceneManager.GetActiveScene().name != "Ending")
		{
			musicBox = Instantiate(musicSource);
			DontDestroyOnLoad(musicBox);
		}

		timer += Time.deltaTime;
		Debug.Log(timer);
	}
}
