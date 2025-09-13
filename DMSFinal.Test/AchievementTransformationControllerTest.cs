using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.AchievementTransformationVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class AchievementTransformationControllerTest
    {
        private AchievementTransformationController _controller;
        private string _seed;

        public AchievementTransformationControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<AchievementTransformationController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as AchievementTransformationListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(AchievementTransformationVM));

            AchievementTransformationVM vm = rv.Model as AchievementTransformationVM;
            AchievementTransformation v = new AchievementTransformation();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "9p";
            v.Name = "zCAVEm7E3";
            v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
            v.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
            v.SubjectName = "RLapGn2UNa8Nu8MtJ7eCitTcVGyv1mJ45FqmVmdErt";
            v.CompanyName = "tE";
            v.Funds = 53;
            v.StartTime = DateTime.Parse("2025-08-25 10:55:26");
            v.EndTime = DateTime.Parse("2025-05-15 10:55:26");
            v.Participants = "HEEbXYjxR1o1Uktkle4ayJZtoRqdLEu4ddNVBTWTapgJF3wvKSjfw3U9pVwFsGlNG";
            v.Examine = DMSFinal.Model.CheckEnum.NotPass;
            v.Reason = "7r5BTNKlfOHc7macNZ";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<AchievementTransformation>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "9p");
                Assert.AreEqual(data.Name, "zCAVEm7E3");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.noTitle);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.JIshu);
                Assert.AreEqual(data.SubjectName, "RLapGn2UNa8Nu8MtJ7eCitTcVGyv1mJ45FqmVmdErt");
                Assert.AreEqual(data.CompanyName, "tE");
                Assert.AreEqual(data.Funds, 53);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2025-08-25 10:55:26"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2025-05-15 10:55:26"));
                Assert.AreEqual(data.Participants, "HEEbXYjxR1o1Uktkle4ayJZtoRqdLEu4ddNVBTWTapgJF3wvKSjfw3U9pVwFsGlNG");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data.Reason, "7r5BTNKlfOHc7macNZ");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            AchievementTransformation v = new AchievementTransformation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "9p";
                v.Name = "zCAVEm7E3";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v.SubjectName = "RLapGn2UNa8Nu8MtJ7eCitTcVGyv1mJ45FqmVmdErt";
                v.CompanyName = "tE";
                v.Funds = 53;
                v.StartTime = DateTime.Parse("2025-08-25 10:55:26");
                v.EndTime = DateTime.Parse("2025-05-15 10:55:26");
                v.Participants = "HEEbXYjxR1o1Uktkle4ayJZtoRqdLEu4ddNVBTWTapgJF3wvKSjfw3U9pVwFsGlNG";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "7r5BTNKlfOHc7macNZ";
                context.Set<AchievementTransformation>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AchievementTransformationVM));

            AchievementTransformationVM vm = rv.Model as AchievementTransformationVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new AchievementTransformation();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "Zy64Rfk";
            v.Name = "ltKGjY2";
            v.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            v.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
            v.SubjectName = "Kw9viFNqJZ0TZdJxE9mQN92ZB3YHkh0BBKbdTIDyOVLoIfygiUDCQR8M5juqqGFmZ9SPBpd65";
            v.CompanyName = "z0GzU1CuVObc3xjw7rsjKQeYlBJHDCt5iZXFwCxg0MwUzJszCrUG5mPjesNTr5rSfg4";
            v.Funds = 44;
            v.StartTime = DateTime.Parse("2023-08-05 10:55:26");
            v.EndTime = DateTime.Parse("2024-12-08 10:55:26");
            v.Participants = "3Yg4I5GfOYnfEDFR9b9IbB8VE8keH45SArJHaK2D";
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "VaLetoUz7Skv8Zj";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.SubjectName", "");
            vm.FC.Add("Entity.CompanyName", "");
            vm.FC.Add("Entity.Funds", "");
            vm.FC.Add("Entity.StartTime", "");
            vm.FC.Add("Entity.EndTime", "");
            vm.FC.Add("Entity.Participants", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<AchievementTransformation>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "Zy64Rfk");
                Assert.AreEqual(data.Name, "ltKGjY2");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.ShiYanShi);
                Assert.AreEqual(data.SubjectName, "Kw9viFNqJZ0TZdJxE9mQN92ZB3YHkh0BBKbdTIDyOVLoIfygiUDCQR8M5juqqGFmZ9SPBpd65");
                Assert.AreEqual(data.CompanyName, "z0GzU1CuVObc3xjw7rsjKQeYlBJHDCt5iZXFwCxg0MwUzJszCrUG5mPjesNTr5rSfg4");
                Assert.AreEqual(data.Funds, 44);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2023-08-05 10:55:26"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-12-08 10:55:26"));
                Assert.AreEqual(data.Participants, "3Yg4I5GfOYnfEDFR9b9IbB8VE8keH45SArJHaK2D");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "VaLetoUz7Skv8Zj");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            AchievementTransformation v = new AchievementTransformation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "9p";
                v.Name = "zCAVEm7E3";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v.SubjectName = "RLapGn2UNa8Nu8MtJ7eCitTcVGyv1mJ45FqmVmdErt";
                v.CompanyName = "tE";
                v.Funds = 53;
                v.StartTime = DateTime.Parse("2025-08-25 10:55:26");
                v.EndTime = DateTime.Parse("2025-05-15 10:55:26");
                v.Participants = "HEEbXYjxR1o1Uktkle4ayJZtoRqdLEu4ddNVBTWTapgJF3wvKSjfw3U9pVwFsGlNG";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "7r5BTNKlfOHc7macNZ";
                context.Set<AchievementTransformation>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AchievementTransformationVM));

            AchievementTransformationVM vm = rv.Model as AchievementTransformationVM;
            v = new AchievementTransformation();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<AchievementTransformation>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            AchievementTransformation v = new AchievementTransformation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "9p";
                v.Name = "zCAVEm7E3";
                v.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v.SubjectName = "RLapGn2UNa8Nu8MtJ7eCitTcVGyv1mJ45FqmVmdErt";
                v.CompanyName = "tE";
                v.Funds = 53;
                v.StartTime = DateTime.Parse("2025-08-25 10:55:26");
                v.EndTime = DateTime.Parse("2025-05-15 10:55:26");
                v.Participants = "HEEbXYjxR1o1Uktkle4ayJZtoRqdLEu4ddNVBTWTapgJF3wvKSjfw3U9pVwFsGlNG";
                v.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v.Reason = "7r5BTNKlfOHc7macNZ";
                context.Set<AchievementTransformation>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            AchievementTransformation v1 = new AchievementTransformation();
            AchievementTransformation v2 = new AchievementTransformation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "9p";
                v1.Name = "zCAVEm7E3";
                v1.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v1.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v1.SubjectName = "RLapGn2UNa8Nu8MtJ7eCitTcVGyv1mJ45FqmVmdErt";
                v1.CompanyName = "tE";
                v1.Funds = 53;
                v1.StartTime = DateTime.Parse("2025-08-25 10:55:26");
                v1.EndTime = DateTime.Parse("2025-05-15 10:55:26");
                v1.Participants = "HEEbXYjxR1o1Uktkle4ayJZtoRqdLEu4ddNVBTWTapgJF3wvKSjfw3U9pVwFsGlNG";
                v1.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v1.Reason = "7r5BTNKlfOHc7macNZ";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "Zy64Rfk";
                v2.Name = "ltKGjY2";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
                v2.SubjectName = "Kw9viFNqJZ0TZdJxE9mQN92ZB3YHkh0BBKbdTIDyOVLoIfygiUDCQR8M5juqqGFmZ9SPBpd65";
                v2.CompanyName = "z0GzU1CuVObc3xjw7rsjKQeYlBJHDCt5iZXFwCxg0MwUzJszCrUG5mPjesNTr5rSfg4";
                v2.Funds = 44;
                v2.StartTime = DateTime.Parse("2023-08-05 10:55:26");
                v2.EndTime = DateTime.Parse("2024-12-08 10:55:26");
                v2.Participants = "3Yg4I5GfOYnfEDFR9b9IbB8VE8keH45SArJHaK2D";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "VaLetoUz7Skv8Zj";
                context.Set<AchievementTransformation>().Add(v1);
                context.Set<AchievementTransformation>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(AchievementTransformationBatchVM));

            AchievementTransformationBatchVM vm = rv.Model as AchievementTransformationBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "q7QlcE9YSHE";
            vm.LinkedVM.Name = "kjRzaPi5kG";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.ZhengGaoShiYan;
            vm.LinkedVM.SubjectName = "wEWJqmmXCrGbrcrFrGF93ZeQcOvGDeWIcAWdqy2E1Q8XhoOdyV2wnwWWkFqc2g";
            vm.LinkedVM.CompanyName = "hViftxW0xChftTKU9QIjbVM18dmCupNNaKutju48J0EUwhJuBDinmEYLIshQK";
            vm.LinkedVM.Funds = 6;
            vm.LinkedVM.StartTime = DateTime.Parse("2025-05-27 10:55:26");
            vm.LinkedVM.EndTime = DateTime.Parse("2025-04-08 10:55:26");
            vm.LinkedVM.Participants = "0RzofDBjfOiYMOde5LIw6EiDXJ";
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.NotPass;
            vm.LinkedVM.Reason = "afl1Sor6WtH9v";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Department", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.SubjectName", "");
            vm.FC.Add("LinkedVM.CompanyName", "");
            vm.FC.Add("LinkedVM.Funds", "");
            vm.FC.Add("LinkedVM.StartTime", "");
            vm.FC.Add("LinkedVM.EndTime", "");
            vm.FC.Add("LinkedVM.Participants", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<AchievementTransformation>().Find(v1.ID);
                var data2 = context.Set<AchievementTransformation>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "q7QlcE9YSHE");
                Assert.AreEqual(data2.JobNo, "q7QlcE9YSHE");
                Assert.AreEqual(data1.Name, "kjRzaPi5kG");
                Assert.AreEqual(data2.Name, "kjRzaPi5kG");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.AssociateProfessor);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.AssociateProfessor);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.ZhengGaoShiYan);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.ZhengGaoShiYan);
                Assert.AreEqual(data1.SubjectName, "wEWJqmmXCrGbrcrFrGF93ZeQcOvGDeWIcAWdqy2E1Q8XhoOdyV2wnwWWkFqc2g");
                Assert.AreEqual(data2.SubjectName, "wEWJqmmXCrGbrcrFrGF93ZeQcOvGDeWIcAWdqy2E1Q8XhoOdyV2wnwWWkFqc2g");
                Assert.AreEqual(data1.CompanyName, "hViftxW0xChftTKU9QIjbVM18dmCupNNaKutju48J0EUwhJuBDinmEYLIshQK");
                Assert.AreEqual(data2.CompanyName, "hViftxW0xChftTKU9QIjbVM18dmCupNNaKutju48J0EUwhJuBDinmEYLIshQK");
                Assert.AreEqual(data1.Funds, 6);
                Assert.AreEqual(data2.Funds, 6);
                Assert.AreEqual(data1.StartTime, DateTime.Parse("2025-05-27 10:55:26"));
                Assert.AreEqual(data2.StartTime, DateTime.Parse("2025-05-27 10:55:26"));
                Assert.AreEqual(data1.EndTime, DateTime.Parse("2025-04-08 10:55:26"));
                Assert.AreEqual(data2.EndTime, DateTime.Parse("2025-04-08 10:55:26"));
                Assert.AreEqual(data1.Participants, "0RzofDBjfOiYMOde5LIw6EiDXJ");
                Assert.AreEqual(data2.Participants, "0RzofDBjfOiYMOde5LIw6EiDXJ");
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.NotPass);
                Assert.AreEqual(data1.Reason, "afl1Sor6WtH9v");
                Assert.AreEqual(data2.Reason, "afl1Sor6WtH9v");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            AchievementTransformation v1 = new AchievementTransformation();
            AchievementTransformation v2 = new AchievementTransformation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "9p";
                v1.Name = "zCAVEm7E3";
                v1.Title1 = DMSFinal.Model.TitleEnum.noTitle;
                v1.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v1.SubjectName = "RLapGn2UNa8Nu8MtJ7eCitTcVGyv1mJ45FqmVmdErt";
                v1.CompanyName = "tE";
                v1.Funds = 53;
                v1.StartTime = DateTime.Parse("2025-08-25 10:55:26");
                v1.EndTime = DateTime.Parse("2025-05-15 10:55:26");
                v1.Participants = "HEEbXYjxR1o1Uktkle4ayJZtoRqdLEu4ddNVBTWTapgJF3wvKSjfw3U9pVwFsGlNG";
                v1.Examine = DMSFinal.Model.CheckEnum.NotPass;
                v1.Reason = "7r5BTNKlfOHc7macNZ";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "Zy64Rfk";
                v2.Name = "ltKGjY2";
                v2.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
                v2.Title2 = DMSFinal.Model.TitleEnum2.ShiYanShi;
                v2.SubjectName = "Kw9viFNqJZ0TZdJxE9mQN92ZB3YHkh0BBKbdTIDyOVLoIfygiUDCQR8M5juqqGFmZ9SPBpd65";
                v2.CompanyName = "z0GzU1CuVObc3xjw7rsjKQeYlBJHDCt5iZXFwCxg0MwUzJszCrUG5mPjesNTr5rSfg4";
                v2.Funds = 44;
                v2.StartTime = DateTime.Parse("2023-08-05 10:55:26");
                v2.EndTime = DateTime.Parse("2024-12-08 10:55:26");
                v2.Participants = "3Yg4I5GfOYnfEDFR9b9IbB8VE8keH45SArJHaK2D";
                v2.Examine = DMSFinal.Model.CheckEnum.Pass;
                v2.Reason = "VaLetoUz7Skv8Zj";
                context.Set<AchievementTransformation>().Add(v1);
                context.Set<AchievementTransformation>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(AchievementTransformationBatchVM));

            AchievementTransformationBatchVM vm = rv.Model as AchievementTransformationBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<AchievementTransformation>().Find(v1.ID);
                var data2 = context.Set<AchievementTransformation>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
