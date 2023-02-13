using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class RespawnerView: MonoBehaviour,IView
	{


		///  PRIVATE VARIABLES         ///
		private RespawnerMediator _mediator;
		///  PRIVATE METHODS           ///
		private void OnTriggerEnter(Collider other)
		{
			_mediator.SendOutRespawn();
		}
		///  PUBLIC API                ///
		public void InitView(RespawnerMediator mediator)
		{
			_mediator = mediator;
		}
	}
}
