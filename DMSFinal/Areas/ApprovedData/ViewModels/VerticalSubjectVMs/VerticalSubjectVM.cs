using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;


namespace DMSFinal.ApprovedData.ViewModels.VerticalSubjectVMs
{
    public partial class VerticalSubjectVM : BaseCRUDVM<VerticalSubject>
    {

        public VerticalSubjectVM()
        {
            SetInclude(x => x.Evidence);
            SetInclude(x => x.ApprovalDoc);
            SetInclude(x => x.AccCerti);
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
