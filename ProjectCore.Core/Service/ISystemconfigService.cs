using ProjectCore.Model.EntityModel;
using ProjectCore.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Core.Service
{
    public interface ISystemconfigService
    {
        void Add(SystemConfig systemConfig);
        void AddAsync(SystemConfig systemConfig);
        public void Update(SystemConfig systemConfig);
        public IEnumerable<SystemConfig> GetListPaging(BasePagingParam param, ref int totalRow);
        public void Delete(int Id);
    }
}
