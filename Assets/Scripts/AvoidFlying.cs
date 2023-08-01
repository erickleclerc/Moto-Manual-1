
using UnityEngine;

public class AvoidFlying : MonoBehaviour
{
 /// <summary>
 /// Prevents the glitch from happening when the player is flying of sinks into the ground
 /// </summary>
    
    void Update()
    {
        if (transform.position.y > 0.6f || transform.position.y < 0.3f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }
}
