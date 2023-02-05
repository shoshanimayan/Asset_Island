using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CMF;
using Zenject;
using System;
using UniRx;
using Core;

namespace Inputs
{
	public class CharacterInputExtendedView : CharacterInput,IView
	{


		///  INSPECTOR VARIABLES      ///
		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS          ///
		private CharacterInputExtendedMediator _mediator;
		///  PUBLIC API               ///



		public override float GetHorizontalMovementInput()
		{
			if (_mediator.MovementEnabled())
			{
			}

			return 0;
		}

		public override float GetVerticalMovementInput()
		{
			if (_mediator.MovementEnabled())
			{
			}

			return 0;
		}

		

		public override bool IsJumpKeyPressed()
		{
			return false;
		}

		public void Init(CharacterInputExtendedMediator mediator)
		{
			_mediator = mediator;
		}


	}
}
