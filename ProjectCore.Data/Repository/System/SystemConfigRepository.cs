using ProjectCore.Core.Data.Repository.System;
using ProjectCore.EFCore;
using ProjectCore.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Data.Repository.System
{
   public  class SystemConfigRepository:RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
