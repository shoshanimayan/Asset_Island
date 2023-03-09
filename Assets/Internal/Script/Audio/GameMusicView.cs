using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace Audio
{
	public class GameMusicView : MonoBehaviour, IView
	{

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
		///  PUBLIC API                ///
		public void SetAudio(string clipName)
		{
			AudioClip clip = FindClip(clipName);
			if (clip != null)
			{
				if (clip == _as.clip)
				{
					UnpauseAudio();
					return;
				}
				
				_as.clip = clip;
				_as.Play();
			}
		}

		public void PauseAudio()
		{
			_as.Pause();		
		}

		public void UnpauseAudio()
		{
			_as.UnPause();
		}

		public void setVolume(float volume)
		{
			_as.volume = volume;
		}

		public float GetVolume()
		{
			return _as.volume;
		}
		
	}
}
