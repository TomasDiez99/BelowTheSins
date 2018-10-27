using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;


[RequireComponent(typeof(TextMeshProUGUI))]
public class Writer : ScriptSingleton<Writer>, IWriter
{

	private TextMeshProUGUI Field => GetComponent<TextMeshProUGUI>();

	private string _textToShow;
	private bool _working;
	private int _index = 0;
	private int _frameCounter = 0;
	private static int _delay = 10;
	private Queue<string> _textsQueue = new Queue<string>();

	public bool IsWorking() => _working;


	public void HurryUp()
	{
		throw new System.NotImplementedException();
	}

	public void SetDelay(int x)
	{
		Assert.IsFalse(x == 0);
		_delay = x;
	}

	public void SetTextNow(string texto)
	{
		while (_index < _textToShow.Length)
		{
			Field.text += _textToShow[_index];
			_index++;
		}
	}

	public void _SetText(string text)
	{
		Assert.IsFalse(_working);
		if (text.Equals(Field.text)) return;


		Field.text = "";
		_textToShow = text;
		_index = 0;
		_working = true;
	}

	public void SetText(string text)
	{
		_textsQueue.Enqueue(text);
		_SetText(_textsQueue.Dequeue());
	}

public void LazySetText(string text)
	{
		_textsQueue.Enqueue(text);
	}

	private void Update()
	{
		_frameCounter++;
		
		if (!_working || _frameCounter%_delay != 0) return; // exit point
		if (_textToShow.Length <= _index)
		{
			_working = false;
			return;
		}
		Field.text += _textToShow[_index];
		_index++;
		
	}

	
	
}