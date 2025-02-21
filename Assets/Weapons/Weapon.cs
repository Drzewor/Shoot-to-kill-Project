using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float range = 100;
    [SerializeField] int weaponDamage = 1;
    [SerializeField] float weaponDelay = 0.5f;
    [SerializeField] ParticleSystem shootBlast;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] Light gunlight;
    bool canShoot = true;

    private void OnEnable() 
    {
        canShoot = true;
        audioSource = GetComponent<AudioSource>();
        gunlight = GetComponentInChildren<Light>();
        gunlight.enabled = false;
    }

    void Update()
    {
        DisplayAmmo();
        if(Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
           StartCoroutine(Shoot());
        }
        
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmoAmount(ammoType) > 0)
        {
            StartCoroutine(DisplayGunLight());
            audioSource.PlayOneShot(audioSource.clip);
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayShootBlast();
            ProccesRayCast();
        }
        yield return new WaitForSeconds(weaponDelay);
        canShoot = true;

    }

    

    private void PlayShootBlast()
    {
        shootBlast.Play();
    }

    private void ProccesRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealt target = hit.transform.GetComponent<EnemyHealt>();
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }
        else return;
    }

    private void CreateHitImpact(RaycastHit hit)
    {
       GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 1f);
    }
    
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmoAmount(ammoType);
        ammoText.text = $"Ammo: {currentAmmo}";
    }

    IEnumerator DisplayGunLight()
    {
        gunlight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        gunlight.enabled = false;
    }
}
