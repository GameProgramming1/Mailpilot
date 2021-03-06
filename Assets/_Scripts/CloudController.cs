﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed 
{
    public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Drift
{
    public float minDrift, maxDrift;
}

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minY, maxY;
}

public class CloudController : MonoBehaviour {
    //public instance variable
    public Speed speed;
    public Drift drift;
    public Boundary boundary;

    //private instance variable
    private float _Currentspeed;
    private float _Currentdrift;

    // Use this for initialization
    void Start()
    {
        this._Reset();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = new Vector2(0.0f, 0.0f);
        currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.x += this._Currentdrift;
        currentPosition.y -= this._Currentspeed;
        //movve the gameobject to th ecurrent position
        gameObject.GetComponent<Transform>().position = currentPosition;

        //bottom boundray check oceans meets camra view point
        if (currentPosition.y <= boundary.minY)
        {
            this._Reset();
        }

    }
    //resets our game object
    private void _Reset()
    {
        this._Currentdrift = Random.Range(drift.minDrift, drift.maxDrift);
        this._Currentspeed = Random.Range(speed.minSpeed,speed.maxSpeed);
        Vector2 resetPosition = new Vector2(Random.Range(boundary.minX, boundary.maxX), boundary.maxY);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }
}
