using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.PatentSoftnessVMs
{
    public partial class PatentSoftnessTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Department);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Title2);
        [Display(Name = "名称")]
        public ExcelPropety Topic_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Topic);
        [Display(Name = "类别")]
        public ExcelPropety PatentCategory_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.PatentCategory);
        [Display(Name = "授权时间")]
        public ExcelPropety AuthorizedDate_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.AuthorizedDate);
        [Display(Name = "专利号")]
        public ExcelPropety PatentNumber_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.PatentNumber);
        [Display(Name = "申请时间")]
        public ExcelPropety ApplicationTime_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.ApplicationTime);
        [Display(Name = "申请号")]
        public ExcelPropety ApplicationNumber_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.ApplicationNumber);
        [Display(Name = "是否职务发明")]
        public ExcelPropety IfEmployee_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.IfEmployee);
        [Display(Name = "第几作者")]
        public ExcelPropety Rank_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Rank);
        [Display(Name = "专利第一作者是否本校教师")]
        public ExcelPropety IsOurSchool_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.IsOurSchool);
        [Display(Name = "计划维持有效时间（年）")]
        public ExcelPropety HoldTime_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.HoldTime);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.JobNo);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<PatentSoftness>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class PatentSoftnessImportVM : BaseImportVM<PatentSoftnessTemplateVM, PatentSoftness>
    {

    }

}
