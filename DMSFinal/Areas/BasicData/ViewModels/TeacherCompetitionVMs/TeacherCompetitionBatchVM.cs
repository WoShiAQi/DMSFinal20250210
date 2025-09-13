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

namespace DMSFinal.BasicData.ViewModels.TeacherCompetitionVMs
{
    public partial class TeacherCompetitionBatchVM : BaseBatchVM<TeacherCompetition, TeacherCompetition_BatchEdit>
    {
        public TeacherCompetitionListVM TeacherListVM { get; set; }
        public TeacherCompetitionBatchVM()
        {
            ListVM = new TeacherCompetitionListVM();
            LinkedVM = new TeacherCompetition_BatchEdit();
        }
        protected override void InitVM()
        {
            TeacherListVM = Wtm.CreateVM<TeacherCompetitionListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<TeacherCompetition>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedTeacherCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedTeacherCodes)
                    {
                        TeacherCompetition r = new TeacherCompetition
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
    public class TeacherCompetition_BatchEdit : BaseVM
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
        public DateTime? RewardTime { get; set; }
        [Display(Name = "排名")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        public List<string> SelectedTeacherCodes { get; set; }
        public List<ComboSelectListItem> AllTeachers { get; set; }


        protected override void InitVM()
        {
            AllTeachers = DC.Set<TeacherCompetition>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
