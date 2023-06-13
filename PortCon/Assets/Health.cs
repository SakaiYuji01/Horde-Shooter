using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float Max_Health = 3;
    [SerializeField] public float current_hp = 3;

    [SerializeField] private Healthbar _healthbar;

    void OnEnable()
    {
        current_hp = 3;
        _healthbar.UpdateHealthBar(current_hp);
        _healthbar.setHealthBar(Max_Health, current_hp);
        current_hp = Max_Health;
    }
    // Start is called before the first frame update
    void Start()
    {
        current_hp = Max_Health;
        _healthbar.setHealthBar(Max_Health, current_hp);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hp <= 0)
        {
            if (gameObject.tag != "Player")
                gameObject.SetActive(false);

            AudioClip player_death = Resources.Load<AudioClip>("Audio/player_death");
            SoundManager.play_audio_onshot(GetComponent<AudioSource>(), player_death);
           
        }
           
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
            _healthbar.UpdateHealthBar(current_hp);
        }


    }




}
