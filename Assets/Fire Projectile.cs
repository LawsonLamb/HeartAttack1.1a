using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FireProjectile : Action
{

    public SharedGameObject Projectile;
    public SharedGameObject Target;
    public SharedFloat timeBetweenSpell;
    private Vector3 direction;

    public override TaskStatus OnUpdate()
    {

        direction = Target.Value.transform.position - this.transform.position;
        GetComponent<Foe>().RangeAttack(Projectile.Value, direction);
        return TaskStatus.Success;
    }
}
