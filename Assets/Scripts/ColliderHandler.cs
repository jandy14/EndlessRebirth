using UnityEngine;
using System.Collections;

public class ColliderHandler : MonoBehaviour {

	void Start () {}
	void Update () {}

	void OnCollisionEnter2D(Collision2D other)
	{
		/* //닿은 곳들의 평균을 찾아 주는데 딱히 필요없어 보인다.
		float pointX = 0, pointY = 0;
		
		foreach (ContactPoint2D point in other.contacts)
		{
			Debug.Log("test : " + point.normal);
			pointX += point.normal.x;
			pointY += point.normal.y;
		}
		pointX /= other.contacts.Length;
		pointY /= other.contacts.Length;
		Debug.Log("Lenght : " + other.contacts.Length);
		Debug.Log("Result : " + new Vector2(pointX, pointY));*/

		Vector2 point = other.contacts[0].normal;
		//이동관련
		if (point.x < -0.98f)
		{
			if (other.collider.tag == "Ground")
			{
				GetComponent<PlayerController>().isMovableRight = false;
			}
		}
		else if(point.x > 0.98f)
		{
			if (other.collider.tag == "Ground")
				GetComponent<PlayerController>().isMovableLeft = false;
		}
		//점프관련
		if(point.y > 0)
		{
			GetComponent<PlayerController>().isJumpable = true;
			//Debug.Break();
		}
		//Debug.Log("Enter : " + point);
    }

	void OnCollisionExit2D(Collision2D other)
	{
		Vector2 point = other.contacts[0].normal;
		//이동관련
		if (point.x < -0)
		{
			if (other.collider.tag == "Ground")
				GetComponent<PlayerController>().isMovableRight = true;
		}
		else if (point.x > 0)
		{
			if (other.collider.tag == "Ground")
				GetComponent<PlayerController>().isMovableLeft = true;
		}
		//점프관련
		if (point.y > 0.9)
		{
			GetComponent<PlayerController>().isJumpable = false;
		}
		//Debug.Log("Exit : " + point);
	}
	void MoveHandler()
	{

	}
	void JumpHandler()
	{

	}
}
