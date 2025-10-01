using UnityEngine;
using UnityEngine.Events;

public class Plant
{
    private string name;
    public string Name { get => name; }

    private int numStages;
    private int currentStage;

    public bool IsGrown => currentStage >= numStages;

    private float timeToGrow;
    public float TimeToGrow { get => timeToGrow; }

    private UnityEvent<float> MyEvent = new UnityEvent<float>();

    public void Create()
    {
        MyEvent.AddListener(Grow);

        DayNightCycle.Instance.SubscribeTimedEvent(MyEvent, DayNightCycle.Instance.DayTime + timeToGrow);
    }

    private void Grow(float time)
    {
        currentStage++;
        if (IsGrown)
        {
            //UwU
        } else
        {
            DayNightCycle.Instance.SubscribeTimedEvent(MyEvent, DayNightCycle.Instance.DayTime + timeToGrow);
        }
        //Update visual
    }
}