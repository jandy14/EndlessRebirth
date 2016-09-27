using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	public GameObject laser;

	void Start () {}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			laser.GetComponent<Laser>().Work(true);
		}
	}
}
