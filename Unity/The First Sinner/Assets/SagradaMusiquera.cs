using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Patterns;
using UnityEditor;
using UnityEngine;

public class SagradaMusiquera : ScriptSingleton<SagradaMusiquera>
{

	public AudioSource Win,
		MenuLoop,
		AmbianceIntro,
		AmbianceLoop,
		ChurchIntro,
		ChurchLoop,
		Lose,
		Menuintro;

	public void PlayMenu()
	{
		MenuLoop.Play();
		MenuLoop.volume = 0;
		MenuLoop.DOFade(1, 5); //cambiar el 5 si arranca muy lento el loop
		Menuintro.Play();
	}

	public void StopMenu()
	{
		MenuLoop.Stop();
		Menuintro.Stop();
	} 

	public void PlayAmbiance()
	{
     		AmbianceIntro.Play();
     		AmbianceLoop.Play();
     		AmbianceLoop.volume = 0;
     		AmbianceLoop.DOFade(1, 5); //cambiar el 5 si arranca muy lento el loop
	}
	
	public void StopAmbiance()
	{
		AmbianceIntro.Stop();
		AmbianceLoop.Stop();
	}
	
	public void PlayChurch()
	{
		ChurchIntro.Play();
		ChurchLoop.Play();
		ChurchLoop.volume = 0;
		ChurchLoop.DOFade(1, 5); //cambiar el 5 si arranca muy lento el loop
	}
	
	public void StopChurch()
	{
		ChurchIntro.Stop();
		ChurchLoop.Stop();
	}

	public void WinSound() => Win.Play();
	public void StopWinSound() => Win.Stop();
	public void LoseSound() => Lose.Play();
	public void StopLoseSound() => Lose.Stop();
	
	

}
	
