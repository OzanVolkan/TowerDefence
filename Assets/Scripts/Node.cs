using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;

    Color startColor;
    Vector3 buildOffset = Vector3.up * 0.5f;
    Renderer rend;
    GameObject currentTurret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.Instance.GetTurretToBuild() == null)
            return;

        if (currentTurret != null)
        {
            Debug.Log("Can't build here! : TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        currentTurret = Instantiate(turretToBuild, transform.position + buildOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.Instance.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
