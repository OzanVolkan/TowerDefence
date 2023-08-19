using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;

    [Header("Optional")]
    [SerializeField] GameObject _currentTurret;
    public  GameObject CurrentTurret
    {
        get { return _currentTurret; }
        set { _currentTurret = value; }
    }


    Color startColor;
    Vector3 buildOffset = Vector3.up * 0.5f;
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.Instance.CanBuild)
            return;

        if (CurrentTurret != null)
        {
            Debug.Log("Can't build here! : TODO: Display on screen");
            return;
        }

        BuildManager.Instance.BuildTurretOn(this, GetBuildPosition());

    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.Instance.CanBuild)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private Vector3 GetBuildPosition()
    {
        return transform.position + buildOffset;
    }
}
