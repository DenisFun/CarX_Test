using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{


	public class SpawnStone : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_prefabStone;
		private GameObject a;

		public void Spawn()
		{
			Vector3 position = transform.position;
			Quaternion rotation = transform.rotation;
			a = Instantiate(m_prefabStone, position, rotation);
		}
		/* public void DestroyK()
		{
			Destroy(gameObject);
		} */
	}
}