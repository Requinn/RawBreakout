using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField]
    protected float width, height;

    private float halfWidth, halfHeight;

    void Start() {
        halfWidth = width / 2f;
        halfHeight = height / 2f;
    }

    //Draw stuff for debug
    //private void OnDrawGizmos() {
    //    Gizmos.color = new Color(1, 1, 1, 0.5f);
    //    Gizmos.DrawCube(transform.position, new Vector3(width, height, 0));
    //}

    /// <summary>
    /// Checks collision of this object with the other
    /// https://yal.cc/rectangle-circle-intersection-test/
    /// https://codeincomplete.com/posts/collision-detection-in-breakout/
    /// </summary>
    /// <param name="otherPosition"></param>
    /// <returns></returns>
    public virtual bool CheckCircleCollision(Circle ball, out Vector3 hitNormal) {
        //find the point closest to the circle within the square
        float nearestX = Mathf.Clamp(ball.transform.position.x, transform.position.x - halfWidth, transform.position.x + halfWidth);//Mathf.Max(transform.position.x - halfWidth, Mathf.Min(ball.transform.position.x, transform.position.x + halfWidth));
        float nearestY = Mathf.Max(transform.position.y - halfHeight, Mathf.Min(ball.transform.position.y, transform.position.y + halfHeight));

        //find the distance of that point to the circle
        float deltaX = ball.transform.position.x - nearestX;
        float deltaY = ball.transform.position.y - nearestY;

        //This normal is the surface normal of where we hit
        hitNormal = new Vector3(deltaX, deltaY, 0).normalized;

        //compare the distance to radius like any other circle check
        return (deltaX * deltaX) + (deltaY * deltaY) <= (ball.Radius * ball.Radius); // <= fixed the collision inaccuracy
    }

    public void Break() {
        Destroy(gameObject);
    }
    
}
