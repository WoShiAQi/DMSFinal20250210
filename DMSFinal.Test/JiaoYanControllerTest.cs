using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.JiaoYanVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class JiaoYanControllerTest
    {
        private JiaoYanController _controller;
        private string _seed;

        public JiaoYanControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<JiaoYanController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as JiaoYanListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(JiaoYanVM));

            JiaoYanVM vm = rv.Model as JiaoYanVM;
            JiaoYan v = new JiaoYan();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "FZ4";
            v.Name = "V";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            v.SubjectName = "X4U";
            v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
            v.SubjectSource = "OVgKpi";
            v.SubjectNo = "Diqg5";
            v.Funds = 15;
            v.StartTime = DateTime.Parse("2026-01-12 15:17:52");
            v.IfClose = DMSFinal.Model.IfEnum.No;
            v.EndTime = DateTime.Parse("2024-02-12 15:17:52");
            v.Rank = DMSFinal.Model.RankEnum.Six;
            v.IfOurSchool = DMSFinal.Model.IfEnum.No;
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "wJyWmGtC4kcUot8Q";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<JiaoYan>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "FZ4");
                Assert.AreEqual(data.Name, "V");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data.SubjectName, "X4U");
                Assert.AreEqual(data.SubjectLevel, DMSFinal.Model.SubjectEnum.Shi);
                Assert.AreEqual(data.SubjectSource, "OVgKpi");
                Assert.AreEqual(data.SubjectNo, "Diqg5");
                Assert.AreEqual(data.Funds, 15);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2026-01-12 15:17:52"));
                Assert.AreEqual(data.IfClose, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-02-12 15:17:52"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Six);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "wJyWmGtC4kcUot8Q");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            JiaoYan v = new JiaoYan();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "FZ4";
                v.Name = "V";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.SubjectName = "X4U";
                v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v.SubjectSource = "OVgKpi";
                v.SubjectNo = "Diqg5";
                v.Funds = 15;
                v.StartTime = DateTime.Parse("2026-01-12 15:17:52");
                v.IfClose = DMSFinal.Model.IfEnum.No;
                v.EndTime = DateTime.Parse("2024-02-12 15:17:52");
                v.Rank = DMSFinal.Model.RankEnum.Six;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "wJyWmGtC4kcUot8Q";
                context.Set<JiaoYan>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(JiaoYanVM));

            JiaoYanVM vm = rv.Model as JiaoYanVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new JiaoYan();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "EnnnV";
            v.Name = "fkkVzkkXH";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            v.SubjectName = "FUzUp";
            v.SubjectLevel = DMSFinal.Model.SubjectEnum.Guo;
            v.SubjectSource = "Bmy8nHERHWCg7JbkE3";
            v.SubjectNo = "p9Of6RQp69T2c";
            v.Funds = 62;
            v.StartTime = DateTime.Parse("2024-07-21 15:17:52");
            v.IfClose = DMSFinal.Model.IfEnum.Yes;
            v.EndTime = DateTime.Parse("2024-11-17 15:17:52");
            v.Rank = DMSFinal.Model.RankEnum.Nine;
            v.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "b07TCi6qE9hmu";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.SubjectName", "");
            vm.FC.Add("Entity.SubjectLevel", "");
            vm.FC.Add("Entity.SubjectSource", "");
            vm.FC.Add("Entity.SubjectNo", "");
            vm.FC.Add("Entity.Funds", "");
            vm.FC.Add("Entity.StartTime", "");
            vm.FC.Add("Entity.IfClose", "");
            vm.FC.Add("Entity.EndTime", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.IfOurSchool", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<JiaoYan>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "EnnnV");
                Assert.AreEqual(data.Name, "fkkVzkkXH");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data.SubjectName, "FUzUp");
                Assert.AreEqual(data.SubjectLevel, DMSFinal.Model.SubjectEnum.Guo);
                Assert.AreEqual(data.SubjectSource, "Bmy8nHERHWCg7JbkE3");
                Assert.AreEqual(data.SubjectNo, "p9Of6RQp69T2c");
                Assert.AreEqual(data.Funds, 62);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2024-07-21 15:17:52"));
                Assert.AreEqual(data.IfClose, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-11-17 15:17:52"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Nine);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "b07TCi6qE9hmu");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            JiaoYan v = new JiaoYan();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "FZ4";
                v.Name = "V";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.SubjectName = "X4U";
                v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v.SubjectSource = "OVgKpi";
                v.SubjectNo = "Diqg5";
                v.Funds = 15;
                v.StartTime = DateTime.Parse("2026-01-12 15:17:52");
                v.IfClose = DMSFinal.Model.IfEnum.No;
                v.EndTime = DateTime.Parse("2024-02-12 15:17:52");
                v.Rank = DMSFinal.Model.RankEnum.Six;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "wJyWmGtC4kcUot8Q";
                context.Set<JiaoYan>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(JiaoYanVM));

            JiaoYanVM vm = rv.Model as JiaoYanVM;
            v = new JiaoYan();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<JiaoYan>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            JiaoYan v = new JiaoYan();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "FZ4";
                v.Name = "V";
                v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.SubjectName = "X4U";
                v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v.SubjectSource = "OVgKpi";
                v.SubjectNo = "Diqg5";
                v.Funds = 15;
                v.StartTime = DateTime.Parse("2026-01-12 15:17:52");
                v.IfClose = DMSFinal.Model.IfEnum.No;
                v.EndTime = DateTime.Parse("2024-02-12 15:17:52");
                v.Rank = DMSFinal.Model.RankEnum.Six;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "wJyWmGtC4kcUot8Q";
                context.Set<JiaoYan>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            JiaoYan v1 = new JiaoYan();
            JiaoYan v2 = new JiaoYan();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "FZ4";
                v1.Name = "V";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.SubjectName = "X4U";
                v1.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v1.SubjectSource = "OVgKpi";
                v1.SubjectNo = "Diqg5";
                v1.Funds = 15;
                v1.StartTime = DateTime.Parse("2026-01-12 15:17:52");
                v1.IfClose = DMSFinal.Model.IfEnum.No;
                v1.EndTime = DateTime.Parse("2024-02-12 15:17:52");
                v1.Rank = DMSFinal.Model.RankEnum.Six;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "wJyWmGtC4kcUot8Q";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "EnnnV";
                v2.Name = "fkkVzkkXH";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v2.SubjectName = "FUzUp";
                v2.SubjectLevel = DMSFinal.Model.SubjectEnum.Guo;
                v2.SubjectSource = "Bmy8nHERHWCg7JbkE3";
                v2.SubjectNo = "p9Of6RQp69T2c";
                v2.Funds = 62;
                v2.StartTime = DateTime.Parse("2024-07-21 15:17:52");
                v2.IfClose = DMSFinal.Model.IfEnum.Yes;
                v2.EndTime = DateTime.Parse("2024-11-17 15:17:52");
                v2.Rank = DMSFinal.Model.RankEnum.Nine;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "b07TCi6qE9hmu";
                context.Set<JiaoYan>().Add(v1);
                context.Set<JiaoYan>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(JiaoYanBatchVM));

            JiaoYanBatchVM vm = rv.Model as JiaoYanBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "zwx";
            vm.LinkedVM.Name = "ZI5l";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Professor;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
            vm.LinkedVM.SubjectName = "ioazAVKXpGWy6LY";
            vm.LinkedVM.SubjectLevel = DMSFinal.Model.SubjectEnum.Xiao;
            vm.LinkedVM.SubjectSource = "AS";
            vm.LinkedVM.SubjectNo = "08WQwesLIF";
            vm.LinkedVM.Funds = 86;
            vm.LinkedVM.StartTime = DateTime.Parse("2024-01-31 15:17:52");
            vm.LinkedVM.IfClose = DMSFinal.Model.IfEnum.Yes;
            vm.LinkedVM.EndTime = DateTime.Parse("2023-07-17 15:17:52");
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.One;
            vm.LinkedVM.IfOurSchool = DMSFinal.Model.IfEnum.No;
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Pass;
            vm.LinkedVM.Reason = "v";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.SubjectName", "");
            vm.FC.Add("LinkedVM.SubjectLevel", "");
            vm.FC.Add("LinkedVM.SubjectSource", "");
            vm.FC.Add("LinkedVM.SubjectNo", "");
            vm.FC.Add("LinkedVM.Funds", "");
            vm.FC.Add("LinkedVM.StartTime", "");
            vm.FC.Add("LinkedVM.IfClose", "");
            vm.FC.Add("LinkedVM.EndTime", "");
            vm.FC.Add("LinkedVM.Rank", "");
            vm.FC.Add("LinkedVM.IfOurSchool", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<JiaoYan>().Find(v1.ID);
                var data2 = context.Set<JiaoYan>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "zwx");
                Assert.AreEqual(data2.JobNo, "zwx");
                Assert.AreEqual(data1.Name, "ZI5l");
                Assert.AreEqual(data2.Name, "ZI5l");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Professor);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Professor);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.GaoShiYan);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.GaoShiYan);
                Assert.AreEqual(data1.SubjectName, "ioazAVKXpGWy6LY");
                Assert.AreEqual(data2.SubjectName, "ioazAVKXpGWy6LY");
                Assert.AreEqual(data1.SubjectLevel, DMSFinal.Model.SubjectEnum.Xiao);
                Assert.AreEqual(data2.SubjectLevel, DMSFinal.Model.SubjectEnum.Xiao);
                Assert.AreEqual(data1.SubjectSource, "AS");
                Assert.AreEqual(data2.SubjectSource, "AS");
                Assert.AreEqual(data1.SubjectNo, "08WQwesLIF");
                Assert.AreEqual(data2.SubjectNo, "08WQwesLIF");
                Assert.AreEqual(data1.Funds, 86);
                Assert.AreEqual(data2.Funds, 86);
                Assert.AreEqual(data1.StartTime, DateTime.Parse("2024-01-31 15:17:52"));
                Assert.AreEqual(data2.StartTime, DateTime.Parse("2024-01-31 15:17:52"));
                Assert.AreEqual(data1.IfClose, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data2.IfClose, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data1.EndTime, DateTime.Parse("2023-07-17 15:17:52"));
                Assert.AreEqual(data2.EndTime, DateTime.Parse("2023-07-17 15:17:52"));
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.One);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.One);
                Assert.AreEqual(data1.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data2.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data1.Reason, "v");
                Assert.AreEqual(data2.Reason, "v");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            JiaoYan v1 = new JiaoYan();
            JiaoYan v2 = new JiaoYan();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "FZ4";
                v1.Name = "V";
                v1.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.SubjectName = "X4U";
                v1.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v1.SubjectSource = "OVgKpi";
                v1.SubjectNo = "Diqg5";
                v1.Funds = 15;
                v1.StartTime = DateTime.Parse("2026-01-12 15:17:52");
                v1.IfClose = DMSFinal.Model.IfEnum.No;
                v1.EndTime = DateTime.Parse("2024-02-12 15:17:52");
                v1.Rank = DMSFinal.Model.RankEnum.Six;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "wJyWmGtC4kcUot8Q";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "EnnnV";
                v2.Name = "fkkVzkkXH";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v2.SubjectName = "FUzUp";
                v2.SubjectLevel = DMSFinal.Model.SubjectEnum.Guo;
                v2.SubjectSource = "Bmy8nHERHWCg7JbkE3";
                v2.SubjectNo = "p9Of6RQp69T2c";
                v2.Funds = 62;
                v2.StartTime = DateTime.Parse("2024-07-21 15:17:52");
                v2.IfClose = DMSFinal.Model.IfEnum.Yes;
                v2.EndTime = DateTime.Parse("2024-11-17 15:17:52");
                v2.Rank = DMSFinal.Model.RankEnum.Nine;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "b07TCi6qE9hmu";
                context.Set<JiaoYan>().Add(v1);
                context.Set<JiaoYan>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(JiaoYanBatchVM));

            JiaoYanBatchVM vm = rv.Model as JiaoYanBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<JiaoYan>().Find(v1.ID);
                var data2 = context.Set<JiaoYan>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
