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
    public partial class StudentCompetitionBatchVM : BaseBatchVM<StudentCompetition, StudentCompetition_BatchEdit>
    {
        public StudentCompetitionBatchVM()
        {
            ListVM = new StudentCompetitionListVM();
            LinkedVM = new StudentCompetition_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class StudentCompetition_BatchEdit : BaseVM
    {
        [Display(Name = "部门")]
        public DepartmentEnum? Department { get; set; }
        [Display(Name = "学生姓名")]
        public String StudentName { get; set; }
        [Display(Name = "工号")]
        public String JobNo { get; set; }
        [Display(Name = "指导教师")]
        public String TeacherName { get; set; }
        [Display(Name = "大赛名称")]
        public String CompetitionName { get; set; }
        [Display(Name = "获奖等级")]
        public AwardLevelEnum? AwardLevel { get; set; }
        [Display(Name = "授奖单位")]
        public String AwardingUnit { get; set; }
        [Display(Name = "级别")]
        public ConpetitonLevelEnum? Level { get; set; }
        [Display(Name = "获奖时间")]
        public DateTime? RewardTime { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }

        protected override void InitVM()
        {
        }

    }

}
