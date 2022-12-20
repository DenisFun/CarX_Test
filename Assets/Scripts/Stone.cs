using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Stone : MonoBehaviour
	{
		[SerializeField] private Rigidbody m_rigidbody;

		public bool isAffect { set; get; } = true;

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent<Stone>(out var stone))
			{
				GameEvent.onCollisionStones?.Invoke(this, stone);
			}
		}
	}

}
