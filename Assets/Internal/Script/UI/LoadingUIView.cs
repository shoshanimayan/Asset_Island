using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class LoadingUIView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] Canvas _LoadingCanvas;
		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void LoadingEnable(bool enable)
		{
			
			_LoadingCanvas.enabled = enable;
		}
	}
}
