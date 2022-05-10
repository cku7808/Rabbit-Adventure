using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class timer : MonoBehaviour
    {
        public static float time;
        public Text timer_text;

        // Start is called before the first frame update
        void Start()
        {
            time = 0;
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
            timer_text.text = "Time : " + Mathf.Round(time);
        }

}

