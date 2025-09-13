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

namespace DMSFinal.BasicData.ViewModels.DepartmentHonorVMs
{
    public partial class DepartmentHonorBatchVM : BaseBatchVM<DepartmentHonor, DepartmentHonor_BatchEdit>
    {
        public DepartmentHonorListVM DeHListVM { get; set; }
        public DepartmentHonorBatchVM()
        {
            ListVM = new DepartmentHonorListVM();
            LinkedVM = new DepartmentHonor_BatchEdit();
        }
        protected override void InitVM()
        {
            DeHListVM = Wtm.CreateVM<DepartmentHonorListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<DepartmentHonor>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedDPCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedDPCodes)
                    {
                        DepartmentHonor r = new DepartmentHonor
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
    public class DepartmentHonor_BatchEdit : BaseVM
    {
        [Display(Name = "系部")]
        public DepartmentEnum? Department { get; set; }
        [Display(Name = "项目名称（荣誉平台基地等）")]
        public String ProjectName { get; set; }
        [Display(Name = "授奖单位")]
        public String AwardingUnit { get; set; }
        [Display(Name = "获奖等级")]
        public SubjectEnum? AwardLevel { get; set; }
        [Display(Name = "获奖时间")]
        public DateTime? RewardTime { get; set; }
        [Display(Name = "批文号")]
        public String AwardNo { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        public List<string> SelectedDPCodes { get; set; }
        public List<ComboSelectListItem> AllDPs { get; set; }


        protected override void InitVM()
        {
            AllDPs = DC.Set<DepartmentHonor>().GetSelectListItems(Wtm, y => y.AwardingUnit, y => y.AwardNo);
        }

    }

}
