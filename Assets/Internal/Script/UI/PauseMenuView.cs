using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class PauseMenuView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private PauseMenuMediator _mediator;

		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void Init(PauseMenuMediator mediator)
		{
			_mediator = mediator;
		}
	}
}
