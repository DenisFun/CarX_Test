using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Animation : MonoBehaviour
	{
		[SerializeField]
		private Animator m_anim;
		public void PushFalse()
		{
			m_anim.SetBool("Zamah", false);
		}
		public void PushTrue()
		{
			m_anim.SetBool("Zamah", true);
		}
		public void KickTrue()
		{
			m_anim.SetBool("Udar", true);
		}
		public void KickFalse()
		{
			m_anim.SetBool("Udar", false);
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



