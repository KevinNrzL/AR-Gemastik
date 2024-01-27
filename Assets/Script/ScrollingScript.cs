using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingScript : MonoBehaviour
{
    public GameObject objek;
    float scroll_post = 0;
    float[] post;
    public MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        post = new float[transform.childCount];
       
        float distance = 1f / (post.Length - 1);
        
        for (int i = 0; i < post.Length; i++) {
            post[i] = distance * i;
        }
        if(Input.GetMouseButton(0))
        {
           
            scroll_post = objek.GetComponent<Scrollbar>().value;
            /*
            for (int i = 0; i < post.Length; i++)
            {
                if ((scroll_post + distance / 3) < post[i] + (distance / 2) && (scroll_post - distance / 3) > post[i] - (distance / 2))
                {
                    Debug.Log("Post [i] = " + post[i]);
                    Debug.Log("i = " + i);
                    Debug.Log("Scroll Post = " + scroll_post);
                    //objek.GetComponent<Scrollbar>().value = Mathf.Lerp(objek.GetComponent<Scrollbar>().value, post[i], 0.3f);

                }
                else
                {
                    Debug.Log("Post [i] = " + post[i]);
                    Debug.Log("i = " + i);
                    Debug.Log("Scroll Post = " + scroll_post);
                }
            }
            */

        }
        else{
          
             for (int i = 0;i < post.Length;i++)
             {
                 if(scroll_post < post[i] + (distance / 2) && scroll_post > post[i] - (distance / 2))
                 {
                     Debug.Log("Post [i] = " + post[i]);
                     Debug.Log("i = " + i);
                    menuManager.modeGame = i;
                     objek.GetComponent<Scrollbar>().value = Mathf.Lerp (objek.GetComponent<Scrollbar>().value, post[i], 0.3f);

                 }

             }
            

            /*
           for (int i = 0;i < post.Length;i++)
            {
                if (scroll_post < post[i] / 2 &&)
            }
            
            for (int i = 0; i <= post.Length; i++)
            {
                if (post[i]  > (scroll_post + (distance / 2)) )
                {
                    Debug.Log("Post [i] = " + post[i]);
                    Debug.Log("i = " + i);
                   // objek.GetComponent<Scrollbar>().value = Mathf.Lerp(objek.GetComponent<Scrollbar>().value, post[i], 0.3f);

                }
            }
            */
        }
    }
}
