using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Foe))]
public class Summoner : MonoBehaviour {

    /*Summons other enemies. For now the only enemy that can be summoned are: 
	 *Colestrol (ID: 1)
	 *Cluster (ID: 5)*/
    public GameObject test;
    public int xRange = 3;
    int oldXran;
    int oldYran;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}
    [ContextMenu("Summon")]
    void Summon()
    {
        int xRan = Random.Range(-xRange, xRange);
        int yRan = Random.Range(-xRange, xRange);

        if(xRan==oldXran && yRan == oldXran)
        {
            Summon();
        }
      else if (xRan == 0 && yRan == 0)
        {
            Summon();
        }

        else {
           

            print("X: " + xRan + "  Y: " + yRan);
            CreateGameObjects(xRan, yRan);
        }
        oldXran = xRan;
        oldYran = yRan;


    }

    void  CreateGameObjects(int x, int y)
    {
        float posX = transform.position.x + (float)x;
        float posY = transform.position.x + (float)y;

        print("POS: " + posX + " , " + posY);

        Vector3 pos = new Vector3(posX, posY, 0.0f);

        GameObject go = Instantiate(test, transform.position, Quaternion.identity) as GameObject;

        go.transform.parent = this.transform;
        go.transform.localPosition = pos;
    }
}
