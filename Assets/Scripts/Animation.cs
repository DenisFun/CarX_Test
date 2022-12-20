using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Animation : MonoBehaviour
	{
		[SerializeField] private Animator m_animation;
		public void PushFalse()
		{
			m_animation.SetBool("Zamah", false);
		}
		public void PushTrue()
		{
			m_animation.SetBool("Zamah", true);
		}
		public void KickTrue()
		{
			m_animation.SetBool("Udar", true);
		}
		public void KickFalse()
		{
			m_animation.SetBool("Udar", false);
		}
		public void Up()
        {
			PushFalse();
            KickTrue();
        }
        public void Down()
        {
            PushTrue();
            KickFalse();
        }
	}
}



