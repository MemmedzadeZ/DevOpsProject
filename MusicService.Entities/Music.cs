using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.Entities
{
    public class Music
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public bool IsFav { get; set; }
        public bool IsLike { get; set; }
        public int LikeCount { get; set; }

        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
