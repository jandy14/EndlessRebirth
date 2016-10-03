using UnityEngine;
using System.Collections;

public class GetReward : MonoBehaviour {
	void Start () {}
	void Update () {}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == "Player")
		{
			transform.parent = other.transform;
			//other.gameObject.GetComponent<PlayerController>().isDying = true;
		}
	}
}
