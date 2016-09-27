using UnityEngine;
using System.Collections;

public class BurnBody : MonoBehaviour {
	void Start ()
	{
		StartCoroutine("Burn");
	}
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			BurnStart();
        }
	}
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
		Destroy(GetComponentInParent<PolygonCollider2D>());
		yield return new WaitForSeconds(1);
		//Debug.Log(transform.parent.gameObject);
		Destroy(transform.parent.gameObject);
	}
}
