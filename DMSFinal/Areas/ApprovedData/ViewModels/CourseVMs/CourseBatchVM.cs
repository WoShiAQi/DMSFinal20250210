using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;


namespace DMSFinal.ApprovedData.ViewModels.CourseVMs
{
    public partial class CourseBatchVM : BaseBatchVM<Course, Course_BatchEdit>
    {
        public CourseBatchVM()
        {
            ListVM = new CourseListVM();
            LinkedVM = new Course_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Course_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
