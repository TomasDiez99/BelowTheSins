using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;


[RequireComponent(typeof(TextMeshProUGUI))]
public class Writer : MonoBehaviour, IWriter
{

	private TextMeshProUGUI Field => GetComponent<TextMeshProUGUI>();

	private string _textToShow;
	public bool working;
	private int _index = 0;
	private int _frameCounter = 0;
	private static int _delay = 10;
	public bool IsWorking() => working;

	public void HurryUp()
	{
		throw new System.NotImplementedException();
	}

	public void SetDelay(int x)
	{
		Assert.IsFalse(x==0);
		_delay = x;
	}

	public void SetTextNow(string texto)
	{
		throw new System.NotImplementedException();
	}

	public void SetText(string text)
	{
		Assert.IsFalse(working);
		if (text.Equals(Field.text)) return;
		
		Field.text = "";
		_textToShow = text;
		_index = 0;
		working = true;
	}

	public void LazySetText(string text)
	{
		throw new System.NotImplementedException();
	}

	private void Update()
	{
		_frameCounter++;
		
		if (!working || _frameCounter%_delay != 0) return; // exit point
		if (_textToShow.Length <= _index)
		{
			working = false;
			return;
		}
		Field.text += _textToShow[_index];
		_index++;
		
	}

	
	
}