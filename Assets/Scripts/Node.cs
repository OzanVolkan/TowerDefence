using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;

    Color startColor;
    Renderer rend;
    bool hasTurret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (hasTurret)
        {
            Debug.Log("Can't build here! : TODO: Display on screen");
            return;
        }

        EventManager.Broadcast(GameEvent.OnBuildStandartTurret, transform.position, transform.rotation);
        hasTurret = true;
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
