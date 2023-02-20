using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class PauseMenuView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private Canvas _pauseCanvas;
		[SerializeField] private ExtendedButton _firstButton;
		///  PRIVATE VARIABLES         ///
		private PauseMenuMediator _mediator;

		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void Init(PauseMenuMediator mediator)
		{
			_mediator = mediator;
			EnableCanvas(false);
		}

		public void Continue()
		{
			_mediator.Unpause();
		}

		public void Menu()
		{
			_mediator.ToMenu();
		}

		public void EnableCanvas(bool enabled)
		{
			_pauseCanvas.gameObject.SetActive( enabled);
			if (enabled)
			{
				_firstButton.Select();
			}
		}
	}
}
