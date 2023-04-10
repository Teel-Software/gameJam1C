using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Общие характеристики игрока и врагов
/// </summary>
public class PaEData : MonoBehaviour
{
    public TankType Type {get; set;}

    public int Speed {get; set;}

    public int Health{get; set;}

    public int NumberOfShots {get; set;}

    public int ShotSpeed {get; set;}

    public int Damage {get; set;}

    public PaEData(){

    }

    public PaEData(PaEData pae){
        Type = pae.Type;
        Speed = pae.Speed;
        Health = pae.Health;
        NumberOfShots = pae.NumberOfShots;
        ShotSpeed = pae.ShotSpeed;
        Damage = pae.Damage;
    }

}
