using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class controllerGambar : MonoBehaviour
{
    public GameObject Harimau;
    public GameObject Kambing;
    public GameObject Kangguru;
    public GameObject Sapi;
    public GameObject Singa;

    public float x_kiri = 20;
    public float x_kanan = -20;
    public string Jawaban;

    public float level = 1;
    public float time = 120;
    public float waktu;
    bool runningTime = true;
    bool feedback = false;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Indicator;
    public TextMeshProUGUI Pertanyaan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Press(GameObject objek)
    {
        Debug.Log("Nama Objeknya = " +  objek.name);
        Jawaban = objek.name;
    }
    // Update is called once per frame
    void Update()
    {
        if (runningTime)
        {
            RunningTime();
        }
        Timer.text = time.ToString();
        levelText.text = level.ToString();
        soal();
    }
    private Vector3 newPos(GameObject objek, float x)
    {
        Vector3 newPosition = objek.transform.position; // Mendapatkan posisi saat ini
        newPosition.x = x; // Mengubah posisi x
        objek.transform.position = newPosition; // Mengatur posisi baru
        return newPosition;
    }
    private void soal()
    {
        if (level == 1)
        {

            Pertanyaan.text = "Manakah Ganbar Harimau ?";

            Harimau.SetActive(true);
            Harimau.transform.position = newPos(Harimau, x_kiri);
            Kangguru.SetActive(true);
            Kangguru.transform.position = newPos(Kangguru, x_kanan);
            if (Jawaban == "Harimau")
            {
                Harimau.SetActive(false);
                Kangguru.SetActive(false);
                feedback = true;
                if (Input.GetMouseButtonUp(0))
                {
                    benar();
                }


            }
            else
            {
                if(Input.GetMouseButtonUp(0)) {
                    salah();
                }
                
            }
        }
        if (level == 2)
        {
            Pertanyaan.text = "Manakah Ganbar Kambing ?";

            Singa.SetActive(true);
            Singa.transform.position = newPos(Singa, x_kiri);
            Kambing.SetActive(true);
            Kambing.transform.position = newPos(Kambing, x_kanan);
            if (Jawaban == "Kambing")
            {
                Singa.SetActive(false);
                Kambing.SetActive(false);
                feedback = true;
                if (Input.GetMouseButtonUp(0))
                {
                    benar();
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    salah();
                }
            }
        }
        if (level == 3)
        {
            Pertanyaan.text = "Manakah Ganbar Sapi ?";

            Sapi.SetActive(true);
            Sapi.transform.position = newPos(Sapi, x_kiri);
            Harimau.SetActive(true);
            Harimau.transform.position = newPos(Harimau, x_kanan);
            if (Jawaban == "Sapi")
            {
                Harimau.SetActive(false);
                Sapi.SetActive(false);
                feedback = true;
                if (feedback)
                {
                    benar();
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    salah();
                }
            }
        }
    }
    public void wait(float value)
    {
        
    }
    public void waitSec(float value)
    {
        waktu += Time.deltaTime;
        if(waktu > value)
        {
            waktu = 0;
        }
    }
    public void RunningTime()
    {
        runningTime = true;
        time -= Time.deltaTime;
    }
    async void benar()
    {
        Indicator.text = "Benar!";
        float value = level;
        level = 0;
        Pertanyaan.text = "";
        await Task.Delay(2000);
        Indicator.text = "";
        
        feedback = false;

        runningTime = false;
        level = value + 1;
            waktu = 0;
            RunningTime();

        
    }
    async void salah()
    {
        Indicator.text = "Salah!";
        await Task.Delay(2000);
        Indicator.text = "";
    }
    public void back(float value)
    {
        Application.LoadLevel("MainMenu");
    }
}
