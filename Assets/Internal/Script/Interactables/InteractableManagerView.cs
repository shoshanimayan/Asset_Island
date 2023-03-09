using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace Interactables
{
	public class InteractableManagerView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		public InteractableView[] InteractableList;
		public float PositionSetRadius;
		public float RestrictionDistance;

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		private void OnDrawGizmosSelected()
		{
			Handles.color = Color.red;
			Handles.DrawWireDisc(transform.position, new Vector3(0, 1, 0), PositionSetRadius);
		}
		///  PUBLIC API                ///

	}
}
