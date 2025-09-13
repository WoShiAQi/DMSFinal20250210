using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;


namespace DMSFinal.ApprovedData.ViewModels.PersonInfoVMs
{
    public partial class PersonInfoBatchVM : BaseBatchVM<PersonInfo, PersonInfo_BatchEdit>
    {
        public PersonInfoBatchVM()
        {
            ListVM = new PersonInfoListVM();
            LinkedVM = new PersonInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PersonInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
