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
		[SerializeField]
		private GameController m_gameController;

		public void RefreshScore(int m_score)
		{
			m_scorePanel.SetScore(m_score);
		}

		public void MainMenyState()
		{
			m_gameController.enabled = false;
			m_mainMenyPanel.SetActive(true);
			m_gamePanel.SetActive(false);
		}

		public void GameState()
		{

			m_gameController.Start();
			m_gameController.CalcNextDelay();
			m_gameController.enabled = true;
			m_mainMenyPanel.SetActive(false);
			m_gamePanel.SetActive(true);
		}
	}
}
