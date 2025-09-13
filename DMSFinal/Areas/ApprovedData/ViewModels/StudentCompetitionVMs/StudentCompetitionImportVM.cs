using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.StudentCompetitionVMs
{
    public partial class StudentCompetitionTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.Department);
        [Display(Name = "学生姓名")]
        public ExcelPropety StudentName_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.StudentName);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.JobNo);
        [Display(Name = "指导教师")]
        public ExcelPropety TeacherName_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.TeacherName);
        [Display(Name = "大赛名称")]
        public ExcelPropety CompetitionName_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.CompetitionName);
        [Display(Name = "获奖等级")]
        public ExcelPropety AwardLevel_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.AwardLevel);
        [Display(Name = "授奖单位")]
        public ExcelPropety AwardingUnit_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.AwardingUnit);
        [Display(Name = "级别")]
        public ExcelPropety Level_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.Level);
        [Display(Name = "获奖时间")]
        public ExcelPropety RewardTime_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.RewardTime);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<StudentCompetition>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class StudentCompetitionImportVM : BaseImportVM<StudentCompetitionTemplateVM, StudentCompetition>
    {

    }

}
