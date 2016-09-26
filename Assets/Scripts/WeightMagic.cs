using UnityEngine;
using System.Collections;

public class WeightMagic : MonoBehaviour {
	void Start () {}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Body")
		{
			other.GetComponent<Rigidbody2D>().mass *= 20;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Body")
		{
			other.GetComponent<Rigidbody2D>().mass /= 20;
		}
	}

}
