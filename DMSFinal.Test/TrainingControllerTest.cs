using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.TrainingVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class TrainingControllerTest
    {
        private TrainingController _controller;
        private string _seed;

        public TrainingControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<TrainingController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as TrainingListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(TrainingVM));

            TrainingVM vm = rv.Model as TrainingVM;
            Training v = new Training();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "wBROXbVDWB2oOl";
            v.Name = "GHuGSI";
            v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            v.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
            v.TrainName = "hkVI2sbnFrzGTA";
            v.TeachingTime = 659793780;
            v.StartTime = DateTime.Parse("2024-10-25 11:08:54");
            v.EndTime = DateTime.Parse("2024-02-02 11:08:54");
            v.TrainingUnit = "jihD9r5cBv3mKrryF";
            v.Examin = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "4HnnkIE4C0Kc0dP";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Training>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "wBROXbVDWB2oOl");
                Assert.AreEqual(data.Name, "GHuGSI");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.AssGong);
                Assert.AreEqual(data.TrainName, "hkVI2sbnFrzGTA");
                Assert.AreEqual(data.TeachingTime, 659793780);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2024-10-25 11:08:54"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-02-02 11:08:54"));
                Assert.AreEqual(data.TrainingUnit, "jihD9r5cBv3mKrryF");
                Assert.AreEqual(data.Examin, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "4HnnkIE4C0Kc0dP");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Training v = new Training();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "wBROXbVDWB2oOl";
                v.Name = "GHuGSI";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v.TrainName = "hkVI2sbnFrzGTA";
                v.TeachingTime = 659793780;
                v.StartTime = DateTime.Parse("2024-10-25 11:08:54");
                v.EndTime = DateTime.Parse("2024-02-02 11:08:54");
                v.TrainingUnit = "jihD9r5cBv3mKrryF";
                v.Examin = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "4HnnkIE4C0Kc0dP";
                context.Set<Training>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TrainingVM));

            TrainingVM vm = rv.Model as TrainingVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Training();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "kk";
            v.Name = "bX5HnYh2";
            v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
            v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
            v.TrainName = "Ip3geGeXlbccDudF6P3AX3iEZGxPopABTisxBfVVPgI";
            v.TeachingTime = 357583436;
            v.StartTime = DateTime.Parse("2025-01-04 11:08:54");
            v.EndTime = DateTime.Parse("2024-11-12 11:08:54");
            v.TrainingUnit = "tut49G2bn";
            v.Examin = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "IREIq0GeP9AkL";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.TrainName", "");
            vm.FC.Add("Entity.TeachingTime", "");
            vm.FC.Add("Entity.StartTime", "");
            vm.FC.Add("Entity.EndTime", "");
            vm.FC.Add("Entity.TrainingUnit", "");
            vm.FC.Add("Entity.Examin", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Training>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "kk");
                Assert.AreEqual(data.Name, "bX5HnYh2");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.noTitle);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ShiYanShi);
                Assert.AreEqual(data.TrainName, "Ip3geGeXlbccDudF6P3AX3iEZGxPopABTisxBfVVPgI");
                Assert.AreEqual(data.TeachingTime, 357583436);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2025-01-04 11:08:54"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-11-12 11:08:54"));
                Assert.AreEqual(data.TrainingUnit, "tut49G2bn");
                Assert.AreEqual(data.Examin, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "IREIq0GeP9AkL");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Training v = new Training();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "wBROXbVDWB2oOl";
                v.Name = "GHuGSI";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v.TrainName = "hkVI2sbnFrzGTA";
                v.TeachingTime = 659793780;
                v.StartTime = DateTime.Parse("2024-10-25 11:08:54");
                v.EndTime = DateTime.Parse("2024-02-02 11:08:54");
                v.TrainingUnit = "jihD9r5cBv3mKrryF";
                v.Examin = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "4HnnkIE4C0Kc0dP";
                context.Set<Training>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TrainingVM));

            TrainingVM vm = rv.Model as TrainingVM;
            v = new Training();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Training>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Training v = new Training();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "wBROXbVDWB2oOl";
                v.Name = "GHuGSI";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v.TrainName = "hkVI2sbnFrzGTA";
                v.TeachingTime = 659793780;
                v.StartTime = DateTime.Parse("2024-10-25 11:08:54");
                v.EndTime = DateTime.Parse("2024-02-02 11:08:54");
                v.TrainingUnit = "jihD9r5cBv3mKrryF";
                v.Examin = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "4HnnkIE4C0Kc0dP";
                context.Set<Training>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Training v1 = new Training();
            Training v2 = new Training();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "wBROXbVDWB2oOl";
                v1.Name = "GHuGSI";
                v1.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v1.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v1.TrainName = "hkVI2sbnFrzGTA";
                v1.TeachingTime = 659793780;
                v1.StartTime = DateTime.Parse("2024-10-25 11:08:54");
                v1.EndTime = DateTime.Parse("2024-02-02 11:08:54");
                v1.TrainingUnit = "jihD9r5cBv3mKrryF";
                v1.Examin = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "4HnnkIE4C0Kc0dP";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "kk";
                v2.Name = "bX5HnYh2";
                v2.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
                v2.TrainName = "Ip3geGeXlbccDudF6P3AX3iEZGxPopABTisxBfVVPgI";
                v2.TeachingTime = 357583436;
                v2.StartTime = DateTime.Parse("2025-01-04 11:08:54");
                v2.EndTime = DateTime.Parse("2024-11-12 11:08:54");
                v2.TrainingUnit = "tut49G2bn";
                v2.Examin = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "IREIq0GeP9AkL";
                context.Set<Training>().Add(v1);
                context.Set<Training>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TrainingBatchVM));

            TrainingBatchVM vm = rv.Model as TrainingBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "4tbVEH9";
            vm.LinkedVM.Name = "9dQky4p1VQELG";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.ZhengGao;
            vm.LinkedVM.TrainName = "e5MjkMhnwys7hMCvSA07Srw";
            vm.LinkedVM.TeachingTime = 732087862;
            vm.LinkedVM.StartTime = DateTime.Parse("2024-04-01 11:08:54");
            vm.LinkedVM.EndTime = DateTime.Parse("2024-11-02 11:08:54");
            vm.LinkedVM.TrainingUnit = "g";
            vm.LinkedVM.Examin = DMSFinal.Model.CheckEnum.NotPass;
            vm.LinkedVM.Reason = "e7zi";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.TrainName", "");
            vm.FC.Add("LinkedVM.TeachingTime", "");
            vm.FC.Add("LinkedVM.StartTime", "");
            vm.FC.Add("LinkedVM.EndTime", "");
            vm.FC.Add("LinkedVM.TrainingUnit", "");
            vm.FC.Add("LinkedVM.Examin", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Training>().Find(v1.ID);
                var data2 = context.Set<Training>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "4tbVEH9");
                Assert.AreEqual(data2.JobNo, "4tbVEH9");
                Assert.AreEqual(data1.Name, "9dQky4p1VQELG");
                Assert.AreEqual(data2.Name, "9dQky4p1VQELG");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.ZhengGao);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.ZhengGao);
                Assert.AreEqual(data1.TrainName, "e5MjkMhnwys7hMCvSA07Srw");
                Assert.AreEqual(data2.TrainName, "e5MjkMhnwys7hMCvSA07Srw");
                Assert.AreEqual(data1.TeachingTime, 732087862);
                Assert.AreEqual(data2.TeachingTime, 732087862);
                Assert.AreEqual(data1.StartTime, DateTime.Parse("2024-04-01 11:08:54"));
                Assert.AreEqual(data2.StartTime, DateTime.Parse("2024-04-01 11:08:54"));
                Assert.AreEqual(data1.EndTime, DateTime.Parse("2024-11-02 11:08:54"));
                Assert.AreEqual(data2.EndTime, DateTime.Parse("2024-11-02 11:08:54"));
                Assert.AreEqual(data1.TrainingUnit, "g");
                Assert.AreEqual(data2.TrainingUnit, "g");
                Assert.AreEqual(data1.Examin, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data2.Examin, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data1.Reason, "e7zi");
                Assert.AreEqual(data2.Reason, "e7zi");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Training v1 = new Training();
            Training v2 = new Training();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "wBROXbVDWB2oOl";
                v1.Name = "GHuGSI";
                v1.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v1.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v1.TrainName = "hkVI2sbnFrzGTA";
                v1.TeachingTime = 659793780;
                v1.StartTime = DateTime.Parse("2024-10-25 11:08:54");
                v1.EndTime = DateTime.Parse("2024-02-02 11:08:54");
                v1.TrainingUnit = "jihD9r5cBv3mKrryF";
                v1.Examin = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "4HnnkIE4C0Kc0dP";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "kk";
                v2.Name = "bX5HnYh2";
                v2.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
                v2.TrainName = "Ip3geGeXlbccDudF6P3AX3iEZGxPopABTisxBfVVPgI";
                v2.TeachingTime = 357583436;
                v2.StartTime = DateTime.Parse("2025-01-04 11:08:54");
                v2.EndTime = DateTime.Parse("2024-11-12 11:08:54");
                v2.TrainingUnit = "tut49G2bn";
                v2.Examin = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "IREIq0GeP9AkL";
                context.Set<Training>().Add(v1);
                context.Set<Training>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TrainingBatchVM));

            TrainingBatchVM vm = rv.Model as TrainingBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Training>().Find(v1.ID);
                var data2 = context.Set<Training>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
