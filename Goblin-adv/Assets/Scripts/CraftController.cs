using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

public class CraftController
{
    private Transform craftedObject;
    private Ray _ray;
    public bool craftActive;

    public void Craft(Transform transform, Transform player)
    {
        if (craftActive == false)
        {
             craftedObject = Object.Instantiate(transform, player.position, Quaternion.identity);
             
             craftActive = true;
        }
        else
        {
            Debug.Log("скрафтился");
            craftedObject = null;
            craftActive = false;
        }
    }

    public void MoveCraftedObject()
    {
        Debug.Log("кидаю луч");
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(_ray);
            Debug.DrawRay(_ray.origin,_ray.direction);
            if (Physics.Raycast(_ray, out var hit))
            {
                craftedObject.position = hit.point;
                Debug.Log("луч попал");
            }
        
    }
    
    
}

