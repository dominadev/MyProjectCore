using ProjectCore.Core.Data;
using ProjectCore.Core.Service;
using ProjectCore.Data;
using ProjectCore.EFCore;
using ProjectCore.Model.EntityModel;
using ProjectCore.Model.Parameter;
using ProjectCore.Ultility.ExpressionExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ProjectCore.Service.System
{
    public class SystemConfigService : ISystemconfigService
    {
        private UnitOfWork _UnitOfWork;
        public SystemConfigService(ApplicationDbContext dbContext)
        {
            _UnitOfWork = new UnitOfWork(dbContext);
        }
        public void Add(SystemConfig systemConfig)
        {
            _UnitOfWork.SystemConfigRepository.Add(systemConfig);
            _UnitOfWork.Commit();
        }
        public async void AddAsync(SystemConfig systemConfig)
        {
            await _UnitOfWork.SystemConfigRepository.AddAsync(systemConfig);
            _UnitOfWork.Commit();
        }
        public void Update(SystemConfig systemConfig)
        {
            _UnitOfWork.SystemConfigRepository.Update(systemConfig);
            _UnitOfWork.Commit();
        }
        public IEnumerable<SystemConfig> GetListPaging(BasePagingParam param, ref int totalRow)
        {
            IEnumerable<SystemConfig> listSystemConfig = new List<SystemConfig>();
            switch (param.SortName)
            {
                case "Key":
                    listSystemConfig = _UnitOfWork.SystemConfigRepository.GetMultiPaging(
                        t => param.SearchText == null || (param.SearchText != null && t.Key.Contains(param.SearchText)),
                         out totalRow,
                         param.PageNumber,
                         param.PageSize,
                         null,
                        t => t.OrderBy(a => a.Key)
                    ).ToList();
                    break;
                case "Value":
                    listSystemConfig = _UnitOfWork.SystemConfigRepository.GetMultiPaging(
                         t => param.SearchText == null || (param.SearchText != null && t.Key.Contains(param.SearchText)),
                          out totalRow,
                          param.PageNumber,
                          param.PageSize,
                          null,
                         t => t.OrderBy(a => a.Value)
                     ).ToList();
                    break;

            }
         
            return listSystemConfig;
        }
        public void Delete(int Id)
        {
            SystemConfig entity = new SystemConfig() { Id = Id };
            _UnitOfWork.SystemConfigRepository.Delete(entity);
            _UnitOfWork.Commit();
        }
     
       
    }
}
