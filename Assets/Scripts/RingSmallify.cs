using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSmallify : MonoBehaviour {

    void Update()
    {
        if (Global.Playable)
        {
            // in 120 seconds to 0.5
            transform.localScale = new Vector3(transform.localScale.x - (Time.deltaTime / 600), transform.localScale.x - (Time.deltaTime / 600));
        }
    }
}
