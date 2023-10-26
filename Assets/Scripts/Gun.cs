using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gun : MonoBehaviour
{
    //Gun Specs
    public int damage, magSize, bulletsPerTap;
    public float fireRate, spread, range, reloadTime, timeBetweenShots;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    //Game Refrecnces
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit RayHit;
    public Enemy enemy; // Drag and drop the enemy GameObject with the Enemy script attached in the Inspector.

    //public LayerMask WhatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHole;
    public TextMeshProUGUI text;

    private void Start()
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    private void Update()
    {
        myInput();
        //text
        text.SetText(bulletsLeft + " / " + magSize);
    }

    private void myInput()
    {
        if(allowButtonHold)shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        

        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out RayHit, range))//, WhatIsEnemy))
        {
            Debug.Log(RayHit.collider.name);
            if (RayHit.collider.CompareTag("Enemy"))
            {
                if (enemy != null)
                {
                    // Call the TakeDamage function when the gun fires (e.g., when a shot hits the enemy).
                    enemy.TakeDamage(damage);
                }
            }
        }
        


        //Graphics
        Instantiate(bulletHole, RayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position,Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShots);
        if(bulletsShot>0 && bulletsLeft>0)
        Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
    

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magSize;
        reloading = false;
    }
}