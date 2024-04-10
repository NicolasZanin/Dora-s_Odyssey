using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Firstscene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("planet1");
    }
}
