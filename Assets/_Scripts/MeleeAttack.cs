using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MeleeAttack : Action
{
    public SharedGameObject Target;
    // Use this for initialization
    private Vector3 direction;
    public override TaskStatus OnUpdate() {

      direction=  Target.Value.transform.position - this.transform.position;
        GetComponent<Foe>().MeleeAttack(direction);
        return TaskStatus.Success;
    }
}
