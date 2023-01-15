using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public string gameOverScene;
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

        SceneManager.LoadScene(gameOverScene);
    }
}
