using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Command;
using UnityEngine;

public class AttackCommand : ICommand
{
    private NumberPanel _firstPanel;
    private NumberPanel _secondPanel;
    private int _selectedFirstIndex;
    private int _beforeFirstIndex;
    private int _selectedSecondIndex;
    private int _beforeSecondIndex;

    public AttackCommand(NumberPanel firstPanel, NumberPanel secondPanel,  int firstSelectIndex, int secondSelectIndex)
    {
        _firstPanel = firstPanel;
        _secondPanel = secondPanel;
        _selectedFirstIndex = firstSelectIndex;
        _selectedSecondIndex = secondSelectIndex;
    }
    
    public void Execute()
    {
        _beforeFirstIndex = _firstPanel.panelIndex;
        _beforeSecondIndex = _secondPanel.panelIndex;
        _firstPanel.panelIndex = _selectedFirstIndex;
        _secondPanel.panelIndex = _selectedSecondIndex;
        _firstPanel.panelState = PanelState.Confirmed;
        _secondPanel.panelState = PanelState.Confirmed;
        _firstPanel.ChangePanelColor();
        _secondPanel.ChangePanelColor();
    }

    public void Undo()
    {
        _firstPanel.panelIndex = _beforeFirstIndex;
        _secondPanel.panelIndex = _beforeSecondIndex;
        _firstPanel.panelState = PanelState.Selected;
        _secondPanel.panelState = PanelState.Selected;
        _firstPanel.ChangePanelColor();
        _secondPanel.ChangePanelColor();
    }
}