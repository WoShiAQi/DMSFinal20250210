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

namespace DMSFinal.BasicData.ViewModels.AchievementTransformationVMs
{
    public partial class AchievementTransformationBatchVM : BaseBatchVM<AchievementTransformation, AchievementTransformation_BatchEdit>
    {
        public AchievementTransformationListVM ATListVM { get; set; }
        public AchievementTransformationBatchVM()
        {
            ListVM = new AchievementTransformationListVM();
            LinkedVM = new AchievementTransformation_BatchEdit();
        }

        protected override void InitVM()
        {
            ATListVM = Wtm.CreateVM<AchievementTransformationListVM>();
        }

        public override bool DoBatchEdit() {
            var entityList = DC.Set<AchievementTransformation>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList) {
                if (LinkedVM.SelectedATCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedATCodes)
                    {
                        AchievementTransformation r = new AchievementTransformation
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
    public class AchievementTransformation_BatchEdit : BaseVM
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
        [Display(Name = "成果转化名称")]
        public String SubjectName { get; set; }
        [Display(Name = "合作企业全称")]
        public String CompanyName { get; set; }
        [Display(Name = "经费(元)")]
        public Int32? Funds { get; set; }
        [Display(Name = "签订时间")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "项目完成时间")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "参与人员")]
        public String Participants { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        public List<string> SelectedATCodes { get; set; }
        public List<ComboSelectListItem> AllATs { get; set; }


        protected override void InitVM()
        {
            AllATs = DC.Set<AchievementTransformation>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
