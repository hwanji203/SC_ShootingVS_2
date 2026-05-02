using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "[agent] attack [target]", category: "Action", id: "3e878ad1fe45623a43f016a8ea1cc915")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private Enemy agent;

    protected override Status OnStart()
    {
        agent = Agent.Value.GetComponent<Enemy>();
        agent.RenderCompo.FaceDirection(Target.Value.transform.position);
        agent.GetComponent<EnemyAttack>().TryShooting(Target.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

