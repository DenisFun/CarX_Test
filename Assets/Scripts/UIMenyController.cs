using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class UIMenyController : MonoBehaviour
	{
		[SerializeField] private UIScorePanel m_scorePanel;
		[SerializeField] private GameObject m_mainMenyPanel;
		[SerializeField] private GameObject m_gamePanel;
		[SerializeField] private GameController m_gameController;
		[SerializeField] private Camera m_playCamera;
		[SerializeField] private Camera m_mainMenyCamera;

		public void RefreshScore(int m_score)
		{
			m_scorePanel.SetScore(m_score);
		}

		public void MainMenyState()
		{
			m_mainMenyCamera.enabled = true;
        	m_playCamera.enabled = false;
			m_gameController.enabled = false;
			m_mainMenyPanel.SetActive(true);
			m_gamePanel.SetActive(false);
		}

		public void GameState()
		{
			m_gameController.Start();
			m_mainMenyCamera.enabled = false;
        	m_playCamera.enabled = true;
			m_gameController.CalcNextDelay();
			m_gameController.enabled = true;
			m_mainMenyPanel.SetActive(false);
			m_gamePanel.SetActive(true);
		}
		
		public void Exit()
		{
			Application.Quit();
		}
	}
}
