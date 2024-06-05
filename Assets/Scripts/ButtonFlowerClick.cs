//#define DEBUG_MODE

using UnityEngine;

public class ButtonFlowerClick : MonoBehaviour
{
    void OnMouseDown()
    {  
#if (DEBUG_MODE)
Debug.Log("Object " + gameObject.name + "clicked! у родительского объекта " + gameObject.transform.parent.gameObject.name ); 
#endif
        GameObject.Find("GameManager").GetComponent<MainScript>().ButtonFlowerClicked(gameObject.transform.parent.gameObject);     
    }
}
