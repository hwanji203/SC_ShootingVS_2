using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChaseState", story: "[agent] move to [target]", category: "Action", id: "c8e91515d3b2e7777ecf0f3c37c88a76")]
public partial class ChaseStateAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private Enemy agent;
    private GameObject target;

    protected override Status OnStart()
    {
        agent = Agent.Value.GetComponent<Enemy>();
        target = Target.Value;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector2 dir = target.transform.position - agent.transform.position;

        agent.RenderCompo.FaceDirection(target.transform.position);
        agent.MoveComp.SetMove(dir.normalized);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

