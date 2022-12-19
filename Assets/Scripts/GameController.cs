using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameController : MonoBehaviour
    {
		[SerializeField] private SpawnStone m_stoneSpawner;
		[SerializeField] private float m_power = 100f;
		[SerializeField] private UIMenuController m_MenuUI;
		[SerializeField] private GameSettings m_gameSettings;

		private List<GameObject> m_stones = new();
		private int m_score = 0;
		private int m_maxScore = 0;
		private float m_timer = 0f;
		private float m_delay = 1f;
		private float m_maxDelay = 0f;


		public void Start()
		{
			m_MenuUI.MainMenuState();
			StartGame();
			m_maxDelay = m_gameSettings.maxDelay;
			m_score = 0;
			m_MenuUI.RefreshScore(m_score);
		}
		public void StartGame()
        {
            GameEvent.onGameOver += OnGameOver;
        }
        private void OnGameOver()
        {
            GameEvent.onGameOver -= OnGameOver;
			m_MenuUI.MainMenuState();
			ClearStones();
		}
		private void ClearStones()
		{
			foreach (GameObject stone in m_stones)
			{
				Destroy(stone);
			}
			m_stones.Clear();
		}
		public float CalcNextDelay()
		{
			 return Random.Range(m_gameSettings.minDelay, m_maxDelay);
		} 
        public void Update()
        {
            m_timer += Time.deltaTime;
			if (m_timer >= m_delay)
			{
				var stone = m_stoneSpawner.Spawn();
				m_stones.Add(stone);
				m_timer -= m_delay;
				m_delay = CalcNextDelay();
				while (m_maxDelay > m_gameSettings.minDelay)
				{
					m_maxDelay -= m_gameSettings.stepDelay;
					break;
				}
			}
		}
        public void OnCollisionStone(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.SetAffect(false);

                var contact = collision.contacts[0];
                var body = contact.otherCollider.GetComponent<Rigidbody>();
                var stick = contact.thisCollider.GetComponent<CollisionPlow>();

                body.AddForce(stick.dir * m_power, ForceMode.Impulse);
				m_score++;
				m_maxScore = Mathf.Max(m_score, m_maxScore);
				m_MenuUI.RefreshScore(m_score);
				
				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
            }
        }
    }
}
