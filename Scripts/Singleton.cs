using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements singleton for game elements that should only have one instance (such as game manager)
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Container for the new singleton instance
    /// </summary>
    private static T _instance;

    /// <summary>
    /// checks if there is an instance already and returns it, if there isn't, creates one and returns it.
    /// </summary>
    public static T Instance
    {
        get
        {
            // Check if the instance is null.
            if (_instance == null)
            {
                // First try to find the object already in the scene.
                _instance = GameObject.FindObjectOfType<T>();

                if (_instance == null)
                {
                    // Couldn't find the singleton in the scene, so make it.
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    /// <summary>
    /// prevents more than one instance
    /// </summary>
    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
