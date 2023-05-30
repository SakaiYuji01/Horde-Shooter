using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class followmouse : MonoBehaviour
{
    Vector3 objectpos;
    public float speed = 1f;


    void Start()
    {

    }

    void Update()
    {
        objectpos = Input.mousePosition;
        objectpos.z = speed;
        transform.position = Camera.main.ScreenToWorldPoint(objectpos);
        Debug.Log(transform.position);

    }
}
