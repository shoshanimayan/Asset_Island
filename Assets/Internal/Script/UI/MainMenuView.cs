using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.EventSystems;
namespace UI
{
	public class MainMenuView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		///  PRIVATE VARIABLES         ///
		private MainMenuMediator _mediator;
		private bool _disabledEvent;
		///  PRIVATE METHODS           ///
		

		private void Update()
		{
			if (!_disabledEvent)
			{
				var RootEvent = GameObject.Find("Root_Event");
				if (RootEvent)
				{
					_disabledEvent = true;
					RootEvent.SetActive(false);
				}
			}
		}
		///  PUBLIC API                ///
		public void Init(MainMenuMediator mediator)
		{
			_mediator = mediator;
		}

		public void PlayGame()
		{
			_mediator.PlayGame();
		}

		public void ExitGame() {
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
		}
	}
}
