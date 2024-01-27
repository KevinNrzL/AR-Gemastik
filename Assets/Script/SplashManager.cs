using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }

   
    IEnumerator Load()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("MainMenu");
    }
}
