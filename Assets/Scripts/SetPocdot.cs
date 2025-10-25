using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPocdot : MonoBehaviour
{
    public AudioClip sound;
	public AudioSource source;
    private void Awake()
    {
        Call.Set_SetPocdot(this);
    }
}
