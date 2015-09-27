﻿using UnityEngine;
using System.Collections;

public class IslandController : MonoBehaviour {

    //public instance variable
    public float speed;

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
        currentPosition.y -= speed;
        //movve the gameobject to th ecurrent position
        gameObject.GetComponent<Transform>().position = currentPosition;

        //bottom boundray check oceans meets camra view point
        if (currentPosition.y <= -270)
        {
            this._Reset();
        }

    }
    //resets our game object
    private void _Reset()
    {
        Vector2 resetPosition = new Vector2(Random.Range(-290f, 290f), 270f);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }
}
