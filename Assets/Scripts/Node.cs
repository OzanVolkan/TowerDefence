using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color notEnoughMoneyColor;

    private GameObject _currentTurret;
    public GameObject CurrentTurret
    {
        get { return _currentTurret; }
        set { _currentTurret = value; }
    }

    private TurretBluePrint _turretBluePrint;
    public TurretBluePrint TurretBluePrint
    {
        get { return _turretBluePrint; }
        set { _turretBluePrint = value; }
    }

    private bool _isUpgraded;
    public bool IsUpgraded
    {
        get { return _isUpgraded; }
        set { _isUpgraded = value; }
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

        BuildTurret(BuildManager.Instance.GetTurretToBuild());
    }

    private void BuildTurret(TurretBluePrint turretBluePrint)
    {
        if (DataManager.Instance.gameData.Money < turretBluePrint.Cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        DataManager.Instance.gameData.Money -= turretBluePrint.Cost;

        GameObject turret = Instantiate(turretBluePrint.Prefab, GetBuildPosition(), Quaternion.identity);
        CurrentTurret = turret;

        TurretBluePrint = turretBluePrint;

        GameObject effect = Instantiate(BuildManager.Instance.BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    public void UpgradeTurret()
    {
        if (DataManager.Instance.gameData.Money < TurretBluePrint.UpgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        DataManager.Instance.gameData.Money -= TurretBluePrint.UpgradeCost;

        //Eski model basic turretý yok ediyoruz.
        Destroy(CurrentTurret);

        //Upgraded versiyonunu oluþturuyoruz.
        GameObject turret = Instantiate(TurretBluePrint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        CurrentTurret = turret;

        GameObject effect = Instantiate(BuildManager.Instance.BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        IsUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret()
    {
        DataManager.Instance.gameData.Money += TurretBluePrint.GetSellAmount();

        Destroy(CurrentTurret);
        TurretBluePrint = null;

        GameObject effect = Instantiate(BuildManager.Instance.SellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
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
