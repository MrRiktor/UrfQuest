using System;

public interface IPartyMember
{
    String BeingName
    { 
        get; 
        set; 
    }

    long AttackDamage
    {
        get;
        set;
    }

    long HealthPool
    {
        get;
        set;
    }

    long MovementSpeed
    {
        get;
        set;
    }

    UnityEngine.Sprite Icon
    {
        get;
        set;
    }

    UnityEngine.Sprite Portrait
    {
        get;
        set;
    }
    UnityEngine.AudioClip AttackClip
    {
        get;
        set;
    }

}
