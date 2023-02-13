using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace General
{
	public class RespawnMediator: MediatorBase<RespawnView>, IInitializable, IDisposable
	{

		

		///  LISTNER METHODS           ///
		private void Respawn()
		{
			_view.Respawn();
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<RespawnSignal>()
					   .Subscribe(x => Respawn()).AddTo(_disposables);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
