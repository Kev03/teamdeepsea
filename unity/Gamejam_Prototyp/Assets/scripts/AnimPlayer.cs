using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thikk.Games { 
public class AnimPlayer : MonoBehaviour
{
    [SerializeField]
    private Animation animationComponent;

    public void PlayAnimation()
    {
        animationComponent.Play();
    }

    public void PlayAnimation(AnimationClip animationClip)
    {
        animationComponent.clip = animationClip;
        animationComponent.Play();
    }


}
}