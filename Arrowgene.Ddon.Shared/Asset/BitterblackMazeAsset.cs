using System.Collections.Generic;
using Arrowgene.Ddon.Shared.Entity.Structure;
using Arrowgene.Ddon.Shared.Model;
using Arrowgene.Ddon.Shared.Model.Appraisal;
using Arrowgene.Ddon.Shared.Model.BattleContent;

namespace Arrowgene.Ddon.Shared.Asset
{
    public class BitterblackMazeAsset
    {
        public BitterblackMazeAsset()
        {
            Stages = new Dictionary<StageId, BitterblackMazeConfig>();
            StarterEquipment = new Dictionary<JobId, Dictionary<EquipType, List<Item>>>();
            StarterJobEquipment = new Dictionary<JobId, List<Item>>();
            RareItemAppraisalList = new List<CDataCommonU32>();
            ItemTakeawayList = new List<CDataCommonU32>();
            StageProgressionList = new List<CDataBattleContentStageProgression>();

            LowQualityWeapons = new Dictionary<JobId, List<uint>>();
            HighQualityWeapons = new Dictionary<JobId, List<uint>>();
            LowQualityArmors = new Dictionary<BitterblackMazeEquipmentClass, List<uint>>();
            HighQualityArmors = new Dictionary<BitterblackMazeEquipmentClass, List<uint>>();
            LowQualityOther = new List<uint>();
            HighQualityOther = new List<uint>();
        }

        public Dictionary<StageId, BitterblackMazeConfig> Stages { get; set; }
        public Dictionary<JobId, Dictionary<EquipType, List<Item>>> StarterEquipment {  get; set; }
        public Dictionary<JobId, List<Item>> StarterJobEquipment { get; set; }
        public List<CDataCommonU32> RareItemAppraisalList { get; set; }
        public List<CDataCommonU32> ItemTakeawayList {  get; set; }
        public List<CDataBattleContentStageProgression> StageProgressionList {  get; set; }

        public Dictionary<JobId, List<uint>> LowQualityWeapons {  get; set; }
        public Dictionary<JobId, List<uint>> HighQualityWeapons { get; set; }
        public Dictionary<BitterblackMazeEquipmentClass, List<uint>> LowQualityArmors { get; set; }
        public Dictionary<BitterblackMazeEquipmentClass, List<uint>> HighQualityArmors { get; set; }
        public List<uint> LowQualityOther {  get; set; }
        public List<uint> HighQualityOther {  get; set; }

        public Dictionary<JobId, Dictionary<EquipType, List<Item>>> GenerateStarterEquipment()
        {
            var result = new Dictionary<JobId, Dictionary<EquipType, List<Item>>>();

            foreach (var (jobId, equipMap) in StarterEquipment)
            {
                result[jobId] = new Dictionary<EquipType, List<Item>>();
                foreach (var (equipType, items) in equipMap)
                {
                    result[jobId][equipType] = new List<Item>();
                    foreach (var item in items)
                    {
                        result[jobId][equipType].Add((item == null) ? null : new Item(item));
                    }
                }
            }

            return result;
        }

        public Dictionary<JobId, List<Item>> GenerateStarterJobEquipment()
        {
            var result = new Dictionary<JobId, List<Item>>();

            foreach (var (jobId, items) in StarterJobEquipment)
            {
                result[jobId] = new List<Item>();
                foreach (var item in items)
                {
                    result[jobId].Add((item == null) ? null : new Item(item));
                }
            }

            return result;
        }
    }
}