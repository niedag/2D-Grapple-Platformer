using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void Quit()
    {
       if(UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.Exit(0);
        } else
        {
            Debug.Log("Quitting!");
            Application.Quit();
        }
    }
}
