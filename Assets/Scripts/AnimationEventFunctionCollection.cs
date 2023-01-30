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
        Rigidbody rbP1 = GetComponentInParent <Rigidbody>();
        CharacterMovementP1 CMP1 = rbP1.gameObject.GetComponent<CharacterMovementP1>();
        GroundedAndJumpSystem GAJS = GetComponentInParent<GroundedAndJumpSystem>();
        GAJS.StartCooldown();
        GAJS.NotMovableInJump = false;
        rbP1.AddForce(0, CMP1.Jumpforce, 0);
    }
    public void SetJumpedBool()
    {
        GroundedAndJumpSystem GAJS = GetComponentInParent<GroundedAndJumpSystem>();
        GAJS.OnAir = true;
    }
    public void Landed()
    {
        GroundedAndJumpSystem GAJS = GetComponentInParent<GroundedAndJumpSystem>();
        GAJS.NotMovableInJump = false;
    }
}
