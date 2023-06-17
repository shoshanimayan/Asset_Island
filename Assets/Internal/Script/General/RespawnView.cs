using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using CMF;

namespace General
{
	public class RespawnView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		[SerializeField] private CameraController _camController;
		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public Vector3 RespawnPos;

		public void Respawn()
		{
			transform.position = RespawnPos;
			_camController.ResetCurrentAngle();
		}
	}
}
