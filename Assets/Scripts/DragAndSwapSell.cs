//#define DEBUG_MODE

using UnityEngine;

public class DragAndSwapSell : MonoBehaviour
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
        startPosition = transform.position; // Запоминаем дефолтную позицию объекта
        stopwatch = new System.Diagnostics.Stopwatch();
    }
    public void HandleClick()
    {
#if (DEBUG_MODE)
Debug.Log("Object " + gameObject.name + "clicked!, elapsed time = "+ stopwatch.ElapsedMilliseconds +" ms." ); 
#endif
        GameObject.Find("GameManager").GetComponent<MainScript>().SellFlowerClicked(gameObject);  
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
        GameObject.Find("GameManager").GetComponent<MainScript>().CalculateAllBonus();
        GameObject.Find("GameManager").GetComponent<MainScript>().TurnAllSellAffinityOn();
        GameObject.Find("GameManager").GetComponent<MainScript>().TurnAllBonusOff();
        GameObject.Find("GameManager").GetComponent<MainScript>().TurnAllSellOff();
        GameObject.Find("GameManager").GetComponent<MainScript>().HideEmptySellColliders(true);
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
            (gameObject.GetComponent<SellFlowerComponent>().FlowerData, hit.collider.GetComponent<SellFlowerComponent>().FlowerData) = (hit.collider.GetComponent<SellFlowerComponent>().FlowerData, gameObject.GetComponent<SellFlowerComponent>().FlowerData);
            GameObject.Find("GameManager").GetComponent<MainScript>().UpdateSellShelfObjectByFlower(gameObject.GetComponent<SellFlowerComponent>().ShelfData, gameObject.GetComponent<SellFlowerComponent>().FlowerData);
            GameObject.Find("GameManager").GetComponent<MainScript>().UpdateSellShelfObjectByFlower(hit.collider.GetComponent<SellFlowerComponent>().ShelfData, hit.collider.GetComponent<SellFlowerComponent>().FlowerData);
        }   
        else
        {
#if (DEBUG_MODE)
Debug.Log("Курсор не пересекается с другими объектами");
#endif
            transform.position = startPosition;
        }
        GameObject.Find("GameManager").GetComponent<MainScript>().TurnAllSellAffinityOff();
        GameObject.Find("GameManager").GetComponent<MainScript>().CalculateAllBonus();
        GameObject.Find("GameManager").GetComponent<MainScript>().TurnAllBonusOn();
        GameObject.Find("GameManager").GetComponent<MainScript>().TurnAllSellOn();
        GameObject.Find("GameManager").GetComponent<MainScript>().CalculateTotalSellValue();
        if ((distance <= DISTANCE_TO_CLICK) & (elapsedtime <= TIME_TO_CLICK)) HandleClick();
        GameObject.Find("GameManager").GetComponent<MainScript>().HideEmptySellColliders(false);
    }
}