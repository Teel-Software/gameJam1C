using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader
{
    ///<summary>
    /// Возвращает список существующих врагов
    ///</summary>
    public static List<PaEData> ReadPaEData(){
        var strData = Resources
        .Load<TextAsset>("PlayerAndEnemy_stats")
        .text
        .Split('\n');

        var pae_Stats = new List<PaEData>();
        var mas = new List<List<string>>();

        var dict = new Dictionary<string, TankType>(){
            {"Player", TankType.Player},
            {"Standart", TankType.StandartEnemy},
            {"Fast", TankType.FastEnemy},
            {"Armored", TankType.ArmoredEnemy}
        };

        foreach(var line in strData){
            mas.Add(line.Split(";").Select(x => x.Trim()).ToList());
        }

        for (int i = 1; i < mas[0].Count; i++){
            var playerORenemyData = new PaEData();

            for(int k = 0; k < mas.Count; k++){
                switch(mas[k][0]){
                    case var str when str.Contains("TankType"):
                    playerORenemyData.Type = dict[ mas[k][i] ];
                    break;

                    case var str when str.Contains("Speed"):
                    playerORenemyData.Speed = int.Parse(mas[k][i]);
                    break;

                    case var str when str.Contains("Health"):
                    playerORenemyData.Health = int.Parse(mas[k][i]);
                    break;

                    case var str when str.Contains("Number of shots"):
                    playerORenemyData.NumberOfShots = int.Parse(mas[k][i]);
                    break;

                    case var str when str.Contains("Shot speed"):
                    playerORenemyData.ShotSpeed = int.Parse(mas[k][i]);
                    break;

                    case var str when str.Contains("Damage"):
                    playerORenemyData.Damage = int.Parse(mas[k][i]);
                    break;
                }
            }
            pae_Stats.Add(playerORenemyData);
        }
        return pae_Stats;
    }
}
