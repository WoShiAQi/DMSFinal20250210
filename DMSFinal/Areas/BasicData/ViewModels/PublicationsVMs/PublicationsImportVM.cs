using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.PublicationsVMs
{
    public partial class PublicationsTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Department);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Title2);
        [Display(Name = "著作形式")]
        public ExcelPropety PublicationForm_Excel = ExcelPropety.CreateProperty<Publications>(x => x.PublicationForm);
        [Display(Name = "著作名称")]
        public ExcelPropety PublicationName_Excel = ExcelPropety.CreateProperty<Publications>(x => x.PublicationName);
        [Display(Name = "出版社")]
        public ExcelPropety Press_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Press);
        [Display(Name = "出版时间")]
        public ExcelPropety PublicationTime_Excel = ExcelPropety.CreateProperty<Publications>(x => x.PublicationTime);
        [Display(Name = "撰写字数（万）")]
        public ExcelPropety WriteWordCount_Excel = ExcelPropety.CreateProperty<Publications>(x => x.WriteWordCount);
        [Display(Name = "书号")]
        public ExcelPropety BookNo_Excel = ExcelPropety.CreateProperty<Publications>(x => x.BookNo);
        [Display(Name = "排名")]
        public ExcelPropety Rank_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Rank);
        [Display(Name = "第一主编是否本校")]
        public ExcelPropety IsOurSchool_Excel = ExcelPropety.CreateProperty<Publications>(x => x.IsOurSchool);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<Publications>(x => x.JobNo);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<Publications>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class PublicationsImportVM : BaseImportVM<PublicationsTemplateVM, Publications>
    {

    }

}
