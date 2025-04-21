using System.Collections.Generic;
using BehaviourTree;

public class GuardBT : BTree
{
    public UnityEngine.Transform[] waypoints;
    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;
    public static float friendRange = 2f;
    public static float stompRange = 0.1f;
    public static float inspectTimer = 3f;
    public static float inspectRange = 2f;
    public static float dismissRange = 3.5f;
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {

            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
            
            new Sequence(new List<Node>
            {
                new CheckFireInStompRange(transform),
                new TaskStomp(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckCrateInInspectRange(transform),
                new TaskInspect(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckFriendInDismissRange(transform),
                new TaskDismiss(transform),
            }),


            new Sequence(new List<Node>
            {
                new CheckFOVRange(transform, 6), // Enemy
                new TaskGoToTarget(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckFOVRange(transform, 7), // Fire
                new TaskGoToTarget(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckFOVRange(transform, 8), // Crate
                new TaskGoToTarget(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckFOVRange(transform, 3), // Friend
                new TaskGoToTarget(transform),
            }),

            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}