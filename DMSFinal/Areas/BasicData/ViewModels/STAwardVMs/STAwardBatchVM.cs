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

namespace DMSFinal.BasicData.ViewModels.STAwardVMs
{    
    public partial class STAwardBatchVM : BaseBatchVM<STAward, STAward_BatchEdit>
    {
        public STAwardListVM STAListVM { get; set; }
        public STAwardBatchVM()
        {
            ListVM = new STAwardListVM();
            LinkedVM = new STAward_BatchEdit();
        }
        protected override void InitVM()
        {
            STAListVM = Wtm.CreateVM<STAwardListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<STAward>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedSTACodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedSTACodes)
                    {
                        STAward r = new STAward
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
    public class STAward_BatchEdit : BaseVM
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
        [Display(Name = "获奖成果名称")]
        public String Topic { get; set; }
        [Display(Name = "证书编号/批文号")]
        public String AwardNo { get; set; }
        [Display(Name = "获奖名称")]
        public RewardEnum? RewardName { get; set; }
        [Display(Name = "授奖单位")]
        public String AwardingUnit { get; set; }
        [Display(Name = "获奖等级")]
        public AwardLevelEnum? AwardLevel { get; set; }
        [Display(Name = "获奖时间")]
        public DateTime? RewardTime { get; set; }
        [Display(Name = "排名")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "第一是否本校老师")]
        public IfEnum? IfOurSchool { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        public List<string> SelectedSTACodes { get; set; }
        public List<ComboSelectListItem> AllSTAs { get; set; }


        protected override void InitVM()
        {
            AllSTAs = DC.Set<STAward>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
