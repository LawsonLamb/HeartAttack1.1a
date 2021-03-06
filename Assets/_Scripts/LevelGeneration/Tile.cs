﻿using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
[System.Serializable]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Tile : MonoBehaviour {


   public SortingLayer Layer;
 

   private SpriteRenderer Rend;

   
	// Use this for initialization
	void Start () {
   
	
        Rend = GetComponent<SpriteRenderer>();
       

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("SetTile")]
    void SetTile()
    {
      


    }




    public bool Flip_X
    {

        get { return Rend.flipX; }


        set { Rend.flipX = value; }

    }

    public bool Flip_y
    {

		get { return Rend.flipY; }

		set { Rend.flipY = value; }
    }

    public Sprite Image
    {
		get { return Rend.sprite; }

        set
        {
			Rend.sprite = value;

        }

    }

    public string LayerName
    {

		get { return Rend.sortingLayerName; }

		set{ Rend.sortingLayerName = value; }
    }


    public bool isTrigger
    {

		get { return GetComponent<BoxCollider2D>().isTrigger; }

		set { GetComponent<BoxCollider2D>().isTrigger = value; }
    }




}
