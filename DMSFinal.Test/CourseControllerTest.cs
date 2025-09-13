using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.CourseVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class CourseControllerTest
    {
        private CourseController _controller;
        private string _seed;

        public CourseControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<CourseController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as CourseListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(CourseVM));

            CourseVM vm = rv.Model as CourseVM;
            Course v = new Course();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.Name = "qXzBDNl";
            v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
            v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            v.RewardName = "A8dplChF8wegENhQlozsFqJrVa5OnqXSr8H1E";
            v.AwardingUnit = "ppYEB9DSAxYEOKewou15rz3DpacmpYcU3F8DPJV";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
            v.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
            v.Rank = DMSFinal.Model.RankEnum.Two;
            v.IfOurSchool = DMSFinal.Model.IfEnum.No;
            v.JobNo = "LsobdB";
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "A";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Course>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.Name, "qXzBDNl");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.noTitle);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data.RewardName, "A8dplChF8wegENhQlozsFqJrVa5OnqXSr8H1E");
                Assert.AreEqual(data.AwardingUnit, "ppYEB9DSAxYEOKewou15rz3DpacmpYcU3F8DPJV");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.NationalThree);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2023-04-26 20:37:17"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Two);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.JobNo, "LsobdB");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "A");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Course v = new Course();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "qXzBDNl";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.RewardName = "A8dplChF8wegENhQlozsFqJrVa5OnqXSr8H1E";
                v.AwardingUnit = "ppYEB9DSAxYEOKewou15rz3DpacmpYcU3F8DPJV";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
                v.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.JobNo = "LsobdB";
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "A";
                context.Set<Course>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(CourseVM));

            CourseVM vm = rv.Model as CourseVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Course();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.Name = "yU5L6viN6VBOlfr";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.GongChengShi;
            v.RewardName = "MJcfqGkUFFpt2H6vaih1KvXQKicrNCcfYT";
            v.AwardingUnit = "Gyle6259A5ctLhmgQgUC";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
            v.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
            v.Rank = DMSFinal.Model.RankEnum.Ten;
            v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.JobNo = "rZqfTZ7dMpKNIc";
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "scKjX9wpvrXh98";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.RewardName", "");
            vm.FC.Add("Entity.AwardingUnit", "");
            vm.FC.Add("Entity.AwardLevel", "");
            vm.FC.Add("Entity.RewardTime", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.IfOurSchool", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Course>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.Name, "yU5L6viN6VBOlfr");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.GongChengShi);
                Assert.AreEqual(data.RewardName, "MJcfqGkUFFpt2H6vaih1KvXQKicrNCcfYT");
                Assert.AreEqual(data.AwardingUnit, "Gyle6259A5ctLhmgQgUC");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.NationalThree);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2023-04-26 20:37:17"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Ten);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.JobNo, "rZqfTZ7dMpKNIc");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "scKjX9wpvrXh98");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Course v = new Course();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "qXzBDNl";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.RewardName = "A8dplChF8wegENhQlozsFqJrVa5OnqXSr8H1E";
                v.AwardingUnit = "ppYEB9DSAxYEOKewou15rz3DpacmpYcU3F8DPJV";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
                v.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.JobNo = "LsobdB";
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "A";
                context.Set<Course>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(CourseVM));

            CourseVM vm = rv.Model as CourseVM;
            v = new Course();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Course>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Course v = new Course();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "qXzBDNl";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.RewardName = "A8dplChF8wegENhQlozsFqJrVa5OnqXSr8H1E";
                v.AwardingUnit = "ppYEB9DSAxYEOKewou15rz3DpacmpYcU3F8DPJV";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
                v.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.JobNo = "LsobdB";
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "A";
                context.Set<Course>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Course v1 = new Course();
            Course v2 = new Course();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.Name = "qXzBDNl";
                v1.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.RewardName = "A8dplChF8wegENhQlozsFqJrVa5OnqXSr8H1E";
                v1.AwardingUnit = "ppYEB9DSAxYEOKewou15rz3DpacmpYcU3F8DPJV";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
                v1.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
                v1.Rank = DMSFinal.Model.RankEnum.Two;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v1.JobNo = "LsobdB";
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "A";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.Name = "yU5L6viN6VBOlfr";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.GongChengShi;
                v2.RewardName = "MJcfqGkUFFpt2H6vaih1KvXQKicrNCcfYT";
                v2.AwardingUnit = "Gyle6259A5ctLhmgQgUC";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
                v2.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
                v2.Rank = DMSFinal.Model.RankEnum.Ten;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.JobNo = "rZqfTZ7dMpKNIc";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "scKjX9wpvrXh98";
                context.Set<Course>().Add(v1);
                context.Set<Course>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(CourseBatchVM));

            CourseBatchVM vm = rv.Model as CourseBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Course>().Find(v1.ID);
                var data2 = context.Set<Course>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Course v1 = new Course();
            Course v2 = new Course();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.Name = "qXzBDNl";
                v1.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.RewardName = "A8dplChF8wegENhQlozsFqJrVa5OnqXSr8H1E";
                v1.AwardingUnit = "ppYEB9DSAxYEOKewou15rz3DpacmpYcU3F8DPJV";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
                v1.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
                v1.Rank = DMSFinal.Model.RankEnum.Two;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v1.JobNo = "LsobdB";
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "A";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.Name = "yU5L6viN6VBOlfr";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.GongChengShi;
                v2.RewardName = "MJcfqGkUFFpt2H6vaih1KvXQKicrNCcfYT";
                v2.AwardingUnit = "Gyle6259A5ctLhmgQgUC";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.NationalThree;
                v2.RewardTime = DateTime.Parse("2023-04-26 20:37:17");
                v2.Rank = DMSFinal.Model.RankEnum.Ten;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.JobNo = "rZqfTZ7dMpKNIc";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "scKjX9wpvrXh98";
                context.Set<Course>().Add(v1);
                context.Set<Course>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(CourseBatchVM));

            CourseBatchVM vm = rv.Model as CourseBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Course>().Find(v1.ID);
                var data2 = context.Set<Course>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
