using UnityEngine;
using System.Collections;

public class LaserControl : MonoBehaviour {

	public GameObject[] laser;

	private float timer;
	private bool isWorking;

	void Start ()
	{
		timer = 0;
		isWorking = false;
	}
	void Update ()
	{
		if(isWorking)
		{
			timer -= Time.deltaTime;
			if (timer < 0)
			{
				GetComponent<Animator>().SetBool("isPressed", false);
				foreach (GameObject target in laser)
				{
					target.GetComponent<Laser>().Work(true);
				}
				isWorking = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Body")
		{
			{
				GetComponent<Animator>().SetBool("isPressed", true);

				foreach (GameObject target in laser)
				{
					target.GetComponent<Laser>().Work(false);
				}
				timer = 5;
				isWorking = true;
			}
		}
	}

	/*void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Body")
		{
			count--;
			if(count == 0)
			{
				GetComponent<Animator>().SetBool("isPressed", false);

				foreach (GameObject target in laser)
				{
					target.GetComponent<Laser>().Work(true);
				}
			}
		}
		Debug.Break();
	}*/
}
