using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	private Transform[] shootPoint = new Transform[2];
	private GameObject laser;

	public bool isRealTime;

	void Start ()
	{
		shootPoint[0] = transform.FindChild("Mount1");
		shootPoint[1] = transform.FindChild("Mount2");
		laser = transform.FindChild("Laser").gameObject;

		SetLaserPoint();
	}

	void Update ()
	{
		if(isRealTime)
			SetLaserPoint();
	}

	private void SetLaserPoint()
	{
		int index;
		Vector2[] shootPoint2D = new Vector2[2];

		index = 0;
		foreach(Transform point in shootPoint)
		{
			shootPoint2D[index] = new Vector2(point.localPosition.x, point.localPosition.y);
			index++;
		}

		laser.GetComponent<EdgeCollider2D>().points = shootPoint2D;
		//이게 나을지도
		//shootPoint2D[0] = new Vector2(shootPoint[0].localPosition.x, shootPoint[0].localPosition.y);
		//shootPoint2D[1] = new Vector2(shootPoint[1].localPosition.x, shootPoint[1].localPosition.y);

		index = 0;
		foreach(Transform point in shootPoint)
		{
			laser.GetComponent<LineRenderer>().SetPosition(index, shootPoint[index].localPosition);
			index++;
		}
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
	public void WorkToggle()
	{
		if (laser.activeInHierarchy)
			laser.SetActive(false);
		else
			laser.SetActive(true);

	}
}
