using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	private Vector3[] shootPoint;
	private GameObject laser;

	void Start ()
	{
		shootPoint = new Vector3[2];
		shootPoint[0] = transform.FindChild("Mount1").localPosition;
		shootPoint[1] = transform.FindChild("Mount2").localPosition;
		laser = transform.FindChild("Laser").gameObject;

		Vector2[] shootPoint2D = new Vector2[2];
		shootPoint2D[0] = new Vector2(shootPoint[0].x, shootPoint[0].y);
		shootPoint2D[1] = new Vector2(shootPoint[1].x, shootPoint[1].y);

		laser.GetComponent<LineRenderer>().SetPositions(shootPoint);
		laser.GetComponent<EdgeCollider2D>().points = shootPoint2D;

		Work(false);
	}

	void Update ()
	{
		//작동되는지 테스트용
		/*if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Work(true);
		}
		
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			Work(false);
		}*/
	}

	public void Work(bool isWork)
	{
		if(isWork)
		{
			laser.SetActive(true);
		}
		else
		{
			laser.SetActive(false);
		}
	}
}
