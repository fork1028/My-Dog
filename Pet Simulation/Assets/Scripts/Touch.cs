using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Touch : MonoBehaviour {


    //public GameObject happinessText;
    public Dog dog;


    public void touch(){
        dog.updateHappiness(2);
        dog.saveDog();
    }
}
