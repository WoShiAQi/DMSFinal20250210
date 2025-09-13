using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.TeacherCompetitionVMs
{
    public partial class TeacherCompetitionTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Department);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Title2);
        [Display(Name = "大赛名称")]
        public ExcelPropety CompetitionName_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.CompetitionName);
        [Display(Name = "获奖等级")]
        public ExcelPropety RewardLevel_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.RewardLevel);
        [Display(Name = "授奖单位")]
        public ExcelPropety AwardingUnit_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.AwardingUnit);
        [Display(Name = "级别")]
        public ExcelPropety Level_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Level);
        [Display(Name = "获奖时间")]
        public ExcelPropety RewardTime_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.RewardTime);
        [Display(Name = "排名")]
        public ExcelPropety Rank_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Rank);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<TeacherCompetition>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class TeacherCompetitionImportVM : BaseImportVM<TeacherCompetitionTemplateVM, TeacherCompetition>
    {

    }

}
