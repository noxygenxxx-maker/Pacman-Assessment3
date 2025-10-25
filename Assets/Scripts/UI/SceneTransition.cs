using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int nextIndex;
    public void TransitionToNextScene()
    {
        TransitionToIndex(nextIndex);
    }
    public void TransitionToCurrent()
    {
        TransitionToIndex(nextIndex-1);
    }
    private void TransitionToIndex(int index)
    {
        SceneManager.LoadScene("Level_" + index.ToString());
    }
}
