using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.TeacherCompetitionVMs
{
    public partial class TeacherCompetitionSearcher : BaseSearcher
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
        [Display(Name = "大赛名称")]
        public String CompetitionName { get; set; }
        [Display(Name = "获奖等级")]
        public AwardLevelEnum? RewardLevel { get; set; }
        [Display(Name = "授奖单位")]
        public String AwardingUnit { get; set; }
        [Display(Name = "级别")]
        public ConpetitonLevelEnum? Level { get; set; }
        [Display(Name = "获奖时间")]
        public DateRange RewardTime { get; set; }
        [Display(Name = "排名")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }

        protected override void InitVM()
        {
        }

    }
}
