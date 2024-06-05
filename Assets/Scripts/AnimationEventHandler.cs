using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
    }
}