using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class MainMenuView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private MainMenuMediator _mediator;
		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void Init(MainMenuMediator mediator)
		{
			_mediator = mediator;
		}
	}
}
