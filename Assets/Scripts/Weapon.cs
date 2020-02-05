using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Button pressed!");
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out RaycastHit hit, range))
        {
            CreateHitImpact(hit);
            // TODO add hit effects
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 5f);
    }
}
