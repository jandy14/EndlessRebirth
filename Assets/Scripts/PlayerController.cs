using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject body;
	public GameObject savePoint;

	public bool isMovableRight;
	public bool isMovableLeft;
	public bool isJumpable;

	void Start()
	{
		isMovableRight = true;
		isMovableLeft = true;
		isJumpable = false;
	}
	
	void Update()
	{
		if(isJumpable)
			if (Input.GetButtonDown("Jump"))
				Jump();
		if (Input.GetButtonDown("Fire1"))
			Die();
    }

	void FixedUpdate()
	{
		//Debug.Log(Input.GetAxis("Horizontal"));
		if(isMovableRight)
			if (Input.GetAxis("Horizontal") > 0.1f)
				Move(true);//오른쪽
		if(isMovableLeft)
			if (Input.GetAxis("Horizontal") < -0.1f)
				Move(false);//왼쪽
		Friction();
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
	}
	private void Jump()
	{
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
		isJumpable = false;
	}
	private void Move(bool isRight)
	{
		if (isRight) //오른쪽
		{
			//Debug.Log("Right");
			if (GetComponent<Rigidbody2D>().velocity.x < 0.5) //초반 스퍼트
				GetComponent<Rigidbody2D>().AddForce(new Vector2(150, 0));
			else if (GetComponent<Rigidbody2D>().velocity.x < 4)
				GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 0));
		}
		else //왼쪽
		{
			//Debug.Log("Left");

			if (GetComponent<Rigidbody2D>().velocity.x > -0.5) //초반 스퍼트
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-150, 0));
			else if (GetComponent<Rigidbody2D>().velocity.x > -4)
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-30, 0));
		}
		//Debug.Log(GetComponent<Rigidbody2D>().velocity);
	}
	private void Friction()	//마찰
	{
		float velocityX = GetComponent<Rigidbody2D>().velocity.x;
        if (velocityX > 0.3)
		{
			if (velocityX > 3)
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 0));
			else
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-15, 0));
        }
		else if (velocityX < -0.3)
		{
			if (velocityX < -3)
				GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0));
			else
				GetComponent<Rigidbody2D>().AddForce(new Vector2(15, 0));
		}
		else GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
	}
	private void Die()
	{
		//시체 생성및 다시 부활
		GameObject newBody = Instantiate(body, GetComponent<Transform>().position, GetComponent<Transform>().rotation) as GameObject;
		newBody.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
		Birth();
	}
	private void Birth()
	{
		//위치로 돌아가기
		GetComponent<Transform>().position = savePoint.GetComponent<Transform>().position;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		isMovableRight = true;
		isMovableLeft = true;
		isJumpable = false;
	}
}
