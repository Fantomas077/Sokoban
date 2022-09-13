using UnityEngine;
using TMPro;

public class LoadHandler : MonoBehaviour
{
    public TextMeshProUGUI LoadField;
    public static string levelNameDistribution;
    
    public void distribute()
    {
        LoadHandler.levelNameDistribution = GameObject.Find("LoadButton").GetComponent<LoadHandler>().LoadField.text;

    }
}
