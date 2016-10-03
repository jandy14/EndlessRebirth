using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour {
	
	public string nextStageName;
	private GameObject curtain;
	private float timer_goNext;
	void Start ()
	{
		timer_goNext = 0;
		curtain = GameObject.Find("Curtain");
	}

	void Update ()
	{
		if(timer_goNext > 0)
		{
			timer_goNext -= Time.deltaTime;
			if(timer_goNext <= 0)
			{
				SceneManager.LoadScene(nextStageName);
            }
		}
	
	}
	public void GoNext()
	{
		curtain.GetComponent<Curtain>().SetCurtain(true);
		timer_goNext = 1f;
	}
}
