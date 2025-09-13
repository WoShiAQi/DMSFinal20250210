using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.DepartmentHonorVMs
{
    public partial class DepartmentHonorSearcher : BaseSearcher
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
        public DateRange RewardTime { get; set; }
        [Display(Name = "批文号")]
        public String AwardNo { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }

        protected override void InitVM()
        {
        }

    }
}
