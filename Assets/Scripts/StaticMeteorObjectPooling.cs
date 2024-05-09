using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMeteorObjectPooling : ObjectPooling<MeteorBehaviour>
{
    protected override void Start()
    {
        base.Start();
    }

    public override MeteorBehaviour GetObject()
    {
        MeteorBehaviour obj = base.GetObject();
        if (obj != null)
        {
            obj.InitVariables();
        }
        return obj;
    }
}
