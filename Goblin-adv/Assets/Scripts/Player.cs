using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform PlayerTransform;

    public int PlayerSpeed=0;

    public Vector3 Playermovement;
    void Start()
    {
        PlayerTransform = this.GetComponent<Transform>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Playermovement.z=+1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Playermovement.z=-1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Playermovement.x = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Playermovement.x=-1;
        }

        PlayerTransform.Translate(Playermovement.normalized*PlayerSpeed*Time.deltaTime);

        Playermovement = new Vector3(0, 0, 0);
    }
}
