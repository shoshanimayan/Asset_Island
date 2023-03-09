using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace General
{
	public class PlayerHandler
	{



		private Transform _player;

		///  PUBLIC API                ///
		public PlayerHandler() { }
		public Vector3 GetPlayerWorldPosition()
		{
			return _player.position;
		}

		public Vector3 GetPlayerLocalPosition()
		{
			return _player.localPosition;
		}

		public Transform GetPlayerTransform()
		{
			return _player.transform;
		}

		public void SetPlayerTransform(Transform t)
		{
			_player = t;
		}
	}
}
