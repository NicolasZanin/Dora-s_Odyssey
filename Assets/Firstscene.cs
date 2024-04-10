using UnityEngine;
using UnityEngine.SceneManagement;

public class Firstscene : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}