using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;

namespace UI
{
	public class TextDisplayView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private Canvas _pauseCanvas;
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private InputActionReference _ActionInput;

		///  PRIVATE VARIABLES         ///
		private bool _displaying;
		///  PRIVATE METHODS           ///
		private void ProceedText()
		{
			if (_displaying)
			{ 
			
			}
		}
		///  PUBLIC API                ///
		public void DisplayText(string text)
		{
			_displaying = true;
			_pauseCanvas.enabled = true;
		}



		public void InitDisplay()
		{
			_ActionInput.action.performed += ctx =>ProceedText();
			_pauseCanvas.enabled = false;

		}
	}
}
