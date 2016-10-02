using UnityEngine;
using System.Collections;

public class HorizonViewCamera : MonoBehaviour {

	public GameObject target;

	private bool isMoving;

	void Start()
	{
		isMoving = false;
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 velocity = new Vector2((target.transform.position.x - transform.position.x) * 2, 0);
		if (!isMoving)
		{
			if (velocity.magnitude < 1)
				velocity = new Vector2(0, 0);
			else
				isMoving = true;
		}
		if (isMoving)
		{
			if (velocity.magnitude < 0.3)
			{
				velocity = new Vector2(0, 0);
				isMoving = false;
			}
		}
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
