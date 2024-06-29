using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;
public class OnDeadReloadScene : MonoBehaviour
{
    public static Action<string> onDead;
    // Start is called before the first frame update
    private void OnEnable()
    {
        onDead += Die;
    }
    private void OnDisable()
    {
        onDead -= Die;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Die(string value)
    {
        Debug.Log("”мер от " + value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
