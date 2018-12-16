using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp1 : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = GameObject.FindGameObjectWithTag("Warp2").transform.position;
    }
}
