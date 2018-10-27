using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

public class PersonPic : ScriptSingleton<PersonPic>
{

	private Image Img => GetComponent<Image>(); 
	
	// Use this for initialization
	void Start () {
		
	}

	public void SetVisible(bool b)
	{
		var tw = Img.DOColor(new Color(1, 1, 1, b ? 1 : 0), 1.5f);
		tw.SetEase(Ease.InOutQuart);
		
	}
	
	public void HideNow()
	{
		Img.color = new Color(1,1,1,0);
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetKeyDown(KeyCode.S))
		{
			SetVisible(true);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			SetVisible(false);
		}
		
	}

	
	public void SetPic(Sprite sinnerSprite)
	{
		Img.sprite = sinnerSprite;
	}
}
