using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
   public void level1(){
    Debug.Log("Pressed");

    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
   }
}
