using UnityEngine;
using System.Collections;

public class PeriodLaser : MonoBehaviour {

	public float timer_Sleep;
	public float timer_Act;

	public float timer;

	void Start ()
	{
		timer = timer_Sleep + timer_Act;
	}
	void Update ()
	{
		if (timer < 0)
		{
			GetComponent<Laser>().Work(false);
			timer = timer_Sleep + timer_Act;
		}
		else if (timer < timer_Act)
		{
			GetComponent<Laser>().Work(true);
		}
		
		timer -= Time.deltaTime;
	}
}
