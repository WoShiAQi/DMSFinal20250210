using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;


namespace DMSFinal.BasicData.ViewModels.TitleNameVMs
{
    public partial class TitleNameTemplateVM : BaseTemplateVM
    {
        [Display(Name = "职称")]
        public ExcelPropety TitleList_Excel = ExcelPropety.CreateProperty<TitleName>(x => x.TitleList);

	    protected override void InitVM()
        {
        }

    }

    public class TitleNameImportVM : BaseImportVM<TitleNameTemplateVM, TitleName>
    {

    }

}
