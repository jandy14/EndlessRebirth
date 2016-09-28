using UnityEngine;
using System.Collections;

public class FallingViewCamera : MonoBehaviour {

	public GameObject target;
	public float distance;

	void Start () {}
	void Update ()
	{
		Vector2 velocity = new Vector2((-transform.position.x), (target.transform.position.y - distance - transform.position.y));
		GetComponent<Rigidbody2D>().velocity = velocity * 10;
	}
}
