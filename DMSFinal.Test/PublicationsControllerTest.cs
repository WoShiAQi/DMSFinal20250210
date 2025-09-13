using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.PublicationsVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class PublicationsControllerTest
    {
        private PublicationsController _controller;
        private string _seed;

        public PublicationsControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PublicationsController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as PublicationsListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PublicationsVM));

            PublicationsVM vm = rv.Model as PublicationsVM;
            Publications v = new Publications();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.Name = "oPrmiX";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
            v.PublicationForm = DMSFinal.Model.PublicationEnum.Textbook;
            v.PublicationName = "1P5zXlQEmtYxPgAbcKaRJKbWLpiTdtfrJD";
            v.Press = "LgCxgT7VUABENlZ";
            v.PublicationTime = DateTime.Parse("2024-11-17 11:00:14");
            v.WriteWordCount = 36;
            v.BookNo = "SccaV";
            v.Rank = DMSFinal.Model.RankEnum.Two;
            v.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.JobNo = "yCtx7BgN7A2R93";
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "aiNa8r90ofo09nRAyo";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Publications>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.Name, "oPrmiX");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ShiYanYuan);
                Assert.AreEqual(data.PublicationForm, DMSFinal.Model.PublicationEnum.Textbook);
                Assert.AreEqual(data.PublicationName, "1P5zXlQEmtYxPgAbcKaRJKbWLpiTdtfrJD");
                Assert.AreEqual(data.Press, "LgCxgT7VUABENlZ");
                Assert.AreEqual(data.PublicationTime, DateTime.Parse("2024-11-17 11:00:14"));
                Assert.AreEqual(data.WriteWordCount, 36);
                Assert.AreEqual(data.BookNo, "SccaV");
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Two);
                Assert.AreEqual(data.IsOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.JobNo, "yCtx7BgN7A2R93");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "aiNa8r90ofo09nRAyo");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Publications v = new Publications();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "oPrmiX";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
                v.PublicationForm = DMSFinal.Model.PublicationEnum.Textbook;
                v.PublicationName = "1P5zXlQEmtYxPgAbcKaRJKbWLpiTdtfrJD";
                v.Press = "LgCxgT7VUABENlZ";
                v.PublicationTime = DateTime.Parse("2024-11-17 11:00:14");
                v.WriteWordCount = 36;
                v.BookNo = "SccaV";
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.JobNo = "yCtx7BgN7A2R93";
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "aiNa8r90ofo09nRAyo";
                context.Set<Publications>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PublicationsVM));

            PublicationsVM vm = rv.Model as PublicationsVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Publications();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.Name = "RJxdv";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
            v.PublicationForm = DMSFinal.Model.PublicationEnum.Translation;
            v.PublicationName = "bQGjEtRkJNc35YoERocMyfihEQRsRTRs";
            v.Press = "6swks1G12gMCa1RvbpE7yV5gBDEHX1oCP";
            v.PublicationTime = DateTime.Parse("2023-06-25 11:00:14");
            v.WriteWordCount = 66;
            v.BookNo = "yVqXeRzSGj1d";
            v.Rank = DMSFinal.Model.RankEnum.Ten;
            v.IsOurSchool = DMSFinal.Model.IfEnum.No;
            v.JobNo = "P";
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "6Q3lCxO7Tokd";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.PublicationForm", "");
            vm.FC.Add("Entity.PublicationName", "");
            vm.FC.Add("Entity.Press", "");
            vm.FC.Add("Entity.PublicationTime", "");
            vm.FC.Add("Entity.WriteWordCount", "");
            vm.FC.Add("Entity.BookNo", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.IsOurSchool", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Publications>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.Name, "RJxdv");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.AssShiYan);
                Assert.AreEqual(data.PublicationForm, DMSFinal.Model.PublicationEnum.Translation);
                Assert.AreEqual(data.PublicationName, "bQGjEtRkJNc35YoERocMyfihEQRsRTRs");
                Assert.AreEqual(data.Press, "6swks1G12gMCa1RvbpE7yV5gBDEHX1oCP");
                Assert.AreEqual(data.PublicationTime, DateTime.Parse("2023-06-25 11:00:14"));
                Assert.AreEqual(data.WriteWordCount, 66);
                Assert.AreEqual(data.BookNo, "yVqXeRzSGj1d");
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Ten);
                Assert.AreEqual(data.IsOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.JobNo, "P");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "6Q3lCxO7Tokd");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Publications v = new Publications();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "oPrmiX";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
                v.PublicationForm = DMSFinal.Model.PublicationEnum.Textbook;
                v.PublicationName = "1P5zXlQEmtYxPgAbcKaRJKbWLpiTdtfrJD";
                v.Press = "LgCxgT7VUABENlZ";
                v.PublicationTime = DateTime.Parse("2024-11-17 11:00:14");
                v.WriteWordCount = 36;
                v.BookNo = "SccaV";
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.JobNo = "yCtx7BgN7A2R93";
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "aiNa8r90ofo09nRAyo";
                context.Set<Publications>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PublicationsVM));

            PublicationsVM vm = rv.Model as PublicationsVM;
            v = new Publications();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Publications>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Publications v = new Publications();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "oPrmiX";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
                v.PublicationForm = DMSFinal.Model.PublicationEnum.Textbook;
                v.PublicationName = "1P5zXlQEmtYxPgAbcKaRJKbWLpiTdtfrJD";
                v.Press = "LgCxgT7VUABENlZ";
                v.PublicationTime = DateTime.Parse("2024-11-17 11:00:14");
                v.WriteWordCount = 36;
                v.BookNo = "SccaV";
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.JobNo = "yCtx7BgN7A2R93";
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "aiNa8r90ofo09nRAyo";
                context.Set<Publications>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Publications v1 = new Publications();
            Publications v2 = new Publications();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.Name = "oPrmiX";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
                v1.PublicationForm = DMSFinal.Model.PublicationEnum.Textbook;
                v1.PublicationName = "1P5zXlQEmtYxPgAbcKaRJKbWLpiTdtfrJD";
                v1.Press = "LgCxgT7VUABENlZ";
                v1.PublicationTime = DateTime.Parse("2024-11-17 11:00:14");
                v1.WriteWordCount = 36;
                v1.BookNo = "SccaV";
                v1.Rank = DMSFinal.Model.RankEnum.Two;
                v1.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v1.JobNo = "yCtx7BgN7A2R93";
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "aiNa8r90ofo09nRAyo";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.Name = "RJxdv";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v2.PublicationForm = DMSFinal.Model.PublicationEnum.Translation;
                v2.PublicationName = "bQGjEtRkJNc35YoERocMyfihEQRsRTRs";
                v2.Press = "6swks1G12gMCa1RvbpE7yV5gBDEHX1oCP";
                v2.PublicationTime = DateTime.Parse("2023-06-25 11:00:14");
                v2.WriteWordCount = 66;
                v2.BookNo = "yVqXeRzSGj1d";
                v2.Rank = DMSFinal.Model.RankEnum.Ten;
                v2.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v2.JobNo = "P";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "6Q3lCxO7Tokd";
                context.Set<Publications>().Add(v1);
                context.Set<Publications>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PublicationsBatchVM));

            PublicationsBatchVM vm = rv.Model as PublicationsBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.Name = "NPsm0gBFodsgaebU";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.GaoJi;
            vm.LinkedVM.PublicationForm = DMSFinal.Model.PublicationEnum.Translation;
            vm.LinkedVM.PublicationName = "AUDWPbrl8nuRBYDY7Dw4jhUVpnqjX09jC73b8MJ6";
            vm.LinkedVM.Press = "c3T57APl4JfRoO51UeGXDrZzM0KX7IsW91N";
            vm.LinkedVM.PublicationTime = DateTime.Parse("2024-09-19 11:00:14");
            vm.LinkedVM.WriteWordCount = 7;
            vm.LinkedVM.BookNo = "sExeihNJAzFok2";
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.Nine;
            vm.LinkedVM.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
            vm.LinkedVM.JobNo = "xCs05S0GCGkz";
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Pass;
            vm.LinkedVM.Reason = "Hxjzga36awOY9kU";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.PublicationForm", "");
            vm.FC.Add("LinkedVM.PublicationName", "");
            vm.FC.Add("LinkedVM.Press", "");
            vm.FC.Add("LinkedVM.PublicationTime", "");
            vm.FC.Add("LinkedVM.WriteWordCount", "");
            vm.FC.Add("LinkedVM.BookNo", "");
            vm.FC.Add("LinkedVM.Rank", "");
            vm.FC.Add("LinkedVM.IsOurSchool", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Publications>().Find(v1.ID);
                var data2 = context.Set<Publications>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.Name, "NPsm0gBFodsgaebU");
                Assert.AreEqual(data2.Name, "NPsm0gBFodsgaebU");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.GaoJi);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.GaoJi);
                Assert.AreEqual(data1.PublicationForm, DMSFinal.Model.PublicationEnum.Translation);
                Assert.AreEqual(data2.PublicationForm, DMSFinal.Model.PublicationEnum.Translation);
                Assert.AreEqual(data1.PublicationName, "AUDWPbrl8nuRBYDY7Dw4jhUVpnqjX09jC73b8MJ6");
                Assert.AreEqual(data2.PublicationName, "AUDWPbrl8nuRBYDY7Dw4jhUVpnqjX09jC73b8MJ6");
                Assert.AreEqual(data1.Press, "c3T57APl4JfRoO51UeGXDrZzM0KX7IsW91N");
                Assert.AreEqual(data2.Press, "c3T57APl4JfRoO51UeGXDrZzM0KX7IsW91N");
                Assert.AreEqual(data1.PublicationTime, DateTime.Parse("2024-09-19 11:00:14"));
                Assert.AreEqual(data2.PublicationTime, DateTime.Parse("2024-09-19 11:00:14"));
                Assert.AreEqual(data1.WriteWordCount, 7);
                Assert.AreEqual(data2.WriteWordCount, 7);
                Assert.AreEqual(data1.BookNo, "sExeihNJAzFok2");
                Assert.AreEqual(data2.BookNo, "sExeihNJAzFok2");
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.Nine);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.Nine);
                Assert.AreEqual(data1.IsOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data2.IsOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data1.JobNo, "xCs05S0GCGkz");
                Assert.AreEqual(data2.JobNo, "xCs05S0GCGkz");
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data1.Reason, "Hxjzga36awOY9kU");
                Assert.AreEqual(data2.Reason, "Hxjzga36awOY9kU");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Publications v1 = new Publications();
            Publications v2 = new Publications();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.Name = "oPrmiX";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
                v1.PublicationForm = DMSFinal.Model.PublicationEnum.Textbook;
                v1.PublicationName = "1P5zXlQEmtYxPgAbcKaRJKbWLpiTdtfrJD";
                v1.Press = "LgCxgT7VUABENlZ";
                v1.PublicationTime = DateTime.Parse("2024-11-17 11:00:14");
                v1.WriteWordCount = 36;
                v1.BookNo = "SccaV";
                v1.Rank = DMSFinal.Model.RankEnum.Two;
                v1.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v1.JobNo = "yCtx7BgN7A2R93";
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "aiNa8r90ofo09nRAyo";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.Name = "RJxdv";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v2.PublicationForm = DMSFinal.Model.PublicationEnum.Translation;
                v2.PublicationName = "bQGjEtRkJNc35YoERocMyfihEQRsRTRs";
                v2.Press = "6swks1G12gMCa1RvbpE7yV5gBDEHX1oCP";
                v2.PublicationTime = DateTime.Parse("2023-06-25 11:00:14");
                v2.WriteWordCount = 66;
                v2.BookNo = "yVqXeRzSGj1d";
                v2.Rank = DMSFinal.Model.RankEnum.Ten;
                v2.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v2.JobNo = "P";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "6Q3lCxO7Tokd";
                context.Set<Publications>().Add(v1);
                context.Set<Publications>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PublicationsBatchVM));

            PublicationsBatchVM vm = rv.Model as PublicationsBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Publications>().Find(v1.ID);
                var data2 = context.Set<Publications>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
