using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class RespawnerMediator: MediatorBase<RespawnerView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///

		///  PUBLIC API                ///
		public void SendOutRespawn()
		{
			_signalBus.Fire(new AudioEffectSignal { AudioEffectName = "Splash" });
			_signalBus.Fire(new RespawnSignal());
		}
		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_view.InitView(this);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
