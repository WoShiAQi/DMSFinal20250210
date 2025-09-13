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
    public partial class PatentSoftnessBatchVM : BaseBatchVM<PatentSoftness, PatentSoftness_BatchEdit>
    {
        public PatentSoftnessBatchVM()
        {
            ListVM = new PatentSoftnessListVM();
            LinkedVM = new PatentSoftness_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PatentSoftness_BatchEdit : BaseVM
    {
        [Display(Name = "部门")]
        public DepartmentEnum? Department { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "职称1")]
        public TitleEnum? Title1 { get; set; }
        [Display(Name = "职称2")]
        public TitleEnum2? Title2 { get; set; }
        [Display(Name = "名称")]
        public String Topic { get; set; }
        [Display(Name = "类别")]
        public PatentEnum? PatentCategory { get; set; }
        [Display(Name = "授权时间")]
        public DateTime? AuthorizedDate { get; set; }
        [Display(Name = "专利号")]
        public String PatentNumber { get; set; }
        [Display(Name = "申请时间")]
        public DateTime? ApplicationTime { get; set; }
        [Display(Name = "申请号")]
        public String ApplicationNumber { get; set; }
        [Display(Name = "是否职务发明")]
        public IfEnum? IfEmployee { get; set; }
        [Display(Name = "第几作者")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "专利第一作者是否本校教师")]
        public IfEnum? IsOurSchool { get; set; }
        [Display(Name = "计划维持有效时间（年）")]
        public Int32? HoldTime { get; set; }
        [Display(Name = "工号")]
        public String JobNo { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }

        protected override void InitVM()
        {
        }

    }

}
