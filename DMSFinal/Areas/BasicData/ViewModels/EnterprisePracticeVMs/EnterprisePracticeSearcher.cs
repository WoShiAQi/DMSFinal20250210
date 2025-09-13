using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.EnterprisePracticeVMs
{
    public partial class EnterprisePracticeSearcher : BaseSearcher
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
        [Display(Name = "企业名称")]
        public String CompanyName { get; set; }
        [Display(Name = "实践方式")]
        public PracticeEnum? PracticalWay { get; set; }
        [Display(Name = "实践开始时间")]
        public DateRange StartTime { get; set; }
        [Display(Name = "实践结束时间")]
        public DateRange EndTime { get; set; }
        [Display(Name = "企业联系人")]
        public String Contacts { get; set; }
        [Display(Name = "联系方式")]
        public String PhoneNumber { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }

        protected override void InitVM()
        {
        }

    }
}
