//#define DEBUG_MODE

using System;
using UnityEngine;

public class SwipeHandler : MonoBehaviour
{
    private const float TIME_TO_SWIPE = 800;
    private const float DISTANCE_TO_SWIPE = 250.0f;
    //private Collider2D myCollider;
    private Vector3 offset; 
    private Vector3 startPosition, endPosition;
    private System.Diagnostics.Stopwatch stopwatch;

    void Start()
    {
        stopwatch = new System.Diagnostics.Stopwatch();         
    }
    void OnMouseDown()
    {
        stopwatch.Reset();
        stopwatch.Start();
        startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#if (DEBUG_MODE)
Debug.Log("Object " + gameObject.name + "clicked!, SwipeManager" ); 
#endif
    }
    void OnMouseUp()
    {
        stopwatch.Stop();
        endPosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = endPosition - startPosition;
        float distance = Vector3.Distance(startPosition, endPosition);
        float elapsedtime = stopwatch.ElapsedMilliseconds;
#if (DEBUG_MODE)
Debug.Log("SwipeDistance = " + distance.ToString() + ",  time =" + elapsedtime.ToString() + " x =" + offset.x + " y =" + offset.y ); 
#endif
        if ( (distance >= DISTANCE_TO_SWIPE)& (elapsedtime <= TIME_TO_SWIPE) & (offset.x < 0) & (Math.Abs(offset.x) > Math.Abs(offset.y*3) ) ) OnSwipeLeft();
        if ( (distance >= DISTANCE_TO_SWIPE)& (elapsedtime <= TIME_TO_SWIPE) & (offset.x > 0) & (Math.Abs(offset.x) > Math.Abs(offset.y*3) ) ) OnSwipeRight();
    }
    void OnSwipeLeft()
    {
#if (DEBUG_MODE)
Debug.Log("Swipe Left "); 
#endif
        GameObject.Find("GameManager").GetComponent<MainScript>().SwipeLeft();
    }
    void OnSwipeRight()
    {
#if (DEBUG_MODE)
Debug.Log("Swipe Right "); 
#endif        
        GameObject.Find("GameManager").GetComponent<MainScript>().SwipeRight();
    }
}