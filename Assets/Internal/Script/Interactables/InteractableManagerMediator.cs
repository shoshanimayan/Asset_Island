using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class InteractableManagerMediator: MediatorBase<InteractableManagerView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			var index = 0;
			foreach (InteractableView interactable in _view.InteractableList)
			{
				interactable.SetIndex(index);
				index++;
			}

			
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
