using UnityEngine;
using System.Collections;

public class MakeBody : MonoBehaviour {

	public GameObject body;
	public Vector3 velocity;
	public Quaternion rotation;
	public float frequency;
	public bool isWork;

	private float timer;
	void Start ()
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isWork)
		{
			timer -= Time.deltaTime;
			if(timer < 0)
			{
				GameObject newBody = Instantiate(body, transform.position, rotation) as GameObject;
				newBody.GetComponent<Rigidbody2D>().velocity = velocity;
				timer = frequency;
			}
		}
	}
}
