using System.Timers;
using TMPro;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private Plant plant;

    public bool IsPlanted => plant != null;
    public bool HasWater;
    public bool isFertilized;
    public float MultiplierSpeed;

    public TextMeshProUGUI statusText;

    public void Plant(Plant plant)
    {
        if (IsPlanted)
        {
            Debug.Log("Hey! I'm already a plant");
            return;
        }

        this.plant = plant;
        HasWater = true;
        isFertilized = false;

        Debug.Log("Calling Growth");
        this.plant.Create();
    }

    public void Harvest()
    {
        if (!IsPlanted || !this.plant.IsGrown)
        {
            Debug.Log("Not today");
            return;
        }

        Debug.Log("Yw. Harvested");
        //Spawn drop and stuff
        this.plant = null;
    }

    public void UpdateUI()
    {
        if(statusText == null)
        {
            return;
        }

        if(!IsPlanted)
        {
            statusText.text = "Anything :<";
            return;
        }

        statusText.text = $"{plant.Name}\n" + 
                          $"Tiempo: {plant.TimeToGrow:F1}s\n";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        PlantManager.Instance.AssignPlot(this);
    }
    
}
