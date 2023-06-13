using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private GameObject O_Bullet;
    [SerializeField]  Transform debugTransform;
    [SerializeField] private Transform Bulletpoint;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
   int bulletcount = 8;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        bulletcount = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.R))
        {
            AudioClip gun_reload = Resources.Load<AudioClip>("Audio/gun_reload");
            SoundManager.play_audio(this.GetComponent<AudioSource>(), gun_reload);
            bulletcount = 8;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {

            debugTransform.position = raycastHit.point;
        }

        if (this.GetComponent<Health>().current_hp <= 0)
        {
           debugTransform.gameObject.SetActive(false);
        }
    }
    public void Shoot()
    {


        if(bulletcount > 0)
        {
            AudioClip gun_shoot = Resources.Load<AudioClip>("Audio/gun_shoot");
            SoundManager.play_audio(this.GetComponent<AudioSource>(), gun_shoot);

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
            bulletcount = bulletcount - 1;
        }
        else
        {
            AudioClip gun_nobullet = Resources.Load<AudioClip>("Audio/gun_nobullet");
            SoundManager.play_audio(this.GetComponent<AudioSource>(), gun_nobullet);

        }





    }

    private IEnumerator ActivationRoutine()
    {


        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(1);

        this.gameObject.GetComponent<Player>().ChangePlayerstate("Shooting", false);
    }

}
