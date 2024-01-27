using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Engklek : MonoBehaviour
{
    public TimerPoint timerpoint;
    public GameObject nextButton;
    public float time = 1000, totalSeconds;
    public Camera camera;
    public DetectionCollider DetectionScript;
    public int point = 1 , point2;
    public int point_disable = 2;

    public bool double_touch = true;
    public jariDetection jari_detection;
    public int touch1,touch2;

    public float timing = 3;
    public bool game_maju = true;
    public bool endGame = false;
    public bool press = false;
    public bool start = false;

    public bool bool_point1 = false, bool_point2;
    public bool do_it_again = false;
    public bool angkat_jarinya = false;
    public bool HitungSekor = false;
    public int point_now = 1, point2_now = 1;

    public int score = 0;

    public GameObject scoreObject;
    public TextMeshProUGUI Debug_text,debug1,debug2,debug3,debug4, debug5, skor,final_score,level;
    // Start is called before the first frame update\
    public void home()
    {
        Application.LoadLevel("MainMenu");
    }
    void Start()
    {
         totalSeconds = time;
    }
    void effect_disable()
    {
    }
    void effect_point()
    {
    }
    // Update is called once per frame
    void Update()
    {
        controller();
        if (double_touch)
        {
            double_touch_logic();
        }
        else
        {
            converterCube();
        }
        totalSeconds -= Time.deltaTime;
        string formattedTime = FormatTime(totalSeconds);
        Debug.Log(formattedTime);

        skor.text = score.ToString();
        level.text = point_disable.ToString();
        final_score.text = score.ToString();
        if (endGame)
        {
            nextButton.SetActive(false);
            done();
        }
        else
        {
            nextButton.SetActive(true);
        }

    }
    public string FormatTime(float totalSeconds)
    {
        float hours = totalSeconds / 3600;
       
        float minutes = (totalSeconds / 60);
       
        float seconds = (totalSeconds % 60);
        

        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
    void done()
    {
        scoreObject.SetActive(true);

        if (!HitungSekor)
        {
            scoreTotal();
        }
        timerpoint.Play = false;
        timerpoint.ResetTimer();
        

    }
    void controller()
    {
        if (jari_detection.leftFingerId != -1)
        {


            Debug_text.text = "Touch " + Input.touchCount;
            Touch Utouch1 = Input.GetTouch(0);

            if (Utouch1.phase == TouchPhase.Began)
            {

                Ray ray = camera.ScreenPointToRay(Utouch1.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject touchedObject = hit.transform.gameObject;
                    Debug.Log("Nama GameObject yang disentuh: " + touchedObject.name);
                    debug1.text = "Debugging : " + touchedObject.name;
                    touch1 = int.Parse(touchedObject.name);

                }
            }
            /*
            
            */
        }
        if (jari_detection.rightFingerId != -1)
        {
            Touch Utouch2 = Input.GetTouch(1);

            if (Utouch2.phase == TouchPhase.Began)
            {

                Ray ray = camera.ScreenPointToRay(Utouch2.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject touchedObject = hit.transform.gameObject;
                    Debug.Log("Nama GameObject yang disentuh: " + touchedObject.name);
                    debug2.text = "Debugging : " + touchedObject.name;
                    touch2 = int.Parse(touchedObject.name);

                }
            }
        }

        debug3.text = "Touch1 = " + touch1;
        debug5.text = "Touch2 = " + touch2;
        debug4.text = "Point = " + point;

        
    }
    void double_touch_logic()
    {
       
        
        // game logic
        
        if (jari_detection.leftFingerId == -1)
        {
            touch1 = 0;
            timing = 3;

        }
        if (jari_detection.rightFingerId == -1)
        {
            touch2 = 0;
            timing = 3;
        }


        if (point_disable > 7)
        {
            point_disable = 0;
            endGame = true;
        }
        if (touch1 == point_disable || touch2 == point_disable)
        {
            lose();
        }
        logicPoint1();
        //logicPoint2();

    }
    void logicPoint1()
    {

        if (start)
        {

            if (touch1 != point_now && touch1 != point)
            {

                timing -= Time.deltaTime;
                if (timing <= 0)
                {
                    lose();
                    Debug.Log("Error 1");
                }


            }
        }

        if (game_maju)
        {

            
            if (bool_point2)
            {
                if (angkat_jarinya)
                {
                    if (jari_detection.leftFingerId == -1 && jari_detection.rightFingerId == -1)
                    {
                        angkat_jarinya = false;
                        do_it_again = true;
                        bool_point2 = false;
                        
                    }
                    
                }else
                
                if (touch1 == point || touch1 == point2)
                {
                    
                    point_now = touch1;
                    if (touch2 == point || touch2 == point2)
                    {
                        angkat_jarinya = true;
                        point2 = 0;
                        point2_now = touch2;
                        score += 10;




                    }

                }
            }
            else
            {
                if(point == point_disable)
                {
                    point++;
                }
                

                if (do_it_again)
                {
                    if (touch1 == point)
                    {
                        point_now = touch1;

                        point++;
                        score += 10;


                        do_it_again = false;
                    }
                }
                else
                {
                    
                    
                    if (point == 4)
                    {
                        point++;

                        point2 = 0;
                        bool_point2 = false;
                    }
                    else
                    if (point == 5)
                    {
                        bool_point2 = true;
                        point2 = 4;
                    }
                    else
                    if (point == 6)
                    {
                        bool_point2 = true;
                        point2 = 4;
                    }
                    else
                    if (point == 7)
                    {
                        bool_point2 = true;
                        point2 = 4;
                    }
                    else
                    {
                        bool_point2 = false;
                        point2 = 0;
                    }
                    if (point2 == point_disable)
                    {
                        point2 = 0;
                        bool_point2 = false;
                    }
                    if (touch1 == point)
                    {
                        point_now = touch1;

                        point++;
                        score += 10;

                    }
                }
                


            }
            
            if (point > 7)
            {
                point = 4;
                point2 = 0;
                game_maju = false;
                bool_point2 = false;
            }
        }
        else
        {
            for (int i = 0; i <= 7; i++)
            {
                if (point == point_disable)
                {

                    point--;
                }
                debug3.text = "Touch1 = " + touch1;
                debug5.text = "Touch2 = " + touch2;
                debug4.text = "Point = " + point;
                if (touch1 == point)
                {
                    point_now = touch1;
                    score += 10;
                    point--;
                }
            }
            if (point <= -2 && Input.touchCount == 0)
            {
                point_disable++;
                HitungSekor = false;
                point = 0;
                game_maju = true;
                done();
            }
        }
    }
    void scoreTotal()
    {
        float menit, detik;
        menit = timerpoint.menit_temp;
        detik = timerpoint.timer;
        score = (int)(score - (menit * 3.5));
        score = (int)(score - (detik * 1.5));
        final_score.text = score.ToString();
        HitungSekor = true;
    }
    void logicPoint2()
    {

        if (start)
        {

            if (touch2 != point_now && touch2 != point)
            {

                timing -= Time.deltaTime;
                if (timing <= 0)
                {
                    lose();
                    Debug.Log("Error 1");
                }


            }
        }

        if (game_maju)
        {

            for (int i = 0; i <= 7; i++)
            {
                if (point2 == point_disable)
                {
                    point2++;
                }
                debug3.text = "Touch1 = " + touch1;
                debug5.text = "Touch2 = " + touch2;
                debug4.text = "Point = " + point;
                if (touch2 == point2)
                {

                    point2++;
                    point2_now = touch2;
                }
            }
            if (point2 > 7)
            {
                point2 = 4;
                game_maju = false;
            }
        }
        else
        {
            for (int i = 0; i <= 7; i++)
            {
                if (point == point_disable)
                {

                    point--;
                }
                debug3.text = "Touch1 = " + touch1;
                debug5.text = "Touch2 = " + touch2;
                debug4.text = "Point = " + point;
                if (touch1 == point)
                {
                    point_now = touch1;
                    point--;
                }
            }
            if (point <= -2 && Input.touchCount == 0)
            {
                point_disable++;
                HitungSekor = false;
                point = 0;
                game_maju = true;
                done();
            }
        }
    }
    int converToInt(string a)
    {
        
        int number = int.Parse(a);
        return number;
    }
    public void lose()
    {
        Debug.Log("KALAH!");
        endGame = true;
        done();
    }
    void converterCube()
    {
        if (Input.GetMouseButtonDown(0)) {
            touch1 = int.Parse(DetectionScript.NameSentuh1);
            
            touch2 = int.Parse(DetectionScript.NameSentuh2);
            Debug.Log(touch1);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            touch1 = 0;
            touch2 = 0;
            timing = 3;
            
        }

       
        if (point_disable > 7)
        {
            point_disable = 0;
        }
        if (touch1 == point_disable)
        {
            lose();
        }
        if (start)
        {
            
            if (touch1 != point_now && touch1 != point)
            {
                
                timing -= Time.deltaTime;
                if (timing <=  0)
                {
                    lose();
                    Debug.Log("Error 1");
                }

                
            }
        }
        
        if (game_maju)
        {
            
            for (int i = 0; i <= 7; i++)
            {
                if (point == point_disable)
                {
                    point++;
                    
                }
                if (touch1 == point || touch2 == point)
                {
                    point++;
                    score+= 10;
                    point_now = touch1;
                }
            }
            if (point > 7 )
            {
                point = 4;
                game_maju = false;
            }
        }
        else
        {
            for (int i = 0; i <= 7; i++)
            {
                if (point == point_disable)
                {

                    point--;
                }
                if (touch1 == point || touch2 == point)
                {
                    point_now = touch1;
                    point--;
                    score += 10;
                }
            }
            if (point <= -2 && Input.GetMouseButtonUp(0)) {
                point_disable++;
                HitungSekor = false;
                point = 0;
                game_maju = true;
                done();
            }
        }
        
        
    }

} 
