using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedClick : MonoBehaviour {

    public Dog dog;

    public void feed()
    {

        dog.updateHunger(5);
        dog.saveDog();
    }
}
