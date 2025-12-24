using UnityEngine;

public class EnterCrimpZoneTask : Task
{
    [SerializeField] private CrimpZoneTrigger crimpTrigger;

    public override string RUDescription => "войдите в одну из предложенных зон";
    public override string Name => "EnterCrimpZone";


    public override void Terms()
    {
        base.Terms();

        crimpTrigger.ResetTrigger();
        crimpTrigger.gameObject.SetActive(true);
    }

    public override void Complete()
    {
        if (!activated) return;

        base.Complete();

        if (TaskController.instance.trainingPath ==
            TaskController.TrainingPath.StartedWithAssembly)
        {
            TaskController.instance.ChangeTaskAndSetIndex("FinishTraining");
        }
        else
        {
            TaskController.instance.ChangeTaskAndSetIndex("StartCrimp");
        }
    }

}
