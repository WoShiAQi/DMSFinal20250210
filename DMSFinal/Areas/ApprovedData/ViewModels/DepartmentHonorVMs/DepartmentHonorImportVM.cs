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
    public partial class DepartmentHonorTemplateVM : BaseTemplateVM
    {
        [Display(Name = "系部")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.Department);
        [Display(Name = "项目名称（荣誉平台基地等）")]
        public ExcelPropety ProjectName_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.ProjectName);
        [Display(Name = "授奖单位")]
        public ExcelPropety AwardingUnit_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.AwardingUnit);
        [Display(Name = "获奖等级")]
        public ExcelPropety AwardLevel_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.AwardLevel);
        [Display(Name = "获奖时间")]
        public ExcelPropety RewardTime_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.RewardTime);
        [Display(Name = "批文号")]
        public ExcelPropety AwardNo_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.AwardNo);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<DepartmentHonor>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class DepartmentHonorImportVM : BaseImportVM<DepartmentHonorTemplateVM, DepartmentHonor>
    {

    }

}
