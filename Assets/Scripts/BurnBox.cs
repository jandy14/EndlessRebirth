using UnityEngine;
using System.Collections;

public class BurnBox : MonoBehaviour {
	void Start()
	{
		StartCoroutine("Burn");
	}
	void Update(){}

	public void BurnStart()
	{
		StartCoroutine("Burn");
	}
	IEnumerator Burn()
	{
		//Debug.Log(transform.parent.gameObject);
		GetComponent<ParticleSystem>().Play();
		yield return new WaitForSeconds(5);
		Destroy(GetComponentInParent<SpriteRenderer>());
		Destroy(GetComponentInParent<BoxCollider2D>());
		yield return new WaitForSeconds(1);
		//Debug.Log(transform.parent.gameObject);
		Destroy(transform.parent.gameObject);
	}
}