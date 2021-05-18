using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{ 
    
    [SerializeField]
    private Text TimerText;

    [SerializeField] 
    private Text highscore;
    
    private bool finnished = false;

    private float startTime;
    private float t;
   
    void Start()
    {
        startTime = Time.time;
       
        if (PlayerPrefs.HasKey("Highscore") == true)
        {
            highscore.text = PlayerPrefs.GetFloat("Highscore").ToString("f2");
        }
        else
        {
            highscore.text = "No high scores yet";
        }
    }


    void Update()
    {
        
        if (finnished)
        {
            if (highscore.text.Equals("No high scores yet"))
            {
                SetHighscore();
            }
            if (PlayerPrefs.GetFloat("Highscore") > t)
            {
                SetHighscore();
            }
            return;
        }
        else
        {
            
            t = Time.time - startTime;
            string minutes = ((int) t / 60).ToString();
            string secounds = (t % 60).ToString("f2");
            
            TimerText.text = minutes + ":" + secounds;
        }
        
    }

    public void Finnish()
    {
        finnished = true;
        TimerText.color = Color.yellow;
    }
    public void SetHighscore () 
    {
        PlayerPrefs.SetFloat("Highscore", t);
        highscore.text = PlayerPrefs.GetFloat("Highscore").ToString("f2");

    }
}
