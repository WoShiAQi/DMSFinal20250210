using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.PersonInfoVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class PersonInfoControllerTest
    {
        private PersonInfoController _controller;
        private string _seed;

        public PersonInfoControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PersonInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as PersonInfoListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PersonInfoVM));

            PersonInfoVM vm = rv.Model as PersonInfoVM;
            PersonInfo v = new PersonInfo();
			
            v.JobNo = "sMefKvP";
            v.Name = "LHUlPpaPmzVklzXwbs";
            v.PersonID = "O4EHM3M9k5";
            v.PoliticalID = DMSFinal.Model.PoliticalIDEnum.MinZhu;
            v.Diplomas = DMSFinal.Model.DiplomasEnum.Chu;
            v.Degree = DMSFinal.Model.DegreeEnum.Bo;
            v.GraduateTime = DateTime.Parse("2025-03-12 18:06:09");
            v.InWorkTime = DateTime.Parse("2025-10-01 18:06:09");
            v.PartTimeJob = "Qz";
            v.IfDoubleTeacher = DMSFinal.Model.IfEnum.No;
            v.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
            v.Discipline = "W3uLmvsf6knG41F";
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "eEPjefjbFFHobj";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PersonInfo>().Find(v.ID);
				
                Assert.AreEqual(data.JobNo, "sMefKvP");
                Assert.AreEqual(data.Name, "LHUlPpaPmzVklzXwbs");
                Assert.AreEqual(data.PersonID, "O4EHM3M9k5");
                Assert.AreEqual(data.PoliticalID, DMSFinal.Model.PoliticalIDEnum.MinZhu);
                Assert.AreEqual(data.Diplomas, DMSFinal.Model.DiplomasEnum.Chu);
                Assert.AreEqual(data.Degree, DMSFinal.Model.DegreeEnum.Bo);
                Assert.AreEqual(data.GraduateTime, DateTime.Parse("2025-03-12 18:06:09"));
                Assert.AreEqual(data.InWorkTime, DateTime.Parse("2025-10-01 18:06:09"));
                Assert.AreEqual(data.PartTimeJob, "Qz");
                Assert.AreEqual(data.IfDoubleTeacher, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.IfDisciplineLeader, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Discipline, "W3uLmvsf6knG41F");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "eEPjefjbFFHobj");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PersonInfo v = new PersonInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.JobNo = "sMefKvP";
                v.Name = "LHUlPpaPmzVklzXwbs";
                v.PersonID = "O4EHM3M9k5";
                v.PoliticalID = DMSFinal.Model.PoliticalIDEnum.MinZhu;
                v.Diplomas = DMSFinal.Model.DiplomasEnum.Chu;
                v.Degree = DMSFinal.Model.DegreeEnum.Bo;
                v.GraduateTime = DateTime.Parse("2025-03-12 18:06:09");
                v.InWorkTime = DateTime.Parse("2025-10-01 18:06:09");
                v.PartTimeJob = "Qz";
                v.IfDoubleTeacher = DMSFinal.Model.IfEnum.No;
                v.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
                v.Discipline = "W3uLmvsf6knG41F";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "eEPjefjbFFHobj";
                context.Set<PersonInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PersonInfoVM));

            PersonInfoVM vm = rv.Model as PersonInfoVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new PersonInfo();
            v.ID = vm.Entity.ID;
       		
            v.JobNo = "YMJb8Jdtdh";
            v.Name = "wXJt8F17U3hIb";
            v.PersonID = "032k6";
            v.PoliticalID = DMSFinal.Model.PoliticalIDEnum.Dang;
            v.Diplomas = DMSFinal.Model.DiplomasEnum.Gao;
            v.Degree = DMSFinal.Model.DegreeEnum.Shuo;
            v.GraduateTime = DateTime.Parse("2025-03-10 18:06:09");
            v.InWorkTime = DateTime.Parse("2024-01-30 18:06:09");
            v.PartTimeJob = "Ss";
            v.IfDoubleTeacher = DMSFinal.Model.IfEnum.Yes;
            v.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
            v.Discipline = "tVK9PFY6Cn9QgEHj6";
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "KiagxYxdX7xpfCUgzW";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.PersonID", "");
            vm.FC.Add("Entity.PoliticalID", "");
            vm.FC.Add("Entity.Diplomas", "");
            vm.FC.Add("Entity.Degree", "");
            vm.FC.Add("Entity.GraduateTime", "");
            vm.FC.Add("Entity.InWorkTime", "");
            vm.FC.Add("Entity.PartTimeJob", "");
            vm.FC.Add("Entity.IfDoubleTeacher", "");
            vm.FC.Add("Entity.IfDisciplineLeader", "");
            vm.FC.Add("Entity.Discipline", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PersonInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.JobNo, "YMJb8Jdtdh");
                Assert.AreEqual(data.Name, "wXJt8F17U3hIb");
                Assert.AreEqual(data.PersonID, "032k6");
                Assert.AreEqual(data.PoliticalID, DMSFinal.Model.PoliticalIDEnum.Dang);
                Assert.AreEqual(data.Diplomas, DMSFinal.Model.DiplomasEnum.Gao);
                Assert.AreEqual(data.Degree, DMSFinal.Model.DegreeEnum.Shuo);
                Assert.AreEqual(data.GraduateTime, DateTime.Parse("2025-03-10 18:06:09"));
                Assert.AreEqual(data.InWorkTime, DateTime.Parse("2024-01-30 18:06:09"));
                Assert.AreEqual(data.PartTimeJob, "Ss");
                Assert.AreEqual(data.IfDoubleTeacher, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.IfDisciplineLeader, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Discipline, "tVK9PFY6Cn9QgEHj6");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "KiagxYxdX7xpfCUgzW");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PersonInfo v = new PersonInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.JobNo = "sMefKvP";
                v.Name = "LHUlPpaPmzVklzXwbs";
                v.PersonID = "O4EHM3M9k5";
                v.PoliticalID = DMSFinal.Model.PoliticalIDEnum.MinZhu;
                v.Diplomas = DMSFinal.Model.DiplomasEnum.Chu;
                v.Degree = DMSFinal.Model.DegreeEnum.Bo;
                v.GraduateTime = DateTime.Parse("2025-03-12 18:06:09");
                v.InWorkTime = DateTime.Parse("2025-10-01 18:06:09");
                v.PartTimeJob = "Qz";
                v.IfDoubleTeacher = DMSFinal.Model.IfEnum.No;
                v.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
                v.Discipline = "W3uLmvsf6knG41F";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "eEPjefjbFFHobj";
                context.Set<PersonInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PersonInfoVM));

            PersonInfoVM vm = rv.Model as PersonInfoVM;
            v = new PersonInfo();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PersonInfo>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PersonInfo v = new PersonInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.JobNo = "sMefKvP";
                v.Name = "LHUlPpaPmzVklzXwbs";
                v.PersonID = "O4EHM3M9k5";
                v.PoliticalID = DMSFinal.Model.PoliticalIDEnum.MinZhu;
                v.Diplomas = DMSFinal.Model.DiplomasEnum.Chu;
                v.Degree = DMSFinal.Model.DegreeEnum.Bo;
                v.GraduateTime = DateTime.Parse("2025-03-12 18:06:09");
                v.InWorkTime = DateTime.Parse("2025-10-01 18:06:09");
                v.PartTimeJob = "Qz";
                v.IfDoubleTeacher = DMSFinal.Model.IfEnum.No;
                v.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
                v.Discipline = "W3uLmvsf6knG41F";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "eEPjefjbFFHobj";
                context.Set<PersonInfo>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            PersonInfo v1 = new PersonInfo();
            PersonInfo v2 = new PersonInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.JobNo = "sMefKvP";
                v1.Name = "LHUlPpaPmzVklzXwbs";
                v1.PersonID = "O4EHM3M9k5";
                v1.PoliticalID = DMSFinal.Model.PoliticalIDEnum.MinZhu;
                v1.Diplomas = DMSFinal.Model.DiplomasEnum.Chu;
                v1.Degree = DMSFinal.Model.DegreeEnum.Bo;
                v1.GraduateTime = DateTime.Parse("2025-03-12 18:06:09");
                v1.InWorkTime = DateTime.Parse("2025-10-01 18:06:09");
                v1.PartTimeJob = "Qz";
                v1.IfDoubleTeacher = DMSFinal.Model.IfEnum.No;
                v1.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
                v1.Discipline = "W3uLmvsf6knG41F";
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "eEPjefjbFFHobj";
                v2.JobNo = "YMJb8Jdtdh";
                v2.Name = "wXJt8F17U3hIb";
                v2.PersonID = "032k6";
                v2.PoliticalID = DMSFinal.Model.PoliticalIDEnum.Dang;
                v2.Diplomas = DMSFinal.Model.DiplomasEnum.Gao;
                v2.Degree = DMSFinal.Model.DegreeEnum.Shuo;
                v2.GraduateTime = DateTime.Parse("2025-03-10 18:06:09");
                v2.InWorkTime = DateTime.Parse("2024-01-30 18:06:09");
                v2.PartTimeJob = "Ss";
                v2.IfDoubleTeacher = DMSFinal.Model.IfEnum.Yes;
                v2.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
                v2.Discipline = "tVK9PFY6Cn9QgEHj6";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "KiagxYxdX7xpfCUgzW";
                context.Set<PersonInfo>().Add(v1);
                context.Set<PersonInfo>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PersonInfoBatchVM));

            PersonInfoBatchVM vm = rv.Model as PersonInfoBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<PersonInfo>().Find(v1.ID);
                var data2 = context.Set<PersonInfo>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            PersonInfo v1 = new PersonInfo();
            PersonInfo v2 = new PersonInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.JobNo = "sMefKvP";
                v1.Name = "LHUlPpaPmzVklzXwbs";
                v1.PersonID = "O4EHM3M9k5";
                v1.PoliticalID = DMSFinal.Model.PoliticalIDEnum.MinZhu;
                v1.Diplomas = DMSFinal.Model.DiplomasEnum.Chu;
                v1.Degree = DMSFinal.Model.DegreeEnum.Bo;
                v1.GraduateTime = DateTime.Parse("2025-03-12 18:06:09");
                v1.InWorkTime = DateTime.Parse("2025-10-01 18:06:09");
                v1.PartTimeJob = "Qz";
                v1.IfDoubleTeacher = DMSFinal.Model.IfEnum.No;
                v1.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
                v1.Discipline = "W3uLmvsf6knG41F";
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "eEPjefjbFFHobj";
                v2.JobNo = "YMJb8Jdtdh";
                v2.Name = "wXJt8F17U3hIb";
                v2.PersonID = "032k6";
                v2.PoliticalID = DMSFinal.Model.PoliticalIDEnum.Dang;
                v2.Diplomas = DMSFinal.Model.DiplomasEnum.Gao;
                v2.Degree = DMSFinal.Model.DegreeEnum.Shuo;
                v2.GraduateTime = DateTime.Parse("2025-03-10 18:06:09");
                v2.InWorkTime = DateTime.Parse("2024-01-30 18:06:09");
                v2.PartTimeJob = "Ss";
                v2.IfDoubleTeacher = DMSFinal.Model.IfEnum.Yes;
                v2.IfDisciplineLeader = DMSFinal.Model.IfEnum.Yes;
                v2.Discipline = "tVK9PFY6Cn9QgEHj6";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "KiagxYxdX7xpfCUgzW";
                context.Set<PersonInfo>().Add(v1);
                context.Set<PersonInfo>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PersonInfoBatchVM));

            PersonInfoBatchVM vm = rv.Model as PersonInfoBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<PersonInfo>().Find(v1.ID);
                var data2 = context.Set<PersonInfo>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
