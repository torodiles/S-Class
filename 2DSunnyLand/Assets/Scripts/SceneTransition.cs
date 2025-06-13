using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float timeDelay;
    public void MoveToScene(string sceneName)
    {
        StartCoroutine(delayTransition(sceneName, timeDelay));
    }

    IEnumerator delayTransition(string sceneName, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneName);

    }
}
