using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PersonAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private AnimationReferenceAsset idle, walking;
    [SerializeField] private string currentState;
    [SerializeField] private string currenAnim;
    
    private void Awake()
    {
        currentState = "Idle";
        SetCharacterState(currentState);
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if(animation.name.Equals(currenAnim))
            return;
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
        currenAnim = animation.name;
    }

    public void SetCharacterState(string state)
    {
        if(state.Equals("Idle"))
            SetAnimation(idle, true, 1f);
        else if(state.Equals("Walking"))
            SetAnimation(walking, true, 1f);
    }
}
