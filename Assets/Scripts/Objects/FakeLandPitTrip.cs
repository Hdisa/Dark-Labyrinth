using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLandPitTrip : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
