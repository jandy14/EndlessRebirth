using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	public float distance;
	public float speed;

	private bool isStand;
	private Vector3 originalPosition;

	void Start ()
	{
		isStand = true;
		originalPosition = transform.position;
	}
	
	void Update ()
	{
		if(!isStand)
		{
			if (transform.position.x > originalPosition.x + distance)
				StopPatrol();
			if(transform.position.x < originalPosition.x)
			{
				isStand = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				transform.position = originalPosition;
			}
		}
		if (Input.GetKeyDown(KeyCode.P))
			StartPatrol();
	
	}
	public void StartPatrol()
	{
		if (isStand)
		{
			isStand = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		}
	}
	public void StopPatrol()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * 5, 0);
	}
}
