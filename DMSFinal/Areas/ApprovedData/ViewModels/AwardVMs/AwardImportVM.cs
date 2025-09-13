using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.AwardVMs
{
    public partial class AwardTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<Award>(x => x.Department);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<Award>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Award>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<Award>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<Award>(x => x.Title2);
        [Display(Name = "获奖成果名称")]
        public ExcelPropety Topic_Excel = ExcelPropety.CreateProperty<Award>(x => x.Topic);
        [Display(Name = "证书编号/批文号")]
        public ExcelPropety AwardNo_Excel = ExcelPropety.CreateProperty<Award>(x => x.AwardNo);
        [Display(Name = "获奖名称")]
        public ExcelPropety RewardName_Excel = ExcelPropety.CreateProperty<Award>(x => x.RewardName);
        [Display(Name = "授奖单位")]
        public ExcelPropety AwardingUnit_Excel = ExcelPropety.CreateProperty<Award>(x => x.AwardingUnit);
        [Display(Name = "获奖等级")]
        public ExcelPropety AwardLevel_Excel = ExcelPropety.CreateProperty<Award>(x => x.AwardLevel);
        [Display(Name = "获奖时间")]
        public ExcelPropety RewardTime_Excel = ExcelPropety.CreateProperty<Award>(x => x.RewardTime);
        [Display(Name = "排名")]
        public ExcelPropety Rank_Excel = ExcelPropety.CreateProperty<Award>(x => x.Rank);
        [Display(Name = "第一是否本校老师")]
        public ExcelPropety IfOurSchool_Excel = ExcelPropety.CreateProperty<Award>(x => x.IfOurSchool);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<Award>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<Award>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class AwardImportVM : BaseImportVM<AwardTemplateVM, Award>
    {

    }

}
