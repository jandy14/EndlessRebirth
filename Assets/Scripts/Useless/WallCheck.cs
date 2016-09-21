using UnityEngine;
using System.Collections;

public class WallCheck : MonoBehaviour {

	public bool isRight;

	void Start () {}
	void Update () {}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Ground")
		{
			if (isRight)
			{
				GetComponentInParent<PlayerController>().isMovableRight = false;
			}
			else
			{
				GetComponentInParent<PlayerController>().isMovableLeft = false;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Ground")
		{
			if (isRight)
			{
				GetComponentInParent<PlayerController>().isMovableRight = true;
			}
			else
			{
				GetComponentInParent<PlayerController>().isMovableLeft = true;
			}
		}
	}
}
