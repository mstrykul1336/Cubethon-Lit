using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{

  void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            
        }
    }
}
