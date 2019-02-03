using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonManager : MonoBehaviour
{

    private int _clickCount;


    public void press()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _clickCount++;
            if (_clickCount > 1)
            {
                SceneManager.LoadScene("Room");


            }
        }

    }


}
