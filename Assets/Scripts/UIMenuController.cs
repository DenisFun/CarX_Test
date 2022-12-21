using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class UIMenuController : MonoBehaviour
	{
		[SerializeField] private UIScorePanel m_scorePanel;
		[SerializeField] private GameObject m_mainMenuPanel;
		[SerializeField] private GameObject m_gamePanel;
		[SerializeField] private GameController m_gameController;
		[SerializeField] private Camera m_playCamera;
		[SerializeField] private Camera m_mainMenuCamera;
		[SerializeField] private AnimationTarget m_animTarget;

		public void RefreshScore(int m_score)
		{
			m_scorePanel.SetScore(m_score);
		}

		public void MainMenuState()
		{
			m_mainMenuCamera.enabled = true;
        	m_playCamera.enabled = false;
			m_gameController.enabled = false;
			m_mainMenuPanel.SetActive(true);
			m_gamePanel.SetActive(false);
		}

		public void GameState()
		{
			m_gameController.Start();
			m_mainMenuCamera.enabled = false;
        	m_playCamera.enabled = true;
			m_animTarget.TargetAnimFalse();
			m_gameController.CalcNextDelay();
			m_gameController.enabled = true;
			m_mainMenuPanel.SetActive(false);
			m_gamePanel.SetActive(true);
		}
		
		public void Exit()
		{
			Application.Quit();
		}
	}
}
