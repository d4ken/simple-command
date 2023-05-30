using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Command;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum PanelState
{
    Selected,
    Unselected,
    Confirmed
}

public class NumberPanel : MonoBehaviour, IPointerDownHandler
{
    public int panelIndex;
    public PanelState panelState;
    [SerializeField] private TextMeshProUGUI _panelNumberText;

    void Start()
    {
        panelState = PanelState.Unselected;
        panelIndex = transform.GetSiblingIndex();
        _panelNumberText.text = panelIndex.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (panelState == PanelState.Unselected && SelectPanelManager.Instance.GetPanelSelectedCount() >= 2) return;

        if (panelState == PanelState.Unselected)
        {
            SelectPanelManager.Instance.AddNumberPanel(this);
        }
        else
        {
            SelectPanelManager.Instance.RemoveNumberPanel(this);
        }
        ChangePanelColor();

        
        if (SelectPanelManager.Instance.GetPanelSelectedCount() == 2)
        {
            NumberPanel firstPanel =
                SelectPanelManager.Instance.GetNumberPanel(SelectPanelManager.Instance.GetPanelSetsValue(0));
            NumberPanel secondPanel =
                SelectPanelManager.Instance.GetNumberPanel(SelectPanelManager.Instance.GetPanelSetsValue(1));
            
            ICommand attackCommand =
                new AttackCommand(firstPanel, secondPanel, firstPanel.panelIndex, secondPanel.panelIndex);
            CommandInvoker.ExecuteCommand(attackCommand);
            SelectPanelManager.Instance.ClerNumberPanelSet();
        }
        // ICommand command = new InputCommand(this, panelIndex);
        // CommandInvoker.ExecuteCommand(command);
    }

    public void ChangePanelColor()
    {
        if (panelState == PanelState.Selected)
        {
            panelState = PanelState.Unselected;
            GetComponent<Image>().color = Color.white;
            _panelNumberText.color = Color.black;
        }
        else if (panelState == PanelState.Unselected)
        {
            panelState = PanelState.Selected;
            GetComponent<Image>().color = Color.black;
            _panelNumberText.color = Color.white;
        }
        else if (panelState == PanelState.Confirmed)
        {
            GetComponent<Image>().color = Color.grey;
            _panelNumberText.color = Color.black;
        }
    }
}