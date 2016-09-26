using UnityEngine;
using System.Collections;

public class BurnBody : MonoBehaviour {
	void Start () {}
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
		GetComponent<ParticleSystem>().Play();
		yield return new WaitForSeconds(5);
		Destroy(GetComponent<SpriteRenderer>());
		Destroy(GetComponent<PolygonCollider2D>());
		yield return new WaitForSeconds(1);
		Destroy(this.gameObject);
	}
}
