using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Junction : MonoBehaviour {

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
				SceneManager.LoadScene("Intro");	
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			timer = 3;
			curtain.GetComponent<Curtain>().SetCurtainQuickly(true);

			//이부분은 수정해야한다.
			nextDestination = "Intro";
		}
		else if(other.tag == "Body")
		{
			timer = 3;
			curtain.GetComponent<Curtain>().SetCurtainQuickly(true);
			nextDestination = "Intro";
		}
	}
}
