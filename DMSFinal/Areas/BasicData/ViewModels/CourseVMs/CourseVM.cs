using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;

namespace DMSFinal.BasicData.ViewModels.CourseVMs
{
    public partial class CourseVM : BaseCRUDVM<Course>
    {

        public CourseVM()
        {
            SetInclude(x => x.Evidence);
        }

        protected override void InitVM()
        {
            
        }

        public override void DoAdd()
        {
            Entity.Examine = CheckEnum.Checking;
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
