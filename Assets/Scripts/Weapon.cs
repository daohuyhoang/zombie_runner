using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    } 

    void ProcessRaycast()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range));
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            CreateHitImpact(hit);
            if (target == null) return;
            target.TakeDamage(damage);
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact =Instantiate(hitEffect, hit.transform.position, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}