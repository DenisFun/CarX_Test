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

        [SerializeField] private Animation m_anim;

		[SerializeField] private float m_power = 100f;
		[SerializeField] private UIMenyController m_uiMenyScoreCount;
		private int m_score = 0;
		private bool m_Idle;
        private bool m_Push;
		private float m_timer = 0f;

        public void Update()
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_delay)
            {
                m_stoneSpawner.Spawn();
                m_timer -= m_delay;
            }
        }

        public void Up()
        {
			m_anim.PushFalse();
            m_anim.KickTrue();
        }

        public void Down()
        {
            m_anim.PushTrue();
            m_anim.KickFalse();
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
				m_uiMenyScoreCount.RefreshScore(m_score);

				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
            }
        }

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            GameEvent.onGameOver += OnGameOver;
        }

        private void OnGameOver()
        {
            GameEvent.onGameOver -= OnGameOver;
			Debug.Log("Game Over");
        }

        private void OnDestroy()
        {
            GameEvent.onGameOver -= OnGameOver;
        }
    }
}
