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
    public partial class TitleNameBatchVM : BaseBatchVM<TitleName, TitleName_BatchEdit>
    {
        public TitleNameBatchVM()
        {
            ListVM = new TitleNameListVM();
            LinkedVM = new TitleName_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TitleName_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
