using UnityEngine;
using System.Collections;

public class OnGround : MonoBehaviour {

	void Start () {}
	void Update () {}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == "Ground")
		{
			GetComponentInParent<PlayerController>().isJumpable = true;
			foreach(ContactPoint2D point in other.contacts)
			{
				Debug.Log(point.point);
			}
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.tag == "Ground")
		{
			GetComponentInParent<PlayerController>().isJumpable = false;
		}
	}
}
