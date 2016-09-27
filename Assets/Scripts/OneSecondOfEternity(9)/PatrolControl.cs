using UnityEngine;
using System.Collections;

public class PatrolControl : MonoBehaviour
{

	void Start() { }
	void Update() { }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			GetComponentInParent<Patrol>().StopPatrol();
	}
}
