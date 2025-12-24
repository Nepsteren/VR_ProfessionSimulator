using UnityEngine;

public class Task : MonoBehaviour
{
    protected bool activated;

    public virtual string RUDescription => "";
    public virtual string Name => "";

    public virtual void Terms()
    {
        activated = true;
    }

    public virtual void Complete()
    {
        activated = false;
    }
}
