using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorGauge : MonoBehaviour
{
    /// <summary>
    /// totalGauge: Maximum Gauge amount
    /// gaugeLevel: Current Gauge amount
    /// </summary>
    public float totalGauge;
    public float gaugeLevel;

    /// <summary>
    /// Simple gauge to display how fast a player can move
    /// </summary>
    void Update()
    {
        totalGauge = GameManager.Instance.razorGauge;
        gaugeLevel = GameManager.Instance.razorLevel;
        transform.localScale = new Vector3(1, (gaugeLevel / totalGauge), 1);
    }
}
	

