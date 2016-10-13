using UnityEngine;
using System.Collections;

public class GoCredit : MonoBehaviour
{
	public GameObject finish;

	void Start() { }
	void Update() { }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			finish.GetComponent<NextStage>().GoNext();
		}
	}
}
