using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTime : MonoBehaviour
{
    // Start is called before the first frame update
    public playerMove p;
    public Text t;
    void Start()
    {
        p = GameObject.Find("Player").GetComponent<playerMove>();

        t.text = "Your record : " + Mathf.Round(p.currentTime);
    }
}
