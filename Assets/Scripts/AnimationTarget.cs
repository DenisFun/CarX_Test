using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AnimationTarget : MonoBehaviour
	{
		[SerializeField] private Animator m_targetAnimation;
		public void TargetAnimTrue()
    	{
        	m_targetAnimation.SetBool("CollisionTarget", true);
    	}
		private void OnCollisionEnter(Collision stoneOther)
		{
			TargetAnimTrue();
		}
	}
}