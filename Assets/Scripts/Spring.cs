using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

	public float cor;	//반발 계수 coefficient of restitution

    void Start () {}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		string tag = other.tag;
		if(tag == "Player" || tag == "Body" || tag == "Object")
		{
			Vector2 velocity = other.GetComponent<Rigidbody2D>().velocity;
			other.GetComponent<Rigidbody2D>().velocity = Bounce(velocity);
        }
	}
	private Vector2 RadianToVector2(float radian)
	{
		return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
	}
	private Vector2 Bounce(Vector2 velocity)
	{
		//각도를 구해서
		Vector2 springDegree = RadianToVector2(transform.eulerAngles.z * Mathf.Deg2Rad);
		float angle = Vector2.Angle(velocity, springDegree);
		angle = angle * Mathf.Deg2Rad;
		//속도벡터를 회전시킨다
		float x = Mathf.Cos(angle * 2) * velocity.x - Mathf.Sin(angle * 2) * velocity.y;
		float y = Mathf.Sin(angle * 2) * velocity.x + Mathf.Cos(angle * 2) * velocity.y;

		//Debug.Log("Before : " + velocity);
		//Debug.Log("Angle  : " + angle);
		//Debug.Log("After  : " + new Vector2(x, y));

		return new Vector2(x * cor, y * cor);
    }
}
