using UnityEngine;
using System.Collections;

public class Level3Switch : MonoBehaviour {

	public GameObject target;
	public GameObject target2;

	void Start() { }
	void Update() { }

	void OnTriggerEnter2D(Collider2D other)
	{
		target.GetComponent<Laser>().Work(false);
		GetComponent<Animator>().SetBool("isPressed", true);

		if(target2)
		{
			target2.active = false;
		}
	}
}
