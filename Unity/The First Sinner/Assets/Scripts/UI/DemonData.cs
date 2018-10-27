using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DemonData : MonoBehaviour
{


	[Range(0,1)][SerializeField]
	private float TesterRange;
	
	
	
	/// <summary>
	/// Contract
	/// 	return => Range(0,1)
	/// </summary>
	public float Health
	{
		get
		{
			return TesterRange;
		}
		set
		{
			TesterRange = value;
		}
	}
	
	
}
