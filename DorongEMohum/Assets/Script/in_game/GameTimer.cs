using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text TimerText;
    public int InitialTime;
    public int Timer;
    private float tick = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Timer = InitialTime;
        UpdateTimer(Timer);
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if( tick >= 1.0f )
        {
            Timer -= 1;
            UpdateTimer(Timer);
            if(Timer == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameMenu>().GameOver();
                Timer = InitialTime;
            }
            tick = 0.0f;
        }
    }

    void UpdateTimer(int time)
    {
        TimerText.text = "Timer: " + time;
    }
}
