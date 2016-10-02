using UnityEngine;
using System.Collections;

public class StartTrap : MonoBehaviour {

	public GameObject target;

	void Start () {}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			target.GetComponent<PeriodLaser>().enabled = true;
		}
	}
}
