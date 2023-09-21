using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player_Input;

public class WeaponSystem : MonoBehaviour
{
    #region Variables

    [Header("Gun Stats")]
    public bool automaticFire;
    public int damage, magazineSize, bulletsPerTap;
    public int bulletsLeft, bulletsShot;
    public float spread, range, reloadTime, timeBetweenShots, timeBetweenShooting;
    bool shooting, readyToShoot, reloading, mouseClicked;
    
    [Header("References")]
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsDamagable;
    public Input_Manager inputManager;

    [Header("Weapon Preferences")]
    public GameObject muzzleFlash, bulletHole;
    //public AudioSource audioSource;

    #endregion

    #region Basic Functions

    private void Start()
    {
        inputManager.onFootActions.Shoot.performed += ctx => mouseClicked = true;
        inputManager.onFootActions.Shoot.canceled += ctx => mouseClicked = false;

        inputManager.onFootActions.Reload.performed += ctx => WeaponReload();

        //bulletsLeft = 100;
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        if (automaticFire)
        {
            WeaponShoot(mouseClicked);
        }
        else
        {
            WeaponShoot(mouseClicked);
            mouseClicked = false;
        }
    }

    private void WeaponShoot(bool shoot)
    {
        shooting = shoot;

        if (shooting && readyToShoot && !reloading && bulletsLeft > 0)
        { 
            Debug.Log("Shooting");
            readyToShoot = false;

            Instantiate(muzzleFlash, attackPoint);

            Vector3 forward = fpsCam.transform.forward;

            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 direction = forward + new Vector3(x, y, 0);

            Ray ray = new Ray(fpsCam.transform.position, direction);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.yellow);

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsDamagable))
            {
                Debug.Log($"What We Hit: {rayHit.transform.name}");

                HealthSystem damageObject = rayHit.collider.GetComponent<HealthSystem>();

                if (damageObject)
                    damageObject.TakeDamage(5);
            }

            bulletsLeft--;
            //bulletsShot--;

            Invoke("ResetShot", timeBetweenShooting);

            /*if (bulletsShot > 0 && bulletsLeft < 0)
                Invoke("WeaponShoot", timeBetweenShots);*/
        }
        else
        {
            //Debug.Log("Stopped");
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void WeaponReload()
    {
        if (bulletsLeft < magazineSize && !reloading)
        {
            Debug.Log("Reloading");
            reloading = true;
            Invoke("ReloadFinish", reloadTime);
        }
    }

    private void ReloadFinish()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    #endregion
}
