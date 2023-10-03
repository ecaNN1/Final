﻿using FinalProject.Core.Entities;
using FinalProject.Repository.Context;
using FinalProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository.Concrete
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
