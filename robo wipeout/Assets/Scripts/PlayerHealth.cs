using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Collision!");
        Collider objectWeCollidedWith = hit.collider;

        Hazard hazard = objectWeCollidedWith.GetComponent<Hazard>();

        if (hazard != null)
        {
            Kill();
        }
    }

    public void Kill()
    {

        Destroy(gameObject);
    }
}
