using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.StudentCompetitionVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class StudentCompetitionControllerTest
    {
        private StudentCompetitionController _controller;
        private string _seed;

        public StudentCompetitionControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<StudentCompetitionController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as StudentCompetitionListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(StudentCompetitionVM));

            StudentCompetitionVM vm = rv.Model as StudentCompetitionVM;
            StudentCompetition v = new StudentCompetition();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.StudentName = "teyU8RtqY3XPX7Ie2UKgrocrAvi3vpd8";
            v.JobNo = "EGUXN";
            v.TeacherName = "Qv6MPj2HH";
            v.CompetitionName = "xKXoWhNFovdU831Xm";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
            v.AwardingUnit = "GJcVBTv0abb0N6sW8R5DwVgAHC2J96b5QkpP7GjrEogY";
            v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
            v.RewardTime = DateTime.Parse("2023-12-18 10:34:42");
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "o85PeyldS2uUqpcCIHA";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentCompetition>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.StudentName, "teyU8RtqY3XPX7Ie2UKgrocrAvi3vpd8");
                Assert.AreEqual(data.JobNo, "EGUXN");
                Assert.AreEqual(data.TeacherName, "Qv6MPj2HH");
                Assert.AreEqual(data.CompetitionName, "xKXoWhNFovdU831Xm");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.ProvinceThree);
                Assert.AreEqual(data.AwardingUnit, "GJcVBTv0abb0N6sW8R5DwVgAHC2J96b5QkpP7GjrEogY");
                Assert.AreEqual(data.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2023-12-18 10:34:42"));
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "o85PeyldS2uUqpcCIHA");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            StudentCompetition v = new StudentCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.StudentName = "teyU8RtqY3XPX7Ie2UKgrocrAvi3vpd8";
                v.JobNo = "EGUXN";
                v.TeacherName = "Qv6MPj2HH";
                v.CompetitionName = "xKXoWhNFovdU831Xm";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
                v.AwardingUnit = "GJcVBTv0abb0N6sW8R5DwVgAHC2J96b5QkpP7GjrEogY";
                v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v.RewardTime = DateTime.Parse("2023-12-18 10:34:42");
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "o85PeyldS2uUqpcCIHA";
                context.Set<StudentCompetition>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(StudentCompetitionVM));

            StudentCompetitionVM vm = rv.Model as StudentCompetitionVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new StudentCompetition();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.StudentName = "SVJDrj0RkTGdkHuTJYMg1C";
            v.JobNo = "F9GZ9rg2OP8eLXi09";
            v.TeacherName = "Uy8O6bUlbtjZqcd3P";
            v.CompetitionName = "Evr7s4Lxo";
            v.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceTwo;
            v.AwardingUnit = "neJIZ5ExiJmx";
            v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
            v.RewardTime = DateTime.Parse("2025-04-23 10:34:42");
            v.Examine = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "Zh043wTsiMYvxHyG";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.StudentName", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.TeacherName", "");
            vm.FC.Add("Entity.CompetitionName", "");
            vm.FC.Add("Entity.AwardLevel", "");
            vm.FC.Add("Entity.AwardingUnit", "");
            vm.FC.Add("Entity.Level", "");
            vm.FC.Add("Entity.RewardTime", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentCompetition>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.StudentName, "SVJDrj0RkTGdkHuTJYMg1C");
                Assert.AreEqual(data.JobNo, "F9GZ9rg2OP8eLXi09");
                Assert.AreEqual(data.TeacherName, "Uy8O6bUlbtjZqcd3P");
                Assert.AreEqual(data.CompetitionName, "Evr7s4Lxo");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.AwardLevelEnum.ProvinceTwo);
                Assert.AreEqual(data.AwardingUnit, "neJIZ5ExiJmx");
                Assert.AreEqual(data.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2025-04-23 10:34:42"));
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "Zh043wTsiMYvxHyG");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            StudentCompetition v = new StudentCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.StudentName = "teyU8RtqY3XPX7Ie2UKgrocrAvi3vpd8";
                v.JobNo = "EGUXN";
                v.TeacherName = "Qv6MPj2HH";
                v.CompetitionName = "xKXoWhNFovdU831Xm";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
                v.AwardingUnit = "GJcVBTv0abb0N6sW8R5DwVgAHC2J96b5QkpP7GjrEogY";
                v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v.RewardTime = DateTime.Parse("2023-12-18 10:34:42");
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "o85PeyldS2uUqpcCIHA";
                context.Set<StudentCompetition>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(StudentCompetitionVM));

            StudentCompetitionVM vm = rv.Model as StudentCompetitionVM;
            v = new StudentCompetition();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentCompetition>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            StudentCompetition v = new StudentCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.StudentName = "teyU8RtqY3XPX7Ie2UKgrocrAvi3vpd8";
                v.JobNo = "EGUXN";
                v.TeacherName = "Qv6MPj2HH";
                v.CompetitionName = "xKXoWhNFovdU831Xm";
                v.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
                v.AwardingUnit = "GJcVBTv0abb0N6sW8R5DwVgAHC2J96b5QkpP7GjrEogY";
                v.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v.RewardTime = DateTime.Parse("2023-12-18 10:34:42");
                v.Examine = DMSFinal.Model.CheckEnum.Checking;
                v.Reason = "o85PeyldS2uUqpcCIHA";
                context.Set<StudentCompetition>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            StudentCompetition v1 = new StudentCompetition();
            StudentCompetition v2 = new StudentCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.StudentName = "teyU8RtqY3XPX7Ie2UKgrocrAvi3vpd8";
                v1.JobNo = "EGUXN";
                v1.TeacherName = "Qv6MPj2HH";
                v1.CompetitionName = "xKXoWhNFovdU831Xm";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
                v1.AwardingUnit = "GJcVBTv0abb0N6sW8R5DwVgAHC2J96b5QkpP7GjrEogY";
                v1.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v1.RewardTime = DateTime.Parse("2023-12-18 10:34:42");
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "o85PeyldS2uUqpcCIHA";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.StudentName = "SVJDrj0RkTGdkHuTJYMg1C";
                v2.JobNo = "F9GZ9rg2OP8eLXi09";
                v2.TeacherName = "Uy8O6bUlbtjZqcd3P";
                v2.CompetitionName = "Evr7s4Lxo";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceTwo;
                v2.AwardingUnit = "neJIZ5ExiJmx";
                v2.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v2.RewardTime = DateTime.Parse("2025-04-23 10:34:42");
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "Zh043wTsiMYvxHyG";
                context.Set<StudentCompetition>().Add(v1);
                context.Set<StudentCompetition>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(StudentCompetitionBatchVM));

            StudentCompetitionBatchVM vm = rv.Model as StudentCompetitionBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.StudentName = "WPQC6aRGUeBFGr9P4JvxCbThVmbNA";
            vm.LinkedVM.JobNo = "1cHvNj57hysHoN1amTg";
            vm.LinkedVM.TeacherName = "8rY9pEj";
            vm.LinkedVM.CompetitionName = "a0M7pb21";
            vm.LinkedVM.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
            vm.LinkedVM.AwardingUnit = "DbkxvYwbBulkL6sfhXfHVQBU";
            vm.LinkedVM.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
            vm.LinkedVM.RewardTime = DateTime.Parse("2024-01-27 10:34:42");
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Checking;
            vm.LinkedVM.Reason = "dNwMhpW05Gdp";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.StudentName", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.TeacherName", "");
            vm.FC.Add("LinkedVM.CompetitionName", "");
            vm.FC.Add("LinkedVM.AwardLevel", "");
            vm.FC.Add("LinkedVM.AwardingUnit", "");
            vm.FC.Add("LinkedVM.Level", "");
            vm.FC.Add("LinkedVM.RewardTime", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<StudentCompetition>().Find(v1.ID);
                var data2 = context.Set<StudentCompetition>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.StudentName, "WPQC6aRGUeBFGr9P4JvxCbThVmbNA");
                Assert.AreEqual(data2.StudentName, "WPQC6aRGUeBFGr9P4JvxCbThVmbNA");
                Assert.AreEqual(data1.JobNo, "1cHvNj57hysHoN1amTg");
                Assert.AreEqual(data2.JobNo, "1cHvNj57hysHoN1amTg");
                Assert.AreEqual(data1.TeacherName, "8rY9pEj");
                Assert.AreEqual(data2.TeacherName, "8rY9pEj");
                Assert.AreEqual(data1.CompetitionName, "a0M7pb21");
                Assert.AreEqual(data2.CompetitionName, "a0M7pb21");
                Assert.AreEqual(data1.AwardLevel, DMSFinal.Model.AwardLevelEnum.ProvinceThree);
                Assert.AreEqual(data2.AwardLevel, DMSFinal.Model.AwardLevelEnum.ProvinceThree);
                Assert.AreEqual(data1.AwardingUnit, "DbkxvYwbBulkL6sfhXfHVQBU");
                Assert.AreEqual(data2.AwardingUnit, "DbkxvYwbBulkL6sfhXfHVQBU");
                Assert.AreEqual(data1.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data2.Level, DMSFinal.Model.ConpetitonLevelEnum.national);
                Assert.AreEqual(data1.RewardTime, DateTime.Parse("2024-01-27 10:34:42"));
                Assert.AreEqual(data2.RewardTime, DateTime.Parse("2024-01-27 10:34:42"));
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data1.Reason, "dNwMhpW05Gdp");
                Assert.AreEqual(data2.Reason, "dNwMhpW05Gdp");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            StudentCompetition v1 = new StudentCompetition();
            StudentCompetition v2 = new StudentCompetition();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.StudentName = "teyU8RtqY3XPX7Ie2UKgrocrAvi3vpd8";
                v1.JobNo = "EGUXN";
                v1.TeacherName = "Qv6MPj2HH";
                v1.CompetitionName = "xKXoWhNFovdU831Xm";
                v1.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceThree;
                v1.AwardingUnit = "GJcVBTv0abb0N6sW8R5DwVgAHC2J96b5QkpP7GjrEogY";
                v1.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v1.RewardTime = DateTime.Parse("2023-12-18 10:34:42");
                v1.Examine = DMSFinal.Model.CheckEnum.Checking;
                v1.Reason = "o85PeyldS2uUqpcCIHA";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.StudentName = "SVJDrj0RkTGdkHuTJYMg1C";
                v2.JobNo = "F9GZ9rg2OP8eLXi09";
                v2.TeacherName = "Uy8O6bUlbtjZqcd3P";
                v2.CompetitionName = "Evr7s4Lxo";
                v2.AwardLevel = DMSFinal.Model.AwardLevelEnum.ProvinceTwo;
                v2.AwardingUnit = "neJIZ5ExiJmx";
                v2.Level = DMSFinal.Model.ConpetitonLevelEnum.national;
                v2.RewardTime = DateTime.Parse("2025-04-23 10:34:42");
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "Zh043wTsiMYvxHyG";
                context.Set<StudentCompetition>().Add(v1);
                context.Set<StudentCompetition>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(StudentCompetitionBatchVM));

            StudentCompetitionBatchVM vm = rv.Model as StudentCompetitionBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<StudentCompetition>().Find(v1.ID);
                var data2 = context.Set<StudentCompetition>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
