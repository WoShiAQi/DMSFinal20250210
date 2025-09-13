using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.PublicationsVMs
{
    public partial class PublicationsSearcher : BaseSearcher
    {
        [Display(Name = "部门")]
        public DepartmentEnum? Department { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "职称1")]
        public TitleEnum? Title1 { get; set; }
        [Display(Name = "职称2")]
        public TitleEnum2? Title2 { get; set; }
        [Display(Name = "著作形式")]
        public PublicationEnum? PublicationForm { get; set; }
        [Display(Name = "著作名称")]
        public String PublicationName { get; set; }
        [Display(Name = "出版社")]
        public String Press { get; set; }
        [Display(Name = "出版时间")]
        public DateRange PublicationTime { get; set; }
        [Display(Name = "撰写字数（万）")]
        public Single? WriteWordCount { get; set; }
        [Display(Name = "书号")]
        public String BookNo { get; set; }
        [Display(Name = "排名")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "第一主编是否本校")]
        public IfEnum? IsOurSchool { get; set; }
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
