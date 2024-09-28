using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("The Level Time in Seconds")][SerializeField] float levelTime = 10f;
    bool triggerTimerFinished = false;

    // Update is called once per frame
    void Update()
    {
        if(triggerTimerFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timeFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timeFinished) 
        {
            FindObjectOfType<levelController>().LevelTimerFinished();
            triggerTimerFinished = true;
        }
    }
}
