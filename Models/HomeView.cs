using Humanizer;

namespace MosadMVCServer.Models
{
    public class HomeView
    {
        public int ActiveAgents { get; set; }
        public int NotActiveAgents { get; set; }

        public int AliveTarget { get; set; }
        public int DeadTarget { get; set; }

        public int OfferMission { get; set; }
        public int InMissionMission { get; set; }
        public int FinishMission { get;set; }
        public string RelationOfAgentsToTargets { get; set; }
        public string GoodActiveAgents { get; set;}
    }
}
