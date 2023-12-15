using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPanel : Singleton<PopupPanel>
{
    [Header("Popup Panel")]
    [SerializeField] protected GameObject popupPanelHolder;
    [SerializeField] protected Button yesButton;
    [SerializeField] protected Button noButton;
    [SerializeField] protected Text popupText;
    [SerializeField] protected Text popupLogText;

    protected const string UpgradeString = "Are you sure to upgrade this weapon ?";
    protected const string DowngradeString = "Are you sure to downgrade this weapon ?";
    protected const string UnUseString = "Are you sure to un-use this weapon ?";
    protected const string UnRentString = "Are you sure to un-rent this weapon ?";

    protected const string UpgradeLogString = "Upgraded selected weapon.";
    protected const string DowngradeLogString = "Downgraded selected weapon.";
    protected const string MinLevelLogString = "Weapon is at minimum level, cannot downgrade anymore!";
    protected const string MaxLevelLogString = "Weapon is at maximum level, cannot upgrade anymore!";

    static public Action yesAction;

    protected void Start()
    {
        RegisterOnClickEvent();
    }

    protected void RegisterOnClickEvent()
    {
        yesButton.onClick.AddListener( () => { ExecuteYesAction(); HidePopupPanel(); } );
        noButton.onClick.AddListener( () => { HidePopupPanel(); } );
    }

    protected void ExecuteYesAction()
    {
        yesAction?.Invoke();
    }

    public void ShowPopupPanel()
    {
        popupPanelHolder.SetActive(true);
    }

    public void HidePopupPanel()
    {
        popupPanelHolder.SetActive(false);
    }

    public void SetPopupPanelText(PopupPanelText eText)
    {
        switch (eText)
        {
            case PopupPanelText.Upgrade:
                popupText.text = UpgradeString;
                break;
            case PopupPanelText.Downgrade:
                popupText.text = DowngradeString;
                break;
            case PopupPanelText.UnUse:
                popupText.text = UnUseString;
                break;
            case PopupPanelText.UnRent:
                popupText.text = UnRentString;
                break;
        }
    }

    public void ShowPopupLog(PopupLog eLog)
    {
        switch (eLog)
        {
            case PopupLog.Upgrade:
                DOTweenLog(UpgradeLogString);
                break;
            case PopupLog.Downgrade:
                DOTweenLog(DowngradeLogString);
                break;
            case PopupLog.WeaponMinLevel:
                DOTweenLog(MinLevelLogString);
                break;
            case PopupLog.WeaponMaxLevel:
                DOTweenLog(MaxLevelLogString);
                break;
        }
    }

    public void DOTweenLog(string text)
    {
        DOTween.Rewind("Log DOTween");
        popupLogText.text = text;
        popupLogText.gameObject.SetActive(true);
        popupLogText.transform.localPosition = Vector2.zero;
        popupLogText.rectTransform.DOAnchorPosY(100f, 1f).SetId("Log DOTween").OnComplete( () => { popupLogText.gameObject.SetActive(false); } );
    }
}

public enum PopupPanelText
{
    Upgrade,
    Downgrade,
    UnUse,
    UnRent
}

public enum PopupLog
{
    Upgrade,
    Downgrade,
    WeaponMinLevel,
    WeaponMaxLevel
}
