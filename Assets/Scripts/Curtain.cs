using UnityEngine;
using System.Collections;

public class Curtain : MonoBehaviour {

	private bool isWork;
	private float alpha;

	void Start ()
	{
		isWork = false;
        alpha = 1f;
	}

	void Update ()
	{
		if(isWork)
		{
			if (alpha < 1)
				alpha += Time.deltaTime;
		}
		else
		{
			if (alpha > 0)
				alpha -= Time.deltaTime;
		}
		SetAlpha(alpha);
	}
	public void SetCurtain(bool isActive)
	{
		isWork = isActive;
	}
	public void SetCurtainQuickly(bool isActive)
	{
		isWork = isActive;
		if (isActive)
			alpha = 1;
		else
			alpha = 0;
	}
	private void SetAlpha(float value)
	{
		Color current = GetComponent<SpriteRenderer>().color;
		GetComponent<SpriteRenderer>().color = new Color(current.r, current.g, current.b, value);
    }
}
