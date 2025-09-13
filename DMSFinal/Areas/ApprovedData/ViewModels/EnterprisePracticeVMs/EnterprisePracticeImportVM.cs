using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.EnterprisePracticeVMs
{
    public partial class EnterprisePracticeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.Department);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.Title2);
        [Display(Name = "企业名称")]
        public ExcelPropety CompanyName_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.CompanyName);
        [Display(Name = "实践方式")]
        public ExcelPropety PracticalWay_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.PracticalWay);
        [Display(Name = "实践开始时间")]
        public ExcelPropety StartTime_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.StartTime);
        [Display(Name = "实践结束时间")]
        public ExcelPropety EndTime_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.EndTime);
        [Display(Name = "企业联系人")]
        public ExcelPropety Contacts_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.Contacts);
        [Display(Name = "联系方式")]
        public ExcelPropety PhoneNumber_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.PhoneNumber);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<EnterprisePractice>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class EnterprisePracticeImportVM : BaseImportVM<EnterprisePracticeTemplateVM, EnterprisePractice>
    {

    }

}
