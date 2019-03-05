using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {
    public Circle Ball;
    public Block Paddle;
    public List<Block> Blocks;
    [SerializeField]
    private float leftBounds = 0, rightBounds = 0, topBounds = 0, bottomBounds = 0;

    private Vector3 _reflectNormal = Vector3.zero;

    public delegate void GameOverEvent(bool didWin);
    public GameOverEvent GameOver;
    private bool _isGameOver = false;

    private void FixedUpdate() {
        if(_isGameOver) { return; }

        //move the ball every fixedupdate "frame"
        Ball.Move();
        

        if(Blocks.Count == 0) {
            if (GameOver != null) GameOver(true);
            _isGameOver = true;
            return;
        }

        //check this ball against all blocks
        for (int i = 0; i < Blocks.Count; i++) {
            if (Blocks[i].CheckCircleCollision(Ball, out _reflectNormal)) {
                Ball.ReflectVelocity(_reflectNormal);
                Blocks[i].Break();
                Blocks.Remove(Blocks[i]);
                break;
            }
        }

        //paddle collision
        if (Paddle.CheckCircleCollision(Ball, out _reflectNormal)) {
            Ball.ReflectVelocity(_reflectNormal);
        }

        //all this is wall collision
        if (Ball.transform.position.x + Ball.Radius > rightBounds) {
            Ball.ReflectVelocity(Vector3.left);
        }
        else if (Ball.transform.position.x + Ball.Radius < leftBounds) {
            Ball.ReflectVelocity(Vector3.right);
        }

        if(Ball.transform.position.y > topBounds) {
            Ball.ReflectVelocity(Vector3.down);
        }
        //ball fell through the floor so end the game
        else if(Ball.transform.position.y < bottomBounds) {
            //Debug.Log("Game ober");
            _isGameOver = true;
            if (GameOver != null) GameOver(false);
            return;
        }



        _reflectNormal = Vector3.zero;
    }
}
