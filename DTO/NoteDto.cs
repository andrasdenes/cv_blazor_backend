using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NoteDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Uri Link { get; set; }
    }
}
