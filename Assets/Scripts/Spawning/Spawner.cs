using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject original;

    // This method runs automatically when turning on either the GameObject or the Component (MonoBehaviour)

    private void OnEnable()
    {
        Debug.Log(message: $"{name}: I was <color=green> enabled! </color>");
    }

    private void OnDisable()
    {
        Debug.Log(message: $"{name}: I was <color=red> disabled! </color>");
    }

    [ContextMenu(itemName:"Spawn")]
    private void Spawn()
    {
        //We need to spawn an object in the scene
        GameObject newInstance = Instantiate(original);
        newInstance.transform.position = Vector3.zero;
    }

    [ContextMenu(itemName:"Spawn Tree Wall")]
    private void SpawnTreeWall()
    {
        for(int i = -5; i < 5; i++)
        {
            //We need to spawn an object in the scene
            GameObject newInstance = Instantiate(original);
            newInstance.transform.position = new Vector3(i, 0, 0);
        }
    }
}
