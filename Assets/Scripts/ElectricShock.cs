using UnityEngine;
using System.Collections;

public class ElectricShock : MonoBehaviour {

	void Start ()
	{
		GetComponent<ParticleSystem>().Play();
	}
	void Update () {}

	public void ShockStart()
	{
		GetComponent<ParticleSystem>().Play();
	}
}
