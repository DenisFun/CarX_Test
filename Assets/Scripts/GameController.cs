using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameController : MonoBehaviour
    {
		[SerializeField] private SpawnStone m_stoneSpawner;

        [SerializeField] private float m_delay = 1f;
		[SerializeField] private float m_power = 100f;
		[SerializeField] private UIMenyController m_MenyUI;
		private int m_score = 0;
		private int m_maxScore = 0;
		private float m_timer = 0f;
		private List<GameObject> m_stones = new();

		public void Start()
		{
			m_MenyUI.MainMenyState();
			StartGame();
		}
        public void Update()
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_delay)
            {
                var stone = m_stoneSpawner.Spawn();
				m_stones.Add(stone);
                m_timer -= m_delay;
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
				m_MenyUI.RefreshScore(m_score);
				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
            }
        }
		private void ClearStones()
		{
			foreach (GameObject stone in m_stones)
			{
				Destroy(stone);
			}
			m_stones.Clear();
		}
        public void StartGame()
        {
            GameEvent.onGameOver += OnGameOver;
        }

        private void OnGameOver()
        {
            GameEvent.onGameOver -= OnGameOver;
			Debug.Log("Game Over");
			m_MenyUI.MainMenyState();
			ClearStones();
		}
    }
}