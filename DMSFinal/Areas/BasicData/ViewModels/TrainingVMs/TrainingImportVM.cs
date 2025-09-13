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
    public partial class TrainingTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<Training>(x => x.Department);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<Training>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Training>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<Training>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<Training>(x => x.Title2);
        [Display(Name = "培训项目")]
        public ExcelPropety TrainName_Excel = ExcelPropety.CreateProperty<Training>(x => x.TrainName);
        [Display(Name = "学时")]
        public ExcelPropety TeachingTime_Excel = ExcelPropety.CreateProperty<Training>(x => x.TeachingTime);
        [Display(Name = "开始时间")]
        public ExcelPropety StartTime_Excel = ExcelPropety.CreateProperty<Training>(x => x.StartTime);
        [Display(Name = "结束时间")]
        public ExcelPropety EndTime_Excel = ExcelPropety.CreateProperty<Training>(x => x.EndTime);
        [Display(Name = "培训单位")]
        public ExcelPropety TrainingUnit_Excel = ExcelPropety.CreateProperty<Training>(x => x.TrainingUnit);
        [Display(Name = "审核")]
        public ExcelPropety Examin_Excel = ExcelPropety.CreateProperty<Training>(x => x.Examin);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<Training>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class TrainingImportVM : BaseImportVM<TrainingTemplateVM, Training>
    {

    }

}
