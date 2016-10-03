using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject body;
	public GameObject savePoint;

	public bool isMovableRight;
	public bool isMovableLeft;
	public bool isJumpable;
	public bool isDying;

	private float timer_Jump;
	private GameObject gameManager;

	/*임시변수*/
	private float timer_respown;
	void Start()
	{
		gameManager = GameObject.Find("GameManager");
		isMovableRight = true;
		isMovableLeft = true;
		isJumpable = false;
		isDying = false;
		timer_Jump = 0;

		timer_respown = 0;
    }

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName != "FirstLevel" && sceneName != "Sacrifice" && sceneName != "Intro")
				Die();
		}
		if (Input.GetButtonUp("Jump"))
		{
			timer_Jump = 0;
			//Debug.Log("timer reset : " + timer_Jump);
		}
		Debug.DrawLine(transform.position, new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z), Color.red,10f);

		/*임시이다 후에 없애거나 새로 할거지만 일단은 버그를 막기위해서 해놓았다.*/
		if (timer_respown > 0)
		{
			timer_respown -= Time.deltaTime;
			if (timer_respown <= 0)
			{
				isDying = false;
				GetComponent<Rigidbody2D>().isKinematic = false;
			}
		}
	}
	void FixedUpdate()
	{
		//Debug.Log(Input.GetAxis("Horizontal"));
		if (isJumpable)
		{
			if (Input.GetButton("Jump"))
			{
				timer_Jump += Time.deltaTime;
				Jump();
			}
		}
		if (isMovableRight)
			if (Input.GetAxis("Horizontal") > 0.01f)
				Move(true);//오른쪽
		if(isMovableLeft)
			if (Input.GetAxis("Horizontal") < -0.01f)
				Move(false);//왼쪽
		Friction();
		AirResistance();
		//Debug.Log("velocity : " + GetComponent<Rigidbody2D>().velocity.y);
		//Debug.Log(GetComponent<Rigidbody2D>().velocity);
	}
	private void Jump()
	{
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
		//간단하고 깔끔한거 같다. 몇몇 필요한 상황아니면 그냥 velocity값을 수정해주는게 나은거 같다 적어도 지금은
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 6);
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
	public void Die()
	{
		//시체 생성및 다시 부활
		if (!isDying)
		{
			isDying = true;
			GameObject newBody = Instantiate(body, GetComponent<Transform>().position, GetComponent<Transform>().rotation) as GameObject;
			newBody.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
			gameManager.GetComponent<GameManager>().CountDeath();

			Birth();
		}
	}
	private void Birth()
	{
		//위치로 돌아가기
		GetComponent<Transform>().position = savePoint.GetComponent<Transform>().position;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		isMovableRight = true;
		isMovableLeft = true;
		isJumpable = false;

		GetComponent<Animator>().SetTrigger("Appear");
		GetComponent<Rigidbody2D>().isKinematic = true;
		timer_respown = 0.5f;
	}
	private void AirResistance()
	{
		if(GetComponent<Rigidbody2D>().velocity.y > 20)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 20);
        }
		else if(GetComponent<Rigidbody2D>().velocity.y < -20)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -20);
		}
	}
}
