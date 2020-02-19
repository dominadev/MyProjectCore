using NUnit.Framework;
using ProjectCore.EFCore;
using ProjectCore.Model.EntityModel;
using ProjectCore.Model.Parameter;
using ProjectCore.Service.System;

namespace ProjectCore.UnitTesting
{
    public class Tests
    {

        [Test]
        public void TestInsert()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            SystemConfigService systemConfigService = new SystemConfigService(dbContext);
            for(int i = 0; i < 100; i++)
            {
                SystemConfig systemConfig = new SystemConfig();
                systemConfig.Key = "KeyTest" + i;
                systemConfig.Value = "Value" + i;
                systemConfig.Description = "Description"+i;
                systemConfigService.AddAsync(systemConfig);

            }


            Assert.Pass();
        }
        [Test]
        public void TestUpdate()
        {
            //ApplicationDbContext dbContext = new ApplicationDbContext();
            //SystemConfigService systemConfigService = new SystemConfigService(dbContext);
            //SystemConfig systemConfig = new SystemConfig();
            //systemConfig.Id = 2;
            //systemConfig.Key = "KeyTest2";
            //systemConfig.Value = "Value2Edited";
            //systemConfig.Description = "Description2";

            //systemConfigService.Update(systemConfig);
            //Assert.Pass();
        }
        [Test]
        public void TestPaging()
        {
            //ApplicationDbContext dbContext = new ApplicationDbContext();
            //SystemConfigService systemConfigService = new SystemConfigService(dbContext);
            //BasePagingParam basePagingParam = new BasePagingParam() { PageIndex = 0,Keyword = "1", PageSize = 1 };
            //BasePagingParam basePagingParam2 = new BasePagingParam() { PageIndex = 1,Keyword = "", PageSize = 1 };
            //int totalRow1 = 0;
            //int totalRow2 = 0;
            //var xxx = systemConfigService.GetListPaging(basePagingParam,ref totalRow1);
            //var xxy = systemConfigService.GetListPaging(basePagingParam2, ref totalRow2);
            Assert.Pass();
        }

    }
}