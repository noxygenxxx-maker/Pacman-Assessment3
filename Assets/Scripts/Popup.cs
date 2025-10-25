using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Popup : MonoBehaviour {
	public void Open() {
		gameObject.SetActive(true);
	}
	public void Close() {
		gameObject.SetActive(false);
	}
}
