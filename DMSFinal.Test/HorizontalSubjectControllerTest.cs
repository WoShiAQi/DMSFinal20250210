using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.ApprovedData.ViewModels.HorizontalSubjectVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class HorizontalSubjectControllerTest
    {
        private HorizontalSubjectController _controller;
        private string _seed;

        public HorizontalSubjectControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<HorizontalSubjectController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as HorizontalSubjectListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(HorizontalSubjectVM));

            HorizontalSubjectVM vm = rv.Model as HorizontalSubjectVM;
            HorizontalSubject v = new HorizontalSubject();
			
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "1FtjDrJ";
            v.Name = "Ob";
            v.Title1 = DMSFinal.Model.TitleEnum.Professor;
            v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            v.SubjectName = "sLCNYvE";
            v.CompanyName = "i5JcTToYjmP6B6T1nRhJ1LqUJ";
            v.Funds = 6;
            v.StartTime = DateTime.Parse("2025-03-10 11:03:07");
            v.EndTime = DateTime.Parse("2024-04-15 11:03:07");
            v.Participants = "rziESO31s61nXd5jylE";
            v.Examine = DMSFinal.Model.CheckEnum.Pass;
            v.Reason = "ytOFocGL";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<HorizontalSubject>().Find(v.ID);
				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "1FtjDrJ");
                Assert.AreEqual(data.Name, "Ob");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.Professor);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data.SubjectName, "sLCNYvE");
                Assert.AreEqual(data.CompanyName, "i5JcTToYjmP6B6T1nRhJ1LqUJ");
                Assert.AreEqual(data.Funds, 6);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2025-03-10 11:03:07"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-04-15 11:03:07"));
                Assert.AreEqual(data.Participants, "rziESO31s61nXd5jylE");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data.Reason, "ytOFocGL");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            HorizontalSubject v = new HorizontalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "1FtjDrJ";
                v.Name = "Ob";
                v.Title1 = DMSFinal.Model.TitleEnum.Professor;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.SubjectName = "sLCNYvE";
                v.CompanyName = "i5JcTToYjmP6B6T1nRhJ1LqUJ";
                v.Funds = 6;
                v.StartTime = DateTime.Parse("2025-03-10 11:03:07");
                v.EndTime = DateTime.Parse("2024-04-15 11:03:07");
                v.Participants = "rziESO31s61nXd5jylE";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "ytOFocGL";
                context.Set<HorizontalSubject>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(HorizontalSubjectVM));

            HorizontalSubjectVM vm = rv.Model as HorizontalSubjectVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new HorizontalSubject();
            v.ID = vm.Entity.ID;
       		
            v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            v.JobNo = "5GBzlRBz02";
            v.Name = "MYUhiW8A2";
            v.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
            v.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
            v.SubjectName = "jNRgu9mvt9QhCIHGfCwv5Jh4oKPpC15jET1aPstuYRbofZJPRBm5yENapY2kt8t3EqdtRq1xSBXnr4X";
            v.CompanyName = "1855t3qiXeJswsLMDqz0OWLkRIlaPCBVykne3QVAca0OWK8V7uUHVVGdwUmkRPSUcx5MFrUxVyg";
            v.Funds = 91;
            v.StartTime = DateTime.Parse("2024-12-30 11:03:07");
            v.EndTime = DateTime.Parse("2024-11-08 11:03:07");
            v.Participants = "X7xO63LSZ79p4kYzFWvCII4ULvX3vJoif";
            v.Examine = DMSFinal.Model.CheckEnum.Checking;
            v.Reason = "e47IZ78d";
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
                var data = context.Set<HorizontalSubject>().Find(v.ID);
 				
                Assert.AreEqual(data.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data.JobNo, "5GBzlRBz02");
                Assert.AreEqual(data.Name, "MYUhiW8A2");
                Assert.AreEqual(data.Title1, DMSFinal.Model.TitleEnum.AssociateProfessor);
                Assert.AreEqual(data.Title2, DMSFinal.Model.TitleEnum2.AssGong);
                Assert.AreEqual(data.SubjectName, "jNRgu9mvt9QhCIHGfCwv5Jh4oKPpC15jET1aPstuYRbofZJPRBm5yENapY2kt8t3EqdtRq1xSBXnr4X");
                Assert.AreEqual(data.CompanyName, "1855t3qiXeJswsLMDqz0OWLkRIlaPCBVykne3QVAca0OWK8V7uUHVVGdwUmkRPSUcx5MFrUxVyg");
                Assert.AreEqual(data.Funds, 91);
                Assert.AreEqual(data.StartTime, DateTime.Parse("2024-12-30 11:03:07"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-11-08 11:03:07"));
                Assert.AreEqual(data.Participants, "X7xO63LSZ79p4kYzFWvCII4ULvX3vJoif");
                Assert.AreEqual(data.Examine, DMSFinal.Model.CheckEnum.Checking);
                Assert.AreEqual(data.Reason, "e47IZ78d");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            HorizontalSubject v = new HorizontalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "1FtjDrJ";
                v.Name = "Ob";
                v.Title1 = DMSFinal.Model.TitleEnum.Professor;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.SubjectName = "sLCNYvE";
                v.CompanyName = "i5JcTToYjmP6B6T1nRhJ1LqUJ";
                v.Funds = 6;
                v.StartTime = DateTime.Parse("2025-03-10 11:03:07");
                v.EndTime = DateTime.Parse("2024-04-15 11:03:07");
                v.Participants = "rziESO31s61nXd5jylE";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "ytOFocGL";
                context.Set<HorizontalSubject>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(HorizontalSubjectVM));

            HorizontalSubjectVM vm = rv.Model as HorizontalSubjectVM;
            v = new HorizontalSubject();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<HorizontalSubject>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            HorizontalSubject v = new HorizontalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v.JobNo = "1FtjDrJ";
                v.Name = "Ob";
                v.Title1 = DMSFinal.Model.TitleEnum.Professor;
                v.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v.SubjectName = "sLCNYvE";
                v.CompanyName = "i5JcTToYjmP6B6T1nRhJ1LqUJ";
                v.Funds = 6;
                v.StartTime = DateTime.Parse("2025-03-10 11:03:07");
                v.EndTime = DateTime.Parse("2024-04-15 11:03:07");
                v.Participants = "rziESO31s61nXd5jylE";
                v.Examine = DMSFinal.Model.CheckEnum.Pass;
                v.Reason = "ytOFocGL";
                context.Set<HorizontalSubject>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            HorizontalSubject v1 = new HorizontalSubject();
            HorizontalSubject v2 = new HorizontalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "1FtjDrJ";
                v1.Name = "Ob";
                v1.Title1 = DMSFinal.Model.TitleEnum.Professor;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.SubjectName = "sLCNYvE";
                v1.CompanyName = "i5JcTToYjmP6B6T1nRhJ1LqUJ";
                v1.Funds = 6;
                v1.StartTime = DateTime.Parse("2025-03-10 11:03:07");
                v1.EndTime = DateTime.Parse("2024-04-15 11:03:07");
                v1.Participants = "rziESO31s61nXd5jylE";
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "ytOFocGL";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "5GBzlRBz02";
                v2.Name = "MYUhiW8A2";
                v2.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v2.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v2.SubjectName = "jNRgu9mvt9QhCIHGfCwv5Jh4oKPpC15jET1aPstuYRbofZJPRBm5yENapY2kt8t3EqdtRq1xSBXnr4X";
                v2.CompanyName = "1855t3qiXeJswsLMDqz0OWLkRIlaPCBVykne3QVAca0OWK8V7uUHVVGdwUmkRPSUcx5MFrUxVyg";
                v2.Funds = 91;
                v2.StartTime = DateTime.Parse("2024-12-30 11:03:07");
                v2.EndTime = DateTime.Parse("2024-11-08 11:03:07");
                v2.Participants = "X7xO63LSZ79p4kYzFWvCII4ULvX3vJoif";
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "e47IZ78d";
                context.Set<HorizontalSubject>().Add(v1);
                context.Set<HorizontalSubject>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(HorizontalSubjectBatchVM));

            HorizontalSubjectBatchVM vm = rv.Model as HorizontalSubjectBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.LinkedVM.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
            vm.LinkedVM.JobNo = "Sfm";
            vm.LinkedVM.Name = "2Ro1p";
            vm.LinkedVM.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
            vm.LinkedVM.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
            vm.LinkedVM.SubjectName = "89XY2ouIeo2XRgaTvRnBy";
            vm.LinkedVM.CompanyName = "uSgFexJhhsJ7XQgeqwiNYcHuiUeu1jUqJvV4GZkUGsj6gO6vQtapTStSKvhKSYq";
            vm.LinkedVM.Funds = 37;
            vm.LinkedVM.StartTime = DateTime.Parse("2024-03-10 11:03:07");
            vm.LinkedVM.EndTime = DateTime.Parse("2025-04-05 11:03:07");
            vm.LinkedVM.Participants = "3sqKK8iCjBvoa33KJ6JNTOKVuhAwFgr";
            vm.LinkedVM.Examine = DMSFinal.Model.CheckEnum.Pass;
            vm.LinkedVM.Reason = "jqplcugchgQ";
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
                var data1 = context.Set<HorizontalSubject>().Find(v1.ID);
                var data2 = context.Set<HorizontalSubject>().Find(v2.ID);
 				
                Assert.AreEqual(data1.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data2.Department, DMSFinal.Model.DepartmentEnum.DMSFinal);
                Assert.AreEqual(data1.JobNo, "Sfm");
                Assert.AreEqual(data2.JobNo, "Sfm");
                Assert.AreEqual(data1.Name, "2Ro1p");
                Assert.AreEqual(data2.Name, "2Ro1p");
                Assert.AreEqual(data1.Title1, DMSFinal.Model.TitleEnum.AssociateProfessor);
                Assert.AreEqual(data2.Title1, DMSFinal.Model.TitleEnum.AssociateProfessor);
                Assert.AreEqual(data1.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data2.Title2, DMSFinal.Model.TitleEnum2.noTitle2);
                Assert.AreEqual(data1.SubjectName, "89XY2ouIeo2XRgaTvRnBy");
                Assert.AreEqual(data2.SubjectName, "89XY2ouIeo2XRgaTvRnBy");
                Assert.AreEqual(data1.CompanyName, "uSgFexJhhsJ7XQgeqwiNYcHuiUeu1jUqJvV4GZkUGsj6gO6vQtapTStSKvhKSYq");
                Assert.AreEqual(data2.CompanyName, "uSgFexJhhsJ7XQgeqwiNYcHuiUeu1jUqJvV4GZkUGsj6gO6vQtapTStSKvhKSYq");
                Assert.AreEqual(data1.Funds, 37);
                Assert.AreEqual(data2.Funds, 37);
                Assert.AreEqual(data1.StartTime, DateTime.Parse("2024-03-10 11:03:07"));
                Assert.AreEqual(data2.StartTime, DateTime.Parse("2024-03-10 11:03:07"));
                Assert.AreEqual(data1.EndTime, DateTime.Parse("2025-04-05 11:03:07"));
                Assert.AreEqual(data2.EndTime, DateTime.Parse("2025-04-05 11:03:07"));
                Assert.AreEqual(data1.Participants, "3sqKK8iCjBvoa33KJ6JNTOKVuhAwFgr");
                Assert.AreEqual(data2.Participants, "3sqKK8iCjBvoa33KJ6JNTOKVuhAwFgr");
                Assert.AreEqual(data1.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data2.Examine, DMSFinal.Model.CheckEnum.Pass);
                Assert.AreEqual(data1.Reason, "jqplcugchgQ");
                Assert.AreEqual(data2.Reason, "jqplcugchgQ");
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            HorizontalSubject v1 = new HorizontalSubject();
            HorizontalSubject v2 = new HorizontalSubject();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v1.JobNo = "1FtjDrJ";
                v1.Name = "Ob";
                v1.Title1 = DMSFinal.Model.TitleEnum.Professor;
                v1.Title2 = DMSFinal.Model.TitleEnum2.noTitle2;
                v1.SubjectName = "sLCNYvE";
                v1.CompanyName = "i5JcTToYjmP6B6T1nRhJ1LqUJ";
                v1.Funds = 6;
                v1.StartTime = DateTime.Parse("2025-03-10 11:03:07");
                v1.EndTime = DateTime.Parse("2024-04-15 11:03:07");
                v1.Participants = "rziESO31s61nXd5jylE";
                v1.Examine = DMSFinal.Model.CheckEnum.Pass;
                v1.Reason = "ytOFocGL";
                v2.Department = DMSFinal.Model.DepartmentEnum.DMSFinal;
                v2.JobNo = "5GBzlRBz02";
                v2.Name = "MYUhiW8A2";
                v2.Title1 = DMSFinal.Model.TitleEnum.AssociateProfessor;
                v2.Title2 = DMSFinal.Model.TitleEnum2.AssGong;
                v2.SubjectName = "jNRgu9mvt9QhCIHGfCwv5Jh4oKPpC15jET1aPstuYRbofZJPRBm5yENapY2kt8t3EqdtRq1xSBXnr4X";
                v2.CompanyName = "1855t3qiXeJswsLMDqz0OWLkRIlaPCBVykne3QVAca0OWK8V7uUHVVGdwUmkRPSUcx5MFrUxVyg";
                v2.Funds = 91;
                v2.StartTime = DateTime.Parse("2024-12-30 11:03:07");
                v2.EndTime = DateTime.Parse("2024-11-08 11:03:07");
                v2.Participants = "X7xO63LSZ79p4kYzFWvCII4ULvX3vJoif";
                v2.Examine = DMSFinal.Model.CheckEnum.Checking;
                v2.Reason = "e47IZ78d";
                context.Set<HorizontalSubject>().Add(v1);
                context.Set<HorizontalSubject>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(HorizontalSubjectBatchVM));

            HorizontalSubjectBatchVM vm = rv.Model as HorizontalSubjectBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<HorizontalSubject>().Find(v1.ID);
                var data2 = context.Set<HorizontalSubject>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
