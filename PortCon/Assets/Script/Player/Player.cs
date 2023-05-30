using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 8.0f;
    private float jumpHeight = 5.0f;
    private float gravityValue = -9.81f;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController controller;



    [SerializeField] private Animator anim;
    [SerializeField] private Transform cam;
    private AnimatorStateInfo currentBaseState;

    public float animSpeed = 1.5f;              
    public float lookSmoother = 3.0f;
    public bool useCurves = true;
    public float rotateSpeed = 4.0f;
    float h;
    float v;
    float m_y;
    private Vector3 rotate;

    void OnEnable()
    {
        anim.SetBool("IsDeath", false);
    }
    void Update()
    {
        rotate = new Vector3(0, m_y * rotateSpeed, 0f);
        transform.eulerAngles = transform.eulerAngles - rotate;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        m_y = Input.GetAxis("Mouse X");
        anim.speed = animSpeed;
        

        
        MovePlayer();
        MovePlayerCamera();
        if(GetComponent<Damage>().getHealth()    <= 0)
        {
            anim.SetBool("IsDeath",true);
            StartCoroutine(ActivationRoutine());
        }
    }
    public void ChangePlayerstate(string state , bool b_state)
    {
        anim.SetBool(state, b_state);
    }



    private void MovePlayer()
    {
        Vector3 MoveVector = new Vector3(h,0f,v).normalized;
        MoveVector = this.transform.TransformDirection(MoveVector);

        controller.Move(MoveVector * playerSpeed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);

    }

    private void MovePlayerCamera()
    {

    }

    private IEnumerator ActivationRoutine()
    {


        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
    }



}
