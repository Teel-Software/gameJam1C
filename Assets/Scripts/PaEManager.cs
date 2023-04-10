using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaEManager
{
    static readonly List<PaEData> PlayerAndEnemies = CSVReader.ReadPaEData();


    /// <summary>
    /// Получить данные об игроке
    /// </summary>
    public static PaEData GetPlayer(){
        var player = PlayerAndEnemies.Where(x => x.Type == TankType.Player).ToArray();
        return new PaEData(player[0]);
    }

    /// <summary>
    /// Получить данные о стандартном противнике
    /// </summary>
    public static PaEData GetStandart(){
        var enemy = PlayerAndEnemies.Where(x => x.Type == TankType.StandartEnemy).ToArray();
        return new PaEData(enemy[0]);
    }

    /// <summary>
    /// Получить данные о быстром противнике
    /// </summary>
    public static PaEData GetFast(){
        var enemy = PlayerAndEnemies.Where(x => x.Type == TankType.FastEnemy).ToArray();
        return new PaEData(enemy[0]);
    }

    /// <summary>
    /// Получить данные о бронированном противнике
    /// </summary>
    public static PaEData GetArmored(){
        var enemy = PlayerAndEnemies.Where(x => x.Type == TankType.ArmoredEnemy).ToArray();
        return new PaEData(enemy[0]);
    }
}
