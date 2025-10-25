using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            GetComponent<SceneTransition>().TransitionToNextScene();
        }
    }
}
