using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Command;
using UnityEngine;

public class InputCommand : ICommand
{
    private NumberPanel _numberPanel;
    private int _selectedIndex;
    private int _beforeIndex;

    public InputCommand(NumberPanel numberPanel, int selectedIndex)
    {
        _numberPanel = numberPanel;
        _selectedIndex = selectedIndex;
    }
    
    public void Execute()
    {
        _beforeIndex = _numberPanel.panelIndex;
        _numberPanel.panelIndex = _selectedIndex;
        _numberPanel.ChangePanelColor();
    }

    public void Undo()
    {
        _numberPanel.panelIndex = _beforeIndex;
        _numberPanel.ChangePanelColor();
    }
}
