using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_with_Object_P1 : MonoBehaviour
{
    public Control_Keys C_Keys;
    public GameObject Interact_Object;
    public List<Interact_Translate> I_Translates = new List<Interact_Translate>();



    private void OnTriggerEnter(SphereCollider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            I_Translates.Add(collision.GetComponent<Interact_Translate>());
        }
    }
    private void OnTriggerExit(SphereCollider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Interact_Translate I_Translate = collision.GetComponent<Interact_Translate>();
            if (I_Translates.Contains(I_Translate) == true)
            {
                I_Translates.Remove(I_Translate);
            }
        }
    }
}
