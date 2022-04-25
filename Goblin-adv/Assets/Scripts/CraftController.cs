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
    public Transform Craft(Transform transform, Transform player)
    {
        craftedObject = Object.Instantiate(transform, player.position, Quaternion.identity);
        return craftedObject;
    }
}

