using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingle<T> : MonoBehaviour where T: BaseSingle<T>
{
    // Start is called before the first frame update
   
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("instance is null");
                instance = GameObject.Find("GameManager").GetComponent<T>() ;               
                //Debug.Log("instance is null");
            }
            return instance;
        }
        
    }

}
