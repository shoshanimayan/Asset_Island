using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
using General;
using System.Threading.Tasks;

namespace Interactables
{
	public class InteractableManagerMediator: MediatorBase<InteractableManagerView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private int _counterMax = 0;
		private int _counterCurrent = 0;
		///  PRIVATE METHODS           ///
		///  
		private  async Task SetIteractablePositions(Vector3 playerPosition)
		{
			List<Vector3> tempPos = new List<Vector3>();
			tempPos.Add(playerPosition);
			foreach (var c in _view.InteractableList)
			{
				
				bool searching = true;
				while (searching)
				{
					await Task.Yield();
					Vector3 CirclePoint = RandomPointOnADisc(_view.PositionSetRadius);
					Ray ray = new Ray(CirclePoint, -_view.transform.up);
					if (Physics.Raycast(ray, out RaycastHit hit))
					{
						Vector3 refz = hit.normal;
						if (hit.collider.tag == "ground")
						{
							if (PositionFitsDistanceRestrictions(tempPos, hit.point, _view.RestrictionDistance))
							{
								c.transform.position = hit.point;
								searching = false;
							}
						}
					}
				}
				
			}
		}

		private Vector3 RandomPointOnADisc(float radius)
		{
			Vector3 temp= UnityEngine.Random.insideUnitCircle*radius;
			return (  new Vector3(_view.transform.position.x+ temp.y, _view.transform.position.y, _view.transform.position.z+temp.x));
		}

		



		private bool PositionFitsDistanceRestrictions(List<Vector3> positions, Vector3 newPos, float distanceRestriction)
		{
			bool fits = true;
			foreach (Vector3 pos in positions)
			{
				if (Vector3.Distance(pos, newPos) < distanceRestriction)
				{
					fits = false;
					break;
				}
			}
			return fits;
		
		}

		private Transform GetNearestInteractable()
		{
			float distance=float.MaxValue;
			Transform result = null;
			foreach (var i in _view.InteractableList)
			{

				if (!i.Interacted)
				{
					var tempDistance = Vector3.Distance(_playerHandler.GetPlayerWorldPosition(), i.transform.position);
					if (tempDistance < distance)
					{
						result = i.transform;
						distance = tempDistance;
					}
				}
			}

			return result;
		
		}

		///  LISTNER METHODS           ///
		private void OnCounterIncrement(CounterIncrementSignal signal)
		{
	
			_counterCurrent++;
			_signalBus.Fire(new CounterTextSignal() { Text = _counterCurrent.ToString() + "/" + _counterMax.ToString() });

			if (_counterCurrent >= _counterMax)
			{
				_signalBus.Fire(new EndingGameSignal());

			}
		}


		private void OnRecievedHintSignal(HintSignal signal)
		{
			var NearestInteractable = GetNearestInteractable();
			_signalBus.Fire(new SetHintTransformSignal() { HintTransform = NearestInteractable });

		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private PlayerHandler _playerHandler;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public async  void Initialize()
		{
			var index = 0;
			foreach (InteractableView interactable in _view.InteractableList)
			{
				interactable.SetIndex(index);
				index++;
			}
			_signalBus.GetStream<CounterIncrementSignal>()
				   .Subscribe(x => OnCounterIncrement(x)).AddTo(_disposables);
			_signalBus.GetStream<HintSignal>()
				   .Subscribe(x => OnRecievedHintSignal(x)).AddTo(_disposables);
			_counterCurrent = 0;
			_counterMax = _view.InteractableList.Length;
			_signalBus.Fire(new CounterTextSignal() { Text = _counterCurrent.ToString() + "/" + _counterMax.ToString() });
			_signalBus.Fire(new StartGameSignal());

			await SetIteractablePositions(_playerHandler.GetPlayerWorldPosition());

		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
