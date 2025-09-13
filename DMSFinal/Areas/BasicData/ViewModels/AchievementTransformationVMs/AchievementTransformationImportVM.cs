using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.AchievementTransformationVMs
{
    public partial class AchievementTransformationTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Department);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Title2);
        [Display(Name = "成果转化名称")]
        public ExcelPropety SubjectName_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.SubjectName);
        [Display(Name = "合作企业全称")]
        public ExcelPropety CompanyName_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.CompanyName);
        [Display(Name = "经费(元)")]
        public ExcelPropety Funds_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Funds);
        [Display(Name = "签订时间")]
        public ExcelPropety StartTime_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.StartTime);
        [Display(Name = "项目完成时间")]
        public ExcelPropety EndTime_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.EndTime);
        [Display(Name = "参与人员")]
        public ExcelPropety Participants_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Participants);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<AchievementTransformation>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class AchievementTransformationImportVM : BaseImportVM<AchievementTransformationTemplateVM, AchievementTransformation>
    {

    }

}
