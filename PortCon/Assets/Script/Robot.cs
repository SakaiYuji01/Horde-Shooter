using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    GameObject Player;
    bool isAlive;
    [SerializeField]private Animator anim,a_player;
    private float speed = 10f;
    private Vector3 distancetocheck = new Vector3 (2f,0,2f);

    [SerializeField] private float Max_Health = 3;
    [SerializeField] public float Health = 3;

    // Start is called before the first frame update

    void OnEnable()
    {
        isAlive = true;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        moverobot();
        Debug.Log(Health);

        if (Health <= 0)
            gameObject.SetActive(false);
    }

    private void robot_anim()
    {
        transform.LookAt(Player.transform);
        if (Vector3.Distance(this.transform.position, Player.transform.position) > 15f)
        {
            anim.SetBool("Roll_Anim", true);
            speed = 10f;
        }
        else
        if (Vector3.Distance(this.transform.position, Player.transform.position) < 15f && Vector3.Distance(this.transform.position, Player.transform.position) >= 4f)
        {
            anim.SetBool("Roll_Anim", false);
            anim.SetBool("Walk_Anim", true);
            speed = 3f;
        }
        else
        if (Vector3.Distance(this.transform.position, Player.transform.position) <= 3f )
        {
            anim.SetBool("Walk_Anim", false);
            anim.SetBool("Open_Anim", false);
            anim.SetBool("Attack", true);
        }
    }
 

    private void moverobot()
    {
        robot_anim();
        if (Vector3.Distance(this.transform.position, Player.transform.position) > 2f)
        transform.Translate(Vector3.forward * Time.deltaTime * speed);


    }

    void OnDisable()
    {
        isAlive = false;
    }

    public void HealthDamage()
    {
        if (Health > 0)
        {
            Health -= 1;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Robot collided");    
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Health>().HealthDamage();

            other.GetComponent<Animator>().SetBool("IsHurt", true);
            a_player = other.GetComponent<Animator>();
            StartCoroutine(ChangeAnimation(a_player.GetComponent<Animator>()));
            
        }

    }

    private IEnumerator ChangeAnimation(Animator to_change)
    {

        

        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(0.5f);
        to_change.SetBool("IsHurt", false);
    }



}
