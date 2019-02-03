using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {


    public void buttomBehaviour(int i)
    {
        switch (i)
        {
            case (0):
            default:
                break;
            case (1):
                break;
            case (2):
                break;
            case (3):
                break;
            case (4):

                Application.Quit();
                break;
        }
    }
}
