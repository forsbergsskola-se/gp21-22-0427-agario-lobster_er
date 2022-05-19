using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float increase;
    [SerializeField]
    private float decrease;
    


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.localScale += new Vector3(increase, increase, increase);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.localScale += new Vector3(decrease, decrease, decrease);
        }

    }
}
