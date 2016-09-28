using UnityEngine;
using System.Collections;

public class PatrolSwitch : MonoBehaviour {
	public GameObject target;

	void Start() { }
	void Update() { }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player"/* || other.tag == "Body" || other.tag == "Object"*/)
			target.GetComponent<Patrol>().StartPatrol();
	}
}
