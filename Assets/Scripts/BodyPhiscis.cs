using UnityEngine;
using System.Collections;

public class BodyPhiscis : MonoBehaviour {
	void Start () {}
	void Update () {}

	void FixedUpdate()
	{
		AirResistance();
	}
	private void AirResistance()
	{
		if (GetComponent<Rigidbody2D>().velocity.y > 20)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 20);
		}
		else if (GetComponent<Rigidbody2D>().velocity.y < -20)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -20);
		}
		if (GetComponent<Rigidbody2D>().velocity.x > 20)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(20, GetComponent<Rigidbody2D>().velocity.y);
		}
		else if (GetComponent<Rigidbody2D>().velocity.x < -20)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-20, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
