using UnityEngine;
public class ElementsManager : MonoBehaviour
{
    public bool[] ElementsActivated = new bool[5];
    //0=Standart_activated;
    //1=Fire_activated;
    //2=Water_activated;
    //3=Earth_activated;
    //4=Air_activated;
    public int tmpActiveElement;
    public int p2ActiveElement;
    public int p1ActiveElement;

    private int tmpActiveElements;

    public void ElementChangeRightTurn()
    { 
        for (int i = 0; i < ElementsActivated.Length; i++)
        {
            if (i < ElementsActivated.Length)
            {
                tmpActiveElements += 1;
            }
        }
        
        if(tmpActiveElement < tmpActiveElements)
        {
            tmpActiveElement += 1;
        }
        else
        {
            tmpActiveElement = 0;
        }
    }

    public void ElementChangeLeftTurn()
    {
        for (int i = 0; i < ElementsActivated.Length; i++)
        {
            if (i < ElementsActivated.Length)
            {
                tmpActiveElements += 1;
            }
        }

        if (tmpActiveElement > 0)
        {
            tmpActiveElement -= 1;
        }
        else
        {
            tmpActiveElement = tmpActiveElements;
        }
    }
}
