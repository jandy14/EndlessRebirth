using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	void Start () {}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(true)
		{
			Work(other);
		}
	}

	private void Work(Collider2D other)
	{
		Debug.Log("work");
	}
}
