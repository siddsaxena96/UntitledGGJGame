﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Rigidbody2D crosshairRb;
    public Transform shootingPoint;
    private float nextFire;
    private float fireRate=0.35f;
    public GameObject shot;
    public CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }	
        
    // Update is called once per frame
    void Update()
    {
        // Crosshair movement controls
        crosshairRb.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        crosshairRb.position=new Vector3(Mathf.Clamp(crosshairRb.position.x,-3,7),crosshairRb.position.y,0);

        if(Time.time >= nextFire) {
            if(Input.GetMouseButtonDown(0)) {
                Fire();
                Debug.Log ("Shoot");
            }
        }
        
    }

    // Fire a bullet
    void Fire() {
        Instantiate(shot, shootingPoint.position,crosshairRb.transform.rotation);        
        nextFire = Time.time + fireRate;
    }

    void OnCollisionEnter2D(Collision2D col)
    {        
        if(col.gameObject.tag=="Enemy")
            cameraShake.Shake();
    }
    
}
