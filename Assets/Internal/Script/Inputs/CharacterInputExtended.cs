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
	public class CharacterInputExtended : CharacterInput
	{


		///  INSPECTOR VARIABLES      ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS          ///

		///  PUBLIC API               ///

		readonly SignalBus _signalBus;
		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public override float GetHorizontalMovementInput()
		{
			throw new System.NotImplementedException();
		}

		public override float GetVerticalMovementInput()
		{
			throw new System.NotImplementedException();
		}

		public void Initialize()
		{
			//_signalBus.GetStream<StateChangeSignal>()
			//					   .Subscribe(x => OnStateChanged(x.ToState)).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		public override bool IsJumpKeyPressed()
		{
			return false;
		}

		public CharacterInputExtended(SignalBus signalBus)
		{
			_signalBus = signalBus;


		}
	}
}
