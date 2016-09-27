using UnityEngine;
using System.Collections;

public class ParticleChooser : MonoBehaviour {

	public GameObject[] particle;

	void Start () {}
	void Update () {}
	public void Choose(int index)
	{
		if (index >= particle.Length)
			return;
		Instantiate(particle[index],transform.position,transform.rotation,transform);
    }
}
