using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
public class Shooter : MonoBehaviour {
    public BehaviorTree behaviorTree;
    public float ChaseMagnitude;
    public float AttackMagnitude;
	/*This enemy shoots projectiles.*/

	// Use this for initialization
	void Start () {
        
      //  behaviorTree = GetComponent<BehaviorTree>();
       // var sharedFloat = (SharedFloat)behaviorTree.GetVariable("ChaseMagnitude");
       /// sharedFloat.Value = ChaseMagnitude;

       // sharedFloat = (SharedFloat)behaviorTree.GetVariable("AttackMagnitude");
   
      //  sharedFloat.Value = AttackMagnitude;
      //  var sharedGO = (SharedGameObject)behaviorTree.GetVariable("Player");
     //   sharedGO.Value = GetComponent<Foe>().player;

    

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
