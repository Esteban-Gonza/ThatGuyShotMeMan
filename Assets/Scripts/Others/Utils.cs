using System.Collections;
using UnityEngine;

public static class Utils
{
    public static IEnumerator PlayAnimationAndSetState(GameObject parent, Animator animator, string clipName, bool endState = true)
    {
        animator.Play(clipName);
        float animationLenght = animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSecondsRealtime(animationLenght);

        parent.SetActive(endState);
    }
}
