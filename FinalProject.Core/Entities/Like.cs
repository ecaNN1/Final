using FinalProject.Core.Enums;
using FinalProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Entities
{
    public class Like : IBaseEntity
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}
