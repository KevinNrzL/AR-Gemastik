using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerPoint : MonoBehaviour
{
    public float menit = 6f, menit_temp = 0; // Durasi timer dalam detik
    public float timer = 0f; // Waktu saat ini
    public bool Play = false;
    //  TEXT MESH PRO 
    public TextMeshProUGUI timer_string;
    void changeTimeString()
    {
        timer_string.text = menit_temp.ToString() + ":" + Mathf.Round(timer);
    }
    private void Update()
    {
        if (Play)
        {
            runn();
        }
    }
    public void play()
    {
        Play = true;
    }
    void runn()
    {
        changeTimeString();
        if (menit_temp != menit)
        {
            timer += Time.deltaTime;
            if (timer >= 60f)
            {
                menit_temp++;
                timer = 0;
            }
        }
        else
        {
            Debug.Log("Game Selesai!");
        }

    }
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        timer = 0f;
        menit_temp = 0f;
    }
}
