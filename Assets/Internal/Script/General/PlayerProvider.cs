using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zenject;
using UniRx;
using Interactables;

namespace General
{
	public class PlayerProvider: MonoBehaviour
	{

		

		[Inject]
		private PlayerHandler _playerHandler;


		private void Start()
		{
			_playerHandler.SetPlayerTransform(transform);
		}


	}
}
