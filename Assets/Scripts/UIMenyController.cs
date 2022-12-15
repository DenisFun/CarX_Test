using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class UIMenyController : MonoBehaviour
	{
		[SerializeField]
		private UIScorePanel m_scorePanel;
		[SerializeField]
		private GameObject m_mainMenyPanel;
		[SerializeField]
		private GameObject m_gamePanel;

		public void RefreshScore(int m_score)
		{
			m_scorePanel.SetScore(m_score);
		}

		public void MainMenyState()
		{
			enabled = false;
			m_mainMenyPanel.SetActive(true);
			m_gamePanel.SetActive(false);
		}

		public void GameState()
		{
			enabled = true;
			m_mainMenyPanel.SetActive(false);
			m_gamePanel.SetActive(true);
		}

	}
}
