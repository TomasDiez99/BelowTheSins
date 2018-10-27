using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPointer : MonoBehaviour
{
	private int go = 1;
	private int counter = 0;
	
	// Use this for initialization
	void Start ()
	{
		counter = Random.Range(-10, 5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		counter++;
		if (counter > 40)
		{	
			go*= -1;
			counter = 0;
		}
		transform.position += (Vector3) Vector2.up * go;
	}
}
