using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SuperSpaceArcade
{
	public class ScoreUI : MonoBehaviour
	{

		private Player player;
		private Text scoreUI;


		public void OnEnable()
		{
			EventManager.onPlayerSpawned += this.OnPlayerSpawned;
			EventManager.onPlayerDestroyed += this.OnPlayerDestroyed;
		}


		public void OnDisable()
		{
			EventManager.onPlayerSpawned -= this.OnPlayerSpawned;
			EventManager.onPlayerDestroyed -= this.OnPlayerDestroyed;
			StopCoroutine("UpdateScore");
		}


		public void OnPlayerSpawned(TrackSpectator player)
		{
			this.player = player.gameObject.GetComponent<Player>();
			this.scoreUI = GameObject.FindWithTag("InGameUI").transform.Find("Score").GetComponent<Text>();

			StartCoroutine(UpdateScore());
		}


		public void OnPlayerDestroyed()
		{
			StopCoroutine("UpdateScore");
			this.player = null;
		}


		private IEnumerator UpdateScore()
		{
			while (true) {
				if (this.player && !this.player.gameOver) {
					this.scoreUI.text = this.player.points.ToString();
				} else {
					//
				}
				yield return new WaitForSeconds(0.1f);
			}
		}

	}
}