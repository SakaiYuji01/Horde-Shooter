using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private GameObject O_Bullet;
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform Bulletpoint;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();  
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {

            debugTransform.position = raycastHit.point;
        }
    }
    public void Shoot()
    {
        O_Bullet = PoolManager.SharedInstance.GetPooledObject("Bullet");
        if (O_Bullet != null)
        {
            O_Bullet.transform.position = Bulletpoint.transform.position;
            O_Bullet.transform.rotation = Bulletpoint.transform.rotation;
            O_Bullet.SetActive(true);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            O_Bullet.GetComponent<Bullet>().getMousePosition(raycastHit.point);
        }

        this.gameObject.GetComponent<Player>().ChangePlayerstate("Shooting", true);
        StartCoroutine(ActivationRoutine());


    }

    private IEnumerator ActivationRoutine()
    {


        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(1);

        this.gameObject.GetComponent<Player>().ChangePlayerstate("Shooting", false);
    }

}
