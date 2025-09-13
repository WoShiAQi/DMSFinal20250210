using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.EnterprisePracticeVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class EnterprisePracticeControllerTest
    {
        private EnterprisePracticeController _controller;
        private string _seed;

        public EnterprisePracticeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<EnterprisePracticeController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as EnterprisePracticeListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(EnterprisePracticeVM));

            EnterprisePracticeVM vm = rv.Model as EnterprisePracticeVM;
            EnterprisePractice v = new EnterprisePractice();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "R";
            v.Name = "o3HVOIrIdFHc";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
            v.CompanyName = "7l2GstivHkjOBYlUp";
            v.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
            v.StartTime = DateTime.Parse("2025-07-10 10:54:02");
            v.EndTime = DateTime.Parse("2024-02-21 10:54:02");
            v.Contacts = "uJxF";
            v.PhoneNumber = "uVU38Tc237gm";
            v.Examine = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "Lsh2Y61jh";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterprisePractice>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "R");
                Assert.AreEqual(data.Name, "o3HVOIrIdFHc");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.AssShiYan);
                Assert.AreEqual(data.CompanyName, "7l2GstivHkjOBYlUp");
                Assert.AreEqual(data.PracticalWay, DMSFinal.Model.PracticeEnum.summer);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2025-07-10 10:54:02"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-02-21 10:54:02"));
                Assert.AreEqual(data.Contacts, "uJxF");
                Assert.AreEqual(data.PhoneNumber, "uVU38Tc237gm");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "Lsh2Y61jh");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            EnterprisePractice v = new EnterprisePractice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "R";
                v.Name = "o3HVOIrIdFHc";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v.CompanyName = "7l2GstivHkjOBYlUp";
                v.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
                v.StartTime = DateTime.Parse("2025-07-10 10:54:02");
                v.EndTime = DateTime.Parse("2024-02-21 10:54:02");
                v.Contacts = "uJxF";
                v.PhoneNumber = "uVU38Tc237gm";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "Lsh2Y61jh";
                context.Set<EnterprisePractice>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterprisePracticeVM));

            EnterprisePracticeVM vm = rv.Model as EnterprisePracticeVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new EnterprisePractice();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "ru8vNSRqjgjSm9QlzF";
            v.Name = "lvzy8Y";
            v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
            v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
            v.CompanyName = "opCRehb6ax";
            v.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
            v.StartTime = DateTime.Parse("2025-12-29 10:54:02");
            v.EndTime = DateTime.Parse("2026-01-04 10:54:02");
            v.Contacts = "C8EK";
            v.PhoneNumber = "T";
            v.Examine = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "6XU4fn";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.CompanyName", "");
            vm.FC.Add("Entity.PracticalWay", "");
            vm.FC.Add("Entity.StartTime", "");
            vm.FC.Add("Entity.EndTime", "");
            vm.FC.Add("Entity.Contacts", "");
            vm.FC.Add("Entity.PhoneNumber", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterprisePractice>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "ru8vNSRqjgjSm9QlzF");
                Assert.AreEqual(data.Name, "lvzy8Y");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.noTitle);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ShiYanYuan);
                Assert.AreEqual(data.CompanyName, "opCRehb6ax");
                Assert.AreEqual(data.PracticalWay, DMSFinal.Model.PracticeEnum.summer);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2025-12-29 10:54:02"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2026-01-04 10:54:02"));
                Assert.AreEqual(data.Contacts, "C8EK");
                Assert.AreEqual(data.PhoneNumber, "T");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "6XU4fn");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            EnterprisePractice v = new EnterprisePractice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "R";
                v.Name = "o3HVOIrIdFHc";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v.CompanyName = "7l2GstivHkjOBYlUp";
                v.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
                v.StartTime = DateTime.Parse("2025-07-10 10:54:02");
                v.EndTime = DateTime.Parse("2024-02-21 10:54:02");
                v.Contacts = "uJxF";
                v.PhoneNumber = "uVU38Tc237gm";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "Lsh2Y61jh";
                context.Set<EnterprisePractice>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterprisePracticeVM));

            EnterprisePracticeVM vm = rv.Model as EnterprisePracticeVM;
            v = new EnterprisePractice();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterprisePractice>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            EnterprisePractice v = new EnterprisePractice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "R";
                v.Name = "o3HVOIrIdFHc";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v.CompanyName = "7l2GstivHkjOBYlUp";
                v.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
                v.StartTime = DateTime.Parse("2025-07-10 10:54:02");
                v.EndTime = DateTime.Parse("2024-02-21 10:54:02");
                v.Contacts = "uJxF";
                v.PhoneNumber = "uVU38Tc237gm";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "Lsh2Y61jh";
                context.Set<EnterprisePractice>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            EnterprisePractice v1 = new EnterprisePractice();
            EnterprisePractice v2 = new EnterprisePractice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "R";
                v1.Name = "o3HVOIrIdFHc";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v1.CompanyName = "7l2GstivHkjOBYlUp";
                v1.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
                v1.StartTime = DateTime.Parse("2025-07-10 10:54:02");
                v1.EndTime = DateTime.Parse("2024-02-21 10:54:02");
                v1.Contacts = "uJxF";
                v1.PhoneNumber = "uVU38Tc237gm";
                v1.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v1.Reason = "Lsh2Y61jh";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "ru8vNSRqjgjSm9QlzF";
                v2.Name = "lvzy8Y";
                v2.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
                v2.CompanyName = "opCRehb6ax";
                v2.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
                v2.StartTime = DateTime.Parse("2025-12-29 10:54:02");
                v2.EndTime = DateTime.Parse("2026-01-04 10:54:02");
                v2.Contacts = "C8EK";
                v2.PhoneNumber = "T";
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "6XU4fn";
                context.Set<EnterprisePractice>().Add(v1);
                context.Set<EnterprisePractice>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(EnterprisePracticeBatchVM));

            EnterprisePracticeBatchVM vm = rv.Model as EnterprisePracticeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "Bd5j";
            vm.LinkedVM.Name = "v";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            vm.LinkedVM.CompanyName = "l1231OqFqpKAw6zmmrAWrOzzV2h8dt4AuBLSKzkcPumndNM";
            vm.LinkedVM.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
            vm.LinkedVM.StartTime = DateTime.Parse("2025-09-13 10:54:02");
            vm.LinkedVM.EndTime = DateTime.Parse("2025-02-08 10:54:02");
            vm.LinkedVM.Contacts = "7jJSI7QtGY";
            vm.LinkedVM.PhoneNumber = "XvYGnnLxAmXo";
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.NotPass;
            vm.LinkedVM.Reason = "d3q";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.CompanyName", "");
            vm.FC.Add("LinkedVM.PracticalWay", "");
            vm.FC.Add("LinkedVM.StartTime", "");
            vm.FC.Add("LinkedVM.EndTime", "");
            vm.FC.Add("LinkedVM.Contacts", "");
            vm.FC.Add("LinkedVM.PhoneNumber", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<EnterprisePractice>().Find(v1.ID);
                var data2 = context.Set<EnterprisePractice>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "Bd5j");
                Assert.AreEqual(data2.JobNo, "Bd5j");
                Assert.AreEqual(data1.Name, "v");
                Assert.AreEqual(data2.Name, "v");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data1.CompanyName, "l1231OqFqpKAw6zmmrAWrOzzV2h8dt4AuBLSKzkcPumndNM");
                Assert.AreEqual(data2.CompanyName, "l1231OqFqpKAw6zmmrAWrOzzV2h8dt4AuBLSKzkcPumndNM");
                Assert.AreEqual(data1.PracticalWay, DMSFinal.Model.PracticeEnum.summer);
                Assert.AreEqual(data2.PracticalWay, DMSFinal.Model.PracticeEnum.summer);
                Assert.AreEqual(data1.StartTime, DateTime.Parse("2025-09-13 10:54:02"));
                Assert.AreEqual(data2.StartTime, DateTime.Parse("2025-09-13 10:54:02"));
                Assert.AreEqual(data1.EndTime, DateTime.Parse("2025-02-08 10:54:02"));
                Assert.AreEqual(data2.EndTime, DateTime.Parse("2025-02-08 10:54:02"));
                Assert.AreEqual(data1.Contacts, "7jJSI7QtGY");
                Assert.AreEqual(data2.Contacts, "7jJSI7QtGY");
                Assert.AreEqual(data1.PhoneNumber, "XvYGnnLxAmXo");
                Assert.AreEqual(data2.PhoneNumber, "XvYGnnLxAmXo");
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data1.Reason, "d3q");
                Assert.AreEqual(data2.Reason, "d3q");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            EnterprisePractice v1 = new EnterprisePractice();
            EnterprisePractice v2 = new EnterprisePractice();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "R";
                v1.Name = "o3HVOIrIdFHc";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
                v1.CompanyName = "7l2GstivHkjOBYlUp";
                v1.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
                v1.StartTime = DateTime.Parse("2025-07-10 10:54:02");
                v1.EndTime = DateTime.Parse("2024-02-21 10:54:02");
                v1.Contacts = "uJxF";
                v1.PhoneNumber = "uVU38Tc237gm";
                v1.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v1.Reason = "Lsh2Y61jh";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "ru8vNSRqjgjSm9QlzF";
                v2.Name = "lvzy8Y";
                v2.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanYuan;
                v2.CompanyName = "opCRehb6ax";
                v2.PracticalWay = DMSFinal.Model.PracticeEnum.summer;
                v2.StartTime = DateTime.Parse("2025-12-29 10:54:02");
                v2.EndTime = DateTime.Parse("2026-01-04 10:54:02");
                v2.Contacts = "C8EK";
                v2.PhoneNumber = "T";
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "6XU4fn";
                context.Set<EnterprisePractice>().Add(v1);
                context.Set<EnterprisePractice>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(EnterprisePracticeBatchVM));

            EnterprisePracticeBatchVM vm = rv.Model as EnterprisePracticeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<EnterprisePractice>().Find(v1.ID);
                var data2 = context.Set<EnterprisePractice>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
