using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
        void Update()
        {
            var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var position = transform.position;
            target.z = position.z;
    
            position = Vector3.MoveTowards(position, target, speed * Time.deltaTime / transform.localScale.x);
            transform.position = position;
        }
}
