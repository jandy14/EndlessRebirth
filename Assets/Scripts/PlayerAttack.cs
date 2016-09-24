using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	void Start () {	}
	

	void Update () { }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			//Debug.Log("Work");
			other.transform.gameObject.GetComponentInParent<PlayerController>().Die();
		}
	}
}
