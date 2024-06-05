//#define DEBUG_MODE

using UnityEngine;

public class DragAndSwapGrow : MonoBehaviour
{
    private const float TIME_TO_CLICK = 500;
    private const float DISTANCE_TO_CLICK = 50.0f;
    private bool isDragging = false; // Флаг, указывающий, перетаскивается ли объект в данный момент
    private Vector3 offset; // Смещение между позицией объекта и позицией курсора
    private Vector3 startPosition; // Начальная позиция объекта до перетаскивания
    private System.Diagnostics.Stopwatch stopwatch;
    private Collider2D myCollider, swipeCollider; // Ссылка на коллайдер объекта

    void Start()
    {
        // Получаем ссылку на компонент Collider2D
        myCollider = GetComponent<Collider2D>();
        swipeCollider = GameObject.Find("SwipeManager").transform.Find("SwipeCollider").transform.GetComponent<Collider2D>();
        startPosition = transform.position; // Запоминаем начальную позицию объекта
        stopwatch = new System.Diagnostics.Stopwatch();
    }
    public void HandleClick()
    {
#if (DEBUG_MODE)
Debug.Log("Object " + gameObject.name + "clicked!, elapsed time = "+ stopwatch.ElapsedMilliseconds +" ms." ); 
#endif
        GameObject.Find("GameManager").GetComponent<MainScript>().GrowFlowerClicked(gameObject); 
    }
    void OnMouseDown()
    {   
        stopwatch.Reset();
        stopwatch.Start();
        startPosition = transform.position; // Запоминаем начальную позицию объекта
        // Вычисляем смещение между позицией объекта и позицией курсора
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        swipeCollider.enabled = false;
        GameObject.Find("GameManager").GetComponent<MainScript>().HideEmptyGrowColliders(true);
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
        float distance = Vector3.Distance(startPosition, transform.position);
        float elapsedtime = stopwatch.ElapsedMilliseconds;
        // При отпускании мыши завершаем перетаскивание
        isDragging = false;
        // Отключаем коллайдер 
        myCollider.enabled = false;
        swipeCollider.enabled = false;
        // Проверяем, пересекается ли курсор с другими коллайдерами
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        // Включаем коллайдер
        swipeCollider.enabled = true;
        myCollider.enabled = true;
        // Если есть пересечение с другим коллайдером
        if (hit.collider != null)
        {
#if (DEBUG_MODE)
Debug.Log("Пересечение" + gameObject.name + " у родительского объекта " +gameObject.transform.parent.gameObject.name + " с объектом: " + hit.collider.name + 
" у родительского объекта " + hit.collider.transform.parent.gameObject.name );
#endif
            transform.position = startPosition;
            (gameObject.GetComponent<GrowFlowerComponent>().FlowerData, hit.collider.GetComponent<GrowFlowerComponent>().FlowerData) = (hit.collider.GetComponent<GrowFlowerComponent>().FlowerData, gameObject.GetComponent<GrowFlowerComponent>().FlowerData);
            (GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersArray[gameObject.GetComponent<GrowFlowerComponent>().number], GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersArray[hit.collider.GetComponent<GrowFlowerComponent>().number]) = (GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersArray[hit.collider.GetComponent<GrowFlowerComponent>().number], GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersArray[gameObject.GetComponent<GrowFlowerComponent>().number]);
            (GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersDateTimeList[gameObject.GetComponent<GrowFlowerComponent>().number], GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersDateTimeList[hit.collider.GetComponent<GrowFlowerComponent>().number]) = (GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersDateTimeList[hit.collider.GetComponent<GrowFlowerComponent>().number], GameObject.Find("GameManager").GetComponent<MainScript>().GrowingFlowersDateTimeList[gameObject.GetComponent<GrowFlowerComponent>().number]);
            GameObject.Find("GameManager").GetComponent<MainScript>().UpdateGrowShelfObjectByFlower(gameObject.GetComponent<GrowFlowerComponent>().ShelfData, gameObject.GetComponent<GrowFlowerComponent>().FlowerData);
            GameObject.Find("GameManager").GetComponent<MainScript>().UpdateGrowShelfObjectByFlower(hit.collider.GetComponent<GrowFlowerComponent>().ShelfData, hit.collider.GetComponent<GrowFlowerComponent>().FlowerData);
            //GameObject.Find("GameManager").GetComponent<MainScript>().CheckGrow();
        }   
        else
        {
#if (DEBUG_MODE)
Debug.Log("Курсор не пересекается с другими объектами");
#endif
            transform.position = startPosition;
        }
        if ((distance <= DISTANCE_TO_CLICK)&(elapsedtime <= TIME_TO_CLICK)) HandleClick();
        GameObject.Find("GameManager").GetComponent<MainScript>().HideEmptyGrowColliders(false);
    }
}