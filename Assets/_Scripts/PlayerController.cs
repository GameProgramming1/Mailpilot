using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
    public float speed;
    public Boundary boundary;

    // PRIVATE INSTANCE VARIABLES
    private Vector2 _newPosition = new Vector2(0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this._CheckInput();
    }

    private void _CheckInput()
    {
        this._newPosition = gameObject.GetComponent<Transform>().position; // current position

        if (Input.GetAxis("Horizontal") > 0)
        {
            this._newPosition.x += this.speed; // add move value to current position
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            this._newPosition.x -= this.speed; // subtract move value to current position
        }

        this._BoundaryCheck();

        gameObject.GetComponent<Transform>().position = this._newPosition;
    }

    private void _BoundaryCheck()
    {
        if (this._newPosition.x < this.boundary.minX)
        {
            this._newPosition.x = this.boundary.maxX;
        }

        if (this._newPosition.x > this.boundary.minY)
        {
            this._newPosition.x = this.boundary.maxY;
        }
    }
}
