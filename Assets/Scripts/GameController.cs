using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameController : MonoBehaviour
    {
		[SerializeField]
		private SpawnStone m_stoneSpawner;
		private float m_timer = 0f;

        [SerializeField]
        private float m_delay = 1f;

        [SerializeField]
        private Animation anim;
        private bool m_Idle;
        private bool m_Push;

        [SerializeField]
        private float m_power = 100f;
        Vector3 vec = new Vector3(-10, 10, 1);

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
            anim.KickTrue();
            anim.PushFalse();
            //anim._Idle();
            //Debug.Log("Space key was released.");
        }

        public void Down()
        {
            anim.PushTrue();
            anim.KickFalse();
            //anim.Idle();
            //Debug.Log("Space key was pressed.");
        }

        public void OnCollisionStone(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.SetAffect(false);
                //var contact = collision.contacts[0];
                var contact = collision.GetContact(0);
                var body = contact.otherCollider.GetComponent<Rigidbody>();
                body.AddForce(vec * m_power, ForceMode.Impulse);
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
			//m_stoneSpawner.DestroyK();
			Debug.Log("Game Over");
        }

        private void OnDestroy()
        {
            GameEvent.onGameOver -= OnGameOver;
        }
    }
}
