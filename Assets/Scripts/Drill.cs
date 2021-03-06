﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour {

    public float rotationSpeed = 99.0f;
    public bool reverse = false;
    PlayerController PC;


    public bool Readytodrill;
    public bool isdrilling;

    DrillEnergy DE;

    private void Start()
    {
        PC = FindObjectOfType<PlayerController>();
        isdrilling = false;
        Readytodrill = false;
        DE = GetComponent<DrillEnergy>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) {
                //transform.Rotate(Vector3.back * Time.deltaTime * this.rotationSpeed);
            transform.Rotate(new Vector3(0f, 0f, 10f) * Time.deltaTime * this.rotationSpeed);
            PC.movespeed = 0;
            isdrilling = true;
        }
        else
        {
            isdrilling = false;
            PC.movespeed = 5;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crystal")
        {
            Readytodrill = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Crystal")
        {
            Readytodrill = false;
        }
    }


    public void SetRotationSpeed(float speed)
    {
        this.rotationSpeed = speed;
    }

    public void SetReverse(bool reverse)
    {
        this.reverse = reverse;
    }
}
