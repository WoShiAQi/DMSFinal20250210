using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.DepartmentHonorVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class DepartmentHonorControllerTest
    {
        private DepartmentHonorController _controller;
        private string _seed;

        public DepartmentHonorControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<DepartmentHonorController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as DepartmentHonorListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(DepartmentHonorVM));

            DepartmentHonorVM vm = rv.Model as DepartmentHonorVM;
            DepartmentHonor v = new DepartmentHonor();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.ProjectName = "Gg8C36ufK";
            v.AwardingUnit = "2x1luZEUCS2f3";
            v.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
            v.RewardTime = DateTime.Parse("2024-12-02 11:01:37");
            v.AwardNo = "t2gCztnTA6CjBNZEMx6R7fSmOreVBaSBAdTkem0NwcPq9c4M";
            v.Examine = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "wqqovxp9LS";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DepartmentHonor>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.ProjectName, "Gg8C36ufK");
                Assert.AreEqual(data.AwardingUnit, "2x1luZEUCS2f3");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.SubjectEnum.Xiao);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2024-12-02 11:01:37"));
                Assert.AreEqual(data.AwardNo, "t2gCztnTA6CjBNZEMx6R7fSmOreVBaSBAdTkem0NwcPq9c4M");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "wqqovxp9LS");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            DepartmentHonor v = new DepartmentHonor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.ProjectName = "Gg8C36ufK";
                v.AwardingUnit = "2x1luZEUCS2f3";
                v.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
                v.RewardTime = DateTime.Parse("2024-12-02 11:01:37");
                v.AwardNo = "t2gCztnTA6CjBNZEMx6R7fSmOreVBaSBAdTkem0NwcPq9c4M";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "wqqovxp9LS";
                context.Set<DepartmentHonor>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(DepartmentHonorVM));

            DepartmentHonorVM vm = rv.Model as DepartmentHonorVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new DepartmentHonor();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.ProjectName = "5ae";
            v.AwardingUnit = "pBvVNR";
            v.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
            v.RewardTime = DateTime.Parse("2024-10-03 11:01:37");
            v.AwardNo = "T6aWw58fsPMNm8RSWmuIB";
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "Bp9YWVL";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.ProjectName", "");
            vm.FC.Add("Entity.AwardingUnit", "");
            vm.FC.Add("Entity.AwardLevel", "");
            vm.FC.Add("Entity.RewardTime", "");
            vm.FC.Add("Entity.AwardNo", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DepartmentHonor>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.ProjectName, "5ae");
                Assert.AreEqual(data.AwardingUnit, "pBvVNR");
                Assert.AreEqual(data.AwardLevel, DMSFinal.Model.SubjectEnum.Xiao);
                Assert.AreEqual(data.RewardTime, DateTime.Parse("2024-10-03 11:01:37"));
                Assert.AreEqual(data.AwardNo, "T6aWw58fsPMNm8RSWmuIB");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "Bp9YWVL");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            DepartmentHonor v = new DepartmentHonor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.ProjectName = "Gg8C36ufK";
                v.AwardingUnit = "2x1luZEUCS2f3";
                v.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
                v.RewardTime = DateTime.Parse("2024-12-02 11:01:37");
                v.AwardNo = "t2gCztnTA6CjBNZEMx6R7fSmOreVBaSBAdTkem0NwcPq9c4M";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "wqqovxp9LS";
                context.Set<DepartmentHonor>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(DepartmentHonorVM));

            DepartmentHonorVM vm = rv.Model as DepartmentHonorVM;
            v = new DepartmentHonor();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DepartmentHonor>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            DepartmentHonor v = new DepartmentHonor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.ProjectName = "Gg8C36ufK";
                v.AwardingUnit = "2x1luZEUCS2f3";
                v.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
                v.RewardTime = DateTime.Parse("2024-12-02 11:01:37");
                v.AwardNo = "t2gCztnTA6CjBNZEMx6R7fSmOreVBaSBAdTkem0NwcPq9c4M";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "wqqovxp9LS";
                context.Set<DepartmentHonor>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            DepartmentHonor v1 = new DepartmentHonor();
            DepartmentHonor v2 = new DepartmentHonor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.ProjectName = "Gg8C36ufK";
                v1.AwardingUnit = "2x1luZEUCS2f3";
                v1.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
                v1.RewardTime = DateTime.Parse("2024-12-02 11:01:37");
                v1.AwardNo = "t2gCztnTA6CjBNZEMx6R7fSmOreVBaSBAdTkem0NwcPq9c4M";
                v1.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v1.Reason = "wqqovxp9LS";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.ProjectName = "5ae";
                v2.AwardingUnit = "pBvVNR";
                v2.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
                v2.RewardTime = DateTime.Parse("2024-10-03 11:01:37");
                v2.AwardNo = "T6aWw58fsPMNm8RSWmuIB";
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "Bp9YWVL";
                context.Set<DepartmentHonor>().Add(v1);
                context.Set<DepartmentHonor>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(DepartmentHonorBatchVM));

            DepartmentHonorBatchVM vm = rv.Model as DepartmentHonorBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.ProjectName = "bjGgOJvnZQeYSM";
            vm.LinkedVM.AwardingUnit = "SkGlVYxFo";
            vm.LinkedVM.AwardLevel = DMSFinal.Model.SubjectEnum.Sheng;
            vm.LinkedVM.RewardTime = DateTime.Parse("2024-04-29 11:01:37");
            vm.LinkedVM.AwardNo = "vKAfa7JVxdjSiRD6v2dUIGz0DNiK0FAF";
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.NotPass;
            vm.LinkedVM.Reason = "0loth3DkRCnzOirhHua";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.ProjectName", "");
            vm.FC.Add("LinkedVM.AwardingUnit", "");
            vm.FC.Add("LinkedVM.AwardLevel", "");
            vm.FC.Add("LinkedVM.RewardTime", "");
            vm.FC.Add("LinkedVM.AwardNo", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<DepartmentHonor>().Find(v1.ID);
                var data2 = context.Set<DepartmentHonor>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.ProjectName, "bjGgOJvnZQeYSM");
                Assert.AreEqual(data2.ProjectName, "bjGgOJvnZQeYSM");
                Assert.AreEqual(data1.AwardingUnit, "SkGlVYxFo");
                Assert.AreEqual(data2.AwardingUnit, "SkGlVYxFo");
                Assert.AreEqual(data1.AwardLevel, DMSFinal.Model.SubjectEnum.Sheng);
                Assert.AreEqual(data2.AwardLevel, DMSFinal.Model.SubjectEnum.Sheng);
                Assert.AreEqual(data1.RewardTime, DateTime.Parse("2024-04-29 11:01:37"));
                Assert.AreEqual(data2.RewardTime, DateTime.Parse("2024-04-29 11:01:37"));
                Assert.AreEqual(data1.AwardNo, "vKAfa7JVxdjSiRD6v2dUIGz0DNiK0FAF");
                Assert.AreEqual(data2.AwardNo, "vKAfa7JVxdjSiRD6v2dUIGz0DNiK0FAF");
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data1.Reason, "0loth3DkRCnzOirhHua");
                Assert.AreEqual(data2.Reason, "0loth3DkRCnzOirhHua");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            DepartmentHonor v1 = new DepartmentHonor();
            DepartmentHonor v2 = new DepartmentHonor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.ProjectName = "Gg8C36ufK";
                v1.AwardingUnit = "2x1luZEUCS2f3";
                v1.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
                v1.RewardTime = DateTime.Parse("2024-12-02 11:01:37");
                v1.AwardNo = "t2gCztnTA6CjBNZEMx6R7fSmOreVBaSBAdTkem0NwcPq9c4M";
                v1.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v1.Reason = "wqqovxp9LS";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.ProjectName = "5ae";
                v2.AwardingUnit = "pBvVNR";
                v2.AwardLevel = DMSFinal.Model.SubjectEnum.Xiao;
                v2.RewardTime = DateTime.Parse("2024-10-03 11:01:37");
                v2.AwardNo = "T6aWw58fsPMNm8RSWmuIB";
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "Bp9YWVL";
                context.Set<DepartmentHonor>().Add(v1);
                context.Set<DepartmentHonor>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(DepartmentHonorBatchVM));

            DepartmentHonorBatchVM vm = rv.Model as DepartmentHonorBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<DepartmentHonor>().Find(v1.ID);
                var data2 = context.Set<DepartmentHonor>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
