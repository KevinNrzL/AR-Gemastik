using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject Play_B;
    public GameObject ChangeMode_B;
    public GameObject Setting_B;
    public GameObject Back_B;
    [SerializeField] private Animator anim;   
    [SerializeField] private AudioSource ButtonEffect;

    public float modeGame = 0f;

    private void Update()
    {
        //anim = GetComponentInParent<Animator>();
    }
    public void Play()
    {
        if (modeGame == 0f)
        {
            Application.LoadLevel("Engklek");
        }else if (modeGame == 1f)
        {
            Application.LoadLevel("MainMenu");
        }else if (modeGame == 2f)
        {
            Application.LoadLevel("MainMenu");
        }
        
    }
    public void ButtonEff()
    {
        ButtonEffect.Play();
        
    }
    public void Animati()
    {
        anim.SetTrigger("Pop");
    }
    public void DisablePlay()
    {
        Play_B.SetActive(false);
    }
    public void DisableChange()
    {
        ChangeMode_B.SetActive(false);
    }
    public void DisableSetting()
    {
        Setting_B.SetActive(false);
    }
    public void DisableBack()
    {
        Back_B.SetActive(false);
    }

    //////////////////
    public void EnablePlay()
    {
        Play_B.SetActive(true);
    }
    public void EnableChange()
    {
        ChangeMode_B.SetActive(true);
    }
    public void EnableSetting()
    {
        Setting_B.SetActive(true);
    }
    public void EnableBack()
    {
        Back_B.SetActive(true);
    }

}

