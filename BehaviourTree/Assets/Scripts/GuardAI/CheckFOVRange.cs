using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class CheckFOVRange : Node
{
    private int _layerMask;
    private Transform _transform;
    private Animator _animator;
    int lm;
    public CheckFOVRange(Transform transform, int LayerMask)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _layerMask = 1 << LayerMask;
        //lm = LayerMask;
    }
    public override NodeState Evaluate()
    {

        //Debug.Log($"{_transform.position},{GuardBT.fovRange},{_layerMask}");
        object t = GetData("target");
        if (t == null)
        {
            
            Collider[] colliders = Physics.OverlapSphere(_transform.position, GuardBT.fovRange, _layerMask);
            //Debug.Log($"LM : {lm}");
            if (colliders.Length > 0)
            {
                //Debug.Log($"{_transform.position},{GuardBT.fovRange},{_layerMask}");
                parent.parent.SetData("target", colliders[0].transform);
                _animator.SetBool("Walking", true);
                state = NodeState.SUCCESS;
                return state;
            }
            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
