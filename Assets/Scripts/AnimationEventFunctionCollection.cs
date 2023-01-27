using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventFunctionCollection : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public void AddJumpforce()
    {
        Rigidbody rb = GetComponentInParent <Rigidbody>();
        CharacterMovementP1 CMP1 = rb.gameObject.GetComponent<CharacterMovementP1>();
        JumpManager JM = GetComponentInParent<JumpManager>();
        JM.StartCooldown();
        rb.AddForce(0, CMP1.Jumpforce, 0);
    }
    public void SetJumpedBool()
    {
        JumpManager JM = GetComponentInParent<JumpManager>();
        JM.Jumped = true;
    }
}
