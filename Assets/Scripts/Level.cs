using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //debugging purpose
    SceneLoader sceneLoader;
    
    public void updateBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
