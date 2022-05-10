using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class record : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    float yourRecord;
    public Text YourRecord;
    string currentStage;
    public Text StageClear;
    void Start()
    {
        yourRecord = timer.time;
        yourRecord = Mathf.Round(yourRecord);
        YourRecord.text = yourRecord.ToString();

        currentStage = playerMove.stageLevel.ToString();
        StageClear.text = "Stage " + currentStage + " Clear!";
    }

}
