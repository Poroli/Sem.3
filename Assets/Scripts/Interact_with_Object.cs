using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_with_Object : MonoBehaviour
{
    public bool Test;
    public Control_Keys C_Keys;
    public List<Interact_Translate> I_Translates = new List<Interact_Translate>();

    private Vector3 Targetposition;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable_P1")
        {
            I_Translates.Add(collision.GetComponent<Interact_Translate>());
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable_P1")
        {
            Interact_Translate I_Translate = collision.GetComponent<Interact_Translate>();
            if (I_Translates.Contains(I_Translate) == true)
            {
                I_Translates.Remove(I_Translate);
            }
        }
    }

    private void Update()
    {
        if (I_Translates.Count > 0 && Input.GetKey(C_Keys.Interact_Key_P1) == true)
        {
            Test = true;
            foreach (Interact_Translate I_Translate in I_Translates)
            {
                I_Translate.Interact = true;
            }
        }
    }
}
