using ScriptableObjects;
using UnityEngine;

public class TimedSpeedBuff : TimedBuff
{
    private readonly Entity _entity;

    public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation

        _entity = obj.GetComponent<Entity>();
    }

    protected override void ApplyEffect()
    {
        //Add speed increase to MovementComponent
        ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff)Buff;
        //_movementComponent.MovementSpeed += speedBuff.SpeedIncrease;


        _entity.SetArmorAmount(speedBuff.SpeedIncrease + _entity.GetArmorAmount());
    }

    public override void End()
    {
        //Revert speed increase
        ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff) Buff;
        //_movementComponent.MovementSpeed -= speedBuff.SpeedIncrease * EffectStacks;

        _entity.SetArmorAmount(_entity.GetArmorAmount() - speedBuff.SpeedIncrease);

        EffectStacks = 0;
    }
}