using ProjectCore.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Core.Service
{
    public interface ISystemconfigService
    {
        void Add(SystemConfig systemConfig);
        void AddAsync(SystemConfig systemConfig);
    }
}
