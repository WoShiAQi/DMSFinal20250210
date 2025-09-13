using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.TeacherCompetitionVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class TeacherCompetitionControllerTest
    {
        private TeacherCompetitionController _controller;
        private string _seed;

        public TeacherCompetitionControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<TeacherCompetitionController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as TeacherCompetitionListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(TeacherCompetitionVM));

            TeacherCompetitionVM vm = rv.Model as TeacherCompetitionVM;
            TeacherCompetition v = new TeacherCompetition();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "nETniStiWi1c7";
            v.Name = "D06ffDiXfhwDZvDqb4p";
            v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            v.CompetitionName = "jmVHtMVQZyAHV51kGRnpUSLigS";
            v.RewardLevel = DMSFinal.Model.AwardLevelEnum.NationalTwo;
            v.AwardingUnit = "xepip0e8OGtTdl2SMIXxRKRFSsU1B53hLuJe7oJUw";
            v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
            v.RewardTime = DateTime.Parse("2025-01-11 10:56:31");
            v.Rank = DMSFinal.Model.RankEnum.Seven;
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "w7GHHxeCy0LJkaWjFqq";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherCompetition>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "nETniStiWi1c7");
                Assert.AreEqual(data.Name, "D06ffDiXfhwDZvDqb4p");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data.CompetitionName, "jmVHtMVQZyAHV51kGRnpUSLigS");
                Assert.AreEqual(data.RewardLevel, DMSFinal.Model.AwardLevelEnum.NationalTwo);
                Assert.AreEqual(data.AwardingUnit, "xepip0e8OGtTdl2SMIXxRKRFSsU1B53hLuJe7oJUw");
                Assert.AreEqual(data.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2025-01-11 10:56:31"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Seven);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "w7GHHxeCy0LJkaWjFqq");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            TeacherCompetition v = new TeacherCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "nETniStiWi1c7";
                v.Name = "D06ffDiXfhwDZvDqb4p";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.CompetitionName = "jmVHtMVQZyAHV51kGRnpUSLigS";
                v.RewardLevel = DMSFinal.Model.AwardLevelEnum.NationalTwo;
                v.AwardingUnit = "xepip0e8OGtTdl2SMIXxRKRFSsU1B53hLuJe7oJUw";
                v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v.RewardTime = DateTime.Parse("2025-01-11 10:56:31");
                v.Rank = DMSFinal.Model.RankEnum.Seven;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "w7GHHxeCy0LJkaWjFqq";
                context.Set<TeacherCompetition>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TeacherCompetitionVM));

            TeacherCompetitionVM vm = rv.Model as TeacherCompetitionVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new TeacherCompetition();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "Ck";
            v.Name = "Dry";
            v.Title1 = DMSFinal.Model.TitleEnum.Professor;
            v.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
            v.CompetitionName = "5X2TB50bgqXD8r1lCOKl";
            v.RewardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
            v.AwardingUnit = "264rol0b5oGCignbhYQfteyfjs5s93HbF6tUufXn";
            v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
            v.RewardTime = DateTime.Parse("2025-07-13 10:56:31");
            v.Rank = DMSFinal.Model.RankEnum.Three;
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "OSC6vT3xO2y5";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.CompetitionName", "");
            vm.FC.Add("Entity.RewardLevel", "");
            vm.FC.Add("Entity.AwardingUnit", "");
            vm.FC.Add("Entity.Level", "");
            vm.FC.Add("Entity.RewardTime", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherCompetition>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "Ck");
                Assert.AreEqual(data.Name, "Dry");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Professor);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.AssGong);
                Assert.AreEqual(data.CompetitionName, "5X2TB50bgqXD8r1lCOKl");
                Assert.AreEqual(data.RewardLevel, DMSFinal.Model.AwardLevelEnum.ProvinceThree);
                Assert.AreEqual(data.AwardingUnit, "264rol0b5oGCignbhYQfteyfjs5s93HbF6tUufXn");
                Assert.AreEqual(data.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2025-07-13 10:56:31"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Three);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "OSC6vT3xO2y5");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            TeacherCompetition v = new TeacherCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "nETniStiWi1c7";
                v.Name = "D06ffDiXfhwDZvDqb4p";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.CompetitionName = "jmVHtMVQZyAHV51kGRnpUSLigS";
                v.RewardLevel = DMSFinal.Model.AwardLevelEnum.NationalTwo;
                v.AwardingUnit = "xepip0e8OGtTdl2SMIXxRKRFSsU1B53hLuJe7oJUw";
                v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v.RewardTime = DateTime.Parse("2025-01-11 10:56:31");
                v.Rank = DMSFinal.Model.RankEnum.Seven;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "w7GHHxeCy0LJkaWjFqq";
                context.Set<TeacherCompetition>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TeacherCompetitionVM));

            TeacherCompetitionVM vm = rv.Model as TeacherCompetitionVM;
            v = new TeacherCompetition();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherCompetition>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            TeacherCompetition v = new TeacherCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "nETniStiWi1c7";
                v.Name = "D06ffDiXfhwDZvDqb4p";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.CompetitionName = "jmVHtMVQZyAHV51kGRnpUSLigS";
                v.RewardLevel = DMSFinal.Model.AwardLevelEnum.NationalTwo;
                v.AwardingUnit = "xepip0e8OGtTdl2SMIXxRKRFSsU1B53hLuJe7oJUw";
                v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v.RewardTime = DateTime.Parse("2025-01-11 10:56:31");
                v.Rank = DMSFinal.Model.RankEnum.Seven;
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "w7GHHxeCy0LJkaWjFqq";
                context.Set<TeacherCompetition>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            TeacherCompetition v1 = new TeacherCompetition();
            TeacherCompetition v2 = new TeacherCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "nETniStiWi1c7";
                v1.Name = "D06ffDiXfhwDZvDqb4p";
                v1.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.CompetitionName = "jmVHtMVQZyAHV51kGRnpUSLigS";
                v1.RewardLevel = DMSFinal.Model.AwardLevelEnum.NationalTwo;
                v1.AwardingUnit = "xepip0e8OGtTdl2SMIXxRKRFSsU1B53hLuJe7oJUw";
                v1.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v1.RewardTime = DateTime.Parse("2025-01-11 10:56:31");
                v1.Rank = DMSFinal.Model.RankEnum.Seven;
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "w7GHHxeCy0LJkaWjFqq";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "Ck";
                v2.Name = "Dry";
                v2.Title1 = DMSFinal.Model.TitleEnum.Professor;
                v2.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v2.CompetitionName = "5X2TB50bgqXD8r1lCOKl";
                v2.RewardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
                v2.AwardingUnit = "264rol0b5oGCignbhYQfteyfjs5s93HbF6tUufXn";
                v2.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v2.RewardTime = DateTime.Parse("2025-07-13 10:56:31");
                v2.Rank = DMSFinal.Model.RankEnum.Three;
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "OSC6vT3xO2y5";
                context.Set<TeacherCompetition>().Add(v1);
                context.Set<TeacherCompetition>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TeacherCompetitionBatchVM));

            TeacherCompetitionBatchVM vm = rv.Model as TeacherCompetitionBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "SJDCxx2dj1U";
            vm.LinkedVM.Name = "KDXYhqJy";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.noTitle;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
            vm.LinkedVM.CompetitionName = "5dv0YIdAhzHkCIH";
            vm.LinkedVM.RewardLevel = DMSFinal.Model.AwardLevelEnum.SchoolTwo;
            vm.LinkedVM.AwardingUnit = "QHx1booHzv1BAibgqSldH2lZnCaS5jgoD";
            vm.LinkedVM.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
            vm.LinkedVM.RewardTime = DateTime.Parse("2024-09-11 10:56:31");
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.Eight;
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Pass;
            vm.LinkedVM.Reason = "DhJH";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.CompetitionName", "");
            vm.FC.Add("LinkedVM.RewardLevel", "");
            vm.FC.Add("LinkedVM.AwardingUnit", "");
            vm.FC.Add("LinkedVM.Level", "");
            vm.FC.Add("LinkedVM.RewardTime", "");
            vm.FC.Add("LinkedVM.Rank", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TeacherCompetition>().Find(v1.ID);
                var data2 = context.Set<TeacherCompetition>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "SJDCxx2dj1U");
                Assert.AreEqual(data2.JobNo, "SJDCxx2dj1U");
                Assert.AreEqual(data1.Name, "KDXYhqJy");
                Assert.AreEqual(data2.Name, "KDXYhqJy");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.noTitle);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.noTitle);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.GaoShiYan);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.GaoShiYan);
                Assert.AreEqual(data1.CompetitionName, "5dv0YIdAhzHkCIH");
                Assert.AreEqual(data2.CompetitionName, "5dv0YIdAhzHkCIH");
                Assert.AreEqual(data1.RewardLevel, DMSFinal.Model.AwardLevelEnum.SchoolTwo);
                Assert.AreEqual(data2.RewardLevel, DMSFinal.Model.AwardLevelEnum.SchoolTwo);
                Assert.AreEqual(data1.AwardingUnit, "QHx1booHzv1BAibgqSldH2lZnCaS5jgoD");
                Assert.AreEqual(data2.AwardingUnit, "QHx1booHzv1BAibgqSldH2lZnCaS5jgoD");
                Assert.AreEqual(data1.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data2.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data1.RewardTime, DateTime.Parse("2024-09-11 10:56:31"));
                Assert.AreEqual(data2.RewardTime, DateTime.Parse("2024-09-11 10:56:31"));
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.Eight);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.Eight);
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data1.Reason, "DhJH");
                Assert.AreEqual(data2.Reason, "DhJH");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            TeacherCompetition v1 = new TeacherCompetition();
            TeacherCompetition v2 = new TeacherCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "nETniStiWi1c7";
                v1.Name = "D06ffDiXfhwDZvDqb4p";
                v1.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.CompetitionName = "jmVHtMVQZyAHV51kGRnpUSLigS";
                v1.RewardLevel = DMSFinal.Model.AwardLevelEnum.NationalTwo;
                v1.AwardingUnit = "xepip0e8OGtTdl2SMIXxRKRFSsU1B53hLuJe7oJUw";
                v1.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v1.RewardTime = DateTime.Parse("2025-01-11 10:56:31");
                v1.Rank = DMSFinal.Model.RankEnum.Seven;
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "w7GHHxeCy0LJkaWjFqq";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "Ck";
                v2.Name = "Dry";
                v2.Title1 = DMSFinal.Model.TitleEnum.Professor;
                v2.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v2.CompetitionName = "5X2TB50bgqXD8r1lCOKl";
                v2.RewardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
                v2.AwardingUnit = "264rol0b5oGCignbhYQfteyfjs5s93HbF6tUufXn";
                v2.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v2.RewardTime = DateTime.Parse("2025-07-13 10:56:31");
                v2.Rank = DMSFinal.Model.RankEnum.Three;
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "OSC6vT3xO2y5";
                context.Set<TeacherCompetition>().Add(v1);
                context.Set<TeacherCompetition>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TeacherCompetitionBatchVM));

            TeacherCompetitionBatchVM vm = rv.Model as TeacherCompetitionBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TeacherCompetition>().Find(v1.ID);
                var data2 = context.Set<TeacherCompetition>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
