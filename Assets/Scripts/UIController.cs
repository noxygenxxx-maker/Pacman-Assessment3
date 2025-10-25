using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLabel;
	[SerializeField] private Popup popup;
	[SerializeField] public static event Action OnDeathEvent;
	private int _score;

	void Awake() {
		Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
		Messenger.AddListener(GameEvent.PACMAN_HIT, OnDeath);
	}

	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
		Messenger.RemoveListener(GameEvent.PACMAN_HIT, OnDeath);
	}

	void Start() {
		_score = 0;
		scoreLabel.text = _score.ToString();
		popup.Close();
	}

	private void OnEnemyHit() {
		_score += 1;
		scoreLabel.text = _score.ToString();
	}

	private void OnDeath() {
		OnDeathEvent?.Invoke();
		popup.Open();
	}
}
