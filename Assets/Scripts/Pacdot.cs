using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pacdot : MonoBehaviour {
	public AudioClip sound;
	public AudioSource source;
	private SetPocdot SetPocdot;

	void Start()
	{
		SetPocdot = Call.Call_SetPocdot();
		sound = SetPocdot.sound;
		source = SetPocdot.source;		
		source.clip = sound;
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") {
			Destroy (gameObject);
			Messenger.Broadcast (GameEvent.ENEMY_HIT);
			source.Play();
		}
	}
}
