using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace General
{
	public class RespawnView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public Vector3 RespawnPos;

		public void Respawn()
		{
			transform.position = RespawnPos;
		}
	}
}
