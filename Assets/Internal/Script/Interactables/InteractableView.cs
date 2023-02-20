using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Interactables
{
	public class InteractableView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		public int Index;
		///  PRIVATE VARIABLES         ///
		private bool _triggered;
		private InteractableMediator _mediator;
		///  PRIVATE METHODS           ///
		private void OnTriggerEnter(Collider other)
		{
			_triggered = true;
			if (!Interacted)
			{
				SendMessage();
			}
		}



		private void OnTriggerExit(Collider other)
		{
			_triggered = false;
			if (!Interacted)
			{
				_mediator.SendHelpText("");
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (!Interacted)
			{
				SendMessage();
			}
		}

		private void SendMessage()
		{
			var key = "Press E To Interact";
			if (Gamepad.current != null)
			{
				if (Gamepad.current.added)
				{
					key = "Prss X To Interact";
				}
			}
			_mediator.SendHelpText(key);
		}
		///  PUBLIC API                ///
		public bool Interacted;
		public void SetIndex(int index)
		{
			Index = index;
		}

		public bool IsTriggered()
		{
			return _triggered;
		}

		public void InitView(InteractableMediator mediator)
		{
			_mediator = mediator;
		}

		
	}
}
