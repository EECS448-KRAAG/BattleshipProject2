﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* 
*/
public class ShipPartController : MonoBehaviour
{
    Collider2D collide;
    public ShipController parent;
    public bool hit = false;
    public bool bound = false;
    public SpriteRenderer rend;
    public buttonController bondTarget;
    public int partTeam;
    
    public bool partReadyToPair = false;
    


    /**
    * Start is called before the first frame update.
    */
    void Start()
    {
        parent = transform.parent.GetComponent<ShipController>();
        rend = GetComponent<SpriteRenderer>();
    }

    /**
    * Update is called once per frame.
    */
    void Update()
    {
        if (parent.isMoving)
        {
            transform.parent.transform.position = Input.mousePosition;
            if (Input.GetKeyDown("a"))
            {
                parent.FaceLeft();
            }
            else if (Input.GetKeyDown("d"))
            {
                parent.FaceRight();
            }
            else if (Input.GetKeyDown("s"))
            {
                parent.FaceDown();
            }
            else if (Input.GetKeyDown("w"))
            {
                parent.FaceUp();
            }
        }
        else
        {

        }
    }

    /**
    * 
    */
    public void Hit()
    {
        hit = true;
    }

    /**
    * 
    */
    private void ResetPos()
    {

    }
    
    
    private void OnMouseDown()
    {
        if (!parent.shipReadyToPair)
        {
            Debug.Log("TouchedShip");
            parent.isMoving = true;
        }

    }

    private void OnMouseUp()
    {
        parent.isMoving = false;
        if (!bound)
        parent.AttemptBond();
    }
    

    /**
    * 
    */
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Open")
        {
            if (collision.GetComponent<buttonController>().buttonTeam == partTeam)
            {
                partReadyToPair = true;
                bondTarget = collision.GetComponent<buttonController>();
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Open")
        {
            if (collision.GetComponent<buttonController>().buttonTeam == partTeam)
            {
                partReadyToPair = true;
                bondTarget = collision.GetComponent<buttonController>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.tag == "Open")
        {
            //if (collision.GetComponent<buttonController>().buttonTeam == partTeam)
            {
                partReadyToPair = false;
                bondTarget = null;
            }
        }
    }
}