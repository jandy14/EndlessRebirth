using UnityEngine;
using System.Collections;

public class ElectricLaser : MonoBehaviour {
	void Start() { }
	void Update() { }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Body" || other.tag == "Object")
		{
			other.GetComponent<ParticleChooser>().Choose(1);
		}
	}
}
