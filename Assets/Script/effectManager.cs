using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class effectManager : MonoBehaviour
{
    public AudioSource audio;
    public Engklek engklek;
    public int point = 0, point2 = 0;
    public int point_temp = -1, point2_temp = -1;
    public int point_disable = 0, point_disable_temp =0;

    public GameObject prefab_efek_point;
    public GameObject prefab_efek_point2;
    public GameObject prefab_efek_point_disable;
    public GameObject area_safe,area_0, area_1, area_2, area_3, area_4, area_5, area_6, area_7;

    
    private void Update()
    {
        point = engklek.point;
        point_disable = engklek.point_disable;
        point2 = engklek.point2;
        if (point >= -1)
        {
            if (point != point_temp)
            {

                if (point == -1)
                {
                    prefab_efek_point.transform.position = area_safe.transform.position;
                    point_temp = point;
                }
                if (point == 1)
                {
                    prefab_efek_point.transform.position = area_1.transform.position;
                    point_temp = point;
                }
                if (point == 2)
                {
                    prefab_efek_point.transform.position = area_2.transform.position;
                    point_temp = point;
                }
                if (point == 3)
                {
                    prefab_efek_point.transform.position = area_3.transform.position;
                    point_temp = point;
                }
                if (point == 4)
                {
                    prefab_efek_point.transform.position = area_4.transform.position;
                    point_temp = point;
                }
                if (point == 5)
                {
                    prefab_efek_point.transform.position = area_5.transform.position;
                    point_temp = point;
                }
                if (point == 6)
                {
                    prefab_efek_point.transform.position = area_6.transform.position;
                    point_temp = point;
                }
                if (point == 7)
                {
                    prefab_efek_point.transform.position = area_7.transform.position;
                    point_temp = point;
                }

            }

        }
        if (point2 >= -1 )
        {
            if (point2 != point2_temp)
            {
                
                if (point2 == -1)
                {
                    prefab_efek_point2.transform.position = area_safe.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 0)
                {
                    prefab_efek_point2.transform.position = area_0.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 1)
                {
                    prefab_efek_point2.transform.position = area_1.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 2)
                {
                    prefab_efek_point2.transform.position = area_2.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 3)
                {
                    prefab_efek_point2.transform.position = area_3.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 4)
                {
                    prefab_efek_point2.transform.position = area_4.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 5)
                {
                    prefab_efek_point2.transform.position = area_5.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 6)
                {
                    prefab_efek_point2.transform.position = area_6.transform.position;
                    point2_temp = point2;
                }
                if (point2 == 7)
                {
                    prefab_efek_point2.transform.position = area_7.transform.position;
                    point2_temp = point2;
                }

            }
            
        }
        if (point_disable >= -1)
        {
            if (point_disable != point_disable_temp)
            {
                audio.Play();
                if (point_disable == 0)
                {
                    prefab_efek_point_disable.transform.position = area_0.transform.position;
                    point_disable_temp = point_disable;
                }
                if (point_disable == 1)
                {
                    prefab_efek_point_disable.transform.position = area_1.transform.position;
                    point_disable_temp = point_disable;
                }
                if (point_disable == 2)
                {
                    prefab_efek_point_disable.transform.position = area_2.transform.position;
                    point_disable_temp = point_disable;
                }
                if (point_disable == 3)
                {
                    prefab_efek_point_disable.transform.position = area_3.transform.position;
                    point_disable_temp = point_disable;
                }
                if (point_disable == 4)
                {
                    prefab_efek_point_disable.transform.position = area_4.transform.position;
                    point_disable_temp = point_disable;
                }
                if (point_disable == 5)
                {
                    prefab_efek_point_disable.transform.position = area_5.transform.position;
                    point_disable_temp = point_disable;
                }
                if (point_disable == 6)
                {
                    prefab_efek_point_disable.transform.position = area_6.transform.position;
                    point_disable_temp = point_disable;
                }
                if (point_disable == 7)
                {
                    prefab_efek_point_disable.transform.position = area_7.transform.position;
                    point_disable_temp = point_disable;
                }

            }
        }

    }

}
