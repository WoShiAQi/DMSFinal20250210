using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.JiaoYanVMs
{
    public partial class JiaoYanBatchVM : BaseBatchVM<JiaoYan, JiaoYan_BatchEdit>
    {
        public JiaoYanBatchVM()
        {
            ListVM = new JiaoYanListVM();
            LinkedVM = new JiaoYan_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class JiaoYan_BatchEdit : BaseVM
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
        [Display(Name = "课题名称")]
        public String SubjectName { get; set; }
        [Display(Name = "课题等级")]
        public SubjectEnum? SubjectLevel { get; set; }
        [Display(Name = "课题来源")]
        public String SubjectSource { get; set; }
        [Display(Name = "课题编号")]
        public String SubjectNo { get; set; }
        [Display(Name = "经费（元）")]
        public Int32? Funds { get; set; }
        [Display(Name = "立项时间")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "是否结项")]
        public IfEnum? IfClose { get; set; }
        [Display(Name = "结项时间")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "排名")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "主持人是否本校")]
        public IfEnum? IfOurSchool { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }

        protected override void InitVM()
        {
        }

    }

}
