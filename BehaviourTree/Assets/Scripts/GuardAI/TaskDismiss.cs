using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDismiss : Node
{
    private Animator _animator;
    private Transform _lastTarget;
    private FriendManager _friendManager;

    float cachedTime;
    public TaskDismiss(Transform transform)
    {
        _animator = transform.GetComponent<Animator>();
    }
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _friendManager = target.GetComponent<FriendManager>();
            _lastTarget = target;
            cachedTime = Time.time;
        }


        if (Time.time >= cachedTime + GuardBT.inspectTimer)
        {
            
            if (!_friendManager.dismissed)
            {
                ClearData("target");
                _animator.SetBool("Attacking", false);
                _animator.SetBool("Walking", true);
                _friendManager.dismissed = true;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}