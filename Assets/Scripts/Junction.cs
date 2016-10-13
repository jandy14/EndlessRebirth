using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Junction : MonoBehaviour {

	public GameObject player;

	private GameObject curtain;
	private float timer;
	private string nextDestination;
	
	void Start()
	{
		curtain = GameObject.Find("Curtain");
		timer = 0;
	}
	void Update ()
	{
		if(timer > 0)
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				SceneManager.LoadScene(nextDestination);	
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" || other.tag == "Body")
		{
			timer = 3;
			curtain.GetComponent<Curtain>().SetCurtainQuickly(true);

			if (player.transform.position.y > -35)
				nextDestination = "AnotherEnding";
			else
				nextDestination = "Intro";

			GetComponent<AudioSource>().Stop();
		}
	}
}
