using UnityEngine;
using System.Collections;

public class Shock : MonoBehaviour {

	public bool isShock;
	public float shockPower;

	private Vector3 position;
	private float timer_Shock;

	void Start ()
	{
		isShock = false;
		timer_Shock = 0;
	}
	void Update ()
	{
		if(isShock)
		{
			this.transform.position = new Vector3(position.x + Random.Range(-shockPower, shockPower), position.y + Random.Range(-shockPower, shockPower));
			timer_Shock -= Time.deltaTime;
			if (timer_Shock < 0)
				isShock = false;
		}
		if (Input.GetKeyDown(KeyCode.S))
			StartShock();
	}

	void StartShock()
	{
		position = this.transform.position;
		isShock = true;
		timer_Shock = 5;
	}
}
