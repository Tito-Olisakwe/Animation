using UnityEngine;

public class DanceController : MonoBehaviour
{
    public Animator animator;
    private bool isDancing = false;
    private bool isHipHopDancing = false;
    private bool isBreakdancing = false;

    void Update()
    {
        // Press D to trigger regular Dancing
        if (Input.GetKeyDown(KeyCode.D))
        {
            ResetAllAnimations();
            isDancing = true;
            animator.SetBool("isDancing", true);
        }

        // Press H to trigger Hip Hop Dancing
        if (Input.GetKeyDown(KeyCode.H))
        {
            ResetAllAnimations();
            isHipHopDancing = true;
            animator.SetBool("isHipHopDancing", true);
        }

        // Press B to trigger Breakdancing
        if (Input.GetKeyDown(KeyCode.B))
        {
            ResetAllAnimations();
            isBreakdancing = true;
            animator.SetBool("isBreakdancing", true);
            Debug.Log("Started Breakdancing");
        }

        // Press I to return to Idle 
        if (Input.GetKeyDown(KeyCode.I))
        {
            ResetAllAnimations();
        }

        // Return to Idle after any animation finishes
        if ((isDancing || isHipHopDancing || isBreakdancing) &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            ResetAllAnimations();
            animator.Play("Idle");
        }
    }

    // Resets all animation flags and parameters
    void ResetAllAnimations()
    {
        isDancing = false;
        isHipHopDancing = false;
        isBreakdancing = false;
        animator.SetBool("isDancing", false);
        animator.SetBool("isHipHopDancing", false);
        animator.SetBool("isBreakdancing", false);
    }
}
