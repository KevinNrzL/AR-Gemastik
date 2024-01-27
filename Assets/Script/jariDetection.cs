using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jariDetection : MonoBehaviour
{
    public int leftFingerId = -1;
    public int rightFingerId = -1;
    public TextMeshProUGUI textMeshPro, text2;

    private void Update()
    {
        textMeshPro.text = leftFingerId.ToString();
        text2.text = rightFingerId.ToString();
        // Mendeteksi input sentuhan pada layar
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Memisahkan jari kiri dan jari kanan berdasarkan posisi sentuhan
            if (touch.phase == TouchPhase.Began)
            {
                if (leftFingerId == -1)
                {
                    leftFingerId = touch.fingerId;
                    Debug.Log("Jari kiri terdeteksi!");
                   
                }
                else if (rightFingerId == -1)
                {
                    rightFingerId = touch.fingerId;
                    Debug.Log("Jari kanan terdeteksi!");
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Menghapus identifikasi jari ketika sentuhan berakhir
                if (touch.fingerId == leftFingerId)
                {
                    leftFingerId = -1;
                    Debug.Log("Jari kiri tidak terdeteksi!");
                }
                else if (touch.fingerId == rightFingerId)
                {
                    rightFingerId = -1;
                    Debug.Log("Jari kanan tidak terdeteksi!");
                }
            }
        }
    }
}
