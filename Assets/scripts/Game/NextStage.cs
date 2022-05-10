using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            JumpStage();
        }
    }
    public void JumpStage()
    {
        SceneManager.LoadScene(sceneName);
    }
}
