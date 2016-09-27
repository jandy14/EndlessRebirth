using UnityEngine;
using System.Collections;

public class Level2Switch : MonoBehaviour
{
	public GameObject target;

	void Start() { }
	void Update() { }

	void OnTriggerEnter2D(Collider2D other)
	{
		target.active = false;
		GetComponent<Animator>().SetBool("isPressed", true);
	}
}
