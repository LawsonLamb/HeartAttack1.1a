using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Foe))]
public class Spliter : MonoBehaviour
{


    /*Splits into smaller enemies. There are 3 different spliters.
	 *Spliter 1: Cluster (ID: 5), splits into 3 Colestrol (ID: 1).
	 *Spliter 2: Pack (ID: 6), splits into 4 Cigarettes (ID: 3).
	 *Spliter 3: Chilly Burger (ID: 7), splits into 1 Heart Burn (ID: 0) &  1 Grease Jar (ID: 2).*/

    // Use this for initialization
    public GameObject test;
    public GameObject[] Children;
    public int spiltTotal = 3;
    void Start()
    {
        Children = new GameObject[spiltTotal];
    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("Spilt")]
    void Split()
    {



        GameObject go = Instantiate(test, transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = this.transform;
        // StartCoroutine(WaitAndMove(1.0f, go.transform, new Vector3(0.0f, 1.5f, 0.0f)));
        Vector3 pos = new Vector3(transform.position.x - 0.0f, transform.position.y + 1.5f, 0.0f);
        iTween.MoveTo(go, pos,3.0f);
        // go.transform.localPosition = Vector3.Lerp(transform.position, new Vector3(0.0f, 1.5f, 0.0f), Time.time * 1.0f);

        go = Instantiate(test, transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = this.transform;
        pos = new Vector3(transform.position.x - 0.0f, transform.position.y - 1.5f, 0.0f);
        iTween.MoveTo(go, pos, 3.0f);




        go = Instantiate(test, transform.position, Quaternion.identity) as GameObject;
          go.transform.parent = this.transform;
        pos = new Vector3(transform.position.x - 2.0f, transform.position.y+0.0f, 0.0f);
      
        iTween.MoveTo(go, pos, 3.0f);

      
     
        
    }

    void OnDestory()
    {


    }
    IEnumerator WaitAndMove(float delayTime, Transform child, Vector3 Target)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            child.localPosition = Vector3.Lerp(this.transform.position, Target, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame

        }
    }
}
