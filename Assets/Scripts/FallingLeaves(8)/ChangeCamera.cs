using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour
{
	private GameObject targetCamera;
	//private float timer;
	private bool isStart;
	void Start ()
	{
		targetCamera = GameObject.Find("Main Camera");
		//timer = 0;
		isStart = false;
	}
	void Update ()
	{
		/*if (isStart)
			timer += Time.deltaTime;*/
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			targetCamera.GetComponent<CameraMovement>().enabled = false;
			targetCamera.GetComponent<FallingViewCamera>().enabled = true;
			isStart = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			targetCamera.GetComponent<CameraMovement>().enabled = true;
			targetCamera.GetComponent<FallingViewCamera>().enabled = false;
			isStart = false;
			//Debug.Log("timer : " + timer);
			//timer = 0;
		}
	}
}
