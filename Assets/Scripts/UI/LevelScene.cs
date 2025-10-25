using UnityEngine;

public class LevelScene : MonoBehaviour
{
    public bool Playing = true;
    [SerializeField] private SceneTransition sceneTransition;
    void Start()
    {
        UIController.OnDeathEvent += OnDeath;
        sceneTransition = GetComponent<SceneTransition>();
    }
    private void OnDeath()
    {
        Playing = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Playing)
        {
            if (sceneTransition != null)
                sceneTransition.TransitionToCurrent();
            else
                sceneTransition = GetComponent<SceneTransition>();
        }
    }
}
