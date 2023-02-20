using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace UI
{
	public class HelperUIView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] Canvas _helperCanvas;
		[SerializeField] private TextMeshProUGUI _helperText;

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void SetHelperText(string text)
		{
			_helperText.text = text;
		}


	}
}
