using UnityEngine;
using System.Collections;

public class Level4Switch : MonoBehaviour {

	public GameObject[] target;

	private float timer;

	void Start ()
	{
		timer = 0;
	}
	void Update ()
	{
		if(timer > 0)
		{
			timer -= Time.deltaTime;
			if(timer < 0)
			{
				GetComponent<Animator>().SetBool("isPressed", false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" || other.tag == "Body")
		{
			foreach(GameObject t in target)
			{
				t.GetComponent<Laser>().WorkToggle();
				GetComponent<Animator>().SetBool("isPressed", true);
				timer = 0.2f;
			}
		}
	}
}
