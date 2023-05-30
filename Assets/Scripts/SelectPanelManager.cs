using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectPanelManager : Singleton<SelectPanelManager>
{
    private HashSet<int> numberPanelSet = new HashSet<int>();
    [SerializeField] private Transform numberPanelTransform;
    
    public int GetPanelSelectedCount()
    {
        return numberPanelSet.Count;
    }

    public NumberPanel GetNumberPanel(int index)
    {
        return numberPanelTransform.GetChild(index).gameObject.GetComponent<NumberPanel>();
    }
    
    public int GetPanelSetsValue(int i)
    {
        return numberPanelSet.ToArray()[i];
    }
    
    public void AddNumberPanel(NumberPanel numberPanel)
    {
        numberPanelSet.Add(numberPanel.panelIndex);
    }

    public void RemoveNumberPanel(NumberPanel numberPanel)
    {
        numberPanelSet.Remove(numberPanel.panelIndex);
    }

    public void ClerNumberPanelSet()
    {
        numberPanelSet.Clear();
    }
}
