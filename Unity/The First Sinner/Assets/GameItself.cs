using System.Collections;
using System.Collections.Generic;
using InputManager;
using Patterns;
using UnityEngine;
using Sinners;
using UI;


public class GameItself : ScriptSingleton<GameItself>
{

	public DialogWriter ToWrite => FindObjectOfType<DialogWriter>();
	private AbstractDiscreteInput tecla;
	
	private void Start()
	{
		tecla = new DiscreteKeyboard(KeyCode.N);
		tecla.Event += BeginGame;
	}

	public void BeginGame()
	{

		Sinner sinner = SinnerGetter.Instance.GetOne();
		
		ToWrite.SetText(sinner._conf.text);
		PersonPic.Instance.HideNow();
		PersonPic.Instance.SetVisible(true);
		PersonPic.Instance.SetPic(sinner._sprite);
		
		

	}
	
	
}
