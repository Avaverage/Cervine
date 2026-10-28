using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimatiion : MonoBehaviour
{
    [SerializeField] private InputActionReference gripActionRefrerence;
    [SerializeField] private InputActionReference triggerActionRefrerence;
    public Animator animator;
    private string gripActionName = "Grip";
    private string triggerActionName = "Pinch";
    private void Awake()
    {
        if(animator != null)
        {
            animator = GetComponent<Animator>();
        }
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }
    void Update()
    {
        if (animator == null)
        {
            return; // Exit if animator is not set
        }
        if(gripActionRefrerence != null && triggerActionRefrerence != null)
        {
            float gripValue =gripActionRefrerence.action.ReadValue<float>();
            float triggerValue = triggerActionRefrerence.action.ReadValue<float>();
            // Clamp values to ensure they are between 0 and 1
            if(animator != null)
            {
                animator.SetFloat(gripActionName, gripValue);
                animator.SetFloat(triggerActionName, triggerValue);
            }
        }
    }
}
//What the hell does all this mean? I didn't actually write this, and I didn't watch the video explaining it