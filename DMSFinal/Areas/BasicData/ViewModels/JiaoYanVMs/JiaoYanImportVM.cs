using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.JiaoYanVMs
{
    public partial class JiaoYanTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Department);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Title2);
        [Display(Name = "课题名称")]
        public ExcelPropety SubjectName_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.SubjectName);
        [Display(Name = "课题等级")]
        public ExcelPropety SubjectLevel_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.SubjectLevel);
        [Display(Name = "课题来源")]
        public ExcelPropety SubjectSource_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.SubjectSource);
        [Display(Name = "课题编号")]
        public ExcelPropety SubjectNo_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.SubjectNo);
        [Display(Name = "经费（元）")]
        public ExcelPropety Funds_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Funds);
        [Display(Name = "立项时间")]
        public ExcelPropety StartTime_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.StartTime);
        [Display(Name = "是否结项")]
        public ExcelPropety IfClose_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.IfClose);
        [Display(Name = "结项时间")]
        public ExcelPropety EndTime_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.EndTime);
        [Display(Name = "排名")]
        public ExcelPropety Rank_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Rank);
        [Display(Name = "主持人是否本校")]
        public ExcelPropety IfOurSchool_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.IfOurSchool);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<JiaoYan>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class JiaoYanImportVM : BaseImportVM<JiaoYanTemplateVM, JiaoYan>
    {

    }

}
