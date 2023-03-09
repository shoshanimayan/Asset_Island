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
		[SerializeField] private float _radius=2;
		[SerializeField] private float _minDistance=0;
		[SerializeField] private float _minSoundScale = 2;
		[SerializeField] private float _maxSoundScale = 1;
		[SerializeField] private float _minRumbleScale = 0;
		[SerializeField] private float _maxRumbleScale = 1;

		///  PRIVATE VARIABLES         ///
		private bool _triggered;
		private InteractableMediator _mediator;
		private AudioSource _audioSource;
		private SphereCollider _collider;
		private Transform _player;

		///  PRIVATE METHODS           ///
		///  
		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(transform.position, _radius);	
		}

		private void OnTriggerEnter(Collider other)
		{
			_triggered = true;
			if (other.gameObject.tag == "Player" &&!Interacted)
			{
				_player = other.transform;
				PlayAudio();
			}
		
		}



		private void OnTriggerExit(Collider other)
		{
			_player = null;
			_triggered = false;
			if (!Interacted)
			{
				_mediator.SendHelpText("");
				StopAudio();
				SetHaptics(0);
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (!Interacted)
			{
				if (_mediator.InPlayMode())
				{
					
					if (!_audioSource.isPlaying)
					{
						_audioSource.UnPause();
					}
					var distance = GetDistanceToPlayer();
					var scaleSound = Mathf.Lerp(_maxSoundScale, _minSoundScale, Mathf.InverseLerp(_minDistance, _radius, distance));
					var scaleRumble = Mathf.Lerp(_maxRumbleScale, _minRumbleScale, Mathf.InverseLerp(_minDistance, _radius, distance));

					SetHaptics(scaleRumble);
					_audioSource.pitch = scaleSound;
					if (distance <= _radius / 4)
					{
						SendMessage();
					}
					
				}
				else
				{
					_audioSource.Pause();
					_mediator.SendHelpText("");
					SetHaptics(0);
				}
			}

		}

		private void SetHaptics(float rumble)
		{
			if (Gamepad.current != null)
			{
				Gamepad.current.SetMotorSpeeds((rumble==0?0:(rumble / 4)), rumble);
			}
		}

		

		private float GetDistanceToPlayer()
		{
			float distance = 0;
			if (_player)
			{
				distance = Vector3.Distance(_player.position, transform.position);
			}

			return distance;

		
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
			_audioSource = GetComponent<AudioSource>();
			_collider = GetComponent<SphereCollider>();
			_audioSource.minDistance = _radius;
			_collider.radius = _radius;
		}

		public void PlayAudio()
		{
			_audioSource.Play();	
		}

		public void StopAudio()
		{
			_audioSource.Stop();
		}

		public void SetAudioPitch(float pitch)
		{
			_audioSource.pitch = pitch;
		}

		

	}
}
