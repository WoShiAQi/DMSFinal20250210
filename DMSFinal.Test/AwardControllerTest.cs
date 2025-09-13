using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.AwardVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class AwardControllerTest
    {
        private AwardController _controller;
        private string _seed;

        public AwardControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<AwardController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as AwardListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(AwardVM));

            AwardVM vm = rv.Model as AwardVM;
            Award v = new Award();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "XzBcZMU79rIvf";
            v.Name = "rpd";
            v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
            v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
            v.Topic = "mHrsrGJ2qmQXHPI7ThwrtA2JWLqyiGKQSzyUXBTEJjCK";
            v.AwardNo = "4Vqma";
            v.RewardName = "ScNXFGxEhtJr3lCnwMDqoIR1a7IbPmZH78d8zEfXFwoVwJv6KX";
            v.AwardingUnit = "OHyUweKxj";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.SchoolOne;
            v.RewardTime = DateTime.Parse("2025-05-13 10:58:18");
            v.Rank = DMSFinal.Model.RankEnum.Other;
            v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "vm0uiW";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Award>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "XzBcZMU79rIvf");
                Assert.AreEqual(data.Name, "rpd");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.noTitle);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ZhengGaoShiYan);
                Assert.AreEqual(data.Topic, "mHrsrGJ2qmQXHPI7ThwrtA2JWLqyiGKQSzyUXBTEJjCK");
                Assert.AreEqual(data.AwardNo, "4Vqma");
                Assert.AreEqual(data.RewardName, "ScNXFGxEhtJr3lCnwMDqoIR1a7IbPmZH78d8zEfXFwoVwJv6KX");
                Assert.AreEqual(data.AwardingUnit, "OHyUweKxj");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.SchoolOne);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2025-05-13 10:58:18"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Other);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "vm0uiW");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Award v = new Award();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "XzBcZMU79rIvf";
                v.Name = "rpd";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v.Topic = "mHrsrGJ2qmQXHPI7ThwrtA2JWLqyiGKQSzyUXBTEJjCK";
                v.AwardNo = "4Vqma";
                v.RewardName = "ScNXFGxEhtJr3lCnwMDqoIR1a7IbPmZH78d8zEfXFwoVwJv6KX";
                v.AwardingUnit = "OHyUweKxj";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.SchoolOne;
                v.RewardTime = DateTime.Parse("2025-05-13 10:58:18");
                v.Rank = DMSFinal.Model.RankEnum.Other;
                v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "vm0uiW";
                context.Set<Award>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AwardVM));

            AwardVM vm = rv.Model as AwardVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Award();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "9VCwK371";
            v.Name = "qY3SIHcjeXUoB";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
            v.Topic = "9f8yyIgTBXYwc8lleEK";
            v.AwardNo = "XqzXEzPnm4229DLmoNm37CQVblwL4KP9QMhwXWUWTGIhhaIr";
            v.RewardName = "N4XUbIW3WN9cJY5wALNK3gv5yG6t9vBwy";
            v.AwardingUnit = "bnne0jVUqLXwXyFWJHNCCXOVGaFkLdPs";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceTwo;
            v.RewardTime = DateTime.Parse("2025-05-26 10:58:18");
            v.Rank = DMSFinal.Model.RankEnum.Five;
            v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.Examine = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "a75A";
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
                var data = context.Set<Award>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "9VCwK371");
                Assert.AreEqual(data.Name, "qY3SIHcjeXUoB");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ZhengGaoShiYan);
                Assert.AreEqual(data.Topic, "9f8yyIgTBXYwc8lleEK");
                Assert.AreEqual(data.AwardNo, "XqzXEzPnm4229DLmoNm37CQVblwL4KP9QMhwXWUWTGIhhaIr");
                Assert.AreEqual(data.RewardName, "N4XUbIW3WN9cJY5wALNK3gv5yG6t9vBwy");
                Assert.AreEqual(data.AwardingUnit, "bnne0jVUqLXwXyFWJHNCCXOVGaFkLdPs");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.ProvinceTwo);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2025-05-26 10:58:18"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Five);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "a75A");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Award v = new Award();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "XzBcZMU79rIvf";
                v.Name = "rpd";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v.Topic = "mHrsrGJ2qmQXHPI7ThwrtA2JWLqyiGKQSzyUXBTEJjCK";
                v.AwardNo = "4Vqma";
                v.RewardName = "ScNXFGxEhtJr3lCnwMDqoIR1a7IbPmZH78d8zEfXFwoVwJv6KX";
                v.AwardingUnit = "OHyUweKxj";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.SchoolOne;
                v.RewardTime = DateTime.Parse("2025-05-13 10:58:18");
                v.Rank = DMSFinal.Model.RankEnum.Other;
                v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "vm0uiW";
                context.Set<Award>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AwardVM));

            AwardVM vm = rv.Model as AwardVM;
            v = new Award();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Award>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Award v = new Award();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "XzBcZMU79rIvf";
                v.Name = "rpd";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v.Topic = "mHrsrGJ2qmQXHPI7ThwrtA2JWLqyiGKQSzyUXBTEJjCK";
                v.AwardNo = "4Vqma";
                v.RewardName = "ScNXFGxEhtJr3lCnwMDqoIR1a7IbPmZH78d8zEfXFwoVwJv6KX";
                v.AwardingUnit = "OHyUweKxj";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.SchoolOne;
                v.RewardTime = DateTime.Parse("2025-05-13 10:58:18");
                v.Rank = DMSFinal.Model.RankEnum.Other;
                v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "vm0uiW";
                context.Set<Award>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Award v1 = new Award();
            Award v2 = new Award();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "XzBcZMU79rIvf";
                v1.Name = "rpd";
                v1.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v1.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v1.Topic = "mHrsrGJ2qmQXHPI7ThwrtA2JWLqyiGKQSzyUXBTEJjCK";
                v1.AwardNo = "4Vqma";
                v1.RewardName = "ScNXFGxEhtJr3lCnwMDqoIR1a7IbPmZH78d8zEfXFwoVwJv6KX";
                v1.AwardingUnit = "OHyUweKxj";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.SchoolOne;
                v1.RewardTime = DateTime.Parse("2025-05-13 10:58:18");
                v1.Rank = DMSFinal.Model.RankEnum.Other;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "vm0uiW";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "9VCwK371";
                v2.Name = "qY3SIHcjeXUoB";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v2.Topic = "9f8yyIgTBXYwc8lleEK";
                v2.AwardNo = "XqzXEzPnm4229DLmoNm37CQVblwL4KP9QMhwXWUWTGIhhaIr";
                v2.RewardName = "N4XUbIW3WN9cJY5wALNK3gv5yG6t9vBwy";
                v2.AwardingUnit = "bnne0jVUqLXwXyFWJHNCCXOVGaFkLdPs";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceTwo;
                v2.RewardTime = DateTime.Parse("2025-05-26 10:58:18");
                v2.Rank = DMSFinal.Model.RankEnum.Five;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "a75A";
                context.Set<Award>().Add(v1);
                context.Set<Award>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(AwardBatchVM));

            AwardBatchVM vm = rv.Model as AwardBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "82";
            vm.LinkedVM.Name = "LZloe8joDUFN6cb";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
            vm.LinkedVM.Topic = "iPyeKopWPo3rHO998s9eoe1ib6E8H4";
            vm.LinkedVM.AwardNo = "evqA4vydSV7iy1dewaMSeXGCtZOCNfFNtudCaymyO3Fz1yyXi5s8joTGooQehvQxPszEWaE8xXElRQ";
            vm.LinkedVM.RewardName = "x6LWf0PLv8Fcn7V8smisK3hsXO1pNJLBRlgAgKPeplmgROGYnQPSHI65Yd9QIk9lwEKCaUbi";
            vm.LinkedVM.AwardingUnit = "3BApavGGUeoBwpsNs0yMMF7F3hUzuOYJY6f";
            vm.LinkedVM.AwardLevel = DMSFinal.Model.AwardLevelEnum.SchoolOne;
            vm.LinkedVM.RewardTime = DateTime.Parse("2023-09-28 10:58:18");
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.Seven;
            vm.LinkedVM.IfOurSchool = DMSFinal.Model.IfEnum.No;
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Checking;
            vm.LinkedVM.Reason = "BrO3VfG6JOYOZY3Y";
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
                var data1 = context.Set<Award>().Find(v1.ID);
                var data2 = context.Set<Award>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "82");
                Assert.AreEqual(data2.JobNo, "82");
                Assert.AreEqual(data1.Name, "LZloe8joDUFN6cb");
                Assert.AreEqual(data2.Name, "LZloe8joDUFN6cb");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.ShiYanYuan);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.ShiYanYuan);
                Assert.AreEqual(data1.Topic, "iPyeKopWPo3rHO998s9eoe1ib6E8H4");
                Assert.AreEqual(data2.Topic, "iPyeKopWPo3rHO998s9eoe1ib6E8H4");
                Assert.AreEqual(data1.AwardNo, "evqA4vydSV7iy1dewaMSeXGCtZOCNfFNtudCaymyO3Fz1yyXi5s8joTGooQehvQxPszEWaE8xXElRQ");
                Assert.AreEqual(data2.AwardNo, "evqA4vydSV7iy1dewaMSeXGCtZOCNfFNtudCaymyO3Fz1yyXi5s8joTGooQehvQxPszEWaE8xXElRQ");
                Assert.AreEqual(data1.RewardName, "x6LWf0PLv8Fcn7V8smisK3hsXO1pNJLBRlgAgKPeplmgROGYnQPSHI65Yd9QIk9lwEKCaUbi");
                Assert.AreEqual(data2.RewardName, "x6LWf0PLv8Fcn7V8smisK3hsXO1pNJLBRlgAgKPeplmgROGYnQPSHI65Yd9QIk9lwEKCaUbi");
                Assert.AreEqual(data1.AwardingUnit, "3BApavGGUeoBwpsNs0yMMF7F3hUzuOYJY6f");
                Assert.AreEqual(data2.AwardingUnit, "3BApavGGUeoBwpsNs0yMMF7F3hUzuOYJY6f");
                Assert.AreEqual(data1.AwardLevel, DMSFinal.Model.AwardLevelEnum.SchoolOne);
                Assert.AreEqual(data2.AwardLevel, DMSFinal.Model.AwardLevelEnum.SchoolOne);
                Assert.AreEqual(data1.RewardTime, DateTime.Parse("2023-09-28 10:58:18"));
                Assert.AreEqual(data2.RewardTime, DateTime.Parse("2023-09-28 10:58:18"));
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.Seven);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.Seven);
                Assert.AreEqual(data1.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data2.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data1.Reason, "BrO3VfG6JOYOZY3Y");
                Assert.AreEqual(data2.Reason, "BrO3VfG6JOYOZY3Y");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Award v1 = new Award();
            Award v2 = new Award();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "XzBcZMU79rIvf";
                v1.Name = "rpd";
                v1.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v1.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v1.Topic = "mHrsrGJ2qmQXHPI7ThwrtA2JWLqyiGKQSzyUXBTEJjCK";
                v1.AwardNo = "4Vqma";
                v1.RewardName = "ScNXFGxEhtJr3lCnwMDqoIR1a7IbPmZH78d8zEfXFwoVwJv6KX";
                v1.AwardingUnit = "OHyUweKxj";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.SchoolOne;
                v1.RewardTime = DateTime.Parse("2025-05-13 10:58:18");
                v1.Rank = DMSFinal.Model.RankEnum.Other;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "vm0uiW";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "9VCwK371";
                v2.Name = "qY3SIHcjeXUoB";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
                v2.Topic = "9f8yyIgTBXYwc8lleEK";
                v2.AwardNo = "XqzXEzPnm4229DLmoNm37CQVblwL4KP9QMhwXWUWTGIhhaIr";
                v2.RewardName = "N4XUbIW3WN9cJY5wALNK3gv5yG6t9vBwy";
                v2.AwardingUnit = "bnne0jVUqLXwXyFWJHNCCXOVGaFkLdPs";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceTwo;
                v2.RewardTime = DateTime.Parse("2025-05-26 10:58:18");
                v2.Rank = DMSFinal.Model.RankEnum.Five;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "a75A";
                context.Set<Award>().Add(v1);
                context.Set<Award>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(AwardBatchVM));

            AwardBatchVM vm = rv.Model as AwardBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Award>().Find(v1.ID);
                var data2 = context.Set<Award>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
