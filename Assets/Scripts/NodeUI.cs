using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upgradeText, sellAmountText;
    [SerializeField] Button upgradeBtn;

    private Node target;
    private GameObject ui;

    private void Start()
    {
        ui = transform.GetChild(0).gameObject;
    }
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.IsUpgraded)
        {
            upgradeText.text = "<b> UPGRADE </b> \n$" + _target.TurretBluePrint.UpgradeCost;
            upgradeBtn.interactable = true;
        }
        else
        {
            upgradeBtn.interactable = false;
            upgradeText.text = "<b> UPGRADED </b>";
        }

        sellAmountText.text = "<b> SELL </b> \n$" + _target.TurretBluePrint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    #region Buttons

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.Instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.Instance.DeselectNode();
    }

    #endregion
}
