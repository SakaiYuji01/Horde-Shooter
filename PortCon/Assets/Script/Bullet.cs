using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 10f;
    Vector3 moveDir;
    Vector3 b_target;
    Vector3 directions;
    private GameObject parent;

    void OnEnable()
    {
        StartCoroutine(ActivationRoutine());
    }



    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("ObjectPool");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * m_Speed * Time.deltaTime;

    }


    public void getMousePosition(Vector3 target)
    {
         moveDir = (target - transform.position).normalized;
        b_target = target;
    }

    public void move()
    {
        Debug.Log("moving object");

    }

    private IEnumerator ActivationRoutine()
    {


        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(2);

        //Game object will turn off
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Robot")
        {
            AudioClip Robot_hurt = Resources.Load<AudioClip>("Audio/Robot_hurt");
            SoundManager.play_audio(other.GetComponent<AudioSource>(), Robot_hurt);
            other.GetComponent<Health>().HealthDamage();
            gameObject.SetActive(false);
        }

    }
}
