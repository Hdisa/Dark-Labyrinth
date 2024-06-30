using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    // Start is called before the first frame update
    public void Hit()
    {
        health-= Time.deltaTime;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

}
