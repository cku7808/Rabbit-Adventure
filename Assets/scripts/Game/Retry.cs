using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public string SceneToLoad;
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
