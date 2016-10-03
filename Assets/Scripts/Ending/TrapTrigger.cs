using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	public GameObject[] trap;
	public GameObject junction;

	void Start (){ }
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerController>().isDying = true;
			junction.SetActive(true);
			foreach (GameObject t in trap)
			{
				t.GetComponent<MakeBody>().isWork = true;
			}
		}
	}
}
