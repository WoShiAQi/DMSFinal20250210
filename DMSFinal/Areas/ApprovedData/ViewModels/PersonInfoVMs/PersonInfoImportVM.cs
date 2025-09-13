using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.PersonInfoVMs
{
    public partial class PersonInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.Name);
        [Display(Name = "身份证号")]
        public ExcelPropety PersonID_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.PersonID);
        [Display(Name = "政治身份")]
        public ExcelPropety PoliticalID_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.PoliticalID);
        [Display(Name = "学历")]
        public ExcelPropety Diplomas_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.Diplomas);
        [Display(Name = "学位")]
        public ExcelPropety Degree_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.Degree);
        [Display(Name = "毕业时间")]
        public ExcelPropety GraduateTime_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.GraduateTime);
        [Display(Name = "参加工作时间")]
        public ExcelPropety InWorkTime_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.InWorkTime);
        [Display(Name = "社会兼职")]
        public ExcelPropety PartTimeJob_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.PartTimeJob);
        [Display(Name = "是否双师")]
        public ExcelPropety IfDoubleTeacher_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.IfDoubleTeacher);
        [Display(Name = "是否专业带头人")]
        public ExcelPropety IfDisciplineLeader_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.IfDisciplineLeader);
        [Display(Name = "所学专业")]
        public ExcelPropety Discipline_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.Discipline);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<PersonInfo>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class PersonInfoImportVM : BaseImportVM<PersonInfoTemplateVM, PersonInfo>
    {

    }

}
