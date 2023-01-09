
using UnityEngine.Events;

public class EventManager
{
    public static readonly UnityEvent<FallingObjects> OnObjectFell = new UnityEvent<FallingObjects>();
    public static readonly UnityEvent OnScoreChange = new UnityEvent();
    public static readonly UnityEvent OnGameOver = new UnityEvent();

    public static void SendObjectFell(FallingObjects fellObject)
    {
        if(OnObjectFell != null) OnObjectFell.Invoke(fellObject);
    }

    public static void SendScoreChanged()
    {
        if (OnScoreChange != null) OnScoreChange.Invoke();
    }
    public static void SendGameOver()
    {
        if (OnGameOver != null) OnGameOver.Invoke();
    }


}
