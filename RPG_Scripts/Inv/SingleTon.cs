using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Classic instance bois
 * p static I 
 * Getter 
 * Method to check if initialized
 * Make sure thier aint double of it in awake
 * and a destroy
 * */

public class SingleTon<T> : MonoBehaviour where T : SingleTon<T> 
{

    private static T instance;

	public static T Instance
    {
        get { return instance; }
    }

    public static bool Isinitialized
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("[SingleTon] Trying to instantiate a second instance of S class");
        }
        else
        {
            instance = (T) this;
        }
    }

    protected virtual void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }


    }


}
