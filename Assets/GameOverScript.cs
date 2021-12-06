using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public string RetryLevelName;

    public void RetryLevel()
    {
        SceneManager.LoadScene(RetryLevelName);


    }
}
