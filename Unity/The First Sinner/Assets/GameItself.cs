using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demons;
using DG.Tweening;
using InputManager;
using Patterns;
using UnityEngine;
using Sinners;
using Tools;
using UI;
using UnityEngine.UI;


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
	private bool started;
	public SpriteRenderer FondoMenu;
	public Sprite EvilChabon;
	public int Malotes { get; set; } = 12;
	public bool gameOver;
	public bool Win;
	public Image ui;
	
	
	
	private void Start()
	{

		ui.enabled = false;
		SagradaMusiquera.Instance.PlayMenu();
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
			demon.HaloIn.DOColor(colorPrevius, 1);
		} 
		demon=DemonManager.Instance.GetDemon(index);
		colorPrevius = demon.HaloIn.color;
		var color =demon.HaloIn.DOColor(Color.black, 1);
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
		if (!started)
		{
			FondoMenu.enabled = false;
			ui.enabled = true;
			SagradaMusiquera.Instance.PlayAmbiance();
			SagradaMusiquera.Instance.PlayChurch();
		}
		tecla.Event -= BeginGame;

		string[] a = {
			"Priest, you're finally here. We were waiting for you.",
			"We were told that you're trying to hide a dreadful sin you've committed recently.",
			"Such cruel actions for an honorable man like you, Father.",
			"We are willing to help you but only if you're willing to pay a certain price.",
			"It's your duty to feed us with the spirits of the dead sinners today.",
			"But be careful.",
			"You are required to assign the right soul to each of us.",
			"If you fail to keep us all well-fed and balanced, the hungriest demon will eat you alive.",
			"Let the feast begin."
		};
		
		print(a,0);
		PersonPic.Instance.HideNow();
		PersonPic.Instance.SetVisible(true);
		PersonPic.Instance.SetPic(EvilChabon);
	}

	public void print(string[] s,int i)
	{
		var num = i;
		if (i == s.Length)
		{
			tecla.Event -= DialogWriter.Instance.HurryUp;
			GameStart();	
			return;
		}
		tecla.Event += DialogWriter.Instance.HurryUp;
		ToWrite.SetText(s[num++]);
		ToWrite.OnComplete(()=>
		{
			tecla.Event -= DialogWriter.Instance.HurryUp;
			TimeStuff.DoAfter(() =>
			{
				print(s,num);	
			},2);
			
		});
	}
	
	public void printOver(string[] s,int i)
	{
		var num = i;
		if (i == s.Length)
		{
			tecla.Event -= DialogWriter.Instance.HurryUp;
			return;
		}
		tecla.Event += DialogWriter.Instance.HurryUp;
		ToWrite.SetText(s[num++]);
		ToWrite.OnComplete(()=>
		{
			tecla.Event -= DialogWriter.Instance.HurryUp;
			TimeStuff.DoAfter(() =>
			{
				printOver(s,num);	
			},2);
			
		});
	}

	

	public void GameStart()
	{
		tecla.Event -= GameStart;
		foreach (var d in DemonManager.Instance.EveryDemon)
		{
			d.HaloOut.enabled = true;
			d.HaloIn.enabled = true;
		}

		currentSinner = SinnerGetter.Instance.GetOne();
		
		
		ToWrite.SetText(currentSinner.Confesion.Content);
		Action run = ()=>tecla.Event += SelectTarget;
		ToWrite.OnComplete(run);
		PersonPic.Instance.HideNow();
		PersonPic.Instance.SetVisible(true);
		PersonPic.Instance.SetPic(currentSinner._sprite);
	}

	private void SelectTarget()
	{
		tecla.Event -= SelectTarget;
		
		var resolver= StatsResolver.Instance;
		resolver.Increment(demon);
		var sinsRelated = currentSinner.Confesion.SinsRelated;
		foreach (IDemonParsed demonParsed in sinsRelated)
		{
			if (demonParsed!=demon)
			{
				resolver.Decrement(demonParsed);
				
			}
			
		}

		gameOver=DemonManager.Instance.IsGameOver();
		Malotes--;
		Debug.Log(Malotes);
		if (gameOver)
		{
			tecla.Event += GameOver;
			return;

		}
		else
		{
			
			if (Malotes == 0)
			{
				Win = true;
				tecla.Event += Winner;
				return;
			}
			else
			{
				tecla.Event += GameStart;	
			}
				
		}
		
	}

	private void Winner()
	{
		tecla.Event -= Winner;
		SagradaMusiquera.Instance.StopAmbiance();
		SagradaMusiquera.Instance.StopChurch();
		SagradaMusiquera.Instance.WinSound();
		
		string[] r =
		{
			"Congratulations, you are free for now",
			"But, not of your sins."
		};
		printOver(r,0);
		PersonPic.Instance.HideNow();
		PersonPic.Instance.SetVisible(true);
		PersonPic.Instance.SetPic(EvilChabon);
	}

	public void GameOver()
	{
		tecla.Event -= GameOver;
		SagradaMusiquera.Instance.StopAmbiance();
		SagradaMusiquera.Instance.StopChurch();
		SagradaMusiquera.Instance.LoseSound();
		string[] r =
		{
			"Priest, you have failed to fulfill your duty.",
			"Your soul will now become the precious nurture for our immortal bodies.",
			"Say goodbye to the remnants of your human spirit."
		};
		printOver(r,0);
		PersonPic.Instance.HideNow();
		PersonPic.Instance.SetVisible(true);
		PersonPic.Instance.SetPic(EvilChabon);
		
	}
}
