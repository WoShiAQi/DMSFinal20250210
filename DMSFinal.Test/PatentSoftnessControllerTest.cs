using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.BasicData.ViewModels.PatentSoftnessVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class PatentSoftnessControllerTest
    {
        private PatentSoftnessController _controller;
        private string _seed;

        public PatentSoftnessControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PatentSoftnessController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as PatentSoftnessListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PatentSoftnessVM));

            PatentSoftnessVM vm = rv.Model as PatentSoftnessVM;
            PatentSoftness v = new PatentSoftness();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.Name = "tnBscdv";
            v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
            v.Title2 = DMSFinal.Model.TitleEnum2.GaoJi;
            v.Topic = "MF8FLdoPeCXMH4KsxmKxcIpJdSEtewP1Nj7g5h2Cf9boGL0VuoZ2aw2EZxm4Y6uswh0i7nyQvHSeq";
            v.PatentCategory = DMSFinal.Model.PatentEnum.Copyrights;
            v.AuthorizedDate = DateTime.Parse("2023-07-06 14:16:29");
            v.PatentNumber = "g8KJSpfcEPU";
            v.ApplicationTime = DateTime.Parse("2025-11-13 14:16:29");
            v.ApplicationNumber = "njpZorB";
            v.IfEmployee = DMSFinal.Model.IfEnum.Yes;
            v.Rank = DMSFinal.Model.RankEnum.Two;
            v.IsOurSchool = DMSFinal.Model.IfEnum.No;
            v.HoldTime = 99345927;
            v.JobNo = "orIX3PxCVO";
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "hQE4ZhNzkRgiYYhp2";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PatentSoftness>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.Name, "tnBscdv");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Assistant);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.GaoJi);
                Assert.AreEqual(data.Topic, "MF8FLdoPeCXMH4KsxmKxcIpJdSEtewP1Nj7g5h2Cf9boGL0VuoZ2aw2EZxm4Y6uswh0i7nyQvHSeq");
                Assert.AreEqual(data.PatentCategory, DMSFinal.Model.PatentEnum.Copyrights);
                Assert.AreEqual(data.AuthorizedDate, DateTime.Parse("2023-07-06 14:16:29"));
                Assert.AreEqual(data.PatentNumber, "g8KJSpfcEPU");
                Assert.AreEqual(data.ApplicationTime, DateTime.Parse("2025-11-13 14:16:29"));
                Assert.AreEqual(data.ApplicationNumber, "njpZorB");
                Assert.AreEqual(data.IfEmployee, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Two);
                Assert.AreEqual(data.IsOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.HoldTime, 99345927);
                Assert.AreEqual(data.JobNo, "orIX3PxCVO");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "hQE4ZhNzkRgiYYhp2");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PatentSoftness v = new PatentSoftness();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "tnBscdv";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.GaoJi;
                v.Topic = "MF8FLdoPeCXMH4KsxmKxcIpJdSEtewP1Nj7g5h2Cf9boGL0VuoZ2aw2EZxm4Y6uswh0i7nyQvHSeq";
                v.PatentCategory = DMSFinal.Model.PatentEnum.Copyrights;
                v.AuthorizedDate = DateTime.Parse("2023-07-06 14:16:29");
                v.PatentNumber = "g8KJSpfcEPU";
                v.ApplicationTime = DateTime.Parse("2025-11-13 14:16:29");
                v.ApplicationNumber = "njpZorB";
                v.IfEmployee = DMSFinal.Model.IfEnum.Yes;
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v.HoldTime = 99345927;
                v.JobNo = "orIX3PxCVO";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "hQE4ZhNzkRgiYYhp2";
                context.Set<PatentSoftness>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PatentSoftnessVM));

            PatentSoftnessVM vm = rv.Model as PatentSoftnessVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new PatentSoftness();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.Name = "IB9F";
            v.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
            v.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
            v.Topic = "jGJTshxBStUl6fvU6kx1DQ5sBKch1Hf3W8u6vCZ9GqCG7Owk2OZXeiFSLaS";
            v.PatentCategory = DMSFinal.Model.PatentEnum.IndustrialDesign;
            v.AuthorizedDate = DateTime.Parse("2023-12-04 14:16:29");
            v.PatentNumber = "PviHAsl6oL986XQPuDIoNgHcicgohg8nJ7";
            v.ApplicationTime = DateTime.Parse("2025-05-20 14:16:29");
            v.ApplicationNumber = "NzO8viAHSjMdQd";
            v.IfEmployee = DMSFinal.Model.IfEnum.No;
            v.Rank = DMSFinal.Model.RankEnum.Ten;
            v.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
            v.HoldTime = 545463905;
            v.JobNo = "swWVtoMLB1Zz7";
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "MQMGBQgd";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Department", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Title1", "");
            vm.FC.Add("Entity.Title2", "");
            vm.FC.Add("Entity.Topic", "");
            vm.FC.Add("Entity.PatentCategory", "");
            vm.FC.Add("Entity.AuthorizedDate", "");
            vm.FC.Add("Entity.PatentNumber", "");
            vm.FC.Add("Entity.ApplicationTime", "");
            vm.FC.Add("Entity.ApplicationNumber", "");
            vm.FC.Add("Entity.IfEmployee", "");
            vm.FC.Add("Entity.Rank", "");
            vm.FC.Add("Entity.IsOurSchool", "");
            vm.FC.Add("Entity.HoldTime", "");
            vm.FC.Add("Entity.JobNo", "");
            vm.FC.Add("Entity.Examine", "");
            vm.FC.Add("Entity.Reason", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PatentSoftness>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.Name, "IB9F");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.AssociateProfessor);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.JIshu);
                Assert.AreEqual(data.Topic, "jGJTshxBStUl6fvU6kx1DQ5sBKch1Hf3W8u6vCZ9GqCG7Owk2OZXeiFSLaS");
                Assert.AreEqual(data.PatentCategory, DMSFinal.Model.PatentEnum.IndustrialDesign);
                Assert.AreEqual(data.AuthorizedDate, DateTime.Parse("2023-12-04 14:16:29"));
                Assert.AreEqual(data.PatentNumber, "PviHAsl6oL986XQPuDIoNgHcicgohg8nJ7");
                Assert.AreEqual(data.ApplicationTime, DateTime.Parse("2025-05-20 14:16:29"));
                Assert.AreEqual(data.ApplicationNumber, "NzO8viAHSjMdQd");
                Assert.AreEqual(data.IfEmployee, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data.Rank, DMSFinal.Model.RankEnum.Ten);
                Assert.AreEqual(data.IsOurSchool, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data.HoldTime, 545463905);
                Assert.AreEqual(data.JobNo, "swWVtoMLB1Zz7");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "MQMGBQgd");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PatentSoftness v = new PatentSoftness();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "tnBscdv";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.GaoJi;
                v.Topic = "MF8FLdoPeCXMH4KsxmKxcIpJdSEtewP1Nj7g5h2Cf9boGL0VuoZ2aw2EZxm4Y6uswh0i7nyQvHSeq";
                v.PatentCategory = DMSFinal.Model.PatentEnum.Copyrights;
                v.AuthorizedDate = DateTime.Parse("2023-07-06 14:16:29");
                v.PatentNumber = "g8KJSpfcEPU";
                v.ApplicationTime = DateTime.Parse("2025-11-13 14:16:29");
                v.ApplicationNumber = "njpZorB";
                v.IfEmployee = DMSFinal.Model.IfEnum.Yes;
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v.HoldTime = 99345927;
                v.JobNo = "orIX3PxCVO";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "hQE4ZhNzkRgiYYhp2";
                context.Set<PatentSoftness>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PatentSoftnessVM));

            PatentSoftnessVM vm = rv.Model as PatentSoftnessVM;
            v = new PatentSoftness();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PatentSoftness>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PatentSoftness v = new PatentSoftness();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.Name = "tnBscdv";
                v.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v.Title2 = DMSFinal.Model.TitleEnum2.GaoJi;
                v.Topic = "MF8FLdoPeCXMH4KsxmKxcIpJdSEtewP1Nj7g5h2Cf9boGL0VuoZ2aw2EZxm4Y6uswh0i7nyQvHSeq";
                v.PatentCategory = DMSFinal.Model.PatentEnum.Copyrights;
                v.AuthorizedDate = DateTime.Parse("2023-07-06 14:16:29");
                v.PatentNumber = "g8KJSpfcEPU";
                v.ApplicationTime = DateTime.Parse("2025-11-13 14:16:29");
                v.ApplicationNumber = "njpZorB";
                v.IfEmployee = DMSFinal.Model.IfEnum.Yes;
                v.Rank = DMSFinal.Model.RankEnum.Two;
                v.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v.HoldTime = 99345927;
                v.JobNo = "orIX3PxCVO";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "hQE4ZhNzkRgiYYhp2";
                context.Set<PatentSoftness>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            PatentSoftness v1 = new PatentSoftness();
            PatentSoftness v2 = new PatentSoftness();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.Name = "tnBscdv";
                v1.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v1.Title2 = DMSFinal.Model.TitleEnum2.GaoJi;
                v1.Topic = "MF8FLdoPeCXMH4KsxmKxcIpJdSEtewP1Nj7g5h2Cf9boGL0VuoZ2aw2EZxm4Y6uswh0i7nyQvHSeq";
                v1.PatentCategory = DMSFinal.Model.PatentEnum.Copyrights;
                v1.AuthorizedDate = DateTime.Parse("2023-07-06 14:16:29");
                v1.PatentNumber = "g8KJSpfcEPU";
                v1.ApplicationTime = DateTime.Parse("2025-11-13 14:16:29");
                v1.ApplicationNumber = "njpZorB";
                v1.IfEmployee = DMSFinal.Model.IfEnum.Yes;
                v1.Rank = DMSFinal.Model.RankEnum.Two;
                v1.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v1.HoldTime = 99345927;
                v1.JobNo = "orIX3PxCVO";
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "hQE4ZhNzkRgiYYhp2";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.Name = "IB9F";
                v2.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v2.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v2.Topic = "jGJTshxBStUl6fvU6kx1DQ5sBKch1Hf3W8u6vCZ9GqCG7Owk2OZXeiFSLaS";
                v2.PatentCategory = DMSFinal.Model.PatentEnum.IndustrialDesign;
                v2.AuthorizedDate = DateTime.Parse("2023-12-04 14:16:29");
                v2.PatentNumber = "PviHAsl6oL986XQPuDIoNgHcicgohg8nJ7";
                v2.ApplicationTime = DateTime.Parse("2025-05-20 14:16:29");
                v2.ApplicationNumber = "NzO8viAHSjMdQd";
                v2.IfEmployee = DMSFinal.Model.IfEnum.No;
                v2.Rank = DMSFinal.Model.RankEnum.Ten;
                v2.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.HoldTime = 545463905;
                v2.JobNo = "swWVtoMLB1Zz7";
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "MQMGBQgd";
                context.Set<PatentSoftness>().Add(v1);
                context.Set<PatentSoftness>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PatentSoftnessBatchVM));

            PatentSoftnessBatchVM vm = rv.Model as PatentSoftnessBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Name = "dUtelAsvqL6cPoMGP";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.Lecturer;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.AssShiYan;
            vm.LinkedVM.Topic = "7lT0tUNWhgqMVoRI3oaa5SljqokkY4raSSitGhDVDZ89AgEPOiTm12";
            vm.LinkedVM.PatentCategory = DMSFinal.Model.PatentEnum.Invention;
            vm.LinkedVM.PatentNumber = "fbDQ3MvjNLaahDm";
            vm.LinkedVM.IfEmployee = DMSFinal.Model.IfEnum.Yes;
            vm.LinkedVM.Rank = DMSFinal.Model.RankEnum.Five;
            vm.LinkedVM.IsOurSchool = DMSFinal.Model.IfEnum.No;
            vm.LinkedVM.HoldTime = 219420930;
            vm.LinkedVM.JobNo = "CjHs";
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Pass;
            vm.LinkedVM.Reason = "mLMurq9VncJm";
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("LinkedVM.Name", "");
            vm.FC.Add("LinkedVM.Title1", "");
            vm.FC.Add("LinkedVM.Title2", "");
            vm.FC.Add("LinkedVM.Topic", "");
            vm.FC.Add("LinkedVM.PatentCategory", "");
            vm.FC.Add("LinkedVM.PatentNumber", "");
            vm.FC.Add("LinkedVM.IfEmployee", "");
            vm.FC.Add("LinkedVM.Rank", "");
            vm.FC.Add("LinkedVM.IsOurSchool", "");
            vm.FC.Add("LinkedVM.HoldTime", "");
            vm.FC.Add("LinkedVM.JobNo", "");
            vm.FC.Add("LinkedVM.Examine", "");
            vm.FC.Add("LinkedVM.Reason", "");
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<PatentSoftness>().Find(v1.ID);
                var data2 = context.Set<PatentSoftness>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Name, "dUtelAsvqL6cPoMGP");
                Assert.AreEqual(data2.Name, "dUtelAsvqL6cPoMGP");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.Lecturer);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.AssShiYan);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.AssShiYan);
                Assert.AreEqual(data1.Topic, "7lT0tUNWhgqMVoRI3oaa5SljqokkY4raSSitGhDVDZ89AgEPOiTm12");
                Assert.AreEqual(data2.Topic, "7lT0tUNWhgqMVoRI3oaa5SljqokkY4raSSitGhDVDZ89AgEPOiTm12");
                Assert.AreEqual(data1.PatentCategory, DMSFinal.Model.PatentEnum.Invention);
                Assert.AreEqual(data2.PatentCategory, DMSFinal.Model.PatentEnum.Invention);
                Assert.AreEqual(data1.PatentNumber, "fbDQ3MvjNLaahDm");
                Assert.AreEqual(data2.PatentNumber, "fbDQ3MvjNLaahDm");
                Assert.AreEqual(data1.IfEmployee, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data2.IfEmployee, DMSFinal.Model.IfEnum.Yes);
                Assert.AreEqual(data1.Rank, DMSFinal.Model.RankEnum.Five);
                Assert.AreEqual(data2.Rank, DMSFinal.Model.RankEnum.Five);
                Assert.AreEqual(data1.IsOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data2.IsOurSchool, DMSFinal.Model.IfEnum.No);
                Assert.AreEqual(data1.HoldTime, 219420930);
                Assert.AreEqual(data2.HoldTime, 219420930);
                Assert.AreEqual(data1.JobNo, "CjHs");
                Assert.AreEqual(data2.JobNo, "CjHs");
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data1.Reason, "mLMurq9VncJm");
                Assert.AreEqual(data2.Reason, "mLMurq9VncJm");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            PatentSoftness v1 = new PatentSoftness();
            PatentSoftness v2 = new PatentSoftness();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.Name = "tnBscdv";
                v1.Title1 = DMSFinal.Model.TitleEnum.Assistant;
                v1.Title2 = DMSFinal.Model.TitleEnum2.GaoJi;
                v1.Topic = "MF8FLdoPeCXMH4KsxmKxcIpJdSEtewP1Nj7g5h2Cf9boGL0VuoZ2aw2EZxm4Y6uswh0i7nyQvHSeq";
                v1.PatentCategory = DMSFinal.Model.PatentEnum.Copyrights;
                v1.AuthorizedDate = DateTime.Parse("2023-07-06 14:16:29");
                v1.PatentNumber = "g8KJSpfcEPU";
                v1.ApplicationTime = DateTime.Parse("2025-11-13 14:16:29");
                v1.ApplicationNumber = "njpZorB";
                v1.IfEmployee = DMSFinal.Model.IfEnum.Yes;
                v1.Rank = DMSFinal.Model.RankEnum.Two;
                v1.IsOurSchool = DMSFinal.Model.IfEnum.No;
                v1.HoldTime = 99345927;
                v1.JobNo = "orIX3PxCVO";
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "hQE4ZhNzkRgiYYhp2";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.Name = "IB9F";
                v2.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v2.Title2 = DMSFinal.Model.TitleEnum2.JIshu;
                v2.Topic = "jGJTshxBStUl6fvU6kx1DQ5sBKch1Hf3W8u6vCZ9GqCG7Owk2OZXeiFSLaS";
                v2.PatentCategory = DMSFinal.Model.PatentEnum.IndustrialDesign;
                v2.AuthorizedDate = DateTime.Parse("2023-12-04 14:16:29");
                v2.PatentNumber = "PviHAsl6oL986XQPuDIoNgHcicgohg8nJ7";
                v2.ApplicationTime = DateTime.Parse("2025-05-20 14:16:29");
                v2.ApplicationNumber = "NzO8viAHSjMdQd";
                v2.IfEmployee = DMSFinal.Model.IfEnum.No;
                v2.Rank = DMSFinal.Model.RankEnum.Ten;
                v2.IsOurSchool = DMSFinal.Model.IfEnum.Yes;
                v2.HoldTime = 545463905;
                v2.JobNo = "swWVtoMLB1Zz7";
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "MQMGBQgd";
                context.Set<PatentSoftness>().Add(v1);
                context.Set<PatentSoftness>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PatentSoftnessBatchVM));

            PatentSoftnessBatchVM vm = rv.Model as PatentSoftnessBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<PatentSoftness>().Find(v1.ID);
                var data2 = context.Set<PatentSoftness>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
