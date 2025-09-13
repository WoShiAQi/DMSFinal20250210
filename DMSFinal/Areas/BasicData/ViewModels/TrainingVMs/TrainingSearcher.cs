using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.TrainingVMs
{
    public partial class TrainingSearcher : BaseSearcher
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
        [Display(Name = "培训项目")]
        public String TrainName { get; set; }
        [Display(Name = "学时")]
        public Int32? TeachingTime { get; set; }
        [Display(Name = "开始时间")]
        public DateRange StartTime { get; set; }
        [Display(Name = "结束时间")]
        public DateRange EndTime { get; set; }
        [Display(Name = "培训单位")]
        public String TrainingUnit { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examin { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }

        protected override void InitVM()
        {
        }

    }
}
