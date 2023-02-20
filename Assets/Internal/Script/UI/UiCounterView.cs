using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace UI
{
	public class UiCounterView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] Canvas _counterCanvas;

		[SerializeField] private TextMeshProUGUI _helperText;

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void SetText(string text)
		{
			_helperText.text = text;
		}

		public void EnableCanvas(bool enabled)
		{
			_counterCanvas.enabled = enabled;
		}

	}
}
