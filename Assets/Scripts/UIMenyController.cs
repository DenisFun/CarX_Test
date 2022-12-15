using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class UIMenyController : MonoBehaviour
	{
		[SerializeField]
		private UIScorePanel m_scorePanel;

		public void RefreshScore(int m_score)
		{
			m_scorePanel.SetScore(m_score);
		}

	}
}
