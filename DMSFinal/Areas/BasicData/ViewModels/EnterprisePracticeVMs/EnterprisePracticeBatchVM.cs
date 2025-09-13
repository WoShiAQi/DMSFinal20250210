using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;
using Microsoft.EntityFrameworkCore;

namespace DMSFinal.BasicData.ViewModels.EnterprisePracticeVMs
{
    public partial class EnterprisePracticeBatchVM : BaseBatchVM<EnterprisePractice, EnterprisePractice_BatchEdit>
    {
        public EnterprisePracticeListVM ATListVM { get; set; }
        public EnterprisePracticeBatchVM()
        {
            ListVM = new EnterprisePracticeListVM();
            LinkedVM = new EnterprisePractice_BatchEdit();
        }
        protected override void InitVM()
        {
            ATListVM = Wtm.CreateVM<EnterprisePracticeListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<EnterprisePractice>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedEnterCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedEnterCodes)
                    {
                        EnterprisePractice r = new EnterprisePractice
                        {
                            Checked = entity.Checked
                        };
                        DC.AddEntity(r);
                    }
                }
            }
            return base.DoBatchEdit();
        }
    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class EnterprisePractice_BatchEdit : BaseVM
    {
        [Display(Name = "部门")]
        public DepartmentEnum? Department { get; set; }
        [Display(Name = "工号")]
        public String JobNo { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "职称1")]
        public TitleEnum? Title1 { get; set; }
        [Display(Name = "职称2")]
        public TitleEnum2? Title2 { get; set; }
        [Display(Name = "企业名称")]
        public String CompanyName { get; set; }
        [Display(Name = "实践方式")]
        public PracticeEnum? PracticalWay { get; set; }
        [Display(Name = "实践开始时间")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "实践结束时间")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "企业联系人")]
        public String Contacts { get; set; }
        [Display(Name = "联系方式")]
        public String PhoneNumber { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        public List<string> SelectedEnterCodes { get; set; }
        public List<ComboSelectListItem> AllEnters { get; set; }


        protected override void InitVM()
        {
            AllEnters = DC.Set<EnterprisePractice>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
