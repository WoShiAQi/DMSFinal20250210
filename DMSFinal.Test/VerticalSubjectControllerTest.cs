using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.VerticalSubjectVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class VerticalSubjectControllerTest
    {
        private VerticalSubjectController _controller;
        private string _seed;

        public VerticalSubjectControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<VerticalSubjectController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as VerticalSubjectListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(VerticalSubjectVM));

            VerticalSubjectVM vm = rv.Model as VerticalSubjectVM;
            VerticalSubject v = new VerticalSubject();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "WojkTKhHhJgz37i";
            v.Name = "h2Xx";
            v.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
            v.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
            v.SubjectName = "peQld0gISWzImkRmlsu";
            v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
            v.SubjectSource = "g2twO3K4P8BoiQ7h";
            v.SubjectNo = "vu0j7m";
            v.Funds = 74;
            v.StartTime = DateTime.Parse("2025-01-03 11:10:09");
            v.IfCose = DMSFinal.Model.IfEnum.Yes;
            v.EndTime = DateTime.Parse("2023-10-10 11:10:09");
            v.Rank = DMSFinal.Model.RankEnum.Ten;
            v.IfOurSchool = DMSFinal.Model.IfEnum.No;
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "nw9Fs0dFEG";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<VerticalSubject>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "WojkTKhHhJgz37i");
                Assert.AreEqual(data.Name, "h2Xx");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.AssociateProfessor);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.GaoShiYan);
                Assert.AreEqual(data.SubjectName, "peQld0gISWzImkRmlsu");
                Assert.AreEqual(data.SubjectLevel, DMSFinal.Model.SubjectEnum.Shi);
                Assert.AreEqual(data.SubjectSource, "g2twO3K4P8BoiQ7h");
                Assert.AreEqual(data.SubjectNo, "vu0j7m");
                Assert.AreEqual(data.Funds, 74);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2025-01-03 11:10:09"));
                Assert.AreEqual(data.IfCose, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.EndTime, DateTime.Parse("2023-10-10 11:10:09"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Ten);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "nw9Fs0dFEG");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            VerticalSubject v = new VerticalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "WojkTKhHhJgz37i";
                v.Name = "h2Xx";
                v.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
                v.SubjectName = "peQld0gISWzImkRmlsu";
                v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v.SubjectSource = "g2twO3K4P8BoiQ7h";
                v.SubjectNo = "vu0j7m";
                v.Funds = 74;
                v.StartTime = DateTime.Parse("2025-01-03 11:10:09");
                v.IfCose = DMSFinal.Model.IfEnum.Yes;
                v.EndTime = DateTime.Parse("2023-10-10 11:10:09");
                v.Rank = DMSFinal.Model.RankEnum.Ten;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "nw9Fs0dFEG";
                context.Set<VerticalSubject>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(VerticalSubjectVM));

            VerticalSubjectVM vm = rv.Model as VerticalSubjectVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new VerticalSubject();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "Kh";
            v.Name = "ztVt6teXh";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
            v.SubjectName = "FnRFZoiEXxuHa4";
            v.SubjectLevel = DMSFinal.Model.SubjectEnum.Guo;
            v.SubjectSource = "DDwdVDzMuMEw9eU";
            v.SubjectNo = "Qn87cvjhv";
            v.Funds = 46;
            v.StartTime = DateTime.Parse("2023-11-24 11:10:09");
            v.IfCose = DMSFinal.Model.IfEnum.No;
            v.EndTime = DateTime.Parse("2024-03-14 11:10:09");
            v.Rank = DMSFinal.Model.RankEnum.Eight;
            v.IfOurSchool = DMSFinal.Model.IfEnum.No;
            v.Examine = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "lcSwADoV7VI49bcJy";
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
            vm.FC.Add("Entity.IfCose", "");
            vm.FC.Add("Entity.EndTime", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.IfOurSchool", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<VerticalSubject>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "Kh");
                Assert.AreEqual(data.Name, "ztVt6teXh");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.JIshu);
                Assert.AreEqual(data.SubjectName, "FnRFZoiEXxuHa4");
                Assert.AreEqual(data.SubjectLevel, DMSFinal.Model.SubjectEnum.Guo);
                Assert.AreEqual(data.SubjectSource, "DDwdVDzMuMEw9eU");
                Assert.AreEqual(data.SubjectNo, "Qn87cvjhv");
                Assert.AreEqual(data.Funds, 46);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2023-11-24 11:10:09"));
                Assert.AreEqual(data.IfCose, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-03-14 11:10:09"));
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Eight);
                Assert.AreEqual(data.IfOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "lcSwADoV7VI49bcJy");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            VerticalSubject v = new VerticalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "WojkTKhHhJgz37i";
                v.Name = "h2Xx";
                v.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
                v.SubjectName = "peQld0gISWzImkRmlsu";
                v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v.SubjectSource = "g2twO3K4P8BoiQ7h";
                v.SubjectNo = "vu0j7m";
                v.Funds = 74;
                v.StartTime = DateTime.Parse("2025-01-03 11:10:09");
                v.IfCose = DMSFinal.Model.IfEnum.Yes;
                v.EndTime = DateTime.Parse("2023-10-10 11:10:09");
                v.Rank = DMSFinal.Model.RankEnum.Ten;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "nw9Fs0dFEG";
                context.Set<VerticalSubject>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(VerticalSubjectVM));

            VerticalSubjectVM vm = rv.Model as VerticalSubjectVM;
            v = new VerticalSubject();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<VerticalSubject>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            VerticalSubject v = new VerticalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "WojkTKhHhJgz37i";
                v.Name = "h2Xx";
                v.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
                v.SubjectName = "peQld0gISWzImkRmlsu";
                v.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v.SubjectSource = "g2twO3K4P8BoiQ7h";
                v.SubjectNo = "vu0j7m";
                v.Funds = 74;
                v.StartTime = DateTime.Parse("2025-01-03 11:10:09");
                v.IfCose = DMSFinal.Model.IfEnum.Yes;
                v.EndTime = DateTime.Parse("2023-10-10 11:10:09");
                v.Rank = DMSFinal.Model.RankEnum.Ten;
                v.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "nw9Fs0dFEG";
                context.Set<VerticalSubject>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            VerticalSubject v1 = new VerticalSubject();
            VerticalSubject v2 = new VerticalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "WojkTKhHhJgz37i";
                v1.Name = "h2Xx";
                v1.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v1.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
                v1.SubjectName = "peQld0gISWzImkRmlsu";
                v1.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v1.SubjectSource = "g2twO3K4P8BoiQ7h";
                v1.SubjectNo = "vu0j7m";
                v1.Funds = 74;
                v1.StartTime = DateTime.Parse("2025-01-03 11:10:09");
                v1.IfCose = DMSFinal.Model.IfEnum.Yes;
                v1.EndTime = DateTime.Parse("2023-10-10 11:10:09");
                v1.Rank = DMSFinal.Model.RankEnum.Ten;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "nw9Fs0dFEG";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "Kh";
                v2.Name = "ztVt6teXh";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v2.SubjectName = "FnRFZoiEXxuHa4";
                v2.SubjectLevel = DMSFinal.Model.SubjectEnum.Guo;
                v2.SubjectSource = "DDwdVDzMuMEw9eU";
                v2.SubjectNo = "Qn87cvjhv";
                v2.Funds = 46;
                v2.StartTime = DateTime.Parse("2023-11-24 11:10:09");
                v2.IfCose = DMSFinal.Model.IfEnum.No;
                v2.EndTime = DateTime.Parse("2024-03-14 11:10:09");
                v2.Rank = DMSFinal.Model.RankEnum.Eight;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "lcSwADoV7VI49bcJy";
                context.Set<VerticalSubject>().Add(v1);
                context.Set<VerticalSubject>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(VerticalSubjectBatchVM));

            VerticalSubjectBatchVM vm = rv.Model as VerticalSubjectBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "iDI";
            vm.LinkedVM.Name = "sqGEbfB0ml4";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
            vm.LinkedVM.SubjectName = "zP3DSYok";
            vm.LinkedVM.SubjectLevel = DMSFinal.Model.SubjectEnum.Xiao;
            vm.LinkedVM.SubjectSource = "TgnveVjxPUZLOH4iE";
            vm.LinkedVM.SubjectNo = "FIFgIF5qawjN4PZ4c";
            vm.LinkedVM.Funds = 68;
            vm.LinkedVM.StartTime = DateTime.Parse("2024-12-20 11:10:09");
            vm.LinkedVM.IfCose = DMSFinal.Model.IfEnum.No;
            vm.LinkedVM.EndTime = DateTime.Parse("2025-11-14 11:10:09");
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.Eight;
            vm.LinkedVM.IfOurSchool = DMSFinal.Model.IfEnum.Yes;
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Checking;
            vm.LinkedVM.Reason = "be0oy";
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
            vm.FC.Add("LinkedVM.IfCose", "");
            vm.FC.Add("LinkedVM.EndTime", "");
            vm.FC.Add("LinkedVM.Rank", "");
            vm.FC.Add("LinkedVM.IfOurSchool", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<VerticalSubject>().Find(v1.ID);
                var data2 = context.Set<VerticalSubject>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "iDI");
                Assert.AreEqual(data2.JobNo, "iDI");
                Assert.AreEqual(data1.Name, "sqGEbfB0ml4");
                Assert.AreEqual(data2.Name, "sqGEbfB0ml4");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.GaoShiYan);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.GaoShiYan);
                Assert.AreEqual(data1.SubjectName, "zP3DSYok");
                Assert.AreEqual(data2.SubjectName, "zP3DSYok");
                Assert.AreEqual(data1.SubjectLevel, DMSFinal.Model.SubjectEnum.Xiao);
                Assert.AreEqual(data2.SubjectLevel, DMSFinal.Model.SubjectEnum.Xiao);
                Assert.AreEqual(data1.SubjectSource, "TgnveVjxPUZLOH4iE");
                Assert.AreEqual(data2.SubjectSource, "TgnveVjxPUZLOH4iE");
                Assert.AreEqual(data1.SubjectNo, "FIFgIF5qawjN4PZ4c");
                Assert.AreEqual(data2.SubjectNo, "FIFgIF5qawjN4PZ4c");
                Assert.AreEqual(data1.Funds, 68);
                Assert.AreEqual(data2.Funds, 68);
                Assert.AreEqual(data1.StartTime, DateTime.Parse("2024-12-20 11:10:09"));
                Assert.AreEqual(data2.StartTime, DateTime.Parse("2024-12-20 11:10:09"));
                Assert.AreEqual(data1.IfCose, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data2.IfCose, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data1.EndTime, DateTime.Parse("2025-11-14 11:10:09"));
                Assert.AreEqual(data2.EndTime, DateTime.Parse("2025-11-14 11:10:09"));
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.Eight);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.Eight);
                Assert.AreEqual(data1.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data2.IfOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data1.Reason, "be0oy");
                Assert.AreEqual(data2.Reason, "be0oy");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            VerticalSubject v1 = new VerticalSubject();
            VerticalSubject v2 = new VerticalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "WojkTKhHhJgz37i";
                v1.Name = "h2Xx";
                v1.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v1.Title2 = DMSFinal.Model.TitleEnum2.GaoShiYan;
                v1.SubjectName = "peQld0gISWzImkRmlsu";
                v1.SubjectLevel = DMSFinal.Model.SubjectEnum.Shi;
                v1.SubjectSource = "g2twO3K4P8BoiQ7h";
                v1.SubjectNo = "vu0j7m";
                v1.Funds = 74;
                v1.StartTime = DateTime.Parse("2025-01-03 11:10:09");
                v1.IfCose = DMSFinal.Model.IfEnum.Yes;
                v1.EndTime = DateTime.Parse("2023-10-10 11:10:09");
                v1.Rank = DMSFinal.Model.RankEnum.Ten;
                v1.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "nw9Fs0dFEG";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "Kh";
                v2.Name = "ztVt6teXh";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v2.SubjectName = "FnRFZoiEXxuHa4";
                v2.SubjectLevel = DMSFinal.Model.SubjectEnum.Guo;
                v2.SubjectSource = "DDwdVDzMuMEw9eU";
                v2.SubjectNo = "Qn87cvjhv";
                v2.Funds = 46;
                v2.StartTime = DateTime.Parse("2023-11-24 11:10:09");
                v2.IfCose = DMSFinal.Model.IfEnum.No;
                v2.EndTime = DateTime.Parse("2024-03-14 11:10:09");
                v2.Rank = DMSFinal.Model.RankEnum.Eight;
                v2.IfOurSchool = DMSFinal.Model.IfEnum.No;
                v2.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v2.Reason = "lcSwADoV7VI49bcJy";
                context.Set<VerticalSubject>().Add(v1);
                context.Set<VerticalSubject>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(VerticalSubjectBatchVM));

            VerticalSubjectBatchVM vm = rv.Model as VerticalSubjectBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<VerticalSubject>().Find(v1.ID);
                var data2 = context.Set<VerticalSubject>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
