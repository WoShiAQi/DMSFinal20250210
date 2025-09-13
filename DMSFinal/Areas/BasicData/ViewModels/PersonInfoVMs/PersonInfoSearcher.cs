using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;

namespace DMSFinal.BasicData.ViewModels.PersonInfoVMs
{
    public partial class PersonInfoSearcher : BaseSearcher
    {
        [Display(Name = "工号")]
        public String JobNo { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "身份证号")]
        public String PersonID { get; set; }
        [Display(Name = "政治身份")]
        public PoliticalIDEnum? PoliticalID { get; set; }
        public List<ComboSelectListItem> AllTitleNamess { get; set; }
        [Display(Name = "职称")]
        public List<Guid> SelectedTitleNamesIDs { get; set; }
        [Display(Name = "学历")]
        public DiplomasEnum? Diplomas { get; set; }
        [Display(Name = "学位")]
        public DegreeEnum? Degree { get; set; }
        [Display(Name = "毕业时间")]
        public DateRange GraduateTime { get; set; }
        [Display(Name = "参加工作时间")]
        public DateRange InWorkTime { get; set; }
        [Display(Name = "社会兼职")]
        public String PartTimeJob { get; set; }
        [Display(Name = "是否双师")]
        public IfEnum? IfDoubleTeacher { get; set; }
        [Display(Name = "是否专业带头人")]
        public IfEnum? IfDisciplineLeader { get; set; }
        [Display(Name = "所学专业")]
        public String Discipline { get; set; }

        protected override void InitVM()
        {
            AllTitleNamess = DC.Set<TitleName>().GetSelectListItems(Wtm, y => y.TitleList);
        }

    }
}
