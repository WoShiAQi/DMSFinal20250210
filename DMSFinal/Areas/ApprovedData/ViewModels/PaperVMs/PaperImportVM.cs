using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.PaperVMs
{
    public partial class PaperTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Department_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Department);
        [Display(Name = "工号")]
        public ExcelPropety JobNo_Excel = ExcelPropety.CreateProperty<Paper>(x => x.JobNo);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Name);
        [Display(Name = "职称1")]
        public ExcelPropety Title1_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Title1);
        [Display(Name = "职称2")]
        public ExcelPropety Title2_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Title2);
        [Display(Name = "论文名称")]
        public ExcelPropety PaperTitle_Excel = ExcelPropety.CreateProperty<Paper>(x => x.PaperTitle);
        [Display(Name = "刊物名称")]
        public ExcelPropety MagazineName_Excel = ExcelPropety.CreateProperty<Paper>(x => x.MagazineName);
        [Display(Name = "出版时间")]
        public ExcelPropety PublicTime_Excel = ExcelPropety.CreateProperty<Paper>(x => x.PublicTime);
        [Display(Name = "年卷期页")]
        public ExcelPropety Info_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Info);
        [Display(Name = "期刊类别")]
        public ExcelPropety Category_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Category);
        [Display(Name = "是否国际索引SCI")]
        public ExcelPropety IsSCI_Excel = ExcelPropety.CreateProperty<Paper>(x => x.IsSCI);
        [Display(Name = "SCI索引号")]
        public ExcelPropety SCINo_Excel = ExcelPropety.CreateProperty<Paper>(x => x.SCINo);
        [Display(Name = "是否国际索引EI")]
        public ExcelPropety IsEI_Excel = ExcelPropety.CreateProperty<Paper>(x => x.IsEI);
        [Display(Name = "EI索引号")]
        public ExcelPropety EINo_Excel = ExcelPropety.CreateProperty<Paper>(x => x.EINo);
        [Display(Name = "是否国际索引ISTP")]
        public ExcelPropety IsISTP_Excel = ExcelPropety.CreateProperty<Paper>(x => x.IsISTP);
        [Display(Name = "ISTP索引号")]
        public ExcelPropety ISTPNo_Excel = ExcelPropety.CreateProperty<Paper>(x => x.ISTPNo);
        [Display(Name = "他引次数")]
        public ExcelPropety Num_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Num);
        [Display(Name = "影响因子")]
        public ExcelPropety ImpactFactor_Excel = ExcelPropety.CreateProperty<Paper>(x => x.ImpactFactor);
        [Display(Name = "第几作者")]
        public ExcelPropety Rank_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Rank);
        [Display(Name = "文章第一作者是否本校教师")]
        public ExcelPropety IsOurSchool_Excel = ExcelPropety.CreateProperty<Paper>(x => x.IsOurSchool);
        [Display(Name = "审核")]
        public ExcelPropety Examine_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Examine);
        [Display(Name = "不通过原因")]
        public ExcelPropety Reason_Excel = ExcelPropety.CreateProperty<Paper>(x => x.Reason);

	    protected override void InitVM()
        {
        }

    }

    public class PaperImportVM : BaseImportVM<PaperTemplateVM, Paper>
    {

    }

}
