using System.Collections.Generic;
using Arrowgene.Ddon.Shared.Model;

public class EnemySpawnAsset
{
    public EnemySpawnAsset()
    {
        Enemies = new Dictionary<(StageId, byte), List<Enemy>>();
        DropsTables = new Dictionary<uint, DropsTable>();
    }

    public Dictionary<(StageId, byte), List<Enemy>> Enemies { get; set; }
    public Dictionary<uint, DropsTable> DropsTables { get; set; }

}