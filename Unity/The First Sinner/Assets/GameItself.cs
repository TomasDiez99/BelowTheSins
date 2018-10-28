using System;
using System.Collections;
using System.Collections.Generic;
using Demons;
using DG.Tweening;
using InputManager;
using Patterns;
using UnityEngine;
using Sinners;
using UI;


public class GameItself : ScriptSingleton<GameItself>
{

	public DialogWriter ToWrite => FindObjectOfType<DialogWriter>();
	private AbstractDiscreteInput tecla,right,left;
	private int index = 3;
	private const int minCapital=0;
	private const int maxCapital = 6;
	private IDemonParsed demon;
	private Color colorPrevius;
	private Sinner currentSinner;
	
	
	private void Start()
	{
		tecla = new DiscreteKeyboard(KeyCode.Return);
		right = new DiscreteKeyboard(KeyCode.RightArrow);
		left = new DiscreteKeyboard(KeyCode.LeftArrow);

		right.Event += SelectRight;
		left.Event += SelectLeft;
		tecla.Event += BeginGame;
		Selected();
		
	}

	private void Selected()
	{
		if (demon != null)
		{
			demon.Halo.DOColor(colorPrevius, 1);
		} 
		demon=DemonManager.Instance.GetDemon(index);
		colorPrevius = demon.Halo.color;
		var color =demon.Halo.DOColor(Color.black, 1);
	}

	private void SelectLeft()
	{
		index = index == minCapital ? maxCapital : index - 1;
		Selected();
	}

	private void SelectRight()
	{
		index = index == maxCapital ? minCapital : index + 1;
		Selected();
	}

	public void BeginGame()
	{
		tecla.Event -= BeginGame;
		currentSinner = SinnerGetter.Instance.GetOne();
		
		
		ToWrite.SetText(currentSinner._conf.text);
		Action run = ()=>tecla.Event += SelectTarget;
		ToWrite.OnComplete(run);
		PersonPic.Instance.HideNow();
		PersonPic.Instance.SetVisible(true);
		PersonPic.Instance.SetPic(currentSinner._sprite);
	}

	private void SelectTarget()
	{
		var resolver= StatsResolver.Instance;
		resolver.Increment(demon);
		var sinsRelated = currentSinner._phrase.SinsRelated;
		foreach (IDemonParsed demonParsed in sinsRelated)
		{
			if (demonParsed!=demon)
			{
				resolver.Decrement(demonParsed);	
			}
			
		}

		tecla.Event -= SelectTarget;
		tecla.Event += BeginGame;
	}
}
