using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	static public int totalDeath;
	public int sceneDeath;

	private float timer_close;
	private GameObject curtain;
	private GameObject gameOb_SceneCount;
	private GameObject gameOb_TotalCount;
	void Start ()
	{
		curtain = GameObject.Find("Curtain");
		gameOb_SceneCount = GameObject.Find("Main Camera/Canvas/SceneDeath/Value");
		gameOb_TotalCount = GameObject.Find("Main Camera/Canvas/TotalDeath/Value");
		sceneDeath = 0;
		if(SceneManager.GetActiveScene().name == "WasteOfLife")
		{
			sceneDeath = GameObject.FindGameObjectsWithTag("Body").Length;
			totalDeath += (sceneDeath - 30);
		}
		if (SceneManager.GetActiveScene().name != "AnotherEnding" && SceneManager.GetActiveScene().name != "BreakWheel")
		{
			gameOb_SceneCount.GetComponent<Text>().text = sceneDeath.ToString();
			gameOb_TotalCount.GetComponent<Text>().text = totalDeath.ToString();
		}
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName != "WasteOfLife" && sceneName != "Ending" && sceneName != "AnotherEnding" && sceneName != "BreakWheel")
			{
				timer_close = 1;
				curtain.GetComponent<Curtain>().SetCurtain(true);
			}
		}
		if(timer_close > 0)
		{
			timer_close -= Time.deltaTime;
			if (timer_close <= 0)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
	public void CountDeath()
	{
		totalDeath++;
		sceneDeath++;
		Debug.Log("scene : " + sceneDeath);
		Debug.Log("total : " + totalDeath);
		gameOb_SceneCount.GetComponent<Text>().text = sceneDeath.ToString();
		gameOb_TotalCount.GetComponent<Text>().text = totalDeath.ToString();

		if(sceneDeath == 30 || sceneDeath >= 40)
		{
			if (SceneManager.GetActiveScene().name == "WasteOfTime")
				EconomyOfTime();
		}
	}
	private void EconomyOfTime()
	{
		GameObject.Find("teleport(finish)").GetComponent<NextStage>().GoNext();
	}

}
