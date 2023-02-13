using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class ObjectHiderMediator: MediatorBase<ObjectHiderView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			switch (signal.ToState)
			{
				case State.Inspector:
					_view.MeshEnable(true);
					break;
				default:
					_view.MeshEnable(false);

					break;
			}
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<StateChangeSignal>()
								   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
