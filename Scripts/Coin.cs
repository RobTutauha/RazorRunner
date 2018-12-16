using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private float rotateSpeed = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pickup();
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Spin());
	}

    private void Pickup()
    {
        GameManager.Instance.NumCoins++;
    }

    private IEnumerator Spin()
    {
        while (true)
        {
            transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);
            yield return 0;

        }
    }

}
