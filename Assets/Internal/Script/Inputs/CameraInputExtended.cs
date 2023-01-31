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
	public class CameraInputExtended : CameraInput, IInitializable, IDisposable
	{


		///  INSPECTOR VARIABLES      ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS          ///

		///  PUBLIC API               ///
		readonly SignalBus _signalBus;
		readonly CompositeDisposable _disposables = new CompositeDisposable();
		public override float GetHorizontalCameraInput()
		{
			throw new System.NotImplementedException();
		}

		public override float GetVerticalCameraInput()
		{
			throw new System.NotImplementedException();
		}

		public void Initialize()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		public CameraInputExtended(SignalBus signalBus)
		{
			_signalBus = signalBus;


		}
	}
}
