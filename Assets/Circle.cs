using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the ball
/// </summary>
public class Circle : MonoBehaviour
{
    [SerializeField]
    private float _radius;
    public float Radius {
        get { return _radius; }
    }

    private Vector3 direction = new Vector3(-.5f, -0.5f,0);
    private float speed = 1.75f;

    //private void OnDrawGizmos() {
    //    Gizmos.color = new Color(1, 1, 1, 0.5f);
    //    Gizmos.DrawSphere(transform.position, _radius);
    //}

    public void SetVelocity(Vector3 newDirection, float newSpeed) {
        direction = newDirection;
        speed = newSpeed;
    }

    //the normal is going to just be the direction of the ball to here
    public void ReflectVelocity(Vector3 normal) {
        //check if the direction of movement is towards the normal we provide, if so reflect it
        if (Vector3.Dot(direction.normalized, normal) <= 0) {
            direction = (direction + (2 * normal * (Vector3.Dot(-direction, normal)))).normalized;
        }
    }

    public void Move() {
        transform.position += direction * speed * Time.deltaTime;

    }
}
