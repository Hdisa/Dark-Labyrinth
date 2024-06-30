using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class OnDeadReloadScene : MonoBehaviour
{
    public static Action<string> onDead;
    
    private void OnEnable()
    {
        onDead += Die;
    }
    
    private void OnDisable()
    {
        onDead -= Die;
    }
    
    void Die(string value)
    {
        Debug.Log("АХАХАХАх" + value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
