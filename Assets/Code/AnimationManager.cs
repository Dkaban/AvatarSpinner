using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

enum CharacterState
{
    Idle = 0,
    Walk = 1,
    Wave = 2,
    Run = 3,
    PickUp = 4
}

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button idleAnimateButton;
    [SerializeField] private Button walkAnimateButton;
    [SerializeField] private Button waveAnimateButton;
    [SerializeField] private Button runAnimateButton;
    [SerializeField] private Button pickUpAnimateButton;

    private readonly string _animationState = "State";

    private void Awake()
    {
        idleAnimateButton.onClick.AddListener(delegate { SetState(CharacterState.Idle); });
        walkAnimateButton.onClick.AddListener(delegate { SetState(CharacterState.Walk); });
        waveAnimateButton.onClick.AddListener(delegate { SetState(CharacterState.Wave); });
        runAnimateButton.onClick.AddListener(delegate { SetState(CharacterState.Run); });
        pickUpAnimateButton.onClick.AddListener(delegate { SetState(CharacterState.PickUp); });
        
        foreach(var animClip in animator.runtimeAnimatorController.animationClips)
        {
            if (animClip.name != "walk" && animClip.name != "run")
            {
                animClip.AddEvent(new AnimationEvent()
                {
                    time = animClip.length,
                    functionName = "OnAnimationComplete"
                });
            }
        }
    }

    private void SetState(CharacterState state)
    {
        animator.SetInteger(_animationState, (int)state);
    }

    private void OnAnimationComplete()
    {
        animator.SetInteger(_animationState, 0);
    }

    private void RemoveListeners()
    {
        idleAnimateButton.onClick.RemoveAllListeners();
        walkAnimateButton.onClick.RemoveAllListeners();
        waveAnimateButton.onClick.RemoveAllListeners();
        runAnimateButton.onClick.RemoveAllListeners();
        pickUpAnimateButton.onClick.RemoveAllListeners();
    }
}
