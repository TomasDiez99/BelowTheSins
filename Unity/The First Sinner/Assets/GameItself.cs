using System.Collections;
using System.Collections.Generic;
using Demons;
using InputManager;
using Patterns;
using UnityEngine;
using Sinners;
using UI;


public class GameItself : ScriptSingleton<GameItself>
{

	public DialogWriter ToWrite => FindObjectOfType<DialogWriter>();
	private AbstractDiscreteInput tecla,right,left;
	private int index = 0;
	private const int minCapital=0;
	private const int maxCapital = 7; 
	
	
	private void Start()
	{
		tecla = new DiscreteKeyboard(KeyCode.KeypadEnter);
		right = new DiscreteKeyboard(KeyCode.RightArrow);
		left = new DiscreteKeyboard(KeyCode.LeftArrow);

		right.Event += SelectRight;
		left.Event += SelectLeft;
		tecla.Event += BeginGame;
		
	}

	private void SelectLeft()
	{
		index = index == minCapital ? maxCapital : index - 1;
	}

	private void SelectRight()
	{
		index = index == maxCapital ? minCapital : index + 1;
	}

	public void BeginGame()
	{

		Sinner sinner = SinnerGetter.Instance.GetOne();
		
		ToWrite.SetText(sinner._conf.text);
		PersonPic.Instance.HideNow();
		PersonPic.Instance.SetVisible(true);
		PersonPic.Instance.SetPic(sinner._sprite);

		DemonManager.Instance.GetDemon(index);

	}
	
	
}
