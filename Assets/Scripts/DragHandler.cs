#define DEBUG_MODE

using UnityEngine;

public class DragHandler : MonoBehaviour
{
    private bool isDragging = false; // Флаг, указывающий, перетаскивается ли объект в данный момент
    private Vector3 offset; // Смещение между позицией объекта и позицией курсора
    private Vector3 startPosition; // Начальная позиция объекта до перетаскивания
    private System.Diagnostics.Stopwatch stopwatch;

    private int counter = 0;
    private System.DateTime lastClicked;

    void Start()
    {
        startPosition = transform.position; // Запоминаем начальную позицию объекта
        stopwatch = new System.Diagnostics.Stopwatch();  
        lastClicked = System.DateTime.Now;
    }
    void OnMouseDown()
    {   
        stopwatch.Reset();
        stopwatch.Start();
        startPosition = transform.position; // Запоминаем начальную позицию объекта
        // Вычисляем смещение между позицией объекта и позицией курсора
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Вычисляем новую позицию объекта, основанную на текущей позиции курсора
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            // Присваиваем новую позицию объекту
            transform.position = newPosition;
        }
    }
    void OnMouseUp()
    {
        stopwatch.Stop();
        // При отпускании мыши завершаем перетаскивание
        isDragging = false;
        transform.position = startPosition;

        if (counter == 0) 
        {
            lastClicked = System.DateTime.Now;
            counter++;
        }
        else if (counter == 5) 
        {
            GameObject.Find("GameManager").GetComponent<MainScript>().TimeToGrowMultiplier = 1.0f;
            counter = 0;
            GetComponent<Animation>().Play("JumpUp");
        }
        else if ((counter == 4) & (((int)(lastClicked - System.DateTime.Now).TotalSeconds) < 2))
        {
            GameObject.Find("GameManager").GetComponent<MainScript>().TimeToGrowMultiplier = 0.1f;
            counter++;
        }
        else if (((int)(System.DateTime.Now - lastClicked).TotalSeconds) < 2) 
        {
            counter++;
        }
        else counter = 0;
    }
}