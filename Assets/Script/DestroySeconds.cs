using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySeconds : MonoBehaviour
{
    public float timeDestroy = 2f;

    private void Update()
    {
       timeDestroy -= Time.deltaTime;

        if (timeDestroy <= 0 )
        {
            GameObject.Destroy(gameObject);
        }
    }
}
