using UnityEngine;

public class ScreenSizeDetector : MonoBehaviour
{
    private void Start()
    {
        // Mendapatkan ukuran layar dalam piksel
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        Debug.Log("Ukuran Layar: " + screenWidth + "x" + screenHeight);
    }
}