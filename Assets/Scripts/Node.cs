using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color notEnoughMoneyColor;

    [Header("Optional")]
    [SerializeField] GameObject _currentTurret;
    public GameObject CurrentTurret
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


        if (CurrentTurret != null)
        {
            BuildManager.Instance.SelectNode(this);
            return;
        }

        if (!BuildManager.Instance.CanBuild)
            return;

        BuildManager.Instance.BuildTurretOn(this, GetBuildPosition());

    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.Instance.CanBuild)
            return;

        if (BuildManager.Instance.HasMoney)
            rend.material.color = hoverColor;

        else
            rend.material.color = notEnoughMoneyColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + buildOffset;
    }
}
