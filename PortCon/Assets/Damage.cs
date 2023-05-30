using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float Max_Health = 3;
    [SerializeField] private float Health = 3;



    void OnEnable()
    {
        Health = Max_Health;
    }
    public float getHealth()
    {
        return Health;
    }

    public void HealthDamage()
    {
        if (Health > 0)
        {
            Health -= 1;
        }
        else
        {

            gameObject.SetActive(false);
            
        }
          

    }








}
