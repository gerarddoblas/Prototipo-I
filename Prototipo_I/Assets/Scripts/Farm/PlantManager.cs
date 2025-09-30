using UnityEngine;
using System.Collections.Generic;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;
    private List<Plot> plots = new List<Plot>();

    private void Amake()
    {
        Instance = this;
    }

    public void AssginPlot(Plot plot)
    {
        if(!plots.Contains(plot))
        {
            plots.Add(plot);
        }
    }

    private void Update()
    {
        foreach (var plot in plots)
        {
            plot.CheckGrowth();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
}
