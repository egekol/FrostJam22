using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.GamePlay

{
	public enum AnimationType
	{
		Idle,
		Speed
	}
	public class PlayerAnimationController : MonoBehaviour
	{
		private AnimationType CurrentAnimationType { get; set; }

		private Animator _animator;
		private readonly Dictionary<AnimationType, int> _hashDictionary = new Dictionary<AnimationType, int>();

		public bool isWaving = false;

		public void Awake()
		{
			_animator = GetComponentInChildren<Animator>();
			Debug.Log("animator:"+ _animator.GetInstanceID());
			SetupAnimationHashes();
			// SetIdleMultiplier();
		}

		private void SetupAnimationHashes()
		{
			string[] names = Enum.GetNames(typeof(AnimationType));
			Array values = Enum.GetValues(typeof(AnimationType));
			for (int i = 0; i < Enum.GetNames(typeof(AnimationType)).Length; i++)
				_hashDictionary.Add((AnimationType)values.GetValue(i), Animator.StringToHash(names[i]));
		}

		public void SetIdle()
		{
			if (CurrentAnimationType == AnimationType.Idle) return;
			_animator.SetTrigger(_hashDictionary[AnimationType.Idle]);
			CurrentAnimationType = AnimationType.Idle;
		}
		

		/*
		public void SetDeath()
		{
		    _animator.SetTrigger(_hashDictionary[AnimationType.Death]);
		}
	
		public void SetBeg()
		{
		    _animator.SetTrigger(_hashDictionary[AnimationType.Beg]);
		}
		*/

		/*public void SetHit()
		{
		    if(CurrentAnimationType == AnimationType.Hit) return;
		    _animator.SetTrigger(_hashDictionary[AnimationType.Hit]);
		    CurrentAnimationType = AnimationType.Hit;
		}*/

		public void SetSpeed(float speed)
		{
			_animator.SetFloat(_hashDictionary[AnimationType.Speed], speed);
		}
		/*private void SetIdleMultiplier()
		{
		    _animator.SetFloat(_hashDictionary[AnimationType.IdleMultiplier], Random.Range(.8f, 1.2f));
		}*/

		/*
		public void SetLevelUp()
		{
		    _animator.SetTrigger(_hashDictionary[AnimationType.LevelUp]);
		}*/
	}
}