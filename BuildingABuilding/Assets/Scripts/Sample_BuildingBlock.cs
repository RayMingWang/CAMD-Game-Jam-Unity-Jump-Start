using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_BuildingBlock : MonoBehaviour {

    public bool released = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.layer != 8 && released )
        {
            if (collision.gameObject.layer == 8)
                gameObject.layer = 8; 
        }
        
    }
}
