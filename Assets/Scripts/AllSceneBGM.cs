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
		string sceneName = SceneManager.GetActiveScene().name;
        if (!musicBox && timer > delay && sceneName != "WasteOfLife" && sceneName != "Ending" && sceneName != "AnotherEnding" && sceneName != "BreakWheel")
		{
			musicBox = Instantiate(musicSource);
			DontDestroyOnLoad(musicBox);
		}

		timer += Time.deltaTime;
		//Debug.Log(timer);
	}
}
