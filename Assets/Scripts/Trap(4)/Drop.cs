using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {

	public GameObject target;

	void Start () {}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			target.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}
}
