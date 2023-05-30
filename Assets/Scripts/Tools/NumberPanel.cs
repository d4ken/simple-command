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
    Unselected
}

public class NumberPanel : MonoBehaviour, IPointerDownHandler
{
    public int panelIndex;
    private PanelState _panelState;
    
    [SerializeField] private TextMeshProUGUI _panelNumberText;

    void Start()
    {
        _panelState = PanelState.Unselected;
        panelIndex = transform.GetSiblingIndex();
        _panelNumberText.text = panelIndex.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        ICommand command = new InputCommand(this, panelIndex);
        CommandInvoker.ExecuteCommand(command);
    }

    public void ChangePanelColor(PanelState panelState)
    {
        if (panelState == PanelState.Selected)
        {
            GetComponent<Image>().color = Color.black;
            _panelNumberText.color = Color.white; 
        }

        if (panelState == PanelState.Unselected)
        {
            GetComponent<Image>().color = Color.white;
            _panelNumberText.color = Color.black; 
        }
 
    }
    
    
}
