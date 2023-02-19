using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class InteractableView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		public int Index;
		///  PRIVATE VARIABLES         ///
		private bool _triggered;
		///  PRIVATE METHODS           ///
		private void OnTriggerEnter(Collider other)
		{
			_triggered = true;
			Debug.Log("enter");
		}

		private void OnTriggerExit(Collider other)
		{
			_triggered = false;
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

		
	}
}
