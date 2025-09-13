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

namespace DMSFinal.BasicData.ViewModels.HorizontalSubjectVMs
{
    public partial class HorizontalSubjectBatchVM : BaseBatchVM<HorizontalSubject, HorizontalSubject_BatchEdit>
    {
        public HorizontalSubjectListVM HSListVM { get; set; }
        public HorizontalSubjectBatchVM()
        {
            ListVM = new HorizontalSubjectListVM();
            LinkedVM = new HorizontalSubject_BatchEdit();
        }
        protected override void InitVM()
        {
            HSListVM = Wtm.CreateVM<HorizontalSubjectListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<HorizontalSubject>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedHSCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedHSCodes)
                    {
                        HorizontalSubject r = new HorizontalSubject
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
    public class HorizontalSubject_BatchEdit : BaseVM
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
        [Display(Name = "横向课题名称")]
        public String SubjectName { get; set; }
        [Display(Name = "合作公司全称")]
        public String CompanyName { get; set; }
        [Display(Name = "研究经费（元）")]
        public Int32? Funds { get; set; }
        [Display(Name = "签订合同时间")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "项目完成时间")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "参与人员")]
        public String Participants { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        public List<string> SelectedHSCodes { get; set; }
        public List<ComboSelectListItem> AllHSs { get; set; }


        protected override void InitVM()
        {
            AllHSs = DC.Set<HorizontalSubject>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
