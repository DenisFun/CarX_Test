using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Animation : MonoBehaviour
	{
		[SerializeField]
		private Animator anim;

		/* public void Idle()
				{
					anim.SetBool("Idle",true);
				}
				public void _Idle()
				{
					anim.SetBool("Idle",false); 
				}  */
		public void PushFalse()
		{
			anim.SetBool("Zamah", false);
		}
		public void PushTrue()
		{
			anim.SetBool("Zamah", true);
		}
		public void KickTrue()
		{
			anim.SetBool("Udar", true);
		}
		public void KickFalse()
		{
			anim.SetBool("Udar", false);
		}
	}
}



