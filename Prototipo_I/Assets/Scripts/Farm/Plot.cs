using System.Timers;
using TMPro;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private Plant plant;

    public bool IsPlanted => plant != null;

    private bool hasWater;
    public bool HasWater => hasWater;
    private bool isFertilized;
    private float MultiplierSpeed;

    [SerializeField] private TextMeshProUGUI statusText;

    private void Plant(Plant plant)
    {
        if (IsPlanted)
        {
            Debug.Log("Hey! I'm already a plant");
            return;
        }

        this.plant = plant;
        hasWater = false;
        isFertilized = false;

        this.plant.WhenFullGrow += WhenPlantIsFullGrow;

        Debug.Log("Calling Growth");
        this.plant.Create();
    }

    private void Harvest()
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

    private void UpdateUI()
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
                          $"Tieme to Grow: {plant.currentTime:F1}s\n" +
                          $"Watered: {(hasWater ? "Sí" : "No")}\n" +
                          $"Fertilizada: {(isFertilized ? "Sí" : "No")}\n";
    }

    private void WhenPlantIsFullGrow()
    {
        hasWater = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Plant Bulbasaur = new Plant("Bulbasaur", 3, 25f);
        Plant(Bulbasaur);
        //PlantManager.Instance.AssignPlot(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            hasWater = true;
            Debug.Log("XD");
        }
        UpdateUI();

    }

}
