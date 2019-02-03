using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControlller : MonoBehaviour {


    public void press(){
        SceneManager.LoadScene("Room");
    }


}
