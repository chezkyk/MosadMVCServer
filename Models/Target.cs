using System.ComponentModel.DataAnnotations;

namespace MosadMVCServer.Models
{
    public class Target
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string PhotoUrl { get; set; }
        public Location Location { get; set; }
        public string Status { get; set; }

    }
}
