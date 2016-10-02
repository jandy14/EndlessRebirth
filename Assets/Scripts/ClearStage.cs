using UnityEngine;
using System.Collections;

public class ClearStage : MonoBehaviour {

	private GameObject player;

	void Start () {}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			player = other.gameObject;
			StartCoroutine("Clear");
		}
	}
	IEnumerator Clear()
	{
		player.GetComponent<Animator>().SetTrigger("Disappear");
		player.GetComponent<PlayerController>().isJumpable = false;
		player.GetComponent<Rigidbody2D>().isKinematic = true;
		player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		yield return new WaitForSeconds(0.3f);
		player.SetActive(false);
	}
}
