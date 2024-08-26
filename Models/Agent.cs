using System.ComponentModel.DataAnnotations;

namespace MosadMVCServer.Models
{
    public class Agent
    {

        public int Id { get; set; }

        public string Nickname { get; set; }
        public string PhotoUrl { get; set; }

        public Location Location { get; set; }

        public string Status { get; set; }
    }
}
