using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace Audio
{
	public class GameAudioEffectView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private AudioClip[] _clips;

		///  PRIVATE VARIABLES         ///
		private AudioSource _as;
		///  PRIVATE METHODS           ///

		private AudioClip FindClip(string clipName)
		{
			AudioClip clip = null;
			foreach (var c in _clips)
			{
				if (c.name == clipName)
				{
					clip = c;
				}
			}
			return clip;
		}

		private void Awake()
		{
			_as = GetComponent<AudioSource>();
		}

		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void ClearAudio()
		{
			_as.Stop();
		}

		public void PlayAudioClip(string clipName)
		{
			AudioClip clip = FindClip(clipName);
			if (clip != null)
			{
				_as.clip = clip;
				_as.Play();
			}
		}
	}
}
