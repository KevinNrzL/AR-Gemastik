using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public int sentuh1,sentuh2,targetSentuh1,targetSentuh2;

    private void Update()
    {
        if (sentuh1 == targetSentuh1)
        {
            targetSentuh1 += 1;
        }
    }
    
}
