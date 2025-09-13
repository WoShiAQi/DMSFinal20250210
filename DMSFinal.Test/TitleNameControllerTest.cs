using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DMSFinal.Controllers;
using DMSFinal.BasicData.ViewModels.TitleNameVMs;
using DMSFinal.Model.BasicData;
using DMSFinal;


namespace DMSFinal.Test
{
    [TestClass]
    public class TitleNameControllerTest
    {
        private TitleNameController _controller;
        private string _seed;

        public TitleNameControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<TitleNameController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as TitleNameListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(TitleNameVM));

            TitleNameVM vm = rv.Model as TitleNameVM;
            TitleName v = new TitleName();
			
            v.TitleList = "V9OgKFTPWevTpX";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TitleName>().Find(v.ID);
				
                Assert.AreEqual(data.TitleList, "V9OgKFTPWevTpX");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            TitleName v = new TitleName();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.TitleList = "V9OgKFTPWevTpX";
                context.Set<TitleName>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TitleNameVM));

            TitleNameVM vm = rv.Model as TitleNameVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new TitleName();
            v.ID = vm.Entity.ID;
       		
            v.TitleList = "xIZ8x";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.TitleList", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TitleName>().Find(v.ID);
 				
                Assert.AreEqual(data.TitleList, "xIZ8x");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            TitleName v = new TitleName();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.TitleList = "V9OgKFTPWevTpX";
                context.Set<TitleName>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TitleNameVM));

            TitleNameVM vm = rv.Model as TitleNameVM;
            v = new TitleName();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TitleName>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            TitleName v = new TitleName();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.TitleList = "V9OgKFTPWevTpX";
                context.Set<TitleName>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            TitleName v1 = new TitleName();
            TitleName v2 = new TitleName();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.TitleList = "V9OgKFTPWevTpX";
                v2.TitleList = "xIZ8x";
                context.Set<TitleName>().Add(v1);
                context.Set<TitleName>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TitleNameBatchVM));

            TitleNameBatchVM vm = rv.Model as TitleNameBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TitleName>().Find(v1.ID);
                var data2 = context.Set<TitleName>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            TitleName v1 = new TitleName();
            TitleName v2 = new TitleName();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.TitleList = "V9OgKFTPWevTpX";
                v2.TitleList = "xIZ8x";
                context.Set<TitleName>().Add(v1);
                context.Set<TitleName>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TitleNameBatchVM));

            TitleNameBatchVM vm = rv.Model as TitleNameBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TitleName>().Find(v1.ID);
                var data2 = context.Set<TitleName>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
