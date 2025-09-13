using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.PaperVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class PaperControllerTest
    {
        private PaperController _controller;
        private string _seed;

        public PaperControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PaperController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as PaperListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PaperVM));

            PaperVM vm = rv.Model as PaperVM;
            Paper v = new Paper();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "DdE";
            v.Name = "Zl";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
            v.PaperTitle = "N1EUwg6ivoK5";
            v.MagazineName = "smMzvSH5CCV2NtijvrLep3MxqZJM8w7GDIaNSsXQzBCamOxHaVmuO7czaYIVJ68QG";
            v.PublicTime = DateTime.Parse("2024-05-28 11:04:39");
            v.Info = "0MQarKnsUC17qz4a8Nz4h2ibHSrsfRfoIrOHmvSfx3fuoh";
            v.Category = DMSFinal.Model.CategoryEnum.ChineseCore;
            v.IsSCI = DMSFinal.Model.IfEnum.No;
            v.SCINo = "TjtYJMp3juw2od6DofSxSnLJJhbdwRqDIy0d3U4";
            v.IsEI = DMSFinal.Model.CategoryEnum.ChineseRegular;
            v.EINo = "yu69k6GZsvLVDpg0UuwTb6Vwyb4q2LN4";
            v.IsISTP = DMSFinal.Model.IfEnum.Yes;
            v.ISTPNo = "qFxq6HDQBD8P2WMiFRN8ULMe";
            v.Num = 597084602;
            v.ImpactFactor = 13;
            v.Rank = DMSFinal.Model.RankEnum.Eight;
            v.IsOurSchool = DMSFinal.Model.IfEnum.No;
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "3G";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Paper>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "DdE");
                Assert.AreEqual(data.Name, "Zl");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ZhengGaoShiYan);
                Assert.AreEqual(data.PaperTitle, "N1EUwg6ivoK5");
                Assert.AreEqual(data.MagazineName, "smMzvSH5CCV2NtijvrLep3MxqZJM8w7GDIaNSsXQzBCamOxHaVmuO7czaYIVJ68QG");
                Assert.AreEqual(data.PublicTime, DateTime.Parse("2024-05-28 11:04:39"));
                Assert.AreEqual(data.Info, "0MQarKnsUC17qz4a8Nz4h2ibHSrsfRfoIrOHmvSfx3fuoh");
                Assert.AreEqual(data.Category, DMSFinal.Model.CategoryEnum.ChineseCore);
                Assert.AreEqual(data.IsSCI, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.SCINo, "TjtYJMp3juw2od6DofSxSnLJJhbdwRqDIy0d3U4");
                Assert.AreEqual(data.IsEI, DMSFinal.Model.CategoryEnum.ChineseRegular);
                Assert.AreEqual(data.EINo, "yu69k6GZsvLVDpg0UuwTb6Vwyb4q2LN4");
                Assert.AreEqual(data.IsISTP, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.ISTPNo, "qFxq6HDQBD8P2WMiFRN8ULMe");
                Assert.AreEqual(data.Num, 597084602);
                Assert.AreEqual(data.ImpactFactor, 13);
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Eight);
                Assert.AreEqual(data.IsOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "3G");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Paper v = new Paper();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "DdE";
                v.Name = "Zl";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v.PaperTitle = "N1EUwg6ivoK5";
                v.MagazineName = "smMzvSH5CCV2NtijvrLep3MxqZJM8w7GDIaNSsXQzBCamOxHaVmuO7czaYIVJ68QG";
                v.PublicTime = DateTime.Parse("2024-05-28 11:04:39");
                v.Info = "0MQarKnsUC17qz4a8Nz4h2ibHSrsfRfoIrOHmvSfx3fuoh";
                v.Category = DMSFinal.Model.CategoryEnum.ChineseCore;
                v.IsSCI = DMSFinal.Model.IfEnum.No;
                v.SCINo = "TjtYJMp3juw2od6DofSxSnLJJhbdwRqDIy0d3U4";
                v.IsEI = DMSFinal.Model.CategoryEnum.ChineseRegular;
                v.EINo = "yu69k6GZsvLVDpg0UuwTb6Vwyb4q2LN4";
                v.IsISTP = DMSFinal.Model.IfEnum.Yes;
                v.ISTPNo = "qFxq6HDQBD8P2WMiFRN8ULMe";
                v.Num = 597084602;
                v.ImpactFactor = 13;
                v.Rank = DMSFinal.Model.RankEnum.Eight;
                v.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "3G";
                context.Set<Paper>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PaperVM));

            PaperVM vm = rv.Model as PaperVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Paper();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "BeyyGAF8QRsjbEmqKk";
            v.Name = "BlLUaHXPQDbHZGFI8";
            v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
            v.PaperTitle = "gOlUHiwVZjXaAhYwN1lC6KlRPoPQtZImpV69w9NFMBK3wFp";
            v.MagazineName = "3nvsfkOSeSL9g8QT63oO";
            v.PublicTime = DateTime.Parse("2025-03-15 11:04:39");
            v.Info = "fZlHADgv1VDC4xGQ07SuijvFxAiISrWiY8R3wa4OK8lulTm7hgAu";
            v.Category = DMSFinal.Model.CategoryEnum.International;
            v.IsSCI = DMSFinal.Model.IfEnum.Yes;
            v.SCINo = "wzlAufX8V7CEM3QDSi8";
            v.IsEI = DMSFinal.Model.CategoryEnum.ChineseCore;
            v.EINo = "OUQJqMlm";
            v.IsISTP = DMSFinal.Model.IfEnum.No;
            v.ISTPNo = "TMX2t483XGLLs9z9edq3RzscbIt1SIXZ";
            v.Num = 636269140;
            v.ImpactFactor = 39;
            v.Rank = DMSFinal.Model.RankEnum.Two;
            v.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "ci6Na8rcahpnS";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.PaperTitle", "");
            vm.FC.Add("Entity.MagazineName", "");
            vm.FC.Add("Entity.PublicTime", "");
            vm.FC.Add("Entity.Info", "");
            vm.FC.Add("Entity.Category", "");
            vm.FC.Add("Entity.IsSCI", "");
            vm.FC.Add("Entity.SCINo", "");
            vm.FC.Add("Entity.IsEI", "");
            vm.FC.Add("Entity.EINo", "");
            vm.FC.Add("Entity.IsISTP", "");
            vm.FC.Add("Entity.ISTPNo", "");
            vm.FC.Add("Entity.Num", "");
            vm.FC.Add("Entity.ImpactFactor", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.IsOurSchool", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Paper>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "BeyyGAF8QRsjbEmqKk");
                Assert.AreEqual(data.Name, "BlLUaHXPQDbHZGFI8");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ShiYanShi);
                Assert.AreEqual(data.PaperTitle, "gOlUHiwVZjXaAhYwN1lC6KlRPoPQtZImpV69w9NFMBK3wFp");
                Assert.AreEqual(data.MagazineName, "3nvsfkOSeSL9g8QT63oO");
                Assert.AreEqual(data.PublicTime, DateTime.Parse("2025-03-15 11:04:39"));
                Assert.AreEqual(data.Info, "fZlHADgv1VDC4xGQ07SuijvFxAiISrWiY8R3wa4OK8lulTm7hgAu");
                Assert.AreEqual(data.Category, DMSFinal.Model.CategoryEnum.International);
                Assert.AreEqual(data.IsSCI, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.SCINo, "wzlAufX8V7CEM3QDSi8");
                Assert.AreEqual(data.IsEI, DMSFinal.Model.CategoryEnum.ChineseCore);
                Assert.AreEqual(data.EINo, "OUQJqMlm");
                Assert.AreEqual(data.IsISTP, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.ISTPNo, "TMX2t483XGLLs9z9edq3RzscbIt1SIXZ");
                Assert.AreEqual(data.Num, 636269140);
                Assert.AreEqual(data.ImpactFactor, 39);
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Two);
                Assert.AreEqual(data.IsOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "ci6Na8rcahpnS");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Paper v = new Paper();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "DdE";
                v.Name = "Zl";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v.PaperTitle = "N1EUwg6ivoK5";
                v.MagazineName = "smMzvSH5CCV2NtijvrLep3MxqZJM8w7GDIaNSsXQzBCamOxHaVmuO7czaYIVJ68QG";
                v.PublicTime = DateTime.Parse("2024-05-28 11:04:39");
                v.Info = "0MQarKnsUC17qz4a8Nz4h2ibHSrsfRfoIrOHmvSfx3fuoh";
                v.Category = DMSFinal.Model.CategoryEnum.ChineseCore;
                v.IsSCI = DMSFinal.Model.IfEnum.No;
                v.SCINo = "TjtYJMp3juw2od6DofSxSnLJJhbdwRqDIy0d3U4";
                v.IsEI = DMSFinal.Model.CategoryEnum.ChineseRegular;
                v.EINo = "yu69k6GZsvLVDpg0UuwTb6Vwyb4q2LN4";
                v.IsISTP = DMSFinal.Model.IfEnum.Yes;
                v.ISTPNo = "qFxq6HDQBD8P2WMiFRN8ULMe";
                v.Num = 597084602;
                v.ImpactFactor = 13;
                v.Rank = DMSFinal.Model.RankEnum.Eight;
                v.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "3G";
                context.Set<Paper>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PaperVM));

            PaperVM vm = rv.Model as PaperVM;
            v = new Paper();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Paper>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Paper v = new Paper();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "DdE";
                v.Name = "Zl";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v.PaperTitle = "N1EUwg6ivoK5";
                v.MagazineName = "smMzvSH5CCV2NtijvrLep3MxqZJM8w7GDIaNSsXQzBCamOxHaVmuO7czaYIVJ68QG";
                v.PublicTime = DateTime.Parse("2024-05-28 11:04:39");
                v.Info = "0MQarKnsUC17qz4a8Nz4h2ibHSrsfRfoIrOHmvSfx3fuoh";
                v.Category = DMSFinal.Model.CategoryEnum.ChineseCore;
                v.IsSCI = DMSFinal.Model.IfEnum.No;
                v.SCINo = "TjtYJMp3juw2od6DofSxSnLJJhbdwRqDIy0d3U4";
                v.IsEI = DMSFinal.Model.CategoryEnum.ChineseRegular;
                v.EINo = "yu69k6GZsvLVDpg0UuwTb6Vwyb4q2LN4";
                v.IsISTP = DMSFinal.Model.IfEnum.Yes;
                v.ISTPNo = "qFxq6HDQBD8P2WMiFRN8ULMe";
                v.Num = 597084602;
                v.ImpactFactor = 13;
                v.Rank = DMSFinal.Model.RankEnum.Eight;
                v.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "3G";
                context.Set<Paper>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Paper v1 = new Paper();
            Paper v2 = new Paper();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "DdE";
                v1.Name = "Zl";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v1.PaperTitle = "N1EUwg6ivoK5";
                v1.MagazineName = "smMzvSH5CCV2NtijvrLep3MxqZJM8w7GDIaNSsXQzBCamOxHaVmuO7czaYIVJ68QG";
                v1.PublicTime = DateTime.Parse("2024-05-28 11:04:39");
                v1.Info = "0MQarKnsUC17qz4a8Nz4h2ibHSrsfRfoIrOHmvSfx3fuoh";
                v1.Category = DMSFinal.Model.CategoryEnum.ChineseCore;
                v1.IsSCI = DMSFinal.Model.IfEnum.No;
                v1.SCINo = "TjtYJMp3juw2od6DofSxSnLJJhbdwRqDIy0d3U4";
                v1.IsEI = DMSFinal.Model.CategoryEnum.ChineseRegular;
                v1.EINo = "yu69k6GZsvLVDpg0UuwTb6Vwyb4q2LN4";
                v1.IsISTP = DMSFinal.Model.IfEnum.Yes;
                v1.ISTPNo = "qFxq6HDQBD8P2WMiFRN8ULMe";
                v1.Num = 597084602;
                v1.ImpactFactor = 13;
                v1.Rank = DMSFinal.Model.RankEnum.Eight;
                v1.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "3G";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "BeyyGAF8QRsjbEmqKk";
                v2.Name = "BlLUaHXPQDbHZGFI8";
                v2.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
                v2.PaperTitle = "gOlUHiwVZjXaAhYwN1lC6KlRPoPQtZImpV69w9NFMBK3wFp";
                v2.MagazineName = "3nvsfkOSeSL9g8QT63oO";
                v2.PublicTime = DateTime.Parse("2025-03-15 11:04:39");
                v2.Info = "fZlHADgv1VDC4xGQ07SuijvFxAiISrWiY8R3wa4OK8lulTm7hgAu";
                v2.Category = DMSFinal.Model.CategoryEnum.International;
                v2.IsSCI = DMSFinal.Model.IfEnum.Yes;
                v2.SCINo = "wzlAufX8V7CEM3QDSi8";
                v2.IsEI = DMSFinal.Model.CategoryEnum.ChineseCore;
                v2.EINo = "OUQJqMlm";
                v2.IsISTP = DMSFinal.Model.IfEnum.No;
                v2.ISTPNo = "TMX2t483XGLLs9z9edq3RzscbIt1SIXZ";
                v2.Num = 636269140;
                v2.ImpactFactor = 39;
                v2.Rank = DMSFinal.Model.RankEnum.Two;
                v2.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "ci6Na8rcahpnS";
                context.Set<Paper>().Add(v1);
                context.Set<Paper>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PaperBatchVM));

            PaperBatchVM vm = rv.Model as PaperBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "p14pv7gziFcN6b20f";
            vm.LinkedVM.Name = "LbIlH";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Professor;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
            vm.LinkedVM.PaperTitle = "zIpJvr4R";
            vm.LinkedVM.MagazineName = "c9OGnPnC2Q7x9mcLcSkcEqIlHRGeH8pvlpFvqJGHAbfxZipzYeP5gVjvz";
            vm.LinkedVM.PublicTime = DateTime.Parse("2023-06-17 11:04:39");
            vm.LinkedVM.Info = "p56xR4whLt";
            vm.LinkedVM.Category = DMSFinal.Model.CategoryEnum.International;
            vm.LinkedVM.IsSCI = DMSFinal.Model.IfEnum.No;
            vm.LinkedVM.SCINo = "TeRKpqMmZiS2NnZiFzh7pk3MsC865Cq1j9Fv2e6S2lu7t";
            vm.LinkedVM.IsEI = DMSFinal.Model.CategoryEnum.ChineseCore;
            vm.LinkedVM.EINo = "xbd";
            vm.LinkedVM.IsISTP = DMSFinal.Model.IfEnum.No;
            vm.LinkedVM.ISTPNo = "XkFOEgV3d20kbqSv2SSwPCxLOEOE3Ge";
            vm.LinkedVM.Num = 32571013;
            vm.LinkedVM.ImpactFactor = 98;
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.Five;
            vm.LinkedVM.IsOurSchool = DMSFinal.Model.IfEnum.No;
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.NotPass;
            vm.LinkedVM.Reason = "TRUpHNLjfM";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.PaperTitle", "");
            vm.FC.Add("LinkedVM.MagazineName", "");
            vm.FC.Add("LinkedVM.PublicTime", "");
            vm.FC.Add("LinkedVM.Info", "");
            vm.FC.Add("LinkedVM.Category", "");
            vm.FC.Add("LinkedVM.IsSCI", "");
            vm.FC.Add("LinkedVM.SCINo", "");
            vm.FC.Add("LinkedVM.IsEI", "");
            vm.FC.Add("LinkedVM.EINo", "");
            vm.FC.Add("LinkedVM.IsISTP", "");
            vm.FC.Add("LinkedVM.ISTPNo", "");
            vm.FC.Add("LinkedVM.Num", "");
            vm.FC.Add("LinkedVM.ImpactFactor", "");
            vm.FC.Add("LinkedVM.Rank", "");
            vm.FC.Add("LinkedVM.IsOurSchool", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Paper>().Find(v1.ID);
                var data2 = context.Set<Paper>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "p14pv7gziFcN6b20f");
                Assert.AreEqual(data2.JobNo, "p14pv7gziFcN6b20f");
                Assert.AreEqual(data1.Name, "LbIlH");
                Assert.AreEqual(data2.Name, "LbIlH");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Professor);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Professor);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.AssShiYan);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.AssShiYan);
                Assert.AreEqual(data1.PaperTitle, "zIpJvr4R");
                Assert.AreEqual(data2.PaperTitle, "zIpJvr4R");
                Assert.AreEqual(data1.MagazineName, "c9OGnPnC2Q7x9mcLcSkcEqIlHRGeH8pvlpFvqJGHAbfxZipzYeP5gVjvz");
                Assert.AreEqual(data2.MagazineName, "c9OGnPnC2Q7x9mcLcSkcEqIlHRGeH8pvlpFvqJGHAbfxZipzYeP5gVjvz");
                Assert.AreEqual(data1.PublicTime, DateTime.Parse("2023-06-17 11:04:39"));
                Assert.AreEqual(data2.PublicTime, DateTime.Parse("2023-06-17 11:04:39"));
                Assert.AreEqual(data1.Info, "p56xR4whLt");
                Assert.AreEqual(data2.Info, "p56xR4whLt");
                Assert.AreEqual(data1.Category, DMSFinal.Model.CategoryEnum.International);
                Assert.AreEqual(data2.Category, DMSFinal.Model.CategoryEnum.International);
                Assert.AreEqual(data1.IsSCI, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data2.IsSCI, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data1.SCINo, "TeRKpqMmZiS2NnZiFzh7pk3MsC865Cq1j9Fv2e6S2lu7t");
                Assert.AreEqual(data2.SCINo, "TeRKpqMmZiS2NnZiFzh7pk3MsC865Cq1j9Fv2e6S2lu7t");
                Assert.AreEqual(data1.IsEI, DMSFinal.Model.CategoryEnum.ChineseCore);
                Assert.AreEqual(data2.IsEI, DMSFinal.Model.CategoryEnum.ChineseCore);
                Assert.AreEqual(data1.EINo, "xbd");
                Assert.AreEqual(data2.EINo, "xbd");
                Assert.AreEqual(data1.IsISTP, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data2.IsISTP, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data1.ISTPNo, "XkFOEgV3d20kbqSv2SSwPCxLOEOE3Ge");
                Assert.AreEqual(data2.ISTPNo, "XkFOEgV3d20kbqSv2SSwPCxLOEOE3Ge");
                Assert.AreEqual(data1.Num, 32571013);
                Assert.AreEqual(data2.Num, 32571013);
                Assert.AreEqual(data1.ImpactFactor, 98);
                Assert.AreEqual(data2.ImpactFactor, 98);
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.Five);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.Five);
                Assert.AreEqual(data1.IsOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data2.IsOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data1.Reason, "TRUpHNLjfM");
                Assert.AreEqual(data2.Reason, "TRUpHNLjfM");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Paper v1 = new Paper();
            Paper v2 = new Paper();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "DdE";
                v1.Name = "Zl";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v1.PaperTitle = "N1EUwg6ivoK5";
                v1.MagazineName = "smMzvSH5CCV2NtijvrLep3MxqZJM8w7GDIaNSsXQzBCamOxHaVmuO7czaYIVJ68QG";
                v1.PublicTime = DateTime.Parse("2024-05-28 11:04:39");
                v1.Info = "0MQarKnsUC17qz4a8Nz4h2ibHSrsfRfoIrOHmvSfx3fuoh";
                v1.Category = DMSFinal.Model.CategoryEnum.ChineseCore;
                v1.IsSCI = DMSFinal.Model.IfEnum.No;
                v1.SCINo = "TjtYJMp3juw2od6DofSxSnLJJhbdwRqDIy0d3U4";
                v1.IsEI = DMSFinal.Model.CategoryEnum.ChineseRegular;
                v1.EINo = "yu69k6GZsvLVDpg0UuwTb6Vwyb4q2LN4";
                v1.IsISTP = DMSFinal.Model.IfEnum.Yes;
                v1.ISTPNo = "qFxq6HDQBD8P2WMiFRN8ULMe";
                v1.Num = 597084602;
                v1.ImpactFactor = 13;
                v1.Rank = DMSFinal.Model.RankEnum.Eight;
                v1.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "3G";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "BeyyGAF8QRsjbEmqKk";
                v2.Name = "BlLUaHXPQDbHZGFI8";
                v2.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
                v2.PaperTitle = "gOlUHiwVZjXaAhYwN1lC6KlRPoPQtZImpV69w9NFMBK3wFp";
                v2.MagazineName = "3nvsfkOSeSL9g8QT63oO";
                v2.PublicTime = DateTime.Parse("2025-03-15 11:04:39");
                v2.Info = "fZlHADgv1VDC4xGQ07SuijvFxAiISrWiY8R3wa4OK8lulTm7hgAu";
                v2.Category = DMSFinal.Model.CategoryEnum.International;
                v2.IsSCI = DMSFinal.Model.IfEnum.Yes;
                v2.SCINo = "wzlAufX8V7CEM3QDSi8";
                v2.IsEI = DMSFinal.Model.CategoryEnum.ChineseCore;
                v2.EINo = "OUQJqMlm";
                v2.IsISTP = DMSFinal.Model.IfEnum.No;
                v2.ISTPNo = "TMX2t483XGLLs9z9edq3RzscbIt1SIXZ";
                v2.Num = 636269140;
                v2.ImpactFactor = 39;
                v2.Rank = DMSFinal.Model.RankEnum.Two;
                v2.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "ci6Na8rcahpnS";
                context.Set<Paper>().Add(v1);
                context.Set<Paper>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PaperBatchVM));

            PaperBatchVM vm = rv.Model as PaperBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Paper>().Find(v1.ID);
                var data2 = context.Set<Paper>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
