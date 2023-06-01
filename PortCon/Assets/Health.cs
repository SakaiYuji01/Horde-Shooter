using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float Max_Health = 3;
    [SerializeField] public float current_hp = 3;

    void OnEnable()
    {
        current_hp = Max_Health;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hp <= 0)
            gameObject.SetActive(false);
    }
    public float getHP()
    {
        return current_hp;
    }


    public void HealthDamage()
    {
        if (current_hp > 0)
        {
            current_hp -= 1;
        }


    }


}
