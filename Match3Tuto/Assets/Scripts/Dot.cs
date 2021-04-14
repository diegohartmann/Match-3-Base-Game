using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public int column, row;
    public int targetX, targetY;
    private GameObject otherDot = null;
    private Board board = null;
    private Vector2 firstTouchPosition, finalTouchPosition, tempPosition;
    private float swipeAngle = 0;
    private const float swapSmooth = 0.2f;
    private void Awake() {
        board = FindObjectOfType<Board>(); 
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        row = targetY;
        column = targetX;
    }
   
    private void Update() {
        targetX = column;
        targetY = row;
        if(Mathf.Abs(targetX- transform.position.x) > 0.1f){
            //move towrds target;
            tempPosition = new Vector2 (targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, swapSmooth);
        }
        else{
            //directly set the position;
            tempPosition = new Vector2 (targetX, transform.position.y);
            transform.position = tempPosition;
            board.allDots[column, row] = this.gameObject;
        }

        if(Mathf.Abs(targetY- transform.position.y) > 0.1f){
            //move towrds target;
            tempPosition = new Vector2 (transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, swapSmooth);
        }
        else{
            //directly set the position;
            tempPosition = new Vector2 (transform.position.x, targetY);
            transform.position = tempPosition;
            board.allDots[column, row] = this.gameObject;
        }
    }
    private void OnMouseDown() {
        firstTouchPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        // CalculateAngle();
    }
    private void OnMouseUp() {
        finalTouchPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        CalculateAngle();
    }
    private void CalculateAngle(){
        float deltaY = (finalTouchPosition.y - firstTouchPosition.y);
        float deltaX = (finalTouchPosition.x - firstTouchPosition.x);
        swipeAngle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;
        MovePieces();
    }

    private void MovePieces(){
        if( (swipeAngle > -45) && (swipeAngle <= 45) && (this.column < board.width)){
            //right swap
            otherDot = board.allDots[column + 1, row];
            otherDot.GetComponent<Dot>().column -= 1;
            this.column +=1;
        }
        else if( (swipeAngle > 45) && (swipeAngle <= 135) && (this.row < board.height)){
            //up swap
            otherDot = board.allDots[column , row + 1];
            otherDot.GetComponent<Dot>().row -= 1;
            this.row +=1;
        }
        else if( ((swipeAngle > 135) || (swipeAngle <= -135)) && (this.column > 0)){
            //left swap
            otherDot = board.allDots[column - 1, row];
            otherDot.GetComponent<Dot>().column += 1;
            this.column -=1;
        }
        else if( (swipeAngle < -45) && (swipeAngle >= -135) && this.row > 0 ){
            //down swap
            otherDot = board.allDots[column, row - 1];
            otherDot.GetComponent<Dot>().row += 1;
            this.row -=1;
        }
    }
}
