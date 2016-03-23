using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
[System.Serializable]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Tile : MonoBehaviour {


   public SortingLayer Layer;
 
    TileSet set;
   private SpriteRenderer renderer;
    private BoxCollider2D collider;
	// Use this for initialization
	void Start () {
        set = TileSet.GetTileSet();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

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

        get { return renderer.flipX; }


        set { renderer.flipX = value; }

    }

    public bool Flip_y
    {

        get { return renderer.flipY; }

        set { renderer.flipY = value; }
    }

    public Sprite Image
    {
        get { return renderer.sprite; }

        set
        {
           renderer.sprite = value;

        }

    }

    public string LayerName
    {

        get { return renderer.sortingLayerName; }

            set{ renderer.sortingLayerName = value; }
    }


    public bool isTrigger
    {

        get { return collider.isTrigger; }

        set { collider.isTrigger = value; }
    }




}
