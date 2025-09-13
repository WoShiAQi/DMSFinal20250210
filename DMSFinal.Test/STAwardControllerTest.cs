using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.STAwardVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class STAwardControllerTest
    {
        private STAwardController _controller;
        private string _seed;

        public STAwardControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<STAwardController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as STAwardListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(STAwardVM));

            STAwardVM vm = rv.Model as STAwardVM;
            STAward v = new STAward();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "QTIG";
            v.Name = "tYtmwrPtArCdtb7dtc";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
            v.Topic = "ROZlO0SzuxstyfR3Nd6iyWb2AoKzw8KO0OSncpJMI5pkEMhfpyxWTYR5xhkjy";
            v.AwardNo = "XmNgOwR7l8SBhh065nI1eZnq4y02";
            v.RewardName = DMSFinal.Model.RewardEnum.Jin;
            v.AwardingUnit = "htaaZr9Sgfo";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
            v.RewardTime = DateTime.Parse("2024-11-03 11:07:32");
            v.Rank = DMSFinal.Model.RankEnum.One;
            v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "Y5Dz";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<STAward>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "QTIG");
                Assert.AreEqual(data.Name, "tYtmwrPtArCdtb7dtc");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.AssShiYan);
                Assert.AreEqual(data.Topic, "ROZlO0SzuxstyfR3Nd6iyWb2AoKzw8KO0OSncpJMI5pkEMhfpyxWTYR5xhkjy");
                Assert.AreEqual(data.AwardNo, "XmNgOwR7l8SBhh065nI1eZnq4y02");
                Assert.AreEqual(data.RewardName, DMSFinal.Model.RewardEnum.Jin);
                Assert.AreEqual(data.AwardingUnit, "htaaZr9Sgfo");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.NationalOne);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2024-11-03 11:07:32"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.One);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "Y5Dz");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            STAward v = new STAward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "QTIG";
                v.Name = "tYtmwrPtArCdtb7dtc";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v.Topic = "ROZlO0SzuxstyfR3Nd6iyWb2AoKzw8KO0OSncpJMI5pkEMhfpyxWTYR5xhkjy";
                v.AwardNo = "XmNgOwR7l8SBhh065nI1eZnq4y02";
                v.RewardName = DMSFinal.Model.RewardEnum.Jin;
                v.AwardingUnit = "htaaZr9Sgfo";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
                v.RewardTime = DateTime.Parse("2024-11-03 11:07:32");
                v.Rank = DMSFinal.Model.RankEnum.One;
                v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "Y5Dz";
                context.Set<STAward>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(STAwardVM));

            STAwardVM vm = rv.Model as STAwardVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new STAward();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "9yD4MMHoT9Qav";
            v.Name = "HhkYk0oBBeYDO";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
            v.Topic = "VM2w8M2SpEWnZGZYc80JEEfJ4bBBNDBwXaQagQ5DE8LgYvJKW";
            v.AwardNo = "GBQkhWX27T7gtD58xYupGbbn1UFGX9YaJfTvwY25jm0vg";
            v.RewardName = DMSFinal.Model.RewardEnum.Family;
            v.AwardingUnit = "rXndO7Nb1h32Bxc";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
            v.RewardTime = DateTime.Parse("2024-07-15 11:07:32");
            v.Rank = DMSFinal.Model.RankEnum.One;
            v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "eo9XcymT62TUyDbRHh9";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.Topic", "");
            vm.FC.Add("Entity.AwardNo", "");
            vm.FC.Add("Entity.RewardName", "");
            vm.FC.Add("Entity.AwardingUnit", "");
            vm.FC.Add("Entity.AwardLevel", "");
            vm.FC.Add("Entity.RewardTime", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.IfOurSchool", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<STAward>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "9yD4MMHoT9Qav");
                Assert.AreEqual(data.Name, "HhkYk0oBBeYDO");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ZhengGaoShiYan);
                Assert.AreEqual(data.Topic, "VM2w8M2SpEWnZGZYc80JEEfJ4bBBNDBwXaQagQ5DE8LgYvJKW");
                Assert.AreEqual(data.AwardNo, "GBQkhWX27T7gtD58xYupGbbn1UFGX9YaJfTvwY25jm0vg");
                Assert.AreEqual(data.RewardName, DMSFinal.Model.RewardEnum.Family);
                Assert.AreEqual(data.AwardingUnit, "rXndO7Nb1h32Bxc");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.NationalOne);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2024-07-15 11:07:32"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.One);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "eo9XcymT62TUyDbRHh9");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            STAward v = new STAward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "QTIG";
                v.Name = "tYtmwrPtArCdtb7dtc";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v.Topic = "ROZlO0SzuxstyfR3Nd6iyWb2AoKzw8KO0OSncpJMI5pkEMhfpyxWTYR5xhkjy";
                v.AwardNo = "XmNgOwR7l8SBhh065nI1eZnq4y02";
                v.RewardName = DMSFinal.Model.RewardEnum.Jin;
                v.AwardingUnit = "htaaZr9Sgfo";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
                v.RewardTime = DateTime.Parse("2024-11-03 11:07:32");
                v.Rank = DMSFinal.Model.RankEnum.One;
                v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "Y5Dz";
                context.Set<STAward>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(STAwardVM));

            STAwardVM vm = rv.Model as STAwardVM;
            v = new STAward();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<STAward>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            STAward v = new STAward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "QTIG";
                v.Name = "tYtmwrPtArCdtb7dtc";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v.Topic = "ROZlO0SzuxstyfR3Nd6iyWb2AoKzw8KO0OSncpJMI5pkEMhfpyxWTYR5xhkjy";
                v.AwardNo = "XmNgOwR7l8SBhh065nI1eZnq4y02";
                v.RewardName = DMSFinal.Model.RewardEnum.Jin;
                v.AwardingUnit = "htaaZr9Sgfo";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
                v.RewardTime = DateTime.Parse("2024-11-03 11:07:32");
                v.Rank = DMSFinal.Model.RankEnum.One;
                v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "Y5Dz";
                context.Set<STAward>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            STAward v1 = new STAward();
            STAward v2 = new STAward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "QTIG";
                v1.Name = "tYtmwrPtArCdtb7dtc";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v1.Topic = "ROZlO0SzuxstyfR3Nd6iyWb2AoKzw8KO0OSncpJMI5pkEMhfpyxWTYR5xhkjy";
                v1.AwardNo = "XmNgOwR7l8SBhh065nI1eZnq4y02";
                v1.RewardName = DMSFinal.Model.RewardEnum.Jin;
                v1.AwardingUnit = "htaaZr9Sgfo";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
                v1.RewardTime = DateTime.Parse("2024-11-03 11:07:32");
                v1.Rank = DMSFinal.Model.RankEnum.One;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "Y5Dz";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "9yD4MMHoT9Qav";
                v2.Name = "HhkYk0oBBeYDO";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v2.Topic = "VM2w8M2SpEWnZGZYc80JEEfJ4bBBNDBwXaQagQ5DE8LgYvJKW";
                v2.AwardNo = "GBQkhWX27T7gtD58xYupGbbn1UFGX9YaJfTvwY25jm0vg";
                v2.RewardName = DMSFinal.Model.RewardEnum.Family;
                v2.AwardingUnit = "rXndO7Nb1h32Bxc";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
                v2.RewardTime = DateTime.Parse("2024-07-15 11:07:32");
                v2.Rank = DMSFinal.Model.RankEnum.One;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "eo9XcymT62TUyDbRHh9";
                context.Set<STAward>().Add(v1);
                context.Set<STAward>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(STAwardBatchVM));

            STAwardBatchVM vm = rv.Model as STAwardBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "YRo0IgV03pu6X2G8";
            vm.LinkedVM.Name = "GeVazY4IAO";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            vm.LinkedVM.Topic = "550Bl2H";
            vm.LinkedVM.AwardNo = "UIm2ZiYWHgtcf2Bt4Tec82mLhLOnPANF4XurgbeVvtq9OfEhfQ3gZ";
            vm.LinkedVM.RewardName = DMSFinal.Model.RewardEnum.Family;
            vm.LinkedVM.AwardingUnit = "XXmjjPQQbLCwTdsS36SGIfL7BslPOFhK7UE";
            vm.LinkedVM.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalTwo;
            vm.LinkedVM.RewardTime = DateTime.Parse("2023-06-13 11:07:32");
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.One;
            vm.LinkedVM.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.NotPass;
            vm.LinkedVM.Reason = "3bibkc3TC4Bw2akuZM8";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.Topic", "");
            vm.FC.Add("LinkedVM.AwardNo", "");
            vm.FC.Add("LinkedVM.RewardName", "");
            vm.FC.Add("LinkedVM.AwardingUnit", "");
            vm.FC.Add("LinkedVM.AwardLevel", "");
            vm.FC.Add("LinkedVM.RewardTime", "");
            vm.FC.Add("LinkedVM.Rank", "");
            vm.FC.Add("LinkedVM.IfOurSchool", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<STAward>().Find(v1.ID);
                var data2 = context.Set<STAward>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "YRo0IgV03pu6X2G8");
                Assert.AreEqual(data2.JobNo, "YRo0IgV03pu6X2G8");
                Assert.AreEqual(data1.Name, "GeVazY4IAO");
                Assert.AreEqual(data2.Name, "GeVazY4IAO");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data1.Topic, "550Bl2H");
                Assert.AreEqual(data2.Topic, "550Bl2H");
                Assert.AreEqual(data1.AwardNo, "UIm2ZiYWHgtcf2Bt4Tec82mLhLOnPANF4XurgbeVvtq9OfEhfQ3gZ");
                Assert.AreEqual(data2.AwardNo, "UIm2ZiYWHgtcf2Bt4Tec82mLhLOnPANF4XurgbeVvtq9OfEhfQ3gZ");
                Assert.AreEqual(data1.RewardName, DMSFinal.Model.RewardEnum.Family);
                Assert.AreEqual(data2.RewardName, DMSFinal.Model.RewardEnum.Family);
                Assert.AreEqual(data1.AwardingUnit, "XXmjjPQQbLCwTdsS36SGIfL7BslPOFhK7UE");
                Assert.AreEqual(data2.AwardingUnit, "XXmjjPQQbLCwTdsS36SGIfL7BslPOFhK7UE");
                Assert.AreEqual(data1.AwardLevel, DMSFinal.Model.AwardLevelEnum.NationalTwo);
                Assert.AreEqual(data2.AwardLevel, DMSFinal.Model.AwardLevelEnum.NationalTwo);
                Assert.AreEqual(data1.RewardTime, DateTime.Parse("2023-06-13 11:07:32"));
                Assert.AreEqual(data2.RewardTime, DateTime.Parse("2023-06-13 11:07:32"));
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.One);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.One);
                Assert.AreEqual(data1.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data2.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data1.Reason, "3bibkc3TC4Bw2akuZM8");
                Assert.AreEqual(data2.Reason, "3bibkc3TC4Bw2akuZM8");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            STAward v1 = new STAward();
            STAward v2 = new STAward();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "QTIG";
                v1.Name = "tYtmwrPtArCdtb7dtc";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v1.Topic = "ROZlO0SzuxstyfR3Nd6iyWb2AoKzw8KO0OSncpJMI5pkEMhfpyxWTYR5xhkjy";
                v1.AwardNo = "XmNgOwR7l8SBhh065nI1eZnq4y02";
                v1.RewardName = DMSFinal.Model.RewardEnum.Jin;
                v1.AwardingUnit = "htaaZr9Sgfo";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
                v1.RewardTime = DateTime.Parse("2024-11-03 11:07:32");
                v1.Rank = DMSFinal.Model.RankEnum.One;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "Y5Dz";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "9yD4MMHoT9Qav";
                v2.Name = "HhkYk0oBBeYDO";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v2.Topic = "VM2w8M2SpEWnZGZYc80JEEfJ4bBBNDBwXaQagQ5DE8LgYvJKW";
                v2.AwardNo = "GBQkhWX27T7gtD58xYupGbbn1UFGX9YaJfTvwY25jm0vg";
                v2.RewardName = DMSFinal.Model.RewardEnum.Family;
                v2.AwardingUnit = "rXndO7Nb1h32Bxc";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalOne;
                v2.RewardTime = DateTime.Parse("2024-07-15 11:07:32");
                v2.Rank = DMSFinal.Model.RankEnum.One;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "eo9XcymT62TUyDbRHh9";
                context.Set<STAward>().Add(v1);
                context.Set<STAward>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(STAwardBatchVM));

            STAwardBatchVM vm = rv.Model as STAwardBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<STAward>().Find(v1.ID);
                var data2 = context.Set<STAward>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
